using CoreTweet;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using static CoreTweet.OAuth;

namespace TwitterAPI_Issue_AccessToken
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        class token
        {
            public string CK { get; set; }
            public string CS { get; set; }
            public string AT { get; set; }
            public string AS { get; set; }
        }

        private OAuthSession session;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textbox1.Text != "" && textbox2.Text != "")
            {
                this.session = Authorize(textbox1.Text, textbox2.Text);
                string uri = session.AuthorizeUri.ToString();
                Process.Start(uri);
                string Pin = Microsoft.VisualBasic.Interaction.InputBox("認証完了時に表示されるPINコードを入力してください", "PIN認証", "", -1, -1);
                Tokens tokens = OAuth.GetTokens(session, Pin);
                MessageBox.Show("認証しました");
                if (pulldown1.SelectedIndex == 0)
                {
                    textbox3.Text = "[Access Token]" + tokens.AccessToken +
                        "\n[Access Token Secret]" + tokens.AccessTokenSecret;
                }
            }
            else
            {
                MessageBox.Show("APIキーを入力してください");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ablaze.one/wtiat/#help");
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void pulldown1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
