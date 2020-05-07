using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocietyPass.Mobile.Services.Auth;
using SocietyPass.Mobile.Services.Constants;
using SocietyPass.Mobile.Services.Contracts.Auth;
using SocietyPass.Mobile.Services.Contracts.Repositories;
using SocietyPass.Mobile.Services.Utility;

namespace SocietyPass.Mobile.Services.Repositories
{
    public class OAuthRepository : IOAuthRepository
    {
        public async Task<IOAuthResult> AuthenticateUser(string username, string password)
        {
            if (username != null && password != null && username.Trim() != string.Empty && password.Trim() != string.Empty)
            {

                var client = new HttpClient();
                var url = new UrlBuilder(ApiConstants.BaseUrl).Append(ApiConstants.ApiUrl)
                        .Append(ApiConstants.Authenticate).ToString();

                var model = new UserDto
                {
                    UserName = username,
                    Password = password
                };

                var json = JsonConvert.SerializeObject(model);

                HttpContent httpContent = new StringContent(json);

                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(url, httpContent).ConfigureAwait(false);

                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        try
                        {
                            var r =  new OAuthResult
                            {
                                StatusCode = response.StatusCode,
                                Status = response.Content.ToString(),
                                Token = JsonConvert.DeserializeObject<OAuthToken>(result)
                            };

                            return r;
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<OAuthError>(response.Content.ReadAsStringAsync().Result);
                        return new OAuthResult { StatusCode = response.StatusCode, Status = error.Description, Token = null };
                    }
                }
            }
            return null;
        }
    }
}
