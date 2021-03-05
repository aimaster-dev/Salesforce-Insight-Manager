using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesforceWindowsForms.SFDC;
using SalesforceWindowsForms.CollectionObjects;
using SalesforceWindowsForms.DAL;
using SalesforceWindowsForms.View;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using LinqToExcel;

namespace SalesforceWindowsForms
{
    public partial class FMain : Form
    {

        public FMain()
        {
            InitializeComponent();

        }
        private bool buttonFolderShareWasClicked = false;
        private async void bLogin_Click(object sender, EventArgs e)
        {

            label4.Text = "Processing, please wait";
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            dgv.Rows.Clear();
            dgv.Refresh();

            SaleForceConnect con = SaleForceConnect.getInstance(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["ServerURLsoap"]);
            SforceService connection = con.getCon();
            PrivateReportFactory prf = new PrivateReportFactory(connection);

            await Task.Factory.StartNew(() => prf.loadPrivateReport()).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());
            PublicReportFactory pr = new PublicReportFactory(connection);
            await Task.Factory.StartNew(() => pr.loadPublicReport(Convert.ToInt32(publicParams.Text))).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());
            PeopleFactory p = new PeopleFactory(connection);
            await Task.Factory.StartNew(() => p.loadPeopleAsync()).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());
            UserFactory u = new UserFactory(connection);
            await Task.Factory.StartNew(() => u.loadUser()).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());

            /* if (backgroundWorker1.IsBusy != true)
             {

                 bgw.RunWorkerAsync();*/

            // stopwatchLoadPrivateReport.Start();
            // PrivateReportFactory prf = new PrivateReportFactory(connection);
            //  prf.loadPrivateReport(/*bgw*/);

            // stopwatchLoadPrivateReport.Stop();

            //PublicReportFactory pr = new PublicReportFactory(connection);
            // stopwatchLoadPublicReport.Start();
            //pr.loadPublicReport(Convert.ToInt32(publicParams.Text)/*, bgw*/);
            //stopwatchLoadPublicReport.Stop();

            // PeopleFactory p = new PeopleFactory(connection);
            // stopwatchLoadPeople.Start();
            // p.loadPeople(/*bgw*/);
            // stopwatchLoadPeople.Stop();

            //UserFactory u = new UserFactory(connection);
            //stopwatchLoadUser.Start();
            //u.loadUser(/*bgw*/);
            // stopwatchLoadUser.Stop();
            // }
            /*
                 Console.WriteLine("Time elapsed in private report loading: {0:hh\\:mm\\:ss}", stopwatchLoadPrivateReport.Elapsed);
                 Console.WriteLine("Time elapsed in public report loading: {0:hh\\:mm\\:ss}", stopwatchLoadPublicReport.Elapsed);
                 Console.WriteLine("Time elapsed in User loading: {0:hh\\:mm\\:ss}", stopwatchLoadUser.Elapsed);
                 Console.WriteLine("Time elapsed in people loading: {0:hh\\:mm\\:ss}", stopwatchLoadPeople.Elapsed);
                 */

            //authenticate();
            if (listQuery.SelectedItem.ToString().Equals("1a - Inactive Employees (Retired, withdrawn)"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows


                DataGridViewHandler dgv1 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery1a = new ListasSfCollectionObjects();


                //stopwatchQuery1a.Start();

                dgv1.dgvQuery1a(sfQuery1a.query1a(prf.getPrivateReport(), p.getPeople(), u.getUser(), IgnoreIds), dgv, label4);

                // stopwatchQuery1a.Stop();

                //Console.WriteLine("Time elapsed in execution query1a: {0:hh\\:mm\\:ss}", stopwatchQuery1a.Elapsed);


            }
            if (listQuery.SelectedItem.ToString().Equals("1b - Inactive Employees (but not Retired, Withdrawn)"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows

                dgv.Rows.Clear();
                DataGridViewHandler dgv2 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery1b = new ListasSfCollectionObjects();

                //stopwatchQuery1b.Start();

                dgv2.dgvQuery1b(sfQuery1b.query1b(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);

                //stopwatchQuery1b.Stop();

                // Console.WriteLine("Time elapsed in execution query1b: {0:hh\\:mm\\:ss}", stopwatchQuery1b.Elapsed);

            }
            if (listQuery.SelectedItem.ToString().Equals(" 2 - Inactive MMS users - last login is >180 days"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows

                dgv.Rows.Clear();
                DataGridViewHandler dgv3 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery2 = new ListasSfCollectionObjects();

                //stopwatchQuery2.Start();

                dgv3.dgvQuery2(sfQuery2.query2(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);

                // stopwatchQuery2.Stop();

                //Console.WriteLine("Time elapsed in execution query2: {0:hh\\:mm\\:ss}", stopwatchQuery2.Elapsed);


            }

            if (listQuery.SelectedItem.ToString().Equals(" 3 - Active MMS Users - Reports not run in more than 180 days"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows

                dgv.Rows.Clear();
                DataGridViewHandler dgv4 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery3 = new ListasSfCollectionObjects();

                //stopwatchQuery3.Start();

                dgv4.dgvQuery3(sfQuery3.query3(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);

                //stopwatchQuery3.Stop();

                //Console.WriteLine("Time elapsed in execution query3: {0:hh\\:mm\\:ss}", stopwatchQuery3.Elapsed);

            }


            if (listQuery.SelectedItem.ToString().Equals(" 4 - Public Reports not run in more than 90 Days"))
            {//clear columns

                dgv.Columns.Clear();
                //clear rows
                dgv.Rows.Clear();

                DataGridViewHandler dgv5 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery4 = new ListasSfCollectionObjects();

                //stopwatchQuery4.Start();

                dgv5.dgvQuery4(sfQuery4.query4(pr.getPublicReport(), u.getUser(),IgnoreIds), dgv, label4);

                //stopwatchQuery3.Stop();

                //Console.WriteLine("Time elapsed in execution query4: {0:hh\\:mm\\:ss}", stopwatchQuery4.Elapsed);

            }
            if (listQuery.SelectedItem.ToString().Equals(" 5 - Public and private Dashboard"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows
                dgv.Rows.Clear();



                DataGridViewHandler dgv6 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery5 = new ListasSfCollectionObjects();

                PublicDashboardComponentFactory pdcf = new PublicDashboardComponentFactory(connection);
                //stopwatchLoadPrivateDashboardComponent.Start();
                pdcf.loadPublicDashboardComponents();
                //stopwatchLoadPublicDashboardComponent.Stop();

                PublicDashboardFactory pdf = new PublicDashboardFactory(connection);
                //stopwatchLoadPublicDashboard.Start();
                pdf.loadPublicDashboard();
                //stopwatchLoadPublicDashboard.Stop();

                PrivateDashboardComponentFactory prdcf = new PrivateDashboardComponentFactory(connection);
                //stopwatchLoadPrivateDashboardComponent.Start();
                prdcf.loadPrivateDashboardComponent();
                // stopwatchLoadPrivateDashboardComponent.Stop();

                PrivateDashboardFactory prdf = new PrivateDashboardFactory(connection);
                //stopwatchLoadPrivateDashboard.Start();
                prdf.loadPrivateDashboard();
                //stopwatchLoadPrivateDashboard.Stop();

                //stopwatchQuery5.Start();

                dgv6.dgvQuery5(sfQuery5.query5(u.getUser(), pdcf.GetPublicDashboardComponent(),
                    pr.getPublicReport(), pdf.GetPublicDashboards(), prdcf.getPrivateDashboardComponent(), prdf.GetPrivateDashboards(),
                    prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);

                //stopwatchQuery5.Stop();

                // Write hours, minutes and seconds.
                /*
                Console.WriteLine("Time elapsed in public dashboard component: {0:hh\\:mm\\:ss}", stopwatchLoadPublicDashboardComponent.Elapsed);
                Console.WriteLine("Time elapsed in private dashboard component: {0:hh\\:mm\\:ss}", stopwatchLoadPrivateDashboardComponent.Elapsed);
                Console.WriteLine("Time elapsed in public dashboard: {0:hh\\:mm\\:ss}", stopwatchLoadPublicDashboard.Elapsed);
                Console.WriteLine("Time elapsed in public dashboard: {0:hh\\:mm\\:ss}", stopwatchLoadPrivateDashboard.Elapsed);
                Console.WriteLine("Time elapsed in public dashboard: {0:hh\\:mm\\:ss}", stopwatchQuery5.Elapsed);
                */
            }


        }
        [STAThread]
        private async void Export_Click(object sender, EventArgs e)
        {
            label4.Text = "Processing Excel file, wait until your File Explorer pop up";
            progressBar1.Visible = false;
            // DialogResult result = MessageBox.Show("Excel file is loading please wait until a pop up message of completion come up", "Excel Loading", MessageBoxButtons.OK);

            //STAT setting for current thread

            Thread thread = Thread.CurrentThread;
            thread.SetApartmentState(ApartmentState.STA);
            String fileName;

            if (buttonFolderShareWasClicked.Equals(true))
            {

                fileName = "FolderShare";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                dgvA.excelFile(fileName, dgv);
                // await Task.Run(() => dgvA.excelFile(fileName, dgv));
            }


            else if (listQuery.SelectedItem != null && listQuery.SelectedItem.ToString().Equals("1a - Inactive Employees (Retired, withdrawn)"))
            {
                fileName = "Query 1a";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                //await Task.Factory.StartNew(() => dgvA.excelFile(fileName, dgv));
                await Task.Run(() => dgvA.excelFile(fileName, dgv));

                //dgvA.excelFile(fileName, dgv);

            }

            else if (listQuery.SelectedItem != null && listQuery.SelectedItem.ToString().Equals("1b - Inactive Employees (but not Retired, Withdrawn)"))
            {
                fileName = "Query 1b";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                await Task.Run(() => dgvA.excelFile(fileName, dgv));
                //dgvA.excelFile(fileName, dgv);
            }

            else if (listQuery.SelectedItem != null && listQuery.SelectedItem.ToString().Equals("2 - Inactive MMS users - last login is >180 days"))
            {
                fileName = "Query 2";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                await Task.Run(() => dgvA.excelFile(fileName, dgv));
                //dgvA.excelFile(fileName, dgv);

            }
            else if (listQuery.SelectedItem != null && listQuery.SelectedItem.ToString().Equals(" 3 - Active MMS Users - Reports not run in more than 180 days"))
            {
                fileName = "Query 3";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                await Task.Run(() => dgvA.excelFile(fileName, dgv));
                //dgvA.excelFile(fileName, dgv);
            }
            else if (listQuery.SelectedItem != null && listQuery.SelectedItem.ToString().Equals(" 4 - Public Reports not run in more than 90 Days"))
            {
                fileName = "Query 4";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                await Task.Run(() => dgvA.excelFile(fileName, dgv));
                //dgvA.excelFile(fileName, dgv);

            }

            else if (listQuery.SelectedItem != null && listQuery.SelectedItem.ToString().Equals(" 5 - Public and private Dashboard"))
            {
                fileName = "Query 5";
                DataGridViewHandler dgvA = new DataGridViewHandler();
                await Task.Run(() => dgvA.excelFile(fileName, dgv));
                //dgvA.excelFile(fileName, dgv);
            }

        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            /*
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                label4.Text = "Processing, please wait";
            }*/
            /*
            SaleForceConnect con = SaleForceConnect.getInstance(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["ServerURL"]);

            SforceService connection = con.getCon();
            */
            /*
            String stringExcelPath = "CeciReportingTestLOG_deletion.txt";
            AccountFactory a = new AccountFactory(connection);
            a.loadAccount();
            a.deleteAccount(stringExcelPath, a.getAccount());*/
            /*
            PrivateReportFactory prf = new PrivateReportFactory(connection);
            prf.loadPrivateReport();
            PublicReportFactory pr90 = new PublicReportFactory(connection);
            pr90.loadPublicReport(Convert.ToInt32(publicParams.Text)); // tread  initialize on the Go click event
            PublicDashboardComponentFactory pdcf = new PublicDashboardComponentFactory(connection);
            pdcf.loadPublicDashboardComponents();
            PublicDashboardFactory pdf = new PublicDashboardFactory(connection);
            pdf.loadPublicDashboard();
            PrivateDashboardComponentFactory prdcf = new PrivateDashboardComponentFactory(connection);
            prdcf.loadPrivateDashboardComponent();
            PrivateDashboardFactory prdf = new PrivateDashboardFactory(connection);
            prdf.loadPrivateDashboard();
            PeopleFactory p = new PeopleFactory(connection);
            p.loadPeople();  // tread  initialize on the Go click event // with  backgroundworker
            UserFactory u = new UserFactory(connection);
            u.loadUser();  // tread  initialize on the Go click event// with  backgroundworker
            */
            label4.Text = "Processing, please wait";
            progressBar1.Value = 0;
            dgv.Rows.Clear();
            dgv.Refresh();

            SaleForceConnect con = SaleForceConnect.getInstance(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["ServerURLsoap"]);
            SforceService connection = con.getCon();
            PrivateReportFactory prf = new PrivateReportFactory(connection);

            await Task.Factory.StartNew(() => prf.loadPrivateReport()).ContinueWith(t => progressBar1.Value += 5, TaskScheduler.FromCurrentSynchronizationContext());
            PublicReportFactory pr = new PublicReportFactory(connection);
            await Task.Factory.StartNew(() => pr.loadPublicReport(Convert.ToInt32(publicParams.Text))).ContinueWith(t => progressBar1.Value += 5, TaskScheduler.FromCurrentSynchronizationContext());
            PeopleFactory p = new PeopleFactory(connection);
            await Task.Factory.StartNew(() => p.loadPeopleAsync()).ContinueWith(t => progressBar1.Value += 5, TaskScheduler.FromCurrentSynchronizationContext());
            UserFactory u = new UserFactory(connection);
            await Task.Factory.StartNew(() => u.loadUser()).ContinueWith(t => progressBar1.Value += 5, TaskScheduler.FromCurrentSynchronizationContext());
            PublicDashboardComponentFactory pdcf = new PublicDashboardComponentFactory(connection);
            await Task.Factory.StartNew(() => pdcf.loadPublicDashboardComponents()).ContinueWith(t => progressBar1.Value += 10, TaskScheduler.FromCurrentSynchronizationContext());

            //pdcf.loadPublicDashboardComponents();
            PublicDashboardFactory pdf = new PublicDashboardFactory(connection);
            await Task.Factory.StartNew(() => pdf.loadPublicDashboard()).ContinueWith(t => progressBar1.Value += 10, TaskScheduler.FromCurrentSynchronizationContext());

            //pdf.loadPublicDashboard();
            PrivateDashboardComponentFactory prdcf = new PrivateDashboardComponentFactory(connection);
            await Task.Factory.StartNew(() => prdcf.loadPrivateDashboardComponent()).ContinueWith(t => progressBar1.Value += 10, TaskScheduler.FromCurrentSynchronizationContext());

            prdcf.loadPrivateDashboardComponent();
            PrivateDashboardFactory prdf = new PrivateDashboardFactory(connection);
            await Task.Factory.StartNew(() => prdf.loadPrivateDashboard()).ContinueWith(t => progressBar1.Value += 50, TaskScheduler.FromCurrentSynchronizationContext());

            //prdf.loadPrivateDashboard();


            String fileName;
            if (listQuery.SelectedItem.ToString().Equals("1a - Inactive Employees (Retired, withdrawn)"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows


                DataGridViewHandler dgv1 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery1a = new ListasSfCollectionObjects();
                fileName = "Query 1a";




                dgv1.dgvQuery1a(sfQuery1a.query1a(prf.getPrivateReport(), p.getPeople(), u.getUser(), IgnoreIds), dgv, label4);
                dgv1.excelFile(fileName, dgv);
                //Meesage box 

                DialogResult result = MessageBox.Show("This is going to be delete, are you agree?", "Deletion alert", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    /*
                    String stringExcelPath1 = "privateDashboardIDQuery1aLOG_Deletion.txt";
                    prdf.deletePrivateDashboard(stringExcelPath1, sfQuery1a.queryID1aDeletePrivateDashboard(prf.getPrivateReport(), prdcf.getPrivateDashboardComponent(),
                    prdf.GetPrivateDashboards(), p.getPeople(), u.getUser()));

                    String stringExcelPath2 = "publicDashboardIDQuery1aLOG_Deletion.txt";
                    pdf.deletePublicDashboard(stringExcelPath2, sfQuery1a.queryID1aDeletePublicDashboard(prf.getPrivateReport(), pdf.GetPublicDashboards(),
                    pdcf.GetPublicDashboardComponent(), p.getPeople(), u.getUser()));*/

                    String stringExcelPath3 = "PrivateReportQuery1aLOG_deletion.txt";
                    await Task.Run(() => prf.deletePrivateReports(stringExcelPath3, sfQuery1a.queryID1aDeletePrivateReports(prf.getPrivateReport(), p.getPeople(), u.getUser())));

                }
                else
                {
                    MessageBox.Show("The deletion hasn't been done", "Declined Deletion", MessageBoxButtons.OK);

                }

            }
            if (listQuery.SelectedItem.ToString().Equals("1b - Inactive Employees (but not Retired, Withdrawn)"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows

                dgv.Rows.Clear();
                DataGridViewHandler dgv2 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery1b = new ListasSfCollectionObjects();
                fileName = "Query 1b";

                dgv2.dgvQuery1b(sfQuery1b.query1b_deletion(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);
                dgv2.excelFile(fileName, dgv);

                //Meesage box 

                DialogResult result = MessageBox.Show("This is going to be delete, are you agree?", "Deletion alert", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    /*
                    String stringExcelPath1 = "privateDashboardIDQuery1bLOG_Deletion.txt";
                    prdf.deletePrivateDashboard(stringExcelPath1, sfQuery1b.queryID1bDeletePrivateDashboard(prf.getPrivateReport(), prdcf.getPrivateDashboardComponent(),
                    prdf.GetPrivateDashboards(), p.getPeople(), u.getUser(),Convert.ToInt32(privateParams.Text)));

                    String stringExcelPath2 = "publicDashboardIDQuery1bLOG_Deletion.txt";
                    pdf.deletePublicDashboard(stringExcelPath2, sfQuery1b.queryID1bDeletePublicDashboard(prf.getPrivateReport(), pdf.GetPublicDashboards(),
                    pdcf.GetPublicDashboardComponent(), p.getPeople(), u.getUser(),Convert.ToInt32(privateParams.Text)));

                    */

                    String stringExcelPath3 = "PrivateReportQuery1bLOG_deletion.txt";
                    await Task.Run(() => prf.deletePrivateReports(stringExcelPath3, sfQuery1b.queryID1bDeletePrivateReports(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds)));

                }
                else
                {
                    MessageBox.Show("The deletion hasn't been done", "Declined Deletion", MessageBoxButtons.OK);

                }

            }
            if (listQuery.SelectedItem.ToString().Equals(" 2 - Inactive MMS users - last login is >180 days"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows

                dgv.Rows.Clear();
                DataGridViewHandler dgv3 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery2 = new ListasSfCollectionObjects();
                fileName = "Query 2";

                dgv3.dgvQuery2(sfQuery2.query2_delete(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);
                dgv3.excelFile(fileName, dgv);
                //Meesage box 

                DialogResult result = MessageBox.Show("This is going to be delete, are you agree?", "Deletion alert", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    String stringExcelPath1 = "privateDashboardIDQuery2LOG_Deletion.txt";
                    await Task.Run(() => prdf.deletePrivateDashboard(stringExcelPath1, sfQuery2.queryID2DeletePrivateDashboard(prf.getPrivateReport(), prdcf.getPrivateDashboardComponent(),
                    prdf.GetPrivateDashboards(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds)));

                    String stringExcelPath2 = "publicDashboardIDQuery2LOG_Deletion.txt";
                    await Task.Run(() => pdf.deletePublicDashboard(stringExcelPath2, sfQuery2.queryID2DeletePublicDashboard(prf.getPrivateReport(), pdf.GetPublicDashboards(),
                    pdcf.GetPublicDashboardComponent(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds)));

                    String stringExcelPath3 = "PrivateReportIDQuery2LOG_deletion.txt";
                    await Task.Run(() => prf.deletePrivateReports(stringExcelPath3, sfQuery2.queryID2DeletePrivateReports(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds)));


                }
                else
                {
                    MessageBox.Show("The deletion hasn't been done", "Declined Deletion", MessageBoxButtons.OK);

                }
            }
            if (listQuery.SelectedItem.ToString().Equals(" 3 - Active MMS Users - Reports not run in more than 180 days"))
            {
                //clear columns
                dgv.Columns.Clear();
                //clear rows

                dgv.Rows.Clear();
                DataGridViewHandler dgv4 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery3 = new ListasSfCollectionObjects();
                fileName = "Query 3";

                dgv4.dgvQuery3(sfQuery3.query3_deletion(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds), dgv, label4);
                dgv4.excelFile(fileName, dgv);
                //Meesage box 

                DialogResult result = MessageBox.Show("This is going to be delete, are you agree?", "Deletion alert", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    String stringExcelPath3 = "PrivateReportIDQuery3LOG_deletion.txt";
                    await Task.Run(() => prf.deletePrivateReports(stringExcelPath3, sfQuery3.queryID3DeletePrivateReports(prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), IgnoreIds)));

                }
                else
                {
                    MessageBox.Show("The deletion hasn't been done", "Declined Deletion", MessageBoxButtons.OK);

                }
            }
            if (listQuery.SelectedItem.ToString().Equals(" 4 - Public Reports not run in more than 90 Days"))
            {
                //clear columns

                dgv.Columns.Clear();
                //clear rows
                dgv.Rows.Clear();

                DataGridViewHandler dgv5 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery4 = new ListasSfCollectionObjects();
                fileName = "Query 4";

                dgv5.dgvQuery4(sfQuery4.query4(pr.getPublicReport(), u.getUser(), IgnoreIds), dgv, label4);
                dgv5.excelFile(fileName, dgv);
                //Meesage box 

                DialogResult result = MessageBox.Show("This is going to be delete, are you agree?", "Deletion alert", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    String stringExcelPath3 = "PublicReportIDQuery4LOG_deletion.txt";
                    await Task.Run(() => pr.deletePublicReport(stringExcelPath3, sfQuery4.queryID4DeletePublicReports(pr.getPublicReport(), u.getUser(), IgnoreIds)));

                }
                else
                {
                    MessageBox.Show("The deletion hasn't been done", "Declined Deletion", MessageBoxButtons.OK);

                }

            }
            if (listQuery.SelectedItem.ToString().Equals(" 5 - Public and private Dashboard"))
            {
                /*
                //clear columns
                dgv.Columns.Clear();
                //clear rows
                dgv.Rows.Clear();



                DataGridViewHandler dgv6 = new DataGridViewHandler();
                ListasSfCollectionObjects sfQuery5 = new ListasSfCollectionObjects();
                fileName = "Query 5";

                dgv6.dgvQuery5(sfQuery5.query5_deletion(pdcf.GetPublicDashboardComponent(),
                    pr.getPublicReport(), pdf.GetPublicDashboards(), prdcf.getPrivateDashboardComponent(), prdf.GetPrivateDashboards(),
                    prf.getPrivateReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), Convert.ToInt32(publicParams.Text)), dgv, label4);
                dgv6.excelFile(fileName, dgv);
                //Meesage box 

                DialogResult result = MessageBox.Show("This is going to be delete, are you agree?", "Deletion alert", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    String stringExcelPath1 = "privateDashboardIDQuery5LOG_Deletion.txt";
                    prdf.deletePrivateDashboard(stringExcelPath1, sfQuery5.queryID5DeletePrivateDashboard(prf.getPrivateReport(), prdcf.getPrivateDashboardComponent(),
                    prdf.GetPrivateDashboards(), pr.getPublicReport(), p.getPeople(), u.getUser(), Convert.ToInt32(privateParams.Text), Convert.ToInt32(publicParams.Text)));

                    String stringExcelPath2 = "publicDashboardIDQuery5LOG_Deletion.txt";
                    pdf.deletePublicDashboard(stringExcelPath2, sfQuery5.queryID5DeletePublicDashboard(u.getUser(), p.getPeople(), pdcf.GetPublicDashboardComponent(), pr.getPublicReport(),
                        pdf.GetPublicDashboards(), prf.getPrivateReport(), Convert.ToInt32(privateParams.Text), Convert.ToInt32(publicParams.Text)));


                }
                else
                {
                    MessageBox.Show("The deletion hasn't been done", "Declined Deletion", MessageBoxButtons.OK);

                }
                */
                MessageBox.Show("This functionality is not implemented", "Declined Deletion", MessageBoxButtons.OK);


            }

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                // bgw.ReportProgress(i);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label4.Text = e.ProgressPercentage.ToString() + "%";

        }

        private void barra(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                label4.Text = e.Error.Message;
            }
            else
            {
                label4.Text = "the process ended";
            }
        }
        private async void FolderShare_Click(object sender, EventArgs e)
        {
            label4.Text = "Processing, please wait";
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            dgv.Rows.Clear();
            dgv.Refresh();


            SaleForceConnect con = SaleForceConnect.getInstance(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["ServerURLsoap"]);

            SforceService connection = con.getCon();// private connection.
            //clear columns
            //dgv.Columns.Clear();
            //clear rows
            //dgv.Rows.Clear();
            DataGridViewHandler dgvFS = new DataGridViewHandler();
            FolderSecurity fs = new FolderSecurity();


            ////////////////////////////method that retrieve a list with FolderSecurity information for the dgv\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            /************loading private and public reports and dashboard******************/
            int param;

            if (Int32.TryParse(publicParams.Text, out param))
            {
                param = Convert.ToInt32(publicParams.Text);
            }
            else
            {
                param = 0;
            }

            PrivateReportFactory prf = new PrivateReportFactory(connection);
            await Task.Factory.StartNew(() => prf.loadPrivateReport()).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());
            PublicReportFactory pr = new PublicReportFactory(connection);
            await Task.Factory.StartNew(() => pr.loadPublicReport(param)).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());
            PublicDashboardFactory pdf = new PublicDashboardFactory(connection);
            await Task.Factory.StartNew(() => pdf.loadPublicDashboard()).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext());
            PrivateDashboardFactory prdf = new PrivateDashboardFactory(connection);
            await Task.Factory.StartNew(() => prdf.loadPrivateDashboard());


            /************loading  Folders and FolderShare********************************/
            Rootobject rObjFolders = new Rootobject();
            Rootobject rObjFolders2 = new Rootobject();
            RootobjectShares rObjectShares = new RootobjectShares();
            List<string> folderIdList = new List<string>();
            IDictionary<String, List<FolderShare>> mappingFolderIdAndShares = new Dictionary<String, List<FolderShare>>();
            //List<FolderShare> fsList = new List<FolderShare>();
            folderIdList = await rObjFolders.GetFolderIdAsync();
            mappingFolderIdAndShares = await rObjectShares.GetFolderShareListAsync(folderIdList);
            rObjFolders2 = await Rootobject.GetFoldersAsync();

            /******************Query for the final report*******************************/
            List<FolderSecurity> qFolderSecurity = new List<FolderSecurity>();
            ListasSfCollectionObjects fsq = new ListasSfCollectionObjects();
            qFolderSecurity = fsq.QueryFolderSecurity(pr.getPublicReport(), prf.getPrivateReport(), pdf.GetPublicDashboards(),
                                                        prdf.GetPrivateDashboards(), mappingFolderIdAndShares, rObjFolders2);
            //await Task.Factory.StartNew(() => dgvFS.dgvFolderSecurity(qFolderSecurity, dgv, label4).ContinueWith(t => progressBar1.Value += 25, TaskScheduler.FromCurrentSynchronizationContext()));

            dgvFS.dgvFolderSecurity(qFolderSecurity, dgv, label4);
            progressBar1.Value += 25;

            buttonFolderShareWasClicked = true;


        }

        private void FMain_Load(object sender, EventArgs e)
        {

        }
        ///Mati: Vars created to be used in Ingore Button and methods
        List<String> IgnoreIds;
        OpenFileDialog ofd = new OpenFileDialog();
        ///Mati: Code for Upload ID´s to Ignore Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var book = new ExcelQueryFactory(ofd.FileName);
                List<IgnoreId> IgnoreIdsob = (from row in book.Worksheet("Accounts")
                                              let item = new IgnoreId
                                              {
                                                  accounts = row[0].ToString()
                                              }
                                              select item).ToList();
                IgnoreIds = (from o in IgnoreIdsob
                             select o.accounts).ToList();

                book.Dispose();
                label5.Text = "File Uploaded: Yes";
            }
            
        }
    }
}
