using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class Active_MMS_Users_with_Private_Reports_not_run_in_moreThan_180_days
    {
        String _employment_status;
        String _lastLoginDate;
        String _checkPeopleID;
        String _enterpriseID;
        String _isActive;
        String _name;
        DateTime _lastRunDate;
        String _extratPrivateReportID;
        String _mmsUser_c;

        public string Employment_status { get => _employment_status; set => _employment_status = value; }
        public string LastLoginDate { get => _lastLoginDate; set => _lastLoginDate = value; }
        public string CheckPeopleID { get => _checkPeopleID; set => _checkPeopleID = value; }
        public string EnterpriseID { get => _enterpriseID; set => _enterpriseID = value; }
        public string IsActive { get => _isActive; set => _isActive = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime LastRunDate { get => _lastRunDate; set => _lastRunDate = value; }
        public string ExtratPrivateReportID { get => _extratPrivateReportID; set => _extratPrivateReportID = value; }
        public string MmsUser_c { get => _mmsUser_c; set => _mmsUser_c = value; }
    }
}
