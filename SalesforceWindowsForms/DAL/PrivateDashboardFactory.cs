using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesforceWindowsForms.SFDC;
using SalesforceWindowsForms.CollectionObjects;
using System.IO;
using System.Windows.Forms;

namespace SalesforceWindowsForms.DAL
{
    public class PrivateDashboardFactory
    {
        private List<PrivateDashboard> sfPrivateDashboards = new List<PrivateDashboard>();
        private SforceService connect;



        public PrivateDashboardFactory(SforceService con)
        {
            this.connect = con;
        }


        public bool loadPrivateDashboard()
        {
            Boolean done = false;
            String privateDashboard = "Select Id, IsDeleted, FolderId, FolderName, Title, Description, CreatedDate, CreatedById, LastModifiedDate," +
                "LastModifiedById, Type FROM Dashboard USING SCOPE allPrivate";
            QueryResult queryPrivateDashboard = this.connect.query(privateDashboard);

            while (!done)
            {

                for (int j = 0; j < queryPrivateDashboard.records.Length; j++)
                {
                    sObject privateDashboardRecord = queryPrivateDashboard.records[j];// taking the first node or object.
                    PrivateDashboard prD = new PrivateDashboard(); // instance of PubliDashboard

                    //add value to PublicDashboard properties
                    prD.Id = privateDashboardRecord.Any[0].InnerText.ToString();
                    prD.IsDeleted = privateDashboardRecord.Any[1].InnerText.ToString();
                    prD.FolderId = privateDashboardRecord.Any[2].InnerText.ToString();
                    prD.FolderName = privateDashboardRecord.Any[3].InnerText.ToString();
                    prD.Title = privateDashboardRecord.Any[4].InnerText.ToString();
                    prD.Description = privateDashboardRecord.Any[5].InnerText.ToString();
                    prD.CreatedDate = privateDashboardRecord.Any[6].InnerText.ToString();
                    prD.CreatedById = privateDashboardRecord.Any[7].InnerText.ToString();
                    prD.LastModifiedDate = privateDashboardRecord.Any[8].InnerText.ToString();
                    prD.LastModifiedById = privateDashboardRecord.Any[9].InnerText.ToString();
                    prD.Type = privateDashboardRecord.Any[10].InnerText.ToString();


                    // add people object into people list.
                    this.sfPrivateDashboards.Add(prD);
                }
                if (queryPrivateDashboard.done)
                {
                    done = true;
                }
                else
                {
                    queryPrivateDashboard = this.connect.queryMore(queryPrivateDashboard.queryLocator);
                }

            }

            return true;

        }

        public List<PrivateDashboard> GetPrivateDashboards()
        {
            return this.sfPrivateDashboards;
        }
        public void deletePrivateDashboard(String stringExcelPath, List<String> queryID1aDeletePrivateDashboard)
        {


            if (queryID1aDeletePrivateDashboard != null && queryID1aDeletePrivateDashboard.Count != 0)
            {

                //create variable for today variable
                // String stringToday = DateTime.Now.ToString("MM-dd-yyyy");
                String stringToday = DateTime.Now.ToString("MM-dd-yyyy") + "_" + stringExcelPath;

                //create a variable for the path;
                String stringExcelPathLog1 = "c:\\";
                //create a variable to concatenate the Report need
                //String stringExcelPathLog2 = stringExcelPath;
                //create variable for final concatenation of the variable
                //String stringExcelPathLog3 = stringExcelPathLog1 + stringToday + "_" + stringExcelPathLog2;
                String stringExcelPathLog3 = Path.Combine(stringExcelPathLog1, stringToday);


                // it's necessary to parse the "privateDashboardID1a" value to an Array so we can send it through API call.
                String[] privateDashboardID1aArray = queryID1aDeletePrivateDashboard.ToArray();

                DeleteResult[] deleteResults = this.connect.delete(privateDashboardID1aArray);

                for (int i = 0; i < deleteResults.Length; i++)

                {

                    DeleteResult deleteResult = deleteResults[i];

                    if (deleteResult.success)

                    {
                        if (!Directory.Exists(stringExcelPathLog3))
                        {
                            Directory.CreateDirectory(stringExcelPathLog3);
                        }

                        string appendText = "Deleted  private Dashboard Record ID: " + deleteResult.id + Environment.NewLine;
                        File.AppendAllText(stringExcelPathLog3, appendText);


                    }

                    else

                    {

                        // Handle the errors.

                        // We just print the first error out for sample purposes.

                        Error[] errors = deleteResult.errors;

                        if (errors.Length > 0)

                        {

                            string appendText = "Error: could not delete " + " private Dashboard Record ID " + deleteResult.id + "." +
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
