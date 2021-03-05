using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesforceWindowsForms.CollectionObjects;
using SalesforceWindowsForms.SFDC;


namespace SalesforceWindowsForms.DAL
{
    public class PublicDashboardFactory
    {
        private List<PublicDashboard> sfPublicDashboards = new List<PublicDashboard>();
        private SforceService connect;

       

        public PublicDashboardFactory(SforceService con)
        {
            this.connect = con;
        }


        public bool loadPublicDashboard()
        {
            Boolean done = false;
            String publicDashboard = "Select Id, IsDeleted, FolderId, FolderName, Title, Description, CreatedDate, CreatedById, LastModifiedDate," +
                "LastModifiedById, Type FROM Dashboard";
            QueryResult queryPublicDashboard = this.connect.query(publicDashboard);

            while (!done)
            {

                for (int j = 0; j < queryPublicDashboard.records.Length; j++)
                {
                    sObject publicDashboardRecord = queryPublicDashboard.records[j];// taking the first node or object.
                    PublicDashboard pubD = new PublicDashboard(); // instance of PubliDashboard

                    //add value to PublicDashboard properties
                    pubD.Id = publicDashboardRecord.Any[0].InnerText.ToString();
                    pubD.IsDeleted = publicDashboardRecord.Any[1].InnerText.ToString();
                    pubD.FolderId = publicDashboardRecord.Any[2].InnerText.ToString();
                    pubD.FolderName = publicDashboardRecord.Any[3].InnerText.ToString();
                    pubD.Title = publicDashboardRecord.Any[4].InnerText.ToString();
                    pubD.Description = publicDashboardRecord.Any[5].InnerText.ToString();
                    pubD.CreatedDate = publicDashboardRecord.Any[6].InnerText.ToString();
                    pubD.CreatedById = publicDashboardRecord.Any[7].InnerText.ToString();
                    pubD.LastModifiedDate = publicDashboardRecord.Any[8].InnerText.ToString();
                    pubD.LastModifiedById = publicDashboardRecord.Any[9].InnerText.ToString();
                    pubD.Type = publicDashboardRecord.Any[10].InnerText.ToString();


                    // add people object into people list.
                    this.sfPublicDashboards.Add(pubD);
                }
                if (queryPublicDashboard.done)
                {
                    done = true;
                }
                else
                {
                    queryPublicDashboard = this.connect.queryMore(queryPublicDashboard.queryLocator);
                }
            }

            return true;

        }

        public List<PublicDashboard> GetPublicDashboards()
        {
            return this.sfPublicDashboards;
        }
        public void deletePublicDashboard(String stringExcelPath2, List<String> queryID1aDeletePublicDashboard)
        {
            if (queryID1aDeletePublicDashboard != null && queryID1aDeletePublicDashboard.Count != 0)
            {
                //create variable for today variable
                //String stringToday = DateTime.Now.ToString("MM-dd-yyyy");
                String stringToday = DateTime.Now.ToString("MM-dd-yyyy") + "_" + stringExcelPath2;

                //create a variable for the path;
                String stringExcelPathLog1 = "c:\\";
                //create a variable to concatenate the Report need
                // String stringExcelPathLog2 = stringExcelPath2;
                //create variable for final concatenation of the variable
                //String stringExcelPathLog3 = stringExcelPathLog1 + stringToday + "_" + stringExcelPathLog2;
                String stringExcelPathLog3 = Path.Combine(stringExcelPathLog1, stringToday);

                // it's necessary to parse the "privateDashboardID1a" value to an Array so we can send it through API call.
                String[] publicDashboardID1aArray = queryID1aDeletePublicDashboard.ToArray();

                DeleteResult[] deleteResults = this.connect.delete(publicDashboardID1aArray);

                for (int i = 0; i < deleteResults.Length; i++)

                {

                    DeleteResult deleteResult = deleteResults[i];

                    if (deleteResult.success)

                    {

                        if (!Directory.Exists(stringExcelPathLog3))
                        {
                            Directory.CreateDirectory(stringExcelPathLog3);
                        }

                        string appendText = "Deleted  Public Dashboard Record ID: " + deleteResult.id + Environment.NewLine;
                        File.AppendAllText(stringExcelPathLog3, appendText);


                    }

                    else

                    {

                        // Handle the errors.

                        // We just print the first error out for sample purposes.

                        Error[] errors = deleteResult.errors;

                        if (errors.Length > 0)

                        {

                            string appendText = "Error: could not delete " + " public Dashboard Record ID " + deleteResult.id + "." +
                                "   The error reported was: (" + errors[0].statusCode + ") " + errors[0].message + "\n" + Environment.NewLine;
                            File.AppendAllText(stringExcelPathLog3, appendText);


                        }

                        

                    }

                }
            }
            else
            {
                MessageBox.Show("There are not Private Dashboard associated", "Declined Deletion", MessageBoxButtons.OK);

            }

        }
    
    }
}
