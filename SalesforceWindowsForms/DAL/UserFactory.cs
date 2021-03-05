using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesforceWindowsForms.CollectionObjects;
using SalesforceWindowsForms.SFDC;

namespace SalesforceWindowsForms.DAL
{
    public class UserFactory
    {

        private List<User> sfUser = new List<User>();
        private SforceService connect;

        

        public UserFactory(SforceService con)
        {
            this.connect = con;
        }

        public void loadUser(/*BackgroundWorker worker*/)
        {
           /* if (worker.IsBusy != true)
            {

                worker.RunWorkerAsync();*/

            Boolean done = false;
            String user = "SELECT Id, Name, Isactive, Profileid, Employeenumber, Lastlogindate," +
                " Federationidentifier, Enterprise_ID__c, License_Type__c, Peoplekey__c, Inactivitydttm__c," +
                " Inactivityind__c FROM User WHERE License_Type__c = 'Salesforce' and PeopleKey__c != null";
            QueryResult queryUser = connect.query(user);
            // "for" structure to store "queryResult" values into the "User" list collection ( in-memory objects)

            while (!done)
            {
                for (int j = 0; j < queryUser.records.Length; j++)
                {
                    sObject recordUser = queryUser.records[j];// taking the first node or object.
                    User u = new User(); // instance of people

                    //add value to people properties
                    u.ID = recordUser.Any[0].InnerText.ToString();
                    u.NAME = recordUser.Any[1].InnerText.ToString();
                    u.ISACTIVE = recordUser.Any[2].InnerText.ToString();
                    u.PROFILEID = recordUser.Any[3].InnerText.ToString();
                    u.EMPLOYEENUMBER = recordUser.Any[4].InnerText.ToString();
                    if (!string.IsNullOrEmpty(recordUser.Any[5].InnerText.ToString()))
                    {
                        String result = recordUser.Any[5].InnerText.ToString().Substring(0, 10);
                        u.LASTLOGINDATE = DateTime.ParseExact(result, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        u.LASTLOGINDATE = DateTime.ParseExact("0001-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    u.FEDERATIONIDENTIFIER = recordUser.Any[6].InnerText.ToString();
                    u.ENTERPRISE_ID__C = recordUser.Any[7].InnerText.ToString();
                    u.LICENSE_TYPE__C = recordUser.Any[8].InnerText.ToString();
                    u.PEOPLEKEY__C = recordUser.Any[9].InnerText.ToString();
                    u.INACTIVITYDTTM__C = recordUser.Any[10].InnerText.ToString();
                    u.INACTIVITYIND__C = recordUser.Any[11].InnerText.ToString();

                    // add people object into people list.
                    sfUser.Add(u);

                }
                if (queryUser.done)
                {
                    done = true;
                }
                else
                {
                    queryUser = this.connect.queryMore(queryUser.queryLocator);
                }
            }
        //}
           // return true;
        }

        public List<User> getUser()
        {
            return this.sfUser;

        }

    }
}
