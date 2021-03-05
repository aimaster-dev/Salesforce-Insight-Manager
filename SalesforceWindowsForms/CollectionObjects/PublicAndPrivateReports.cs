using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PublicAndPrivateReports
    {
        String _dashboard;
        String _id;
        DateTime _lastRunDate;
        String _enterpriseID;
        String _Name;
        String _folderName;
        String _title;

        public string Dashboard { get => _dashboard; set => _dashboard = value; }
        public string Id { get => _id; set => _id = value; }
        public DateTime LastRunDate { get => _lastRunDate; set => _lastRunDate = value; }
        public string EnterpriseID { get => _enterpriseID; set => _enterpriseID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string FolderName { get => _folderName; set => _folderName = value; }
        public string Title { get => _title; set => _title = value; }
    }
}
