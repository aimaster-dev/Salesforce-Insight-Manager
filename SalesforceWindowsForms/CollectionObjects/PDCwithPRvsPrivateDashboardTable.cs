using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PDCwithPRvsPrivateDashboardTable
    {
        String _dashboard;
        DateTime _lastRunDate;
        String _id;
        String _enterpriseId;
        String _name;
        String _folderName;
        String _LastModifiedById;
        String _title;

        public string Dashboard { get => _dashboard; set => _dashboard = value; }
        public string Id { get => _id; set => _id = value; }
        public string EnterpriseId { get => _enterpriseId; set => _enterpriseId = value; }
        public string Name { get => _name; set => _name = value; }
        public string FolderName { get => _folderName; set => _folderName = value; }
        public string Title { get => _title; set => _title = value; }
        public DateTime LastRunDate { get => _lastRunDate; set => _lastRunDate = value; }
        public string LastModifiedById { get => _LastModifiedById; set => _LastModifiedById = value; }
    }
}
