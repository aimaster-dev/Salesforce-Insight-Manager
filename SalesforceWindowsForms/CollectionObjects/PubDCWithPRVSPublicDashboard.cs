using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PubDCWithPRVSPublicDashboard
    {

        String _dashboard;
        String _privateReportId;
        DateTime _lastRunDate;
        String _enterpriseId;
        String _name;
        String _folder_name;
        String _title;

        public string Dashboard { get => _dashboard; set => _dashboard = value; }
        public string PrivateReportId { get => _privateReportId; set => _privateReportId = value; }
        public DateTime LastRunDate { get => _lastRunDate; set => _lastRunDate = value; }
        public string EnterpriseId { get => _enterpriseId; set => _enterpriseId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Folder_name { get => _folder_name; set => _folder_name = value; }
        public string Title { get => _title; set => _title = value; }
    }
}
