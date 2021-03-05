using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SalesforceWindowsForms.DAL;
using SalesforceWindowsForms.CollectionObjects;
using SalesforceWindowsForms.SFDC;// paquete del partner WSDL - XML - SOAP  API
using System.Threading;

namespace SalesforceWindowsForms.View
{
    class DataGridViewHandler
    {

        private DateTime today = DateTime.Now;

        private List<String> fieldsQuery = new List<string>() { "EMPLOYMENT_STATUS",
                                                                         "LASTLOGINDATE",
                                                                         "CheckPeopleID",
                                                                         "EnterpriseID",
                                                                         "Isactive",
                                                                         "Name",
                                                                         "LastRunDate",
                                                                         "ExtractPrivateReportsID",
                                                                         "FOLDERNAME",
                                                                         "LASTMODIFIEDBYID",
                                                                          "MMS_User__C"};


        private List<String> fieldsQueryForth = new List<string>() { "ID_PublicReport",
                                                                         "FolderName",
                                                                         "LastModifiedById",
                                                                         "Name",
                                                                         "LastRunDate",
                                                                         "EID",
                                                                         };

        private List<String> fieldsFifthQuery = new List<string>() { "Dashboard",
                                                                                "Report_Id",
                                                                                "LastRunDate",
                                                                                "EnterpriseId",
                                                                                "DshCompName",
                                                                                "FolderName",
                                                                                "LastModifiedById",
                                                                               "Title"
                                                                                };
        //New code for FolderShare (Gridview module)
        private List<String> fieldsFolderSecurity = new List<string>() { "FolderId",
                                                                                "FolderName",
                                                                                "Type",
                                                                                "Name",
                                                                                "AccessType"
                                                                           };
        [STAThread]
        public void dgvQuery1a(List<InactivePeopleWithPrivateReports> query1a, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsQuery)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Agrego una fila y lleno cada celda con los resultados del join
            for (int j = 0; j < query1a.Count; j++)
            {
                int index = dgv.Rows.Add();

                InactivePeopleWithPrivateReports fq = query1a.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fq.EMPLOYMENT_STATUS__CS__C;
                dgv.Rows[j].Cells[1].Value = fq.LASTLOGINDATE;
                dgv.Rows[j].Cells[2].Value = fq.CheckPeople_ID;
                dgv.Rows[j].Cells[3].Value = fq.ENTERPRISE_id__C;
                dgv.Rows[j].Cells[4].Value = fq.ISACTIVE;
                dgv.Rows[j].Cells[5].Value = fq.NAME;
                dgv.Rows[j].Cells[6].Value = fq.LASTRUNDATE;
                dgv.Rows[j].Cells[7].Value = fq.ExtractPrivateRepoerts_ID;
                dgv.Rows[j].Cells[8].Value = fq.FOLDERNAME;
                dgv.Rows[j].Cells[9].Value = fq.LASTMODIFIEDBYID;
                dgv.Rows[j].Cells[10].Value = fq.MMS_User__C;


                        



            }
            label4.Text = "Done";
        }

        [STAThread]
        public void dgvQuery1b(List<RetiredOrWithdrawnPeopleWithPrivateReports> query1b, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsQuery)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Agrego una fila y lleno cada celda con los resultados del join
            for (int j = 0; j < query1b.Count; j++)
            {
                int index = dgv.Rows.Add();

                RetiredOrWithdrawnPeopleWithPrivateReports fq = query1b.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fq.EMPLOYMENT_STATUS__C;
                dgv.Rows[j].Cells[1].Value = fq.LASTLOGINDATE;
                dgv.Rows[j].Cells[2].Value = fq.CheckPeople_ID;
                dgv.Rows[j].Cells[3].Value = fq.ENTERPRISE_ID__C;
                dgv.Rows[j].Cells[4].Value = fq.ISACTIVE;
                dgv.Rows[j].Cells[5].Value = fq.NAME;
                dgv.Rows[j].Cells[6].Value = fq.LASTRUNDATE;
                dgv.Rows[j].Cells[7].Value = fq.ExtractPrivateReports_ID;
                dgv.Rows[j].Cells[8].Value = fq.FOLDERNAME;
                dgv.Rows[j].Cells[9].Value = fq.LASTMODIFIEDBYID;
                dgv.Rows[j].Cells[10].Value = fq.MMS_USER__C;



            }
            label4.Text = "Done";
        }

        [STAThread]
        public void dgvQuery2(List<InactivePeopleWithreportsNotRunInMoreThan180Days> query2, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsQuery)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Agrego una fila y lleno cada celda con los resultados del join
            for (int j = 0; j < query2.Count; j++)
            {
                int index = dgv.Rows.Add();

                InactivePeopleWithreportsNotRunInMoreThan180Days fq = query2.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fq.EMPLOYMENT_STATUS__C;
                dgv.Rows[j].Cells[1].Value = fq.LASTLOGINDATE;
                dgv.Rows[j].Cells[2].Value = fq.CheckPeople_ID;
                dgv.Rows[j].Cells[3].Value = fq.ENTERPRISE_ID__C;
                dgv.Rows[j].Cells[4].Value = fq.ISACTIVE;
                dgv.Rows[j].Cells[5].Value = fq.NAME;
                dgv.Rows[j].Cells[6].Value = fq.LASTRUNDATE;
                dgv.Rows[j].Cells[7].Value = fq.ExtractPrivateReports_ID;
                dgv.Rows[j].Cells[8].Value = fq.FOLDERNAME;
                dgv.Rows[j].Cells[9].Value = fq.LASTMODIFIEDBYID;
                dgv.Rows[j].Cells[10].Value = fq.MMS_USER__C;



            }
            label4.Text = "Done";
        }

        [STAThread]
        public void dgvQuery3(List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> query4, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsQuery)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Agrego una fila y lleno cada celda con los resultados del join
            for (int j = 0; j < query4.Count; j++)
            {
                int index = dgv.Rows.Add();

                ActivePeopleWithPrivateReportsNotRunInMoreThan180Days fq = query4.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fq.EMPLOYMENT_STATUS__C;
                dgv.Rows[j].Cells[1].Value = fq.LASTLOGINDATE;
                dgv.Rows[j].Cells[2].Value = fq.CheckPeople_ID;
                dgv.Rows[j].Cells[3].Value = fq.ENTERPRISE_ID__C;
                dgv.Rows[j].Cells[4].Value = fq.ISACTIVE;
                dgv.Rows[j].Cells[5].Value = fq.NAME;
                dgv.Rows[j].Cells[6].Value = fq.LASTRUNDATE;
                dgv.Rows[j].Cells[7].Value = fq.ExtractPrivateReports_ID;
                dgv.Rows[j].Cells[8].Value = fq.FOLDERNAME;
                dgv.Rows[j].Cells[9].Value = fq.LASTMODIFIEDBYID;
                dgv.Rows[j].Cells[10].Value = fq.MMS_USER__C;



            }

            label4.Text = "Done";
        }

        [STAThread]
        public void dgvQuery4(List<PublicReportsNotRunInMoreThan90Days> query4, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsQueryForth)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Agrego una fila y lleno cada celda con los resultados del join
            for (int j = 0; j < query4.Count; j++)
            {
                int index = dgv.Rows.Add();

                PublicReportsNotRunInMoreThan90Days fq = query4.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fq.Id_PublicReport;
                dgv.Rows[j].Cells[1].Value = fq.FolderName;
                dgv.Rows[j].Cells[2].Value = fq.LastModifiedById;
                dgv.Rows[j].Cells[3].Value = fq.Name;
                dgv.Rows[j].Cells[4].Value = fq.LastRunDate;
                dgv.Rows[j].Cells[5].Value = fq.EnterpriseID;



            }
            label4.Text = "Done";
        }

        [STAThread]
        public void dgvQuery5(List<PDCwithPRvsPrivateDashboardTable> query5, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsFifthQuery)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Agrego una fila y lleno cada celda con los resultados del join
            for (int j = 0; j < query5.Count; j++)
            {
                int index = dgv.Rows.Add();

                PDCwithPRvsPrivateDashboardTable fq = query5.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fq.Dashboard;
                dgv.Rows[j].Cells[1].Value = fq.Id;
                dgv.Rows[j].Cells[2].Value = fq.LastRunDate;
                dgv.Rows[j].Cells[3].Value = fq.EnterpriseId;
                dgv.Rows[j].Cells[4].Value = fq.Name;
                dgv.Rows[j].Cells[5].Value = fq.FolderName;
                dgv.Rows[j].Cells[6].Value = fq.LastModifiedById;
                dgv.Rows[j].Cells[7].Value = fq.Title;



            }
            label4.Text = "Done";
        }

        [STAThread]
        //the below function is to display the final query for 
        public void dgvFolderSecurity(List<FolderSecurity> qFolderSecurity, DataGridView dgv, Label label4)
        {
            //columns for the datagridview

            foreach (String s in this.fieldsFolderSecurity)
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = s;
                dgv.Columns.Add(col);
            }

            //Add a row and fill it with the query
            for (int j = 0; j < qFolderSecurity.Count; j++)
            {
                int index = dgv.Rows.Add();

                FolderSecurity fs = qFolderSecurity.ElementAt(j);

                dgv.Rows[j].Cells[0].Value = fs.folderId;
                dgv.Rows[j].Cells[1].Value = fs.folderName;
                dgv.Rows[j].Cells[2].Value = fs.type;
                dgv.Rows[j].Cells[3].Value = fs.name;
                dgv.Rows[j].Cells[4].Value = fs.accessType;
               
            }
            label4.Text = "Done";
           
        }

        
        public void excelFile(String excelName, DataGridView dgv)
        {
            

            //boolean variable to check if the loading is done.
            //Boolean done = false;
            // create a variable for the path; 
            //String stringExcelPath1 = "c:\\";
            //create a variable to concatenate the Report need
            //String stringExcelPath2 = ".xlsx";
            //create variable for final concatenation of the variable
            //String stringExcelPath3 = "";
            //create variable for today variable
            String stringToday = today.ToString("MM-dd-yyyy");

            
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  /// Mati: Changed to False
                app.Visible = false;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                 worksheet = workbook.Sheets["Sheet1"];
                 worksheet = workbook.ActiveSheet;
                 worksheet.Name = excelName;

            
                // storing header part in Excel  
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();//r System.NullReferenceException: 'Object reference not set to an instance of an object.'
                    }
                }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = excelName;
            saveFileDialoge.DefaultExt = ".xlsx";

            Thread thread = new Thread((ThreadStart)(() =>
            {

                if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {

                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            }));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            app.Quit();
            /*
            var algo = app.Worksheets.Application.Ready; // check if the records have been all loaded into Excel file.
             
            if (algo == true)
            {
                DialogResult result = MessageBox.Show("Records have been loaded in Excel file correctly", "Excel ready", MessageBoxButtons.OK);
                
            }*/



            // save the application 
            /*
            stringExcelPath3 = stringExcelPath1 + excelName + "_" + "Date" + stringToday + stringExcelPath2;
            workbook.SaveAs(stringExcelPath3.ToString());*/

        }

        }

    }

    
