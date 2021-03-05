using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesforceWindowsForms.DAL;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class ListasSfCollectionObjects
    {
        private DateTime today = DateTime.Now;
        private List<CheckPeople> listaCheckPeople = new List<CheckPeople>();
        private List<Active_MMS_Users_with_Private_Reports_not_run_in_moreThan_180_days> lista3 = new List<Active_MMS_Users_with_Private_Reports_not_run_in_moreThan_180_days>();
        private List<PrivateDashboardComponents_With_Private_Reports> lista3a = new List<PrivateDashboardComponents_With_Private_Reports>();
        private List<PDCwithPRvsPrivateDashboardTable> lista3aBis = new List<PDCwithPRvsPrivateDashboardTable>();
        private List<PublicDashboardComponentWithPrivateReports> lista3b = new List<PublicDashboardComponentWithPrivateReports>();
        private List<PDCwithPRvsPrivateDashboardTable> lista3bBis = new List<PDCwithPRvsPrivateDashboardTable>();
        private List<PDCwithPRvsPrivateDashboardTable> lista4a = new List<PDCwithPRvsPrivateDashboardTable>();
        private List<PDCwithPRvsPrivateDashboardTable> lista4b = new List<PDCwithPRvsPrivateDashboardTable>();
        private List<String> query1aDeletionPrivateReport = new List<String>();
        private List<String> query1bDeletionPrivateReport = new List<String>();
        private List<String> query2DeletionPrivateReport = new List<String>();
        private List<String> query3DeletionPrivateReport = new List<String>();
        private List<String> query4DeletionPublicReport = new List<String>();
        private List<InactivePeopleWithPrivateReports> InPeWPriRep = new List<InactivePeopleWithPrivateReports>();
        private List<RetiredOrWithdrawnPeopleWithPrivateReports> ReOrWithdPeoWPR = new List<RetiredOrWithdrawnPeopleWithPrivateReports>();
        private List<RetiredOrWithdrawnPeopleWithPrivateReports> ReOrWithdPeoWPR_deletion = new List<RetiredOrWithdrawnPeopleWithPrivateReports>();
        private List<InactivePeopleWithreportsNotRunInMoreThan180Days> inPeoWReNoRunIn180 = new List<InactivePeopleWithreportsNotRunInMoreThan180Days>();
        private List<InactivePeopleWithreportsNotRunInMoreThan180Days> inPeoWReNoRunIn180_deletion = new List<InactivePeopleWithreportsNotRunInMoreThan180Days>();
        private List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> ActPeoWPRNotRun180 = new List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days>();
        private List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> ActPeoWPRNotRun180_deletion = new List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days>();
        private List<PublicReportsNotRunInMoreThan90Days> PubReNotRun90 = new List<PublicReportsNotRunInMoreThan90Days>();
        private List<PDCwithPRvsPrivateDashboardTable> pubAndPrivReports = new List<PDCwithPRvsPrivateDashboardTable>();
        private List<FolderSecurity> qFolderSecurity = new List<FolderSecurity>();
        private List<String> query1aDeletionPrivatedashboard = new List<String>();
        private List<String> query1aDeletionPublicdashboard = new List<String>();
        private List<String> query1bDeletionPrivatedashboard = new List<String>();
        private List<String> query1bDeletionPublicdashboard = new List<String>();
        private List<String> query2DeletionPrivatedashboard = new List<String>();
        private List<String> query2DeletionPublicdashboard = new List<String>();
        private List<String> query5DeletionPrivatedashboard = new List<String>();
        private List<String> query5DeletionPublicdashboard = new List<String>();
        


        private List<CheckPeople> getListaCheckPeople(List<People> p, List<User> u)
        {

            var listaCP = from s in p
                          join
                          r in u on s.PEOPLEKEY__C1 equals r.PEOPLEKEY__C
                          select new CheckPeople()
                          {
                              EmploymentStatus = s.EMPLOYMENT_STATUS__C1,
                              Mms_user_c = s.MMS_USER__C1,
                              Mms_user_status_c = s.MMS_USER_STATUS__C1,
                              PeopleKey_c = s.PEOPLEKEY__C1,
                              IsActve = r.ISACTIVE,
                              EnterpriseID_c = r.ENTERPRISE_ID__C,
                              LastLoginDate = r.LASTLOGINDATE,
                              InactityInd_c = r.INACTIVITYIND__C,
                              Name_user = r.NAME
                          };

            this.listaCheckPeople = listaCP.ToList();




            return this.listaCheckPeople;
        }

        /*public List<Active_MMS_Users_with_Private_Reports_not_run_in_moreThan_180_days> query3(List<PrivateReport> listaPRivateReports)
        {
            var lista3 = from privateReports in listaPRivateReports
                         join
                         checkPeople in this.listaCheckPeople on privateReports.OWNERID equals checkPeople.Mms_user_c
                         where checkPeople.IsActve.Equals("true") && (today - checkPeople.LastLoginDate).TotalDays < 166 ||
                         checkPeople.IsActve.Equals("true") && privateReports.LASTRUNDATE == null && (today - checkPeople.LastLoginDate).TotalDays < 175
                         && !string.IsNullOrEmpty(privateReports.OWNERID)
                         select new
                         {
                             EMPLOYMENT_STATUS = checkPeople.EmploymentStatus,
                             LAST_LOGINDATE = checkPeople.LastLoginDate,
                             CHECKPEOPLE_ID = checkPeople.EnterpriseID_c,
                             ENTERPRISE_ID = checkPeople.EnterpriseID_c,
                             IS_ACTIVE = checkPeople.IsActve,
                             Name = privateReports.NAME,
                             Last_Rundate = privateReports.LASTRUNDATE,
                             EXTRATPRIVATEREPORT_ID = privateReports.ID,
                             MMS_User__C = checkPeople.Mms_user_c
                         };

            return this.lista3;
        }*/
        public List<PrivateDashboardComponents_With_Private_Reports> query_3a(List<PrivateDashboardComponent> listaPrivateDashboardComponent, List<PrivateReport> pr,
            List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {

            List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> drQuery3 = this.query3(pr, p, u, param, IgnoreIds);

            var lista3a = from o in drQuery3
                          join
                          q in listaPrivateDashboardComponent on o.ExtractPrivateReports_ID equals q.CustomReportId
                          select new PrivateDashboardComponents_With_Private_Reports
                          {
                              Dashboard = q.DashboardId,
                              LastRunDate = o.LASTRUNDATE,
                              PrivateReportId = o.ExtractPrivateReports_ID,
                              EnterpriseId = o.ENTERPRISE_ID__C,
                              Name = o.NAME
                          };

            this.lista3a = lista3a.ToList();


            return this.lista3a;
        }

        public List<PDCwithPRvsPrivateDashboardTable> query3aBis(List<PrivateDashboard> privateDashboardList, List<PrivateDashboardComponent> listaPrivateDashboardComponent,
            List<PrivateReport> pr,
            List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            var lista3aBis = from o in privateDashboardList

                             join
                             q in query_3a(listaPrivateDashboardComponent, pr, p, u, param, IgnoreIds) on o.Id equals q.Dashboard
                             select new PDCwithPRvsPrivateDashboardTable
                             {
                                 Dashboard = q.Dashboard,
                                 Id = q.PrivateReportId,
                                 LastRunDate = q.LastRunDate,
                                 EnterpriseId = q.EnterpriseId,
                                 Name = q.Name,
                                 FolderName = o.FolderName,
                                 LastModifiedById = o.LastModifiedById,
                                 Title = o.Title

                             };

            this.lista3aBis = lista3aBis.ToList();

            return this.lista3aBis;
        }

        private List<PublicDashboardComponentWithPrivateReports> query3b(List<PublicDashboardComponent> publicDashboardComponentsList, List<PrivateReport> pr, List<People> p, List<User> u, int param, List<String> IgnoreIds) {

            List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> drQuery3 = this.query3(pr, p, u, param, IgnoreIds);

            var lista3b = from o in drQuery3
                          join
                          q in publicDashboardComponentsList on o.ExtractPrivateReports_ID equals q.CustomReportId
                          select new PublicDashboardComponentWithPrivateReports
                          {
                              Dashboard = q.DashboardId,
                              LastRunDate = o.LASTRUNDATE,
                              PrivateReportId = o.ExtractPrivateReports_ID,
                              EnterpriseId = o.ENTERPRISE_ID__C,
                              Name = q.Name
                          };

            this.lista3b = lista3b.ToList();

            return this.lista3b;

        }

        public List<PDCwithPRvsPrivateDashboardTable> query3bBis(List<PublicDashboard> publicDashboardList, List<PublicDashboardComponent> publicDashboardComponentsList,
            List<PrivateReport> pr,
            List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            var lista3bBis = from o in publicDashboardList
                             join
                             q in query3b(publicDashboardComponentsList, pr, p, u, param, IgnoreIds) on o.Id equals q.Dashboard
                             select new PDCwithPRvsPrivateDashboardTable
                             {
                                 Dashboard = q.Dashboard,
                                 Id = q.PrivateReportId,
                                 LastRunDate = q.LastRunDate,
                                 EnterpriseId = q.EnterpriseId,
                                 Name = q.Name,
                                 FolderName = o.FolderName,
                                 LastModifiedById = o.LastModifiedById,
                                 Title = o.Title
                             };

            this.lista3bBis = lista3bBis.ToList();

            return this.lista3bBis;
        }

        private List<PDCwithPRvsPrivateDashboardTable> query4a(List<User> userList,
            List<PublicDashboardComponent> publicDashboardComponentList, List<PublicReport> publicReportList,
            List<PublicDashboard> publicDashboardList)
        {
            var query_4a_QueryAux1 = from o in publicDashboardComponentList
                                     join
                                     p in publicReportList on o.CustomReportId equals p.ID
                                     select new
                                     {
                                         dshID = o.DashboardId,
                                         dshcompName = o.Name,
                                         publicReportID = p.ID,
                                         prLastRunDate = p.LASTRUNDATE,
                                     };


            var query_4a_QueryAux2 = from q in query_4a_QueryAux1
                                     join r in publicDashboardList
                                         on q.dshID equals r.Id
                                     select new
                                     {
                                         dashID = q.dshID,
                                         pubReportID = q.publicReportID,
                                         pubrLastRunDate = q.prLastRunDate,
                                         dashCompName = q.dshcompName,
                                         dshFolderName = r.FolderName,
                                         LastModifiedById = r.LastModifiedById,
                                         dshTitle = r.Title,
                                         dhsCreatedBy = r.CreatedById
                                     };



            var lista4a = from s in query_4a_QueryAux2
                          join r in userList on s.dhsCreatedBy equals r.ID
                          select new PDCwithPRvsPrivateDashboardTable
                          {
                              Dashboard = s.dashID,
                              Id = s.pubReportID,
                              LastRunDate = s.pubrLastRunDate,
                              EnterpriseId = r.ENTERPRISE_ID__C,
                              Name = s.dashCompName,
                              FolderName = s.dshFolderName,
                              LastModifiedById = s.LastModifiedById,
                              Title = s.dshTitle
                          };

            this.lista4a = lista4a.ToList();

            return this.lista4a;
        }

        public List<PDCwithPRvsPrivateDashboardTable> query4b(List<PrivateDashboardComponent> privateDashboardCompnentList,
            List<PublicReport> publicReportList, List<User> userList, List<PrivateDashboard> privateDashboardList)
        {
            var query_4b_QueryAux1 = from o in privateDashboardCompnentList
                                     join
                                     p in publicReportList on o.CustomReportId equals p.ID
                                     select new
                                     {
                                         dshID = o.DashboardId,
                                         dshcompName = o.Name,
                                         publicReportID = p.ID,
                                         prLastRunDate = p.LASTRUNDATE,
                                     };


            var query_4b_QueryAux2 = from q in privateDashboardList
                                     join r in userList
                                         on q.CreatedById equals r.ID
                                     select new
                                     {

                                         dshFolderName = q.FolderName,
                                         LastModifiedById = q.LastModifiedById,
                                         dshTitle = q.Title,
                                         dhsCreatedBy = q.CreatedById,
                                         privateDshId = q.Id,
                                         eId = r.ENTERPRISE_ID__C

                                     };



            var lista4b = from s in query_4b_QueryAux1
                          join t in query_4b_QueryAux2 on s.dshID equals t.privateDshId
                          select new PDCwithPRvsPrivateDashboardTable
                          {
                              Dashboard = s.dshID,
                              Id = s.publicReportID,
                              LastRunDate = s.prLastRunDate,
                              EnterpriseId = t.eId,
                              Name = s.dshcompName,
                              FolderName = t.dshFolderName,
                              LastModifiedById = t.LastModifiedById,
                              Title = t.dshTitle
                          };

            this.lista4b = lista4b.ToList();

            return this.lista4b;
        }

        public List<InactivePeopleWithPrivateReports> query1a(List<PrivateReport> privateReportList, List<People> p, List<User> u, List<String> IgnoreIds)
        {
            /*
            var q1a = from epr in privateReportList
                      join
                      cp in this.getListaCheckPeople(p, u) on epr.OWNERID equals cp.Mms_user_c
                      where cp.EmploymentStatus.Equals("Withdrawn") || cp.EmploymentStatus.Equals("Retiree")
                      && !string.IsNullOrEmpty(epr.OWNERID)
                      select new InactivePeopleWithPrivateReports
                      {
                          EMPLOYMENT_STATUS__CS__C = cp.EmploymentStatus,
                          LASTLOGINDATE = cp.LastLoginDate,
                          CheckPeople_ID = cp.PeopleKey_c,
                          ENTERPRISE_id__C = cp.EnterpriseID_c,
                          ISACTIVE = cp.IsActve,
                          NAME = epr.NAME,
                          LASTRUNDATE = epr.LASTRUNDATE,
                          ExtractPrivateRepoerts_ID = epr.ID,
                          FOLDERNAME = epr.FOLDERNAME,
                          LASTMODIFIEDBYID = epr.LASTMODIFIEDBYID,
                          MMS_User__C = cp.Mms_user_c
                      };*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter
            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }
          
            var preq1a = from epr in privateReportList
                         join
                         cp in this.getListaCheckPeople(p, u) on epr.OWNERID equals cp.Mms_user_c
                         where cp.EmploymentStatus.Equals("Withdrawn") || cp.EmploymentStatus.Equals("Retiree")
                         && !string.IsNullOrEmpty(epr.OWNERID)
                         select new InactivePeopleWithPrivateReports
                         {
                             EMPLOYMENT_STATUS__CS__C = cp.EmploymentStatus,
                             LASTLOGINDATE = cp.LastLoginDate,
                             CheckPeople_ID = cp.PeopleKey_c,
                             ENTERPRISE_id__C = cp.EnterpriseID_c,
                             ISACTIVE = cp.IsActve,
                             NAME = epr.NAME,
                             LASTRUNDATE = epr.LASTRUNDATE,
                             ExtractPrivateRepoerts_ID = epr.ID,
                             FOLDERNAME = epr.FOLDERNAME,
                             LASTMODIFIEDBYID = epr.LASTMODIFIEDBYID,
                             MMS_User__C = cp.Mms_user_c
                         };

            List<String> preq1aid = (from q in preq1a
                                     select q.ExtractPrivateRepoerts_ID).ToList();

            List<string> q1aid = (preq1aid.Except(IgnoreIds)).ToList();

            List<IgnoreId> q1aAccounts = (from q in q1aid
                                      let item = new IgnoreId
                                      {
                                          accounts = q
                                      }
                                      select item).ToList();

            var q1a = (from r in preq1a
                                                          join cr in q1aAccounts
                                                          on r.ExtractPrivateRepoerts_ID equals cr.accounts
                                                          select new InactivePeopleWithPrivateReports
                                                          {
                                                              EMPLOYMENT_STATUS__CS__C = r.EMPLOYMENT_STATUS__CS__C,
                                                              LASTLOGINDATE = r.LASTLOGINDATE,
                                                              CheckPeople_ID = r.CheckPeople_ID,
                                                              ENTERPRISE_id__C = r.ENTERPRISE_id__C,
                                                              ISACTIVE = r.ISACTIVE,
                                                              NAME = r.NAME,
                                                              LASTRUNDATE = r.LASTRUNDATE,
                                                              ExtractPrivateRepoerts_ID = r.ExtractPrivateRepoerts_ID,
                                                              FOLDERNAME = r.FOLDERNAME,
                                                              LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                                                              MMS_User__C = r.MMS_User__C
                                                          });

            ///Mati: End of modification
            this.InPeWPriRep = q1a.ToList();   //.take(x)

            return this.InPeWPriRep;

        }

        public List<RetiredOrWithdrawnPeopleWithPrivateReports> query1b(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            DateTime daysCalculation = today.AddDays(-param);
            /*
            var q = from privateReports in privateReportList
                    join
                    checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                    where checkPeople.EmploymentStatus.Equals("Inactive") && checkPeople.LastLoginDate < daysCalculation
                    || checkPeople.EmploymentStatus.Equals("Inactive") && privateReports.LASTRUNDATE < daysCalculation
                    && !string.IsNullOrEmpty(privateReports.OWNERID)
                    select new RetiredOrWithdrawnPeopleWithPrivateReports
                    {
                        EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus,
                        LASTLOGINDATE = checkPeople.LastLoginDate,
                        CheckPeople_ID = checkPeople.PeopleKey_c,
                        ENTERPRISE_ID__C = checkPeople.EnterpriseID_c,
                        ISACTIVE = checkPeople.IsActve,
                        NAME = privateReports.NAME,
                        LASTRUNDATE = privateReports.LASTRUNDATE,
                        ExtractPrivateReports_ID = privateReports.ID,
                        FOLDERNAME = privateReports.FOLDERNAME,
                        LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID,
                        MMS_USER__C = checkPeople.Mms_user_c
                    };*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter
            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var preq = from privateReports in privateReportList
                    join
                    checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                    where checkPeople.EmploymentStatus.Equals("Inactive") && checkPeople.LastLoginDate < daysCalculation
                    || checkPeople.EmploymentStatus.Equals("Inactive") && privateReports.LASTRUNDATE < daysCalculation
                    && !string.IsNullOrEmpty(privateReports.OWNERID)
                    select new RetiredOrWithdrawnPeopleWithPrivateReports
                    {
                        EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus,
                        LASTLOGINDATE = checkPeople.LastLoginDate,
                        CheckPeople_ID = checkPeople.PeopleKey_c,
                        ENTERPRISE_ID__C = checkPeople.EnterpriseID_c,
                        ISACTIVE = checkPeople.IsActve,
                        NAME = privateReports.NAME,
                        LASTRUNDATE = privateReports.LASTRUNDATE,
                        ExtractPrivateReports_ID = privateReports.ID,
                        FOLDERNAME = privateReports.FOLDERNAME,
                        LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID,
                        MMS_USER__C = checkPeople.Mms_user_c
                    };

            List<String> preqid = (from qb in preq
                                   select qb.ExtractPrivateReports_ID).ToList();

            List<string> qid = (preqid.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from qb in qid
                                        let item = new IgnoreId
                                          {
                                              accounts = qb
                                          }
                                          select item).ToList();

            var q = (from r in preq
                                                          join cr in qAccounts
                                                          on r.ExtractPrivateReports_ID equals cr.accounts
                                                          select new RetiredOrWithdrawnPeopleWithPrivateReports
                                                          {
                                                              EMPLOYMENT_STATUS__C = r.EMPLOYMENT_STATUS__C,
                                                              LASTLOGINDATE = r.LASTLOGINDATE,
                                                              CheckPeople_ID = r.CheckPeople_ID,
                                                              ENTERPRISE_ID__C = r.ENTERPRISE_ID__C,
                                                              ISACTIVE = r.ISACTIVE,
                                                              NAME = r.NAME,
                                                              LASTRUNDATE = r.LASTRUNDATE,
                                                              ExtractPrivateReports_ID = r.ExtractPrivateReports_ID,
                                                              FOLDERNAME = r.FOLDERNAME,
                                                              LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                                                              MMS_USER__C = r.MMS_USER__C
                                                          });
            ///Mati: End of modification

            this.ReOrWithdPeoWPR = q.ToList();

            return this.ReOrWithdPeoWPR;
        }

        public List<RetiredOrWithdrawnPeopleWithPrivateReports> query1b_deletion(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            DateTime daysCalculation = today.AddDays(-param);
            /*
            var q = from privateReports in privateReportList
                    join
                    checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                    where checkPeople.EmploymentStatus.Equals("Inactive") && checkPeople.LastLoginDate < daysCalculation
                    || checkPeople.EmploymentStatus.Equals("Inactive") && privateReports.LASTRUNDATE < daysCalculation
                    && !string.IsNullOrEmpty(privateReports.OWNERID)
                    select new RetiredOrWithdrawnPeopleWithPrivateReports
                    {
                        EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus,
                        LASTLOGINDATE = checkPeople.LastLoginDate,
                        CheckPeople_ID = checkPeople.PeopleKey_c,
                        ENTERPRISE_ID__C = checkPeople.EnterpriseID_c,
                        ISACTIVE = checkPeople.IsActve,
                        NAME = privateReports.NAME,
                        LASTRUNDATE = privateReports.LASTRUNDATE,
                        ExtractPrivateReports_ID = privateReports.ID,
                        FOLDERNAME = privateReports.FOLDERNAME,
                        LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID,
                        MMS_USER__C = checkPeople.Mms_user_c
                    };*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter

            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var preq1bdeletion = from privateReports in privateReportList
                    join
                    checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                    where checkPeople.EmploymentStatus.Equals("Inactive") && checkPeople.LastLoginDate < daysCalculation
                    || checkPeople.EmploymentStatus.Equals("Inactive") && privateReports.LASTRUNDATE < daysCalculation
                    && !string.IsNullOrEmpty(privateReports.OWNERID)
                    select new RetiredOrWithdrawnPeopleWithPrivateReports
                    {
                        EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus,
                        LASTLOGINDATE = checkPeople.LastLoginDate,
                        CheckPeople_ID = checkPeople.PeopleKey_c,
                        ENTERPRISE_ID__C = checkPeople.EnterpriseID_c,
                        ISACTIVE = checkPeople.IsActve,
                        NAME = privateReports.NAME,
                        LASTRUNDATE = privateReports.LASTRUNDATE,
                        ExtractPrivateReports_ID = privateReports.ID,
                        FOLDERNAME = privateReports.FOLDERNAME,
                        LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID,
                        MMS_USER__C = checkPeople.Mms_user_c
                    };

            List<String> preqiddel = (from qb in preq1bdeletion
                                   select qb.ExtractPrivateReports_ID).ToList();

            List<string> qidbdel = (preqiddel.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from qbd in qidbdel
                                        let item = new IgnoreId
                                        {
                                            accounts = qbd
                                        }
                                        select item).ToList();

            var q = (from r in preq1bdeletion
                                                                  join cr in qAccounts
                                                                  on r.ExtractPrivateReports_ID equals cr.accounts
                                                                  select new RetiredOrWithdrawnPeopleWithPrivateReports
                                                                  {
                                                                      EMPLOYMENT_STATUS__C = r.EMPLOYMENT_STATUS__C,
                                                                      LASTLOGINDATE = r.LASTLOGINDATE,
                                                                      CheckPeople_ID = r.CheckPeople_ID,
                                                                      ENTERPRISE_ID__C = r.ENTERPRISE_ID__C,
                                                                      ISACTIVE = r.ISACTIVE,
                                                                      NAME = r.NAME,
                                                                      LASTRUNDATE = r.LASTRUNDATE,
                                                                      ExtractPrivateReports_ID = r.ExtractPrivateReports_ID,
                                                                      FOLDERNAME = r.FOLDERNAME,
                                                                      LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                                                                      MMS_USER__C = r.MMS_USER__C
                                                                  });
            ///Mati: End of modification

            this.ReOrWithdPeoWPR_deletion = q.ToList();

            return this.ReOrWithdPeoWPR_deletion;
        }

        public List<InactivePeopleWithreportsNotRunInMoreThan180Days> query2(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            /*List<String> query_2 = (from privateReports in listaPrivateReports
                                         join
                                         checkPeople in checkPeopleRecords on privateReports.OWNERID equals checkPeople.MMS_USER__C
                                         where checkPeople.ISACTIVE.Equals("0") && (today - checkPeople.LASTLOGINDATE).TotalDays < 166
                                         && !string.IsNullOrEmpty(privateReports.OWNERID)
                                         select (checkPeople.EMPLOYMENT_STATUS__C)).ToList() ;*/
            DateTime daysCalculation = today.AddDays(-param);
            /*
            var query_2 = (from privateReports in privateReportList
                           join
                           checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (!string.IsNullOrEmpty(checkPeople.IsActve) && checkPeople.IsActve.Equals("0")) && checkPeople.LastLoginDate < daysCalculation
                                      && !string.IsNullOrEmpty(privateReports.OWNERID)
                           select new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : checkPeople.IsActve,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty(new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = "",
                               LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               CheckPeople_ID = "",
                               ENTERPRISE_ID__C = "",
                               ISACTIVE = "",
                               NAME = "",
                               LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               ExtractPrivateReports_ID = "",
                               FOLDERNAME = "",
                               LASTMODIFIEDBYID = "",
                               MMS_USER__C = ""
                           }); // leftjoin
*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter

            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var prequery_2 = (from privateReports in privateReportList
                           join
                           checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (!string.IsNullOrEmpty(checkPeople.IsActve) && checkPeople.IsActve.Equals("0")) && checkPeople.LastLoginDate < daysCalculation
                                      && !string.IsNullOrEmpty(privateReports.OWNERID)
                           select new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : checkPeople.IsActve,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty(new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = "",
                               LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               CheckPeople_ID = "",
                               ENTERPRISE_ID__C = "",
                               ISACTIVE = "",
                               NAME = "",
                               LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               ExtractPrivateReports_ID = "",
                               FOLDERNAME = "",
                               LASTMODIFIEDBYID = "",
                               MMS_USER__C = ""
                           }); // leftjoin

            List<String> preq2 = (from pq2 in prequery_2
                                  select pq2.ExtractPrivateReports_ID).ToList();

            List<string> q2 = (preq2.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from q2a in q2
                                        let item = new IgnoreId
                                        {
                                            accounts = q2a
                                        }
                                        select item).ToList();

            var query_2 = (from r in prequery_2
                                                                        join cr in qAccounts
                                                                  on r.ExtractPrivateReports_ID equals cr.accounts
                                                                  select new InactivePeopleWithreportsNotRunInMoreThan180Days
                                                                  {
                                                                      EMPLOYMENT_STATUS__C = r.EMPLOYMENT_STATUS__C,
                                                                      LASTLOGINDATE = r.LASTLOGINDATE,
                                                                      CheckPeople_ID = r.CheckPeople_ID,
                                                                      ENTERPRISE_ID__C = r.ENTERPRISE_ID__C,
                                                                      ISACTIVE = r.ISACTIVE,
                                                                      NAME = r.NAME,
                                                                      LASTRUNDATE = r.LASTRUNDATE,
                                                                      ExtractPrivateReports_ID = r.ExtractPrivateReports_ID,
                                                                      FOLDERNAME = r.FOLDERNAME,
                                                                      LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                                                                      MMS_USER__C = r.MMS_USER__C
                                                                  }).DefaultIfEmpty(new InactivePeopleWithreportsNotRunInMoreThan180Days
                                                                  {
                                                                      EMPLOYMENT_STATUS__C = "",
                                                                      LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                                                                      CheckPeople_ID = "",
                                                                      ENTERPRISE_ID__C = "",
                                                                      ISACTIVE = "",
                                                                      NAME = "",
                                                                      LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                                                                      ExtractPrivateReports_ID = "",
                                                                      FOLDERNAME = "",
                                                                      LASTMODIFIEDBYID = "",
                                                                      MMS_USER__C = ""
                                                                  }); // leftjoin
            ///Mati: End of modification

            this.inPeoWReNoRunIn180 = query_2.ToList();


            return this.inPeoWReNoRunIn180;
        }

        public List<InactivePeopleWithreportsNotRunInMoreThan180Days> query2_delete(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            /*List<String> query_2 = (from privateReports in listaPrivateReports
                                         join
                                         checkPeople in checkPeopleRecords on privateReports.OWNERID equals checkPeople.MMS_USER__C
                                         where checkPeople.ISACTIVE.Equals("0") && (today - checkPeople.LASTLOGINDATE).TotalDays < 166
                                         && !string.IsNullOrEmpty(privateReports.OWNERID)
                                         select (checkPeople.EMPLOYMENT_STATUS__C)).ToList() ;*/
            DateTime daysCalculation = today.AddDays(-param);
            /*
            var query_2 = (from privateReports in privateReportList
                           join
                           checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (!string.IsNullOrEmpty(checkPeople.IsActve) && checkPeople.IsActve.Equals("0")) && checkPeople.LastLoginDate < daysCalculation
                                      && !string.IsNullOrEmpty(privateReports.OWNERID)
                           select new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : checkPeople.IsActve,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty(new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = "",
                               LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               CheckPeople_ID = "",
                               ENTERPRISE_ID__C = "",
                               ISACTIVE = "",
                               NAME = "",
                               LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               ExtractPrivateReports_ID = "",
                               FOLDERNAME = "",
                               LASTMODIFIEDBYID = "",
                               MMS_USER__C = ""
                           }); // leftjoin
                           */
            ///Mati: Code above commented, Code below to introduce Ignore List and filter

            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var prequery_2 = (from privateReports in privateReportList
                           join
                           checkPeople in this.getListaCheckPeople(p, u) on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (!string.IsNullOrEmpty(checkPeople.IsActve) && checkPeople.IsActve.Equals("0")) && checkPeople.LastLoginDate < daysCalculation
                                      && !string.IsNullOrEmpty(privateReports.OWNERID)
                           select new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : checkPeople.IsActve,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty(new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = "",
                               LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               CheckPeople_ID = "",
                               ENTERPRISE_ID__C = "",
                               ISACTIVE = "",
                               NAME = "",
                               LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               ExtractPrivateReports_ID = "",
                               FOLDERNAME = "",
                               LASTMODIFIEDBYID = "",
                               MMS_USER__C = ""
                           }); // leftjoin

            List<String> preq2 = (from pq2 in prequery_2
                                  select pq2.ExtractPrivateReports_ID).ToList();

            List<string> q2 = (preq2.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from q2a in q2
                                        let item = new IgnoreId
                                        {
                                            accounts = q2a
                                        }
                                        select item).ToList();

            var query_2 = (from r in prequery_2
                           join cr in qAccounts
                        on r.ExtractPrivateReports_ID equals cr.accounts
                           select new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = r.EMPLOYMENT_STATUS__C,
                               LASTLOGINDATE = r.LASTLOGINDATE,
                               CheckPeople_ID = r.CheckPeople_ID,
                               ENTERPRISE_ID__C = r.ENTERPRISE_ID__C,
                               ISACTIVE = r.ISACTIVE,
                               NAME = r.NAME,
                               LASTRUNDATE = r.LASTRUNDATE,
                               ExtractPrivateReports_ID = r.ExtractPrivateReports_ID,
                               FOLDERNAME = r.FOLDERNAME,
                               LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                               MMS_USER__C = r.MMS_USER__C
                           }).DefaultIfEmpty(new InactivePeopleWithreportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = "",
                               LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               CheckPeople_ID = "",
                               ENTERPRISE_ID__C = "",
                               ISACTIVE = "",
                               NAME = "",
                               LASTRUNDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                               ExtractPrivateReports_ID = "",
                               FOLDERNAME = "",
                               LASTMODIFIEDBYID = "",
                               MMS_USER__C = ""
                           }); // leftjoin



            this.inPeoWReNoRunIn180_deletion = query_2.ToList();


            return this.inPeoWReNoRunIn180_deletion;
        }

        public List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> query3(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {

            //build a Linq Join to retrieve reports associated with people that are active and Last Login day it's older than 180 days.

            DateTime daysCalculation = today.AddDays(-param);

            List<CheckPeople> cp = this.getListaCheckPeople(p, u);


            // Console.WriteLine("result : " + );

            /*
            var query_3 = (from privateReports in privateReportList
                           join
                            checkPeople in cp on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE < daysCalculation)) ||
                            (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE == null)) &&
                            (privateReports.CREATEDDATE < daysCalculation)))
                            && (!string.IsNullOrEmpty(privateReports.OWNERID))
                           select new ActivePeopleWithPrivateReportsNotRunInMoreThan180Days
                           {

                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               // CREATEDDATE = privateReports.CREATEDDATE,
                               // LASTMODIFIEDBY = (from check in cp where check.Mms_user_c == privateReports.LASTMODIFIEDBYID select check.Name_user),
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : privateReports.NAME,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty();*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter
            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var prequery_3 = (from privateReports in privateReportList
                           join
                            checkPeople in cp on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE < daysCalculation)) ||
                            (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE == null)) &&
                            (privateReports.CREATEDDATE < daysCalculation)))
                            && (!string.IsNullOrEmpty(privateReports.OWNERID))
                           select new ActivePeopleWithPrivateReportsNotRunInMoreThan180Days
                           {

                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               // CREATEDDATE = privateReports.CREATEDDATE,
                               // LASTMODIFIEDBY = (from check in cp where check.Mms_user_c == privateReports.LASTMODIFIEDBYID select check.Name_user),
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : privateReports.NAME,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty();

            List<String> preq3 = (from pq3 in prequery_3
                                  select pq3.ExtractPrivateReports_ID).ToList();

            List<string> q3 = (preq3.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from q3a in q3
                                        let item = new IgnoreId
                                        {
                                            accounts = q3a
                                        }
                                        select item).ToList();

            var query_3 = (from r in prequery_3
                           join cr in qAccounts
                        on r.ExtractPrivateReports_ID equals cr.accounts
                           select new ActivePeopleWithPrivateReportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = r.EMPLOYMENT_STATUS__C,
                               LASTRUNDATE = r.LASTRUNDATE,
                               CheckPeople_ID = r.CheckPeople_ID,
                               ENTERPRISE_ID__C = r.ENTERPRISE_ID__C,
                               ISACTIVE = r.ISACTIVE,
                               NAME = r.NAME,
                               LASTLOGINDATE = r.LASTLOGINDATE,
                               ExtractPrivateReports_ID = r.ExtractPrivateReports_ID,
                               FOLDERNAME = r.FOLDERNAME,
                               LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                               MMS_USER__C = r.MMS_USER__C
                           }).DefaultIfEmpty();

            this.ActPeoWPRNotRun180 = query_3.ToList();

            return this.ActPeoWPRNotRun180;

        }
        public List<ActivePeopleWithPrivateReportsNotRunInMoreThan180Days> query3_deletion(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {

            //build a Linq Join to retrieve reports associated with people that are active and Last Login day it's older than 180 days.

            DateTime daysCalculation = today.AddDays(-param);

            List<CheckPeople> cp = this.getListaCheckPeople(p, u);


            // Console.WriteLine("result : " + );

            /*
            var query_3 = (from privateReports in privateReportList
                           join
                            checkPeople in cp on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE < daysCalculation)) ||
                            (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE == null)) &&
                            (privateReports.CREATEDDATE < daysCalculation)))
                            && (!string.IsNullOrEmpty(privateReports.OWNERID))
                           select new ActivePeopleWithPrivateReportsNotRunInMoreThan180Days
                           {

                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               // CREATEDDATE = privateReports.CREATEDDATE,
                               // LASTMODIFIEDBY = (from check in cp where check.Mms_user_c == privateReports.LASTMODIFIEDBYID select check.Name_user),
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : privateReports.NAME,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty();*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter
            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var prequery_3 = (from privateReports in privateReportList
                           join
                            checkPeople in cp on privateReports.OWNERID equals checkPeople.Mms_user_c
                           where (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE < daysCalculation)) ||
                            (((checkPeople.IsActve.Equals("true")) && (privateReports.LASTRUNDATE == null)) &&
                            (privateReports.CREATEDDATE < daysCalculation)))
                            && (!string.IsNullOrEmpty(privateReports.OWNERID))
                           select new ActivePeopleWithPrivateReportsNotRunInMoreThan180Days
                           {

                               EMPLOYMENT_STATUS__C = checkPeople.EmploymentStatus == null ? "no value" : checkPeople.EmploymentStatus,
                               LASTRUNDATE = privateReports.LASTRUNDATE == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : privateReports.LASTRUNDATE,
                               // CREATEDDATE = privateReports.CREATEDDATE,
                               // LASTMODIFIEDBY = (from check in cp where check.Mms_user_c == privateReports.LASTMODIFIEDBYID select check.Name_user),
                               CheckPeople_ID = checkPeople.PeopleKey_c == null ? "no value" : checkPeople.PeopleKey_c,
                               ENTERPRISE_ID__C = checkPeople.EnterpriseID_c == null ? "no value" : checkPeople.EnterpriseID_c,
                               ISACTIVE = checkPeople.IsActve == null ? "no value" : checkPeople.IsActve,
                               NAME = privateReports.NAME == null ? "no value" : privateReports.NAME,
                               LASTLOGINDATE = checkPeople.LastLoginDate == null ? DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : checkPeople.LastLoginDate,
                               ExtractPrivateReports_ID = privateReports.ID == null ? "no value" : privateReports.ID,
                               FOLDERNAME = privateReports.FOLDERNAME == null ? "no value" : privateReports.FOLDERNAME,
                               LASTMODIFIEDBYID = privateReports.LASTMODIFIEDBYID == null ? "no value" : privateReports.LASTMODIFIEDBYID,
                               MMS_USER__C = checkPeople.Mms_user_c == null ? "no value" : checkPeople.Mms_user_c
                           }).DefaultIfEmpty();

            List<String> preq3 = (from pq3 in prequery_3
                                  select pq3.ExtractPrivateReports_ID).ToList();

            List<string> q3 = (preq3.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from q3a in q3
                                        let item = new IgnoreId
                                        {
                                            accounts = q3a
                                        }
                                        select item).ToList();

            var query_3 = (from r in prequery_3
                           join cr in qAccounts
                        on r.ExtractPrivateReports_ID equals cr.accounts
                           select new ActivePeopleWithPrivateReportsNotRunInMoreThan180Days
                           {
                               EMPLOYMENT_STATUS__C = r.EMPLOYMENT_STATUS__C,
                               LASTRUNDATE = r.LASTRUNDATE,
                               CheckPeople_ID = r.CheckPeople_ID,
                               ENTERPRISE_ID__C = r.ENTERPRISE_ID__C,
                               ISACTIVE = r.ISACTIVE,
                               NAME = r.NAME,
                               LASTLOGINDATE = r.LASTLOGINDATE,
                               ExtractPrivateReports_ID = r.ExtractPrivateReports_ID,
                               FOLDERNAME = r.FOLDERNAME,
                               LASTMODIFIEDBYID = r.LASTMODIFIEDBYID,
                               MMS_USER__C = r.MMS_USER__C
                           }).DefaultIfEmpty();


            this.ActPeoWPRNotRun180_deletion = query_3.ToList();

            return this.ActPeoWPRNotRun180_deletion;

        }

        public List<PublicReportsNotRunInMoreThan90Days> query4(List<PublicReport> publicReportList, List<User> userList, List<String> IgnoreIds)
        {
            //build a Linq Join to retrieve reports associated with people that are inactive and Last Login day it's older than 180 days.
            /*
            var query_4 = from publicReport in publicReportList
                          join
                          u in userList on publicReport.CREATEDBYID equals u.ID
                          where !string.IsNullOrEmpty(publicReport.OWNERID)
                          select new PublicReportsNotRunInMoreThan90Days
                          {
                              Id_PublicReport = publicReport.ID,
                              FolderName = publicReport.FOLDERNAME,
                              LastModifiedById = publicReport.LASTMODIFIEDBYID,
                              Name = publicReport.NAME,
                              LastRunDate = publicReport.LASTRUNDATE,
                              EnterpriseID = u.ENTERPRISE_ID__C
                          };*/

            ///Mati: Code above commented, Code below to introduce Ignore List and filter
            if (IgnoreIds == null)
            {
                IgnoreIds = new List<string>() { "asd" };
            }

            var prequery_4 = from publicReport in publicReportList
                          join
                          u in userList on publicReport.CREATEDBYID equals u.ID
                          where !string.IsNullOrEmpty(publicReport.OWNERID)
                          select new PublicReportsNotRunInMoreThan90Days
                          {
                              Id_PublicReport = publicReport.ID,
                              FolderName = publicReport.FOLDERNAME,
                              LastModifiedById = publicReport.LASTMODIFIEDBYID,
                              Name = publicReport.NAME,
                              LastRunDate = publicReport.LASTRUNDATE,
                              EnterpriseID = u.ENTERPRISE_ID__C
                          };

            List<String> preq4 = (from pq4 in prequery_4
                                  select pq4.Id_PublicReport).ToList();

            List<string> q4 = (preq4.Except(IgnoreIds)).ToList();

            List<IgnoreId> qAccounts = (from q4a in q4
                                        let item = new IgnoreId
                                        {
                                            accounts = q4a
                                        }
                                        select item).ToList();

            var query_4 = (from r in prequery_4
                           join cr in qAccounts
                        on r.Id_PublicReport equals cr.accounts
                           select new PublicReportsNotRunInMoreThan90Days
                           {
                               Id_PublicReport = r.Id_PublicReport,
                               FolderName = r.FolderName,
                               LastModifiedById = r.LastModifiedById,
                               Name = r.Name,
                               LastRunDate = r.LastRunDate,
                               EnterpriseID = r.EnterpriseID
                           });



            this.PubReNotRun90 = query_4.ToList();

            return this.PubReNotRun90;
        }


        public List<PDCwithPRvsPrivateDashboardTable> query5(List<User> userList,
            List<PublicDashboardComponent> publicDashboardComponentList, List<PublicReport> publicReportList,
            List<PublicDashboard> publicDashboardList, List<PrivateDashboardComponent> privateDashboardComponentList, List<PrivateDashboard> privateDashboardList,
            List<PrivateReport> pr,
            List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            //build a Linq UNION queries 3a bis, 3b bis, 4a, 4b 

            var query_5_3aBis = (query3aBis(privateDashboardList, privateDashboardComponentList, pr, p, u, param, IgnoreIds).Select(z => new { z.Dashboard, z.Id, z.LastRunDate, z.EnterpriseId, z.Name, z.FolderName, z.LastModifiedById, z.Title })).ToList();
            var query_5_3bBis = (query3bBis(publicDashboardList, publicDashboardComponentList, pr, p, u, param, IgnoreIds).Select(w => new { w.Dashboard, w.Id, w.LastRunDate, w.EnterpriseId, w.Name, w.FolderName, w.LastModifiedById, w.Title })).ToList();
            var query_5_4a = (query4a(userList, publicDashboardComponentList, publicReportList, publicDashboardList).Select(t => new { t.Dashboard, t.Id, t.LastRunDate, t.EnterpriseId, t.Name, t.FolderName, t.LastModifiedById, t.Title })).ToList();
            var query_5_4b = (query4b(privateDashboardComponentList, publicReportList, userList, privateDashboardList).Select(t => new { t.Dashboard, t.Id, t.LastRunDate, t.EnterpriseId, t.Name, t.FolderName, t.LastModifiedById, t.Title })).ToList();

            var query_5_Union_54a_and_54b = query_5_4b.Union(query_5_4a).Distinct().ToList(); // added distinct due to some duplicates related with dashboard components 1-6-2020

            var query_5_3aBis_and_3bBis = query_5_3aBis.Union(query_5_3bBis).Distinct().ToList();

            var finalQuery = query_5_3aBis_and_3bBis.Union(query_5_Union_54a_and_54b).Distinct().ToList();

            var finalQuery2 = from f in finalQuery
                              select new PDCwithPRvsPrivateDashboardTable
                              {
                                  Dashboard = f.Dashboard,
                                  Id = f.Id,
                                  LastRunDate = f.LastRunDate,
                                  EnterpriseId = f.EnterpriseId,
                                  Name = f.Name,
                                  FolderName = f.FolderName,
                                  LastModifiedById = f.LastModifiedById,
                                  Title = f.Title

                              };


            this.pubAndPrivReports = finalQuery2.ToList();




            return this.pubAndPrivReports;

        }

        public List<PDCwithPRvsPrivateDashboardTable> query5_deletion(List<PublicDashboardComponent> publicDashboardComponentList, List<PublicReport> publicReportList,
            List<PublicDashboard> publicDashboardList, List<PrivateDashboardComponent> privateDashboardComponentList, List<PrivateDashboard> privateDashboardList,
            List<PrivateReport> pr,
            List<People> p, List<User> u, int privateParam, int publicParam, List<String> IgnoreIds)
        {
            //build a Linq UNION queries 3a bis, 3b bis, 4a, 4b 

            var query_5_3aBis = (query3aBis(privateDashboardList, privateDashboardComponentList, pr, p, u, privateParam, IgnoreIds).Select(z => new { z.Dashboard, z.Id, z.LastRunDate, z.EnterpriseId, z.Name, z.FolderName, z.LastModifiedById, z.Title })).ToList();
            var query_5_3bBis = (query3bBis(publicDashboardList, publicDashboardComponentList, pr, p, u, privateParam, IgnoreIds).Select(w => new { w.Dashboard, w.Id, w.LastRunDate, w.EnterpriseId, w.Name, w.FolderName, w.LastModifiedById, w.Title })).ToList();
            var query_5_4a = (query4a(u, publicDashboardComponentList, publicReportList, publicDashboardList).Select(t => new { t.Dashboard, t.Id, t.LastRunDate, t.EnterpriseId, t.Name, t.FolderName, t.LastModifiedById, t.Title })).ToList();
            var query_5_4b = (query4b(privateDashboardComponentList, publicReportList, u, privateDashboardList).Select(t => new { t.Dashboard, t.Id, t.LastRunDate, t.EnterpriseId, t.Name, t.FolderName, t.LastModifiedById, t.Title })).ToList();

            var query_5_Union_54a_and_54b = query_5_4b.Union(query_5_4a).ToList();

            var query_5_3aBis_and_3bBis = query_5_3aBis.Union(query_5_3bBis).ToList();

            var finalQuery = query_5_3aBis_and_3bBis.Union(query_5_Union_54a_and_54b).ToList();

            var finalQuery2 = from f in finalQuery
                              select new PDCwithPRvsPrivateDashboardTable
                              {
                                  Dashboard = f.Dashboard,
                                  Id = f.Id,
                                  LastRunDate = f.LastRunDate,
                                  EnterpriseId = f.EnterpriseId,
                                  Name = f.Name,
                                  FolderName = f.FolderName,
                                  LastModifiedById = f.LastModifiedById,
                                  Title = f.Title

                              };


            this.pubAndPrivReports = finalQuery2.ToList(); // method .take(10)




            return this.pubAndPrivReports;

        }





        public List<String> queryID1aDeletePrivateReports(List<PrivateReport> privateReportList, List<People> p, List<User> u)
        {
            /*
            var privateReportsID1a = from epr in privateReportList
                                 join
                                 cp in this.getListaCheckPeople(p,u) on epr.OWNERID equals cp.Mms_user_c
                                 where cp.EmploymentStatus.Equals("Withdrawn") || cp.EmploymentStatus.Equals("Retiree")
                                 && !string.IsNullOrEmpty(epr.OWNERID)
                                 select (epr.ID);*/


            var query_1a_deletion_PrivateReportID = from epr in privateReportList
                                                    join
                                                    cp in this.getListaCheckPeople(p, u) on epr.OWNERID equals cp.Mms_user_c
                                                    where cp.EmploymentStatus.Equals("Withdrawn") || cp.EmploymentStatus.Equals("Retiree")
                                                    && !string.IsNullOrEmpty(epr.OWNERID)
                                                    select new
                                                    {
                                                        EXTRATPRIVATEREPORT_ID_1a = epr.ID
                                                    };

            this.query1aDeletionPrivateReport = query_1a_deletion_PrivateReportID.Select(x => x.EXTRATPRIVATEREPORT_ID_1a.ToString()).ToList();


            return this.query1aDeletionPrivateReport;
        }

        public List<String> queryID1aDeletePrivateDashboard(List<PrivateReport> privateReportList, List<PrivateDashboardComponent> privateDashboardComponentList,
            List<PrivateDashboard> privateDashboardList, List<People> p, List<User> u)
        {

            var query_1a_deletion_PrivateReportID = from epr in privateReportList
                                                    join
                                                    cp in this.getListaCheckPeople(p, u) on epr.OWNERID equals cp.Mms_user_c
                                                    where cp.EmploymentStatus.Equals("Withdrawn") || cp.EmploymentStatus.Equals("Retiree")
                                                    && !string.IsNullOrEmpty(epr.OWNERID)
                                                    select new
                                                    {
                                                        EXTRATPRIVATEREPORT_ID_1a = epr.ID
                                                    };


            // Query to get privateDashboardID associeted with privateReport from Inactive people
            var query_1a_deletion_Privatedashboard_Aux = from firstQuery in (from pr in query_1a_deletion_PrivateReportID
                                                                             join pdc in privateDashboardComponentList on pr.EXTRATPRIVATEREPORT_ID_1a equals pdc.CustomReportId
                                                                             select new
                                                                             {

                                                                                 dshID = pdc.DashboardId

                                                                             })
                                                         join pdl in privateDashboardList on firstQuery.dshID equals pdl.Id
                                                         select new
                                                         {

                                                             privateDash_ID = pdl.Id

                                                         };

            this.query1aDeletionPrivatedashboard = query_1a_deletion_Privatedashboard_Aux.Select(x => x.ToString()).ToList();

            return this.query1aDeletionPrivatedashboard;
        }

        public List<String> queryID1aDeletePublicDashboard(List<PrivateReport> privateReportList, List<PublicDashboard> publicDashboardList,
            List<PublicDashboardComponent> publicDashboardComponentList, List<People> p, List<User> u)
        {
            var query_1a_deletion_PrivateReportID = from epr in privateReportList
                                                    join
                                                    cp in this.getListaCheckPeople(p, u) on epr.OWNERID equals cp.Mms_user_c
                                                    where cp.EmploymentStatus.Equals("Withdrawn") || cp.EmploymentStatus.Equals("Retiree")
                                                    && !string.IsNullOrEmpty(epr.OWNERID)
                                                    select new
                                                    {
                                                        EXTRATPRIVATEREPORT_ID_1a = epr.ID
                                                    };


            //Query to track dashboard ID from Dsh component associated, I use Anonymous type to track the correct fields.

            var query_1a_deletion_Publicdashboard_Aux = from secondQuery in (from pr in query_1a_deletion_PrivateReportID
                                                                             join pdc in publicDashboardComponentList on pr.EXTRATPRIVATEREPORT_ID_1a equals pdc.CustomReportId
                                                                             select new
                                                                             {
                                                                                 dshID = pdc.DashboardId
                                                                             })
                                                        join pdl in publicDashboardList on secondQuery.dshID equals pdl.Id
                                                        select new
                                                        {
                                                            publicDshID = pdl.Id
                                                        };

            this.query1aDeletionPublicdashboard = query_1a_deletion_Publicdashboard_Aux.Select(x => x.ToString()).ToList();

            return this.query1aDeletionPublicdashboard;
        }

        public List<String> queryID1bDeletePrivateReports(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {


            var query_1b_deletion_PrivateReportID = from q1b in query1b_deletion(privateReportList, p, u, param, IgnoreIds)
                                                    select new
                                                    {
                                                        q1b.ExtractPrivateReports_ID
                                                    };





            this.query1bDeletionPrivateReport = query_1b_deletion_PrivateReportID.Select(x => x.ExtractPrivateReports_ID.ToString()).ToList();


            return this.query1bDeletionPrivateReport;
        }

        public List<String> queryID1bDeletePrivateDashboard(List<PrivateReport> privateReportList, List<PrivateDashboardComponent> privateDashboardComponentList,
            List<PrivateDashboard> privateDashboardList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {

            var query_1b_deletion_PrivateReportID = from q1b in query1b_deletion(privateReportList, p, u, param, IgnoreIds)
                                                    select new
                                                    {
                                                        EXTRATPRIVATEREPORT_ID_1b = q1b.ExtractPrivateReports_ID
                                                    };


            // Query to get privateDashboardID associeted with privateReport from Inactive people
            var query_1b_deletion_Privatedashboard_Aux = from firstQuery in (from pr in query_1b_deletion_PrivateReportID
                                                                             join pdc in privateDashboardComponentList on pr.EXTRATPRIVATEREPORT_ID_1b equals pdc.CustomReportId
                                                                             select new
                                                                             {

                                                                                 dshID = pdc.DashboardId

                                                                             })
                                                         join pdl in privateDashboardList on firstQuery.dshID equals pdl.Id
                                                         select new
                                                         {

                                                             privateDash_ID = pdl.Id

                                                         };

            this.query1bDeletionPrivatedashboard = query_1b_deletion_Privatedashboard_Aux.Select(x => x.privateDash_ID.ToString()).ToList();

            return this.query1bDeletionPrivatedashboard;
        }

        public List<String> queryID1bDeletePublicDashboard(List<PrivateReport> privateReportList, List<PublicDashboard> publicDashboardList,
            List<PublicDashboardComponent> publicDashboardComponentList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            var query_1b_deletion_PrivateReportID = from q1b in query1b_deletion(privateReportList, p, u, param, IgnoreIds)
                                                    select new
                                                    {
                                                        EXTRATPRIVATEREPORT_ID_1b = q1b.ExtractPrivateReports_ID
                                                    };


            //Query to track dashboard ID from Dsh component associated, I use Anonymous type to track the correct fields.

            var query_1b_deletion_Publicdashboard_Aux = from secondQuery in (from pr in query_1b_deletion_PrivateReportID
                                                                             join pdc in publicDashboardComponentList on pr.EXTRATPRIVATEREPORT_ID_1b equals pdc.CustomReportId
                                                                             select new
                                                                             {
                                                                                 dshID = pdc.DashboardId
                                                                             })
                                                        join pdl in publicDashboardList on secondQuery.dshID equals pdl.Id
                                                        select new
                                                        {
                                                            pdl.Id
                                                        };

            this.query1bDeletionPublicdashboard = query_1b_deletion_Publicdashboard_Aux.Select(x => x.Id.ToString()).ToList();

            return this.query1bDeletionPublicdashboard;
        }

        public List<String> queryID2DeletePrivateReports(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {


            var query_2_deletion_PrivateReportID = from q2 in query2_delete(privateReportList, p, u, param, IgnoreIds)
                                                   select new
                                                   {
                                                       q2.ExtractPrivateReports_ID
                                                   };





            this.query2DeletionPrivateReport = query_2_deletion_PrivateReportID.Select(x => x.ExtractPrivateReports_ID.ToString()).ToList();


            return this.query2DeletionPrivateReport;
        }

        public List<String> queryID2DeletePrivateDashboard(List<PrivateReport> privateReportList, List<PrivateDashboardComponent> privateDashboardComponentList,
            List<PrivateDashboard> privateDashboardList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {

            var query_2_deletion_PrivateReportID = from q2 in query2_delete(privateReportList, p, u, param, IgnoreIds)
                                                   select new
                                                   {
                                                       EXTRATPRIVATEREPORT_ID_2 = q2.ExtractPrivateReports_ID
                                                   };


            // Query to get privateDashboardID associeted with privateReport from Inactive people
            var query_2_deletion_Privatedashboard_Aux = from firstQuery in (from pr in query_2_deletion_PrivateReportID
                                                                            join pdc in privateDashboardComponentList on pr.EXTRATPRIVATEREPORT_ID_2 equals pdc.CustomReportId
                                                                            select new
                                                                            {

                                                                                dshID = pdc.DashboardId

                                                                            })
                                                        join pdl in privateDashboardList on firstQuery.dshID equals pdl.Id
                                                        select new
                                                        {

                                                            pdl.Id

                                                        };

            this.query2DeletionPrivatedashboard = query_2_deletion_Privatedashboard_Aux.Select(x => x.Id.ToString()).ToList();

            return this.query2DeletionPrivatedashboard;
        }

        public List<String> queryID2DeletePublicDashboard(List<PrivateReport> privateReportList, List<PublicDashboard> publicDashboardList,
            List<PublicDashboardComponent> publicDashboardComponentList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {
            var query_2_deletion_PrivateReportID = from q2 in query2_delete(privateReportList, p, u, param, IgnoreIds)
                                                   select new
                                                   {
                                                       EXTRATPRIVATEREPORT_ID_2 = q2.ExtractPrivateReports_ID
                                                   };


            //Query to track dashboard ID from Dsh component associated, I use Anonymous type to track the correct fields.

            var query_2_deletion_Publicdashboard_Aux = from secondQuery in (from pr in query_2_deletion_PrivateReportID
                                                                            join pdc in publicDashboardComponentList on pr.EXTRATPRIVATEREPORT_ID_2 equals pdc.CustomReportId
                                                                            select new
                                                                            {
                                                                                dshID = pdc.DashboardId
                                                                            })
                                                       join pdl in publicDashboardList on secondQuery.dshID equals pdl.Id
                                                       select new
                                                       {
                                                           pdl.Id
                                                       };

            this.query2DeletionPublicdashboard = query_2_deletion_Publicdashboard_Aux.Select(x => x.Id.ToString()).ToList();

            return this.query2DeletionPublicdashboard;
        }
        public List<String> queryID3DeletePrivateReports(List<PrivateReport> privateReportList, List<People> p, List<User> u, int param, List<String> IgnoreIds)
        {


            var query_3_deletion_PrivateReportID = from q3 in query3_deletion(privateReportList, p, u, param, IgnoreIds)
                                                   select new
                                                   {
                                                       q3.ExtractPrivateReports_ID
                                                   };





            this.query3DeletionPrivateReport = query_3_deletion_PrivateReportID.Select(x => x.ExtractPrivateReports_ID.ToString()).ToList();


            return this.query3DeletionPrivateReport;
        }

        public List<String> queryID4DeletePublicReports(List<PublicReport> publicReportList, List<User> u, List<String> IgnoreIds)
        {


            var query_4_deletion_PublicReportID = from q4 in query4(publicReportList, u, IgnoreIds)
                                                  select new
                                                  {
                                                      EXTRACTPUBLICREPORT_ID_3 = q4.Id_PublicReport
                                                  };





            this.query4DeletionPublicReport = query_4_deletion_PublicReportID.Select(x => x.EXTRACTPUBLICREPORT_ID_3.ToString()).ToList();


            return this.query4DeletionPublicReport;
        }
        //falta revisar
        public List<String> queryID5DeletePrivateDashboard(List<PrivateReport> privateReportList, List<PrivateDashboardComponent> privateDashboardComponentList,
            List<PrivateDashboard> privateDashboardList, List<PublicReport> publicReportList, List<People> p, List<User> u, int privateParam, int publicParam, List<String> IgnoreIds)
        {
            //Private dashboards with private report
            var query_5_3aBis = (query3aBis(privateDashboardList, privateDashboardComponentList, privateReportList, p, u, privateParam, IgnoreIds)
                .Select(z => new { z.Dashboard, z.Id, z.LastRunDate, z.EnterpriseId, z.Name, z.FolderName, z.Title })).ToList();
            //Private Dashboard with Public report
            var query_5_4b = (query4b(privateDashboardComponentList, publicReportList, u, privateDashboardList)
                .Select(t => new { t.Dashboard, t.Id, t.LastRunDate, t.EnterpriseId, t.Name, t.FolderName, t.Title })).ToList();

            var privateDashboardUnion_deletion = query_5_3aBis.Union(query_5_4b).ToList();

            //Query to track dashboard ID from Dsh component associated, I use Anonymous type to track the correct fields.

            var PrivateDashboardUnion_Id_deletion = from q5 in privateDashboardUnion_deletion
                                                    select new
                                                    {
                                                        q5.Dashboard
                                                    };

            this.query1aDeletionPrivatedashboard = PrivateDashboardUnion_Id_deletion.Select(x => x.Dashboard.ToString()).ToList();

            return this.query1aDeletionPrivatedashboard;
        }
        //falta revisar
        public List<String> queryID5DeletePublicDashboard(List<User> userList, List<People> p,
            List<PublicDashboardComponent> publicDashboardComponentList, List<PublicReport> publicReportList,
            List<PublicDashboard> publicDashboardList, List<PrivateReport> pr, int PrivateParam, int publicparam, List<String> IgnoreIds)
        {

            var query_5_4a = (query4a(userList, publicDashboardComponentList, publicReportList, publicDashboardList)
                .Select(t => new { t.Dashboard, t.Id, t.LastRunDate, t.EnterpriseId, t.Name, t.FolderName, t.Title })).ToList();

            var query_5_3bBis = (query3bBis(publicDashboardList, publicDashboardComponentList, pr, p, userList, PrivateParam, IgnoreIds)
                .Select(w => new { w.Dashboard, w.Id, w.LastRunDate, w.EnterpriseId, w.Name, w.FolderName, w.Title })).ToList();

            var PublicDashboardUnion = query_5_4a.Union(query_5_3bBis).ToList();


            //Query to track dashboard ID from Dsh component associated, I use Anonymous type to track the correct fields.

            var PublicDashboardUnion_Id_deletion = from q5 in PublicDashboardUnion
                                                   select new
                                                   {
                                                       q5.Dashboard
                                                   };


            this.query5DeletionPublicdashboard = PublicDashboardUnion_Id_deletion.Select(x => x.Dashboard.ToString()).ToList();

            return this.query5DeletionPublicdashboard;
        }
        public List<FolderSecurity> QueryFolderSecurity(List<PublicReport> publicReportList,List<PrivateReport> pr, List<PublicDashboard> publicDashboardList, List<PrivateDashboard> privateDashboardList, IDictionary<String, List<FolderShare>> mappingFolderIdAndShares, Rootobject folList)
        {
            List<Record> folderList = new List<Record>();
            folderList = folList.records.ToList();
            

            var joinPubReportsWFolders = from pubrep in publicReportList
                                              join f in folderList on pubrep.FOLDERNAME equals f.Name
                                              select new { folderId = f.Id, folderName = pubrep.FOLDERNAME, type = "report", name = pubrep.NAME, accessType = "Public Report"};

            var joinPrivReportsWFolders = from privrep in pr
                                          join f in folderList on privrep.FOLDERNAME equals f.Name
                                          select new { folderId = f.Id, folderName = privrep.FOLDERNAME, type = "report", name = privrep.NAME, accessType = "Private Report" };

            var together = joinPubReportsWFolders.Concat(joinPrivReportsWFolders);

            var joinPubDashboardsWFolders = from pubdsh in publicDashboardList
                                         join f in folderList on pubdsh.FolderName equals f.Name
                                         select new { folderId = f.Id, folderName = pubdsh.FolderName, type = "dashboard", name = pubdsh.Title, accessType = "Public Dashboard" };

            var joinPrivDashboardsWFolders = from privdsh in privateDashboardList
                                             join f in folderList on privdsh.FolderName equals f.Name
                                             select new { folderId = f.Id, folderName = privdsh.FolderName, type = "dashboard", name = privdsh.Title, accessType = "Private Dashboard" };

            var together2 = joinPubDashboardsWFolders.Concat(joinPrivDashboardsWFolders);

            var finalTogetherRepAndDsh = together2.Concat(together);

          
            var fsAux = mappingFolderIdAndShares.SelectMany(x => x.Value);

            var  folderShareRecords =   from x in fsAux
                                        join z in folderList on x.folderId equals z.Id
                                     select new
                                     {
                                         folderId = z.Id,
                                         folderName = z.Name ,
                                         type = x.shareType,
                                         name = x.sharedWithLabel,
                                         accessType = x.accessType
                                     };

            var finaltogetherAll = folderShareRecords.Concat(finalTogetherRepAndDsh);


            var objectCreation = from h in finaltogetherAll
                                 select new FolderSecurity
                                 {
                                     folderId = h.folderId,
                                     folderName = h.folderName,
                                     type = h.type,
                                     name = h.name,
                                     accessType = h.accessType
                                 };

            this.qFolderSecurity = objectCreation.ToList();



            return qFolderSecurity;
        }


    }
}
