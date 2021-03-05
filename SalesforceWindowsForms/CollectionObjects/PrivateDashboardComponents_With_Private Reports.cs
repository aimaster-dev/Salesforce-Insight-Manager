using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PrivateDashboardComponents_With_Private_Reports
    {
        String _dashboard;
        DateTime _lastRunDate;
        String _privateReportId;
        String _enterpriseId;
        String _name;

        public string Dashboard { get => _dashboard; set => _dashboard = value; }
        public DateTime LastRunDate { get => _lastRunDate; set => _lastRunDate = value; }
        public string PrivateReportId { get => _privateReportId; set => _privateReportId = value; }
        public string EnterpriseId { get => _enterpriseId; set => _enterpriseId = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
