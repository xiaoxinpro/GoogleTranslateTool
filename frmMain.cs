using Microsoft.JScript.Vsa;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace GoogleTranslateTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private string[] arrLanguage = { "zh-CN", "en", "ja", "de" };
        private void frmMain_Load(object sender, EventArgs e)
        {
            comboFrom.Items.Clear();
            comboFrom.Items.Add("auto");
            comboFrom.Items.AddRange(arrLanguage);
            comboFrom.SelectedIndex = 0;

            comboTo.Items.Clear();
            comboTo.Items.AddRange(arrLanguage);
            comboTo.SelectedIndex = 0;
        }

        private void btnPdfFormat_Click(object sender, EventArgs e)
        {
            string[] arrData = Regex.Split(txtFrom.Text, "\\r\\n");
            Console.WriteLine(arrData.Length);
            StringBuilder strData = new StringBuilder();
            strData.Clear();
            foreach (string item in arrData)
            {
                if (item.Length > 0)
                {
                    byte firstChar = System.Text.Encoding.Default.GetBytes(item)[0];
                    if ((firstChar >= 'a' && firstChar <= 'z') || firstChar == ' ')
                    {
                        strData.Append(" " + item);
                    }
                    else
                    {
                        strData.Append("\r\n" + item);
                    }
                }
            }
            txtFrom.Text = strData.ToString().Trim();
        }

        private void btnGoogleTranslate_Click(object sender, EventArgs e)
        {
            string strFrom = comboFrom.SelectedItem.ToString();
            string strTo = comboTo.SelectedItem.ToString();
            string[] arrData = Regex.Split(txtFrom.Text, "\\r\\n");
            StringBuilder strData = new StringBuilder();
            foreach (string item in arrData)
            {
                strData.Append("\r\n");
                if (item.Trim().Length > 0)
                {
                    strData.Append(GoogleTranslate(item, strFrom, strTo));
                }
            }
            txtTo.Text = strData.ToString().Trim();
        }

        #region 谷歌翻译
        /// <summary>
        /// 谷歌翻译
        /// </summary>
        /// <param name="text">待翻译文本</param>
        /// <param name="fromLanguage">自动检测：auto</param>
        /// <param name="toLanguage">中文：zh-CN，英文：en</param>
        /// <returns>翻译后文本</returns>
        public string GoogleTranslate(string text, string fromLanguage, string toLanguage)
        {
            CookieContainer cc = new CookieContainer();

            string GoogleTransBaseUrl = "https://translate.google.cn/";

            string BaseResultHtml = GetResultHtml(GoogleTransBaseUrl, cc, "");

            Regex re = new Regex(@"(?<=TKK=)(.*?)(?=\);)");

            string TKKStr = re.Match(BaseResultHtml).ToString() + ")";//在返回的HTML中正则匹配TKK的JS代码

            string TKK = EvalJScript(TKKStr).ToString();
            Console.WriteLine("TKK:" + TKK);

            string GetTkkJS = File.ReadAllText("./gettk.js");

            string tk = GetJsMethd(GetTkkJS, "tk", new object[] { text, TKK});
            Console.WriteLine("tk:" + tk);

            string googleTransUrl = "https://translate.google.cn/translate_a/single?client=t&sl=" + fromLanguage + "&tl=" + toLanguage + "&hl=en&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=ss&dt=t&ie=UTF-8&oe=UTF-8&otf=1&ssel=0&tsel=0&kc=1&tk=" + tk + "&q=" + HttpUtility.UrlEncode(text);

            string ResultHtml = GetResultHtml(googleTransUrl, cc, "https://translate.google.cn/");

            dynamic TempResult = Newtonsoft.Json.JsonConvert.DeserializeObject(ResultHtml);

            string ResultText = Convert.ToString(TempResult[0][0][0]);

            return ResultText;
        }

        public string GetResultHtml(string url, CookieContainer cookie, string referer, string useragent = "")
        {
            var html = "";

            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            webRequest.Method = "GET";

            webRequest.CookieContainer = cookie;

            webRequest.Referer = referer;

            webRequest.Timeout = 20000;

            webRequest.Headers.Add("X-Requested-With:XMLHttpRequest");

            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

            //webRequest.UserAgent = useragent;

            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (var reader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {

                    html = reader.ReadToEnd();
                    reader.Close();
                    webResponse.Close();
                }
            }
            return html;
        }

        /// <summary>
        /// 执行JS方法
        /// </summary>
        /// <param name="methodName">方法名</param>
        /// <param name="para">参数</param>
        /// <returns></returns>
        private static string GetJsMethd(string sCode, string methodName, object[] para)
        {

            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateInMemory = true;

            CodeDomProvider _provider = new Microsoft.JScript.JScriptCodeProvider();

            CompilerResults results = _provider.CompileAssemblyFromSource(parameters, sCode);

            Assembly assembly = results.CompiledAssembly;

            Type _evaluateType = assembly.GetType("aa.JScript");

            object obj = _evaluateType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, null, para);

            return obj.ToString();
        }

        public static object EvalJScript(string JScript)
        {
            object Result = null;
            try
            {
                Result = Microsoft.JScript.Eval.JScriptEvaluate(JScript, VsaEngine.CreateEngine());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Result;

        }
        #endregion



    }
}
