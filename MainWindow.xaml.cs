using System.Windows;

namespace API_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void SearchLyrics_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LyricModel lyricModel = await LyricProcessor.GetSongLyrics(this.SongNameTextBox.Text, this.SingerTextBox.Text);

                if (string.IsNullOrEmpty(lyricModel.Lyrics))
                {
                    MessageBox.Show("Empty results returned");
                }
                else
                {
                    LyricsShowPane.Text = lyricModel.Lyrics;
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                MessageBox.Show("No Internet Connection");
            }
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
