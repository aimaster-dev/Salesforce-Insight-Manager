using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PublicReport
    {

        String _ID;
        String _OWNERID;
        String _FOLDERNAME;
        String _LASTMODIFIEDDATE;
        String _LASTMODIFIEDBYID;
        String _ISDELETED;
        String _NAME;
        String _DESCRIPTION;
        String _DEVELOPERNAME;
        String _NAMESPACEPREFIX;
        DateTime _LASTRUNDATE;
        String _SYSTEMMODSTAMP;
        String _FORMAT;
        String _LASTVIEWEDDATE;
        String _LASTREFERENCEDDATE;
        DateTime _CREATEDDATE;
        String _CREATEDBYID;

        public string ID { get => _ID; set => _ID = value; }
        public string OWNERID { get => _OWNERID; set => _OWNERID = value; }
        public string FOLDERNAME { get => _FOLDERNAME; set => _FOLDERNAME = value; }
        public string LASTMODIFIEDDATE { get => _LASTMODIFIEDDATE; set => _LASTMODIFIEDDATE = value; }
        public string LASTMODIFIEDBYID { get => _LASTMODIFIEDBYID; set => _LASTMODIFIEDBYID = value; }
        public string ISDELETED { get => _ISDELETED; set => _ISDELETED = value; }
        public string NAME { get => _NAME; set => _NAME = value; }
        public string DESCRIPTION { get => _DESCRIPTION; set => _DESCRIPTION = value; }
        public string DEVELOPERNAME { get => _DEVELOPERNAME; set => _DEVELOPERNAME = value; }
        public string NAMESPACEPREFIX { get => _NAMESPACEPREFIX; set => _NAMESPACEPREFIX = value; }
        public DateTime LASTRUNDATE { get => _LASTRUNDATE; set => _LASTRUNDATE = value; }
        public string SYSTEMMODSTAMP { get => _SYSTEMMODSTAMP; set => _SYSTEMMODSTAMP = value; }
        public string FORMAT { get => _FORMAT; set => _FORMAT = value; }
        public string LASTVIEWEDDATE { get => _LASTVIEWEDDATE; set => _LASTVIEWEDDATE = value; }
        public string LASTREFERENCEDDATE { get => _LASTREFERENCEDDATE; set => _LASTREFERENCEDDATE = value; }
        public DateTime CREATEDDATE { get => _CREATEDDATE; set => _CREATEDDATE = value; }
        public string CREATEDBYID { get => _CREATEDBYID; set => _CREATEDBYID = value; }
    }
}
