using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PublicReportsNotRunInMoreThan90Days
    {

        String _Id_PublicReport;
        String _FolderName;
        String _LastModifiedById;
        String _Name;
        DateTime _LastRunDate;
        String _EnterpriseID;

        public string Id_PublicReport { get => _Id_PublicReport; set => _Id_PublicReport = value; }
        public string FolderName { get => _FolderName; set => _FolderName = value; }
        public string Name { get => _Name; set => _Name = value; }
        public DateTime LastRunDate { get => _LastRunDate; set => _LastRunDate = value; }
        public string EnterpriseID { get => _EnterpriseID; set => _EnterpriseID = value; }
        public string LastModifiedById { get => _LastModifiedById; set => _LastModifiedById = value; }
    }
}
