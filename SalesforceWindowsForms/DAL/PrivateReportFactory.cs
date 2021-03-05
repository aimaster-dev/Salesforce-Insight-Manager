using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using SalesforceWindowsForms.CollectionObjects;
using SalesforceWindowsForms.SFDC;

namespace SalesforceWindowsForms.DAL
{
    public class PrivateReportFactory
    {
        private SforceService con;
        private List<PrivateReport> sfPrivateReport = new List<PrivateReport>();
        private DeleteResult[] deleteResults;
        private List<String> deleteResultsList = new List<String>();




        public PrivateReportFactory(SforceService con)
        {
            this.con = con;
        }

        public void loadPrivateReport(/*BackgroundWorker worker*/)
        {
            /*if (worker.IsBusy != true){

                

                worker.RunWorkerAsync();*/

            Boolean done = false;
            String privateReport = "SELECT Id, OwnerId, FolderName, CreatedDate, CreatedById, LastModifiedDate," +
            "LastModifiedById, IsDeleted, Name, Description, DeveloperName, NamespacePrefix, LastRunDate," +
            "SystemModstamp, Format, LastViewedDate, LastReferencedDate FROM Report USING SCOPE allPrivate";
            QueryResult queryPrivateReport = this.con.query(privateReport);

            Console.WriteLine("size of queryPrivateReport", queryPrivateReport.size.ToString());

            while (!done)
            {
                for (int j = 0; j < queryPrivateReport.records.Length; j++)
                {
                    sObject privateReportRecord = queryPrivateReport.records[j];// taking the first node or object.
                    PrivateReport pr = new PrivateReport(); // instance of PrivateReport

                    //add value to privateReports properties
                    pr.ID = privateReportRecord.Any[0].InnerText.ToString();
                    pr.OWNERID = privateReportRecord.Any[1].InnerText.ToString();
                    pr.FOLDERNAME = privateReportRecord.Any[2].InnerText.ToString();
                    if (!string.IsNullOrEmpty(privateReportRecord.Any[3].InnerText.ToString()))
                    {
                        String result = privateReportRecord.Any[3].InnerText.ToString().Substring(0, 10);
                        pr.CREATEDDATE = DateTime.ParseExact(result, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        pr.CREATEDDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    pr.CREATEDBYID = privateReportRecord.Any[4].InnerText.ToString();
                    pr.LASTMODIFIEDDATE = privateReportRecord.Any[5].InnerText.ToString();
                    pr.LASTMODIFIEDBYID = privateReportRecord.Any[6].InnerText.ToString();
                    pr.ISDELETED = privateReportRecord.Any[7].InnerText.ToString();
                    pr.NAME = privateReportRecord.Any[8].InnerText.ToString();
                    pr.DESCRIPTION = privateReportRecord.Any[9].InnerText.ToString();
                    pr.DEVELOPERNAME = privateReportRecord.Any[10].InnerText.ToString();
                    pr.NAMESPACEPREFIX = privateReportRecord.Any[11].InnerText.ToString();
                    if (!string.IsNullOrEmpty(privateReportRecord.Any[12].InnerText.ToString()))
                    {
                        String result = privateReportRecord.Any[12].InnerText.ToString().Substring(0, 10);
                        pr.LASTRUNDATE = DateTime.ParseExact(result, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        pr.LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    pr.SYSTEMMODSTAMP = privateReportRecord.Any[13].InnerText.ToString();
                    pr.FORMAT = privateReportRecord.Any[14].InnerText.ToString();
                    pr.LASTVIEWEDDATE = privateReportRecord.Any[15].InnerText.ToString();
                    pr.LASTREFERENCEDDATE = privateReportRecord.Any[16].InnerText.ToString();

                    // add people object into people list.
                    sfPrivateReport.Add(pr);
                }

                if (queryPrivateReport.done)
                {
                    done = true;
                }
                else
                {
                    queryPrivateReport = this.con.queryMore(queryPrivateReport.queryLocator);
                }

            }

        


        }

        public List<PrivateReport> getPrivateReport()
        {
            return this.sfPrivateReport;
        }

        public void deletePrivateReports(String stringExcelPath3, List<String> queryDeletePrivateReports)
        {
            
            if (queryDeletePrivateReports != null)
            {
                Queue<String> queuePrivateReportDeletion = new Queue<String>(queryDeletePrivateReports);

                String[] DeletePrivateReportBatch;
                int countFlag = 0;
                DateTime today = DateTime.Now;
                String stringToday = today.ToString("MM-dd-yyyy hh-mm-ss tt");
                String path3 = stringToday + "_" + stringExcelPath3;

                while (queuePrivateReportDeletion.Count > 0)
                {
                    using (StreamWriter sw = File.AppendText(path3))
                    {
                        deleteResultsList.Add(queuePrivateReportDeletion.Dequeue());
                        countFlag++;

                        if (countFlag == 200 || queuePrivateReportDeletion.Any() || deleteResultsList.Any())
                        {

                            try

                            {
                                DeletePrivateReportBatch = deleteResultsList.ToArray();
                                deleteResults = this.con.delete(DeletePrivateReportBatch);

                                for (int i = 0; i < deleteResults.Length; i++)

                                {

                                    DeleteResult deleteResult = deleteResults[i];


                                    if (deleteResult.success)

                                    {
                                        DirectoryInfo[] cDirs = new DirectoryInfo(@"C:\").GetDirectories();
                                        string appendText = "Success:   deleted " + " Private Report Record ID: " + deleteResult.id + "\n" + Environment.NewLine;
                                        sw.WriteLine(appendText);
                                    }

                                    else

                                    {// Handle the errors.
                                     // We just print the first error out for sample purposes.
                                        DeleteResult deleteResult2 = deleteResults[i];
                                        Error[] errors = deleteResult2.errors;

                                        if (errors.Length > 0)
                                        {
                                            string appendText2 = "Error: could not delete " + " Private Report Record ID: " + DeletePrivateReportBatch[i] +
                                            "   The error reported was: (" + errors[0].statusCode + ") " + errors[0].message + "\n" + Environment.NewLine;
                                            sw.WriteLine(appendText2);
                                        }
                                    }

                                }

                            }

                            catch (SoapException e)

                            {
                                string appendText3 = "An unexpected error has occurred: " + e.Message + "\n" + e.StackTrace + Environment.NewLine;
                                sw.WriteLine(appendText3);
                            }
                        }
                        deleteResultsList.Clear();
                        countFlag = 0;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are not Private report for deletion", "Declined Deletion", MessageBoxButtons.OK);
            }

        }
    }
}

