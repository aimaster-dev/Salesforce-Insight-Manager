using Newtonsoft.Json.Linq;
using SalesforceWindowsForms.SFDC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.DAL
{
    public class SaleForceConnect
    {

        private static SforceService sfService = null;
        private static SaleForceConnect instance = null;
        public  string OauthToken { get; set; }
        public  string serviceUrl { get; set; }

        public static HttpClient authClient = new HttpClient();
        public SaleForceConnect()
        {

        }

        public static SaleForceConnect getInstance(String username, String password, String serverUrl)
        {
            try
            {

                if (instance == null)
                {
                    sfService = new SforceService();
                    instance = new SaleForceConnect(username, password, serverUrl);
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
            catch (System.Web.Services.Protocols.SoapException e)
            {
                // This is likley to be caused by bad username or password
                throw (e);
            }            
        }

        public SaleForceConnect(String username, String password, String serverUrl)
        {
            //sfService = new SforceService();
            //Si vamos a conectar a una Sandbox, descomentar la linea siguiente (el valor por defecto es a login.salesforce, para ambientes Dev/Production)
            sfService.Url = serverUrl;

            LoginResult CurrentLoginResult = sfService.login(username, password);

            //Change the binding to the new endpoint
            sfService.Url = CurrentLoginResult.serverUrl;

            //Create a new session header object and set the session id to that returned by the login
            sfService.SessionHeaderValue = new SessionHeader();
            sfService.SessionHeaderValue.sessionId = CurrentLoginResult.sessionId;
        }

        public  SforceService getCon()
        {
            return sfService;
        }

        public  async Task RestConectionAsync()
        {
            HttpClient authClient = new HttpClient();

            //set OAuth key and secret variables

            string sfdcConsumerKey = ConfigurationManager.AppSettings["sfdcConsumerKey"];

            string sfdcConsumerSecret = ConfigurationManager.AppSettings["sfdcConsumerSecret"];

            //set to Force.com user account that has API access enabled

            string sfdcUserName = ConfigurationManager.AppSettings["UserName"];

            string sfdcPassword = ConfigurationManager.AppSettings["Password"];

            //string sfdcToken = "#";

            //create login password value

            //string loginPassword = sfdcPassword + sfdcToken;

            var dictionary = new Dictionary<String, String>()
            {
                {"grant_type", "password"},
                {"client_id", sfdcConsumerKey},
                {"client_secret", sfdcConsumerSecret},
                {"username", sfdcUserName},
                {"password", sfdcPassword}
            };
            HttpContent content2 = new FormUrlEncodedContent(dictionary);

            HttpResponseMessage message = await authClient.PostAsync("https://test.salesforce.com/services/oauth2/token", content2);

            string responseString = await message.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(responseString);

            OauthToken = (string)obj["access_token"];

            serviceUrl = (string)obj["instance_url"];

        }


    }
}
