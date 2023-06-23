using Microsoft.Web.WebView2.Core;

namespace TmsSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(this.Form_Resize);

            webView.NavigationStarting += EnsureHttps;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            panelSearchEngine.Size = this.ClientSize - new Size(100,100);

            webView.Size = this.panelSearchEngine.Size - new Size(100,100);
            //goButton.Width = this.panelSearchEngine.Width / 10;
            //addressBar.Width = goButton.Width * 9;
            //webView.Size = this.ClientSize - new Size(webView.Location);
            //goButton.Left = this.ClientSize.Width - goButton.Width;
            //addressBar.Width = goButton.Left - addressBar.Left;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                if (addressBar!= null)
                {
                    webView.CoreWebView2.Navigate(addressBar.Text);
                } else
                {
                    MessageBox.Show("please put url");
                }
                
            }
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args) 
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel= true;
            }
        }

       
    }
}