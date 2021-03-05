using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class InactivePeopleWithreportsNotRunInMoreThan180Days
    {
        String _EMPLOYMENT_STATUS__C;
        DateTime _LASTLOGINDATE;
        String _CheckPeople_ID;
        String _ENTERPRISE_ID__C;
        String _ISACTIVE;
        String _NAME;
        DateTime _LASTRUNDATE;
        String _ExtractPrivateReports_ID;
        String _FOLDERNAME;
        String _LASTMODIFIEDBYID;
        String _MMS_USER__C;

        public string EMPLOYMENT_STATUS__C { get => _EMPLOYMENT_STATUS__C; set => _EMPLOYMENT_STATUS__C = value; }
        public DateTime LASTLOGINDATE { get => _LASTLOGINDATE; set => _LASTLOGINDATE = value; }
        public string CheckPeople_ID { get => _CheckPeople_ID; set => _CheckPeople_ID = value; }
        public string ENTERPRISE_ID__C { get => _ENTERPRISE_ID__C; set => _ENTERPRISE_ID__C = value; }
        public string ISACTIVE { get => _ISACTIVE; set => _ISACTIVE = value; }
        public string NAME { get => _NAME; set => _NAME = value; }
        public DateTime LASTRUNDATE { get => _LASTRUNDATE; set => _LASTRUNDATE = value; }
        public string ExtractPrivateReports_ID { get => _ExtractPrivateReports_ID; set => _ExtractPrivateReports_ID = value; }
        public string MMS_USER__C { get => _MMS_USER__C; set => _MMS_USER__C = value; }
        public string FOLDERNAME { get => _FOLDERNAME; set => _FOLDERNAME = value; }
        public string LASTMODIFIEDBYID { get => _LASTMODIFIEDBYID; set => _LASTMODIFIEDBYID = value; }
    }
}
