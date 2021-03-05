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
    public class PublicReportFactory
    {
        private SforceService con;
        private List<PublicReport> sfPublicReport = new List<PublicReport>();
        //private List<PublicReport> sfPublicReports_90Days = new List<PublicReport>();
        // private List<String> queryAccountDeletion = new List<String>();
        private DeleteResult[] deleteResults;
        private List<String> deleteResultsList = new List<String>();



        public PublicReportFactory(SforceService con)
        {
            this.con = con;
        }


        public void loadPublicReport(int param/*, BackgroundWorker worker*/)
        {
            /*if (worker.IsBusy != true)
            {

                worker.RunWorkerAsync();*/
            Boolean done = false;
            QueryResult queryPublicReport;

            //This is a modification for the  security folder functionality.
            if (param.Equals(0)){

                String publicReportExtract = "SELECT Id, OwnerId, FolderName, CreatedDate, CreatedById, LastModifiedDate," +
                    "LastModifiedById, IsDeleted, Name, Description, DeveloperName, NamespacePrefix, LastRunDate, SystemModstamp," +
                    "Format, LastViewedDate, LastReferencedDate FROM Report";

                queryPublicReport = this.con.query(publicReportExtract);

            }
            else { 

            //Boolean done = false;
            String publicReportExtract = "SELECT Id, OwnerId, FolderName, CreatedDate, CreatedById, LastModifiedDate," +
                "LastModifiedById, IsDeleted, Name, Description, DeveloperName, NamespacePrefix, LastRunDate, SystemModstamp," +
                "Format, LastViewedDate, LastReferencedDate FROM Report WHERE LastRunDate < last_N_days:" + param;

             queryPublicReport = this.con.query(publicReportExtract);
        }
            while (!done)
            {

                for (int j = 0; j < queryPublicReport.records.Length; j++)
                {
                    sObject publicReportRecord = queryPublicReport.records[j];// taking the first node or object.
                    PublicReport puR = new PublicReport(); // instance of PrivateReport

                    //add value to privateReports properties
                    puR.ID = publicReportRecord.Any[0].InnerText.ToString();
                    puR.OWNERID = publicReportRecord.Any[1].InnerText.ToString();
                    puR.FOLDERNAME = publicReportRecord.Any[2].InnerText.ToString();
                    if (!string.IsNullOrEmpty(publicReportRecord.Any[3].InnerText.ToString()))
                    {
                        String result = publicReportRecord.Any[3].InnerText.ToString().Substring(0, 10);
                        puR.CREATEDDATE = DateTime.ParseExact(result, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        puR.CREATEDDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    puR.CREATEDBYID = publicReportRecord.Any[4].InnerText.ToString();
                    puR.LASTMODIFIEDDATE = publicReportRecord.Any[5].InnerText.ToString();
                    puR.LASTMODIFIEDBYID = publicReportRecord.Any[6].InnerText.ToString();
                    puR.ISDELETED = publicReportRecord.Any[7].InnerText.ToString();
                    puR.NAME = publicReportRecord.Any[8].InnerText.ToString();
                    puR.DESCRIPTION = publicReportRecord.Any[9].InnerText.ToString();
                    puR.DEVELOPERNAME = publicReportRecord.Any[10].InnerText.ToString();
                    puR.NAMESPACEPREFIX = publicReportRecord.Any[11].InnerText.ToString();
                    if (!string.IsNullOrEmpty(publicReportRecord.Any[12].InnerText.ToString()))
                    {
                        String result = publicReportRecord.Any[12].InnerText.ToString().Substring(0, 10);
                        puR.LASTRUNDATE = DateTime.ParseExact(result, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        puR.LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    puR.SYSTEMMODSTAMP = publicReportRecord.Any[13].InnerText.ToString();
                    puR.FORMAT = publicReportRecord.Any[14].InnerText.ToString();
                    puR.LASTVIEWEDDATE = publicReportRecord.Any[15].InnerText.ToString();
                    puR.LASTREFERENCEDDATE = publicReportRecord.Any[16].InnerText.ToString();

                    // add people object into people list.
                    sfPublicReport.Add(puR);
                }
                if (queryPublicReport.done)
                {
                    done = true;
                }
                else
                {
                    queryPublicReport = this.con.queryMore(queryPublicReport.queryLocator);
                }
            }

            // }

            // return true;
        }

        public List<PublicReport> getPublicReport()
        {
            return this.sfPublicReport;
        }
        

        public void deletePublicReport(String stringExcelPath3, List<String> queryDeletePublicReports)
        {
            if (queryDeletePublicReports != null)
            {
                Queue<String> queuePublicReportDeletion = new Queue<String>(queryDeletePublicReports);

                String[] DeletePublicReportBatch;
                int countFlag = 0;
                DateTime today = DateTime.Now;
                String stringToday = today.ToString("MM-dd-yyyy hh-mm-ss tt");
                String path3 = stringToday + "_" + stringExcelPath3;

                while (queuePublicReportDeletion.Count > 0)
                {
                    using (StreamWriter sw = File.AppendText(path3))
                    {
                        deleteResultsList.Add(queuePublicReportDeletion.Dequeue());
                        countFlag++;

                        if (countFlag == 200 || queuePublicReportDeletion.Any() || deleteResultsList.Any())
                        {

                            try
                            {
                                DeletePublicReportBatch = deleteResultsList.ToArray();
                                deleteResults = this.con.delete(DeletePublicReportBatch);

                                for (int i = 0; i < deleteResults.Length; i++)

                                {
                                    DeleteResult deleteResult = deleteResults[i];
                                    if (deleteResult.success)
                                    {
                                        DirectoryInfo[] cDirs = new DirectoryInfo(@"C:\").GetDirectories();
                                        string appendText = "Success:   deleted  " + "Public Report Record ID: " + deleteResult.id + "\n" + Environment.NewLine;
                                        sw.WriteLine(appendText);
                                    }
                                    else
                                    {   // Handle the errors.
                                        // We just print the first error out for sample purposes.
                                        Error[] errors = deleteResult.errors;
                                        if (errors.Length > 0)
                                        {
                                            string appendText2 = "Error: could not delete " + "Public Report Record ID: " + DeletePublicReportBatch[i] +
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
                MessageBox.Show("There are not Public report for deletion", "Declined Deletion", MessageBoxButtons.OK);
            }
        }
        }
 }


