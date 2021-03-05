using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class InactivePeopleWithPrivateReports
    {
        String _EMPLOYMENT_STATUS__CS__C;
        DateTime _LASTLOGINDATE;
        String _CheckPeople_ID;
        String _ENTERPRISE_id__C;
        String _ISACTIVE;
        String _NAME;
        DateTime _LASTRUNDATE;
        String _ExtractPrivateRepoerts_ID;
        String _FOLDERNAME;
        String _LASTMODIFIEDBYID;
        String _MMS_User__C;

        public string EMPLOYMENT_STATUS__CS__C { get => _EMPLOYMENT_STATUS__CS__C; set => _EMPLOYMENT_STATUS__CS__C = value; }
        public DateTime LASTLOGINDATE { get => _LASTLOGINDATE; set => _LASTLOGINDATE = value; }
        public string CheckPeople_ID { get => _CheckPeople_ID; set => _CheckPeople_ID = value; }
        public string ENTERPRISE_id__C { get => _ENTERPRISE_id__C; set => _ENTERPRISE_id__C = value; }
        public string ISACTIVE { get => _ISACTIVE; set => _ISACTIVE = value; }
        public string NAME { get => _NAME; set => _NAME = value; }
        public DateTime LASTRUNDATE { get => _LASTRUNDATE; set => _LASTRUNDATE = value; }
        public string ExtractPrivateRepoerts_ID { get => _ExtractPrivateRepoerts_ID; set => _ExtractPrivateRepoerts_ID = value; }
        public string MMS_User__C { get => _MMS_User__C; set => _MMS_User__C = value; }
        public string FOLDERNAME { get => _FOLDERNAME; set => _FOLDERNAME = value; }
        public string LASTMODIFIEDBYID { get => _LASTMODIFIEDBYID; set => _LASTMODIFIEDBYID = value; }
    }
}
