using System.Net.Http;
using System.Threading.Tasks;

namespace API_Practice
{
    public class LyricProcessor
    {
        public static async Task<LyricModel> GetSongLyrics(string songName = "What Lovers Do", string singer = "Maroon 5")
        {
            // Set up the connection to api with supplied parameters
            string url = $"https://api.lyrics.ovh/v1/{ singer }/{ songName }";

            using (HttpResponseMessage responseMessage = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    // Wait for the requested lyrics
                    LyricModel lyricModel = await responseMessage.Content.ReadAsAsync<LyricModel>();

                    return lyricModel;
                }
                else
                {
                    throw new System.Exception(responseMessage.ReasonPhrase);
                }
            }
        }

    }
}
