using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class CheckPeople
    {
        String _employmentStatus;                            
        String _mms_user_c;
        String _mms_user_status_c;
        String _peopleKey_c;
        String _isActve;
        String enterpriseID_c;
        DateTime _lastLoginDate;
        String _inactityInd_c;
        String _name_user;

        public string EmploymentStatus { get => _employmentStatus; set => _employmentStatus = value; }
        public string Mms_user_c { get => _mms_user_c; set => _mms_user_c = value; }
        public string Mms_user_status_c { get => _mms_user_status_c; set => _mms_user_status_c = value; }
        public string PeopleKey_c { get => _peopleKey_c; set => _peopleKey_c = value; }
        public string IsActve { get => _isActve; set => _isActve = value; }
        public string EnterpriseID_c { get => enterpriseID_c; set => enterpriseID_c = value; }
        public DateTime LastLoginDate { get => _lastLoginDate; set => _lastLoginDate = value; }
        public string InactityInd_c { get => _inactityInd_c; set => _inactityInd_c = value; }
        public string Name_user { get => _name_user; set => _name_user = value; }
    }
}
