using GogoKit;
using GogoKit.Models.Response;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Helpers
{
    public class ViaGoGoBase
    {
        public static ViagogoClient ViagogoClient;
        private static OAuth2Token _token;

        public static async Task SetUpClient()
        {
            ViagogoClient = new ViagogoClient("TaRJnBcw1ZvYOXENCtj5", "ixGDUqRA5coOHf3FQysjd704BPptwbk6zZreELW2aCYSmIT8XJ9ngvN1MuKV", new ProductHeaderValue("MyAwesomeApp"));

            if (_token == null || _token.ExpiresIn <= 0)
            {
                var token = await ViagogoClient.OAuth2.GetClientAccessTokenAsync(new string[] { });
                await ViagogoClient.TokenStore.SetTokenAsync(token);

                _token = token;
            }
        }
    }
}