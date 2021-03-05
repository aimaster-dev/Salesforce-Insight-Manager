using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class User
    {
        String _ID;
        String _NAME;
        String _ISACTIVE;
        String _PROFILEID;
        String _EMPLOYEENUMBER;
        DateTime _LASTLOGINDATE;
        String _FEDERATIONIDENTIFIER
;       String _ENTERPRISE_ID__C;
        String _LICENSE_TYPE__C;
        String _PEOPLEKEY__C;
        String _INACTIVITYDTTM__C;
        String _INACTIVITYIND__C;

        public string ID { get => _ID; set => _ID = value; }
        public string NAME { get => _NAME; set => _NAME = value; }
        public string ISACTIVE { get => _ISACTIVE; set => _ISACTIVE = value; }
        public string PROFILEID { get => _PROFILEID; set => _PROFILEID = value; }
        public string EMPLOYEENUMBER { get => _EMPLOYEENUMBER; set => _EMPLOYEENUMBER = value; }
        public DateTime LASTLOGINDATE { get => _LASTLOGINDATE; set => _LASTLOGINDATE = value; }
        public string FEDERATIONIDENTIFIER { get => _FEDERATIONIDENTIFIER; set => _FEDERATIONIDENTIFIER = value; }
        public string ENTERPRISE_ID__C { get => _ENTERPRISE_ID__C; set => _ENTERPRISE_ID__C = value; }
        public string LICENSE_TYPE__C { get => _LICENSE_TYPE__C; set => _LICENSE_TYPE__C = value; }
        public string PEOPLEKEY__C { get => _PEOPLEKEY__C; set => _PEOPLEKEY__C = value; }
        public string INACTIVITYDTTM__C { get => _INACTIVITYDTTM__C; set => _INACTIVITYDTTM__C = value; }
        public string INACTIVITYIND__C { get => _INACTIVITYIND__C; set => _INACTIVITYIND__C = value; }
    }
}
