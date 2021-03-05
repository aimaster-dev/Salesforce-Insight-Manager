using SalesforceWindowsForms.SFDC;
using SalesforceWindowsForms.CollectionObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace SalesforceWindowsForms.DAL
{
    public class PeopleFactory
    {
        private List<People> list = new List<People>();
        private SforceService connect;

        private string OauthToken;


        public string serviceUrl { get; private set; }

        public PeopleFactory(SforceService con)
        {
            this.connect = con;
        }


        public void loadPeopleAsync(/*BackgroundWorker worker*/)
        //public async Task loadPeopleAsync(/*BackgroundWorker worker*/)

        {
           /* if (worker.IsBusy != true)
            {

                worker.RunWorkerAsync();*/

                Boolean done = false;
                String people = "Select ID, NAME, EMPLOYMENT_STATUS__C, PEOPLEKEY__C, MMS_USER__C," +
                    " MMS_USER_STATUS__C FROM People__c WHERE MMS_USER__C != null";
                QueryResult queryPeople = this.connect.query(people);


            // String folder = "SELECT Id, Name, ParentId, AccessType, Type, IsReadonly, DeveloperName FROM Folder WHERE Type = 'Report";
            //Array
            //loop pegado en la api ( rest -- Verbo : get);
            // this.connect.query(folder);
            //string[] id = new string[] {"00ld0000001bM57AAE"};
            //sObject[] result = this.connect.retrieve("AccessType", "Folder", id);
            //DescribeSObjectResult describeSObjectResult = this.connect.describeSObject("Folder");
            //DescribeGlobalResult dgr = this.connect.describeGlobal(); /// todos los objects que tira el SOAP API
            // Instantiate a new http object
            //Http.Get(/ services / data / v47.0 / folders / 00l0d0000028qGDAAY / shares / 0AF0d000000LbYuGAK);
            //DescribeSObjectResult[] describeSObjectResults = this.connect.describeSObjects(new String[] { "shares" });
            //Console.WriteLine("retrieve :", describeSObjectResults); // para no pegar a rest api, usar retrive de soap ( prueba).
            // fieldList: accessType, shareType, sharedWithLabel
            //sObjectType: FolderShare ( o shares)
            //////////////////////////****************//////////////Rest Api connection//////////////******************************////////////////////
            /*
            String jsonResponse;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            String Username = ConfigurationManager.AppSettings["UserName"];
            String Password = ConfigurationManager.AppSettings["Password"];
            String LOGIN_ENDPOINT = ConfigurationManager.AppSettings["LOGIN_ENDPOINT"];
            String ClientId = ConfigurationManager.AppSettings["ClientId"];
            String ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            String Token = ConfigurationManager.AppSettings["Token"];

            using (var client = new HttpClient())
            {
        

                var request = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"username", Username},
                {"password", Password+Token}
            }
                );
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.PostAsync(LOGIN_ENDPOINT, request).Result;
                jsonResponse = response.Content.ReadAsStringAsync().Result;
            }
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
            Token = values["access_token"];
            LOGIN_ENDPOINT = values["instance_url"];*/
            //////////////////////////////////////////////////Other type of Authenticate REST endpoint////////////////////////////
            /*HttpClient authClient = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;


            //set OAuth key and secret variables

            string sfdcConsumerKey = "#";

            string sfdcConsumerSecret = "#";


            //set to Force.com user account that has API access enabled

            string sfdcUserName = "#";

            string sfdcPassword = "#";

            //string sfdcToken = "#";



            //create login password value

            //string loginPassword = sfdcPassword + sfdcToken;



            HttpContent content = new FormUrlEncodedContent(new Dictionary<String, String>()
  {
     {"grant_type","password"},

     {"client_id",sfdcConsumerKey},

     {"client_secret",sfdcConsumerSecret},

     {"username",sfdcUserName},

     {"password",sfdcPassword}
   }

);



            HttpResponseMessage message = await authClient.PostAsync("https://test.salesforce.com/services/oauth2/token", content);

            string responseString = await message.Content.ReadAsStringAsync();


            JObject obj = JObject.Parse(responseString);

            OauthToken = (string)obj["access_token"];

            serviceUrl = (string)obj["instance_url"];

            /////////////////////////////////////SF REST API and .net//////////////////////Get method////
            //QUERY: Retrieve records of type "Folder"
            //string restQuery = serviceUrl + "/services/data/v47.0/folders";
            //QUERY: retrieve a specific Folder with "shares" component
            //string restQuery = serviceUrl + "/services/data/v47.0/folders/00l0d0000028qGDAAY/shares/0AF0d000000LbYuGAK";


            string restQuery = serviceUrl + "/services/data/v47.0/folders/00l0d0000028qGDAAY/shares/0AF0d000000LbYuGAK"; //

            //String restQuery = serviceUrl + "/services/data/v47.0/folder/00l0d0000028qGDAAY/share-recipients?shareType=User"; //Not working, check with Salesforce

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, restQuery);



            //add token to header

            request.Headers.Add("Authorization", "Bearer " + OauthToken);



            //return XML to the caller

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            //return JSON to the caller

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            //call endpoint async

            HttpResponseMessage response = await authClient.SendAsync(request);

            string result = await response.Content.ReadAsStringAsync();


*/


            Console.WriteLine("size of queryPeople", queryPeople.size);


                while (!done)
                {

                    for (int j = 0; j < queryPeople.records.Length; j++)
                    {
                        sObject record = queryPeople.records[j];// taking the first node or object.
                        People p = new People(); // instance of people

                        //add value to people properties
                        p.ID = record.Any[0].InnerText.ToString();
                        p.NAME_PEOPLE1 = record.Any[1].InnerText.ToString();
                        p.EMPLOYMENT_STATUS__C1 = record.Any[2].InnerText.ToString();
                        p.PEOPLEKEY__C1 = record.Any[3].InnerText.ToString();
                        p.MMS_USER__C1 = record.Any[4].InnerText.ToString();
                        p.MMS_USER_STATUS__C1 = record.Any[5].InnerText.ToString();

                        // add people object into people list.
                        this.list.Add(p);
                    }
                    if (queryPeople.done)
                    {
                        done = true;
                    }
                    else
                    {
                        queryPeople = this.connect.queryMore(queryPeople.queryLocator);
                    }

                }
           // }
            


            //return true;
        }

        public List<People> getPeople()
        {
            return this.list;
        }
    }
}




