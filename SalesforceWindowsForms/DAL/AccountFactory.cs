using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesforceWindowsForms.SFDC;
using SalesforceWindowsForms.CollectionObjects;
using System.IO;
using System.Windows.Forms;
using System.Web.Services.Protocols;


/*Clase para testeo del modulo de eliminacion*/

namespace SalesforceWindowsForms.DAL
{
    class AccountFactory
    {
        private SforceService con;
        private List<Account> sfAccount = new List<Account>();
        private List<String> queryAccountDeletion = new List<String>();
        private DeleteResult[] deleteResults;
        private List<String> deleteResultsList = new List<String>();



        public AccountFactory(SforceService con)
        {
            this.con = con;
        }

        public void loadAccount()
        {
            Boolean done = false;
            String Account = "SELECT Id FROM CeciReportingTest__c"; // custom object 
            QueryResult queryAccount = this.con.query(Account);



            while (!done)
            {
                for (int j = 0; j < queryAccount.records.Length; j++)
                {
                    sObject accountRecord = queryAccount.records[j];// taking the first node or object.
                    Account ac = new Account(); // instance of PrivateReport

                    //add value to Account property
                    ac.ID = accountRecord.Any[0].InnerText.ToString();

                    // add people object into people list.
                    sfAccount.Add(ac);
                }

                if (queryAccount.done)
                {
                    done = true;
                }
                else
                {
                    queryAccount = this.con.queryMore(queryAccount.queryLocator);
                }

            }


        }

        public List<Account> getAccount()
        {
            return this.sfAccount;
        }

        public void deleteAccount(String stringExcelPathAccount, List<Account> queryAccountToDelete)
        {

            var query_deletion_account_test = from ac in queryAccountToDelete
                                              select new
                                              {
                                                  ac.ID
                                              };

            this.queryAccountDeletion = query_deletion_account_test.Select(x => x.ID.ToString()).ToList();
            Queue<String> queueAccountDeletion = new Queue<String>(queryAccountDeletion);


            //create variable for today variable
            String stringToday = DateTime.Now.ToString("MM-dd-yyyy");
            //create a variable for the path;
            String stringExcelPathLog1 = "c:\\";
            //create variable for final concatenation of the variable
            String stringExcelPathLog3 = stringExcelPathLog1 + stringToday + "_" + stringExcelPathAccount;

            // it's necessary to parse the "privateDashboardID1a" value to an Array so we can send it through API call.
            // String[] DeletePrivateReports= queryDeletePrivateReports.ToArray();
            String[] DeleteAccountBatch;
            int countFlag = 0;

            while (queueAccountDeletion.Count > 0)
            {

                deleteResultsList.Add(queueAccountDeletion.Dequeue());
                countFlag++;

                if (countFlag == 200)
                {
                    try

                    {
                        DeleteAccountBatch = deleteResultsList.ToArray();
                        deleteResults = this.con.delete(DeleteAccountBatch);

                        for (int i = 0; i < deleteResults.Length; i++)

                        {

                            DeleteResult deleteResult = deleteResults[i];

                            if (deleteResult.success)

                            {

                                string appendText = "Deleted Record ID:" + deleteResult.id + Environment.NewLine;
                                File.AppendAllText(stringExcelPathLog3, appendText);

                                //Console.WriteLine("Deleted Record ID: " + deleteResult.id);

                            }

                            else

                            {

                                // Handle the errors.

                                // We just print the first error out for sample purposes.

                                Error[] errors = deleteResult.errors;

                                if (errors.Length > 0)
                                {

                                    string appendText = "Error: could not delete " + "  Record ID " + deleteResult.id + "." +
                                    "   The error reported was: (" + errors[0].statusCode + ") " + errors[0].message + "\n" + Environment.NewLine;
                                    File.AppendAllText(stringExcelPathLog3, appendText);

                                    /*
                                    Console.WriteLine("Error: could not delete " + "Record ID "

                                          + deleteResult.id + ".");

                                    Console.WriteLine("   The error reported was: ("

                                          + errors[0].statusCode + ") "

                                          + errors[0].message + "\n");*/

                                }

                            }

                        }

                    }

                    catch (SoapException e)

                    {

                        string appendText = "An unexpected error has occurred: " +

                                                e.Message + "\n" + e.StackTrace + Environment.NewLine;
                        File.AppendAllText(stringExcelPathLog3, appendText);

                        /*
                        Console.WriteLine("An unexpected error has occurred: " +

                                                e.Message + "\n" + e.StackTrace);*/

                    }
                    deleteResultsList.Clear();
                    countFlag = 0;
                }

            }

        }




        /*
        if (queryAccountDeletion != null && queryAccountDeletion.Count != 0)
        {

            //create variable for today variable
            String stringToday = DateTime.Now.ToString("MM-dd-yyyy");
            //create a variable for the path;
            String stringExcelPathLog1 = "c:\\";
            //create variable for final concatenation of the variable
            String stringExcelPathLog3 = stringExcelPathLog1 + stringToday + "_" + stringExcelPathAccount;

            // it's necessary to parse the "privateDashboardID1a" value to an Array so we can send it through API call.
            // String[] DeletePrivateReports= queryDeletePrivateReports.ToArray();
            String[] DeleteAccountBatch;
            int countFlag = 0;


            for (int j = 0; j <= queryAccountDeletion.Count; j++)
            {

                if (countFlag < 200 || countFlag < deleteResultsList.Count)
                {

                    if ((deleteResultsList.Count == 0 || deleteResultsList.Count < 200)
                                                      && j < queryAccountDeletion.Count)
                    {
                        deleteResultsList.Add(queryAccountDeletion[j]);
                        Console.WriteLine(deleteResultsList.Count.ToString(), queryAccountDeletion.Count.ToString(), queryAccountDeletion[j].ToString(), j.ToString());
                    }
                    if (deleteResultsList.Count == 200)
                    {
                        deleteResultsList.Clear();
                        deleteResultsList.Add(queryAccountDeletion[j]);
                    }
                    countFlag++;
                }

                if (countFlag == 200 || j == queryAccountDeletion.Count)
                {
                    DeleteAccountBatch = deleteResultsList.ToArray();
                    deleteResults = this.con.delete(DeleteAccountBatch);
                    for (int i = 0; i < deleteResults.Length; i++)

                    {

                        DeleteResult deleteResult = deleteResults[i];

                        if (deleteResult.success)

                        {
                            string appendText = "Deleted  private Report Record ID: " + deleteResult.id + Environment.NewLine;
                            File.AppendAllText(stringExcelPathLog3, appendText);


                        }

                        else

                        {

                            // Handle the errors.

                            // We just print the first error out for sample purposes.

                            Error[] errors = deleteResult.errors;

                            if (errors.Length > 0)

                            {

                                string appendText = "Error: could not delete " + " private report Record ID " + deleteResult.id + "." +
                                    "   The error reported was: (" + errors[0].statusCode + ") " + errors[0].message + "\n" + Environment.NewLine;
                                File.AppendAllText(stringExcelPathLog3, appendText);


                            }

                        }
                    }
                    countFlag = 0;
                }

            }


        }
        else
        {
            MessageBox.Show("There are not Private Dashboard associated", "Declined Deletion", MessageBoxButtons.OK);

        }*/

    
        }
}
