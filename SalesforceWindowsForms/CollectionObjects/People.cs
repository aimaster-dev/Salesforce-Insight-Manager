using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class People
    {
                String _ID;
                String NAME_PEOPLE;
                String EMPLOYMENT_STATUS__C;
                String PEOPLEKEY__C;
                String MMS_USER__C;
                String MMS_USER_STATUS__C;

        public string ID { get => _ID; set => _ID = value; }
        public string NAME_PEOPLE1 { get => NAME_PEOPLE; set => NAME_PEOPLE = value; }
        public string EMPLOYMENT_STATUS__C1 { get => EMPLOYMENT_STATUS__C; set => EMPLOYMENT_STATUS__C = value; }
        public string PEOPLEKEY__C1 { get => PEOPLEKEY__C; set => PEOPLEKEY__C = value; }
        public string MMS_USER__C1 { get => MMS_USER__C; set => MMS_USER__C = value; }
        public string MMS_USER_STATUS__C1 { get => MMS_USER_STATUS__C; set => MMS_USER_STATUS__C = value; }
    }
}
