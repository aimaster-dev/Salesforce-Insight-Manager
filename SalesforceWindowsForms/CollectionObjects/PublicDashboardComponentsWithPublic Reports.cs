using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PublicDashboardComponentsWithPublic_Reports
    {
        String _dashboardID;
        String _publicReportID;
        DateTime _pubrepLastRunDate;
        String _eId;
        String _dashboardComponentName;
        String _dasboard_folderName;
        String _dasboard_title;

        public string DashboardID { get => _dashboardID; set => _dashboardID = value; }
        public string PublicReportID { get => _publicReportID; set => _publicReportID = value; }
        public DateTime PubrepLastRunDate { get => _pubrepLastRunDate; set => _pubrepLastRunDate = value; }
        public string EId { get => _eId; set => _eId = value; }
        public string DashboardComponentName { get => _dashboardComponentName; set => _dashboardComponentName = value; }
        public string Dasboard_folderName { get => _dasboard_folderName; set => _dasboard_folderName = value; }
        public string Dasboard_title { get => _dasboard_title; set => _dasboard_title = value; }
    }
}
