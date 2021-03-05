using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SalesforceWindowsForms.DAL;


namespace SalesforceWindowsForms.DAL
{
    // this is the class to handle the response of the following service : "/services/data/v47.0/folders/<folderID>/shares

    public class FolderShare
    {
        public string folderId { get; set; }
        public string accessType { get; set; }
        public string imageColor { get; set; }
        public string imageUrl { get; set; }
        public string shareId { get; set; }
        public string shareType { get; set; }
        public string sharedWithId { get; set; }
        public string sharedWithLabel { get; set; }
        public string url { get; set; }
    }

    public class RootobjectShares
    {
        public FolderShare[] shares { get; set; }

        public async Task<IDictionary<String, List<FolderShare>>> GetFolderShareListAsync(List<String> folderId)
        { /////////////////////////////////////SF REST API and .net//////////////////////Get method////
          //QUERY: Retrieve records of type "Folder"
          //string restQuery = serviceUrl + "/services/data/v47.0/folders";
          //QUERY: retrieve a specific Folder with "shares" component
          //string restQuery = serviceUrl + "/services/data/v47.0/folders/00l0d0000028qGDAAY/shares/0AF0d000000LbYuGAK";

            IDictionary<String, List<FolderShare>> mapFolderShare = new Dictionary<String, List<FolderShare>>();
            SaleForceConnect sfc = new SaleForceConnect();
            RootobjectShares folderS = new RootobjectShares();
            await sfc.RestConectionAsync();

            foreach (String id in folderId)
            {
                string restQuery = sfc.serviceUrl + "/services/data/v47.0/folders/" + id + "/shares";

                //String restQuery = serviceUrl + "/services/data/v47.0/folder/00l0d0000028qGDAAY/share-recipients?shareType=User"; //Not working, check with Salesforce

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, restQuery);

                //add token to header

                request.Headers.Add("Authorization", "Bearer " + sfc.OauthToken);

                //return XML to the caller

                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                //return JSON to the caller

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //call endpoint async

                //call endpoint async
                try
                {
                    HttpResponseMessage response = await SalesforceWindowsForms.DAL.SaleForceConnect.authClient.SendAsync(request);

                    string result = await response.Content.ReadAsStringAsync();


                    folderS = JsonConvert.DeserializeObject<RootobjectShares>(result, new JsonSerializerSettings
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace //set to Replace so that collection values aren't duplicated.
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to deserialize object" + ex.Message);
                }
                List<FolderShare> fs = new List<FolderShare>();

                foreach (FolderShare x in folderS.shares)
                {
                    x.folderId = id;
                    fs.Add(x);
                }


                mapFolderShare.Add(id, fs);

                /*foreach (FolderShare office in folderS.shares)
                {
                    Console.WriteLine(office);
                }*/
            }

            return mapFolderShare;
        }


    }
}


