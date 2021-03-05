using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PublicDashboardComponent
    {

        String _id;
        String _name;
        String _dashboardId;
        String _customReportId;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string DashboardId { get => _dashboardId; set => _dashboardId = value; }
        public string CustomReportId { get => _customReportId; set => _customReportId = value; }
    }
}
