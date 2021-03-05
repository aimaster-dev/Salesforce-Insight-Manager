using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.DAL
{
    // this is the class to handle the response of the following service : "/services/data/v47.0/folders"


   

    public class Record
    {
        public Attributes attributes { get; set; }
        public string AccessType { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class Attributes
    {
        public string type { get; set; }
        public string url { get; set; }
    }
    /*
    public class Folder
    {
        public string id { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }

    }*/
    /* public class RootobjectFolders
     {
         public Folder[] folders { get; set; }
         public string nextPageUrl { get; set; }
         public int totalSize { get; set; }
         public string url { get; set; }
         */
    public class Rootobject
    {
        public int totalSize { get; set; }
        public bool done { get; set; }
        public Record[] records { get; set; }
        public static async Task<Rootobject> GetFoldersAsync()
        { /////////////////////////////////////SF REST API and .net//////////////////////Get method////
          //QUERY: Retrieve records of type "Folder"
          //string restQuery = serviceUrl + "/services/data/v47.0/folders";
          //QUERY: retrieve a specific Folder with "shares" component
          //string restQuery = serviceUrl + "/services/data/v47.0/folders/00l0d0000028qGDAAY/shares/0AF0d000000LbYuGAK";

            SaleForceConnect sfc = new SaleForceConnect();
            await sfc.RestConectionAsync();

            string restQuery = sfc.serviceUrl + "/services/data/v47.0/query/?q=SELECT+AccessType,Type,Name,id+from+folder+where+Type%3D%27report%27%20or%20Type%3D%27dashboard%27";//"/services/data/v47.0/folders";

            //String restQuery = serviceUrl + "/services/data/v47.0/folder/00l0d0000028qGDAAY/share-recipients?shareType=User"; //Not working, check with Salesforce

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, restQuery);

            //add token to header
            request.Headers.Add("Authorization", "Bearer " + sfc.OauthToken);

            //return XML to the caller
            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            //return JSON to the caller
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            //call endpoint async

            HttpResponseMessage response = await SalesforceWindowsForms.DAL.SaleForceConnect.authClient.SendAsync(request);

            string result = await response.Content.ReadAsStringAsync();

            Rootobject Folders = JsonConvert.DeserializeObject<Rootobject>(result, new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace //set to Replace so that collection values aren't duplicated.
            });

            /*foreach (Folder office in Folders)
            {
                Console.WriteLine(office);
            }*/



            return Folders;
        }

        public async Task<List<string>> GetFolderIdAsync()
        {

           
            List<String> folderId = new List<string>();
            Rootobject folderList = await GetFoldersAsync();
            List<Record> fol = new List<Record>();
            fol = folderList.records.ToList();


            foreach (Record f in fol)
            {
                folderId.Add(f.Id);
            }

            return folderId;

        }
    }

}
