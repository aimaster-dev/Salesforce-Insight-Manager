using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesforceWindowsForms.SFDC;
using SalesforceWindowsForms.CollectionObjects;

namespace SalesforceWindowsForms.DAL
{
    public class PrivateDashboardComponentFactory
    {

        private List<PrivateDashboardComponent> sfPrivateDashboardComponent = new List<PrivateDashboardComponent>();
        private SforceService connect;

        

        public PrivateDashboardComponentFactory(SforceService con)
        {
            this.connect = con;
        }

        public bool loadPrivateDashboardComponent()
        {
            Boolean done = false;
            String privateDashboardComponent = "Select Id, Name, DashboardId, CustomReportId " +
                    "FROM DashboardComponent USING SCOPE allPrivate";
            QueryResult queryPrivateDashboardComponent = this.connect.query(privateDashboardComponent);

            while (!done)
            {

                for (int j = 0; j < queryPrivateDashboardComponent.records.Length; j++)
                {
                    sObject privateDashboardComponentRecord = queryPrivateDashboardComponent.records[j];// taking the first node or object.
                    PrivateDashboardComponent pdc = new PrivateDashboardComponent(); // instance of PrivateReport

                    //add value to privateReports properties
                    pdc.Id = privateDashboardComponentRecord.Any[0].InnerText.ToString();
                    pdc.Name = privateDashboardComponentRecord.Any[1].InnerText.ToString();
                    pdc.DashboardId = privateDashboardComponentRecord.Any[2].InnerText.ToString();
                    pdc.CustomReportId = privateDashboardComponentRecord.Any[3].InnerText.ToString();


                    // add people object into people list.
                    this.sfPrivateDashboardComponent.Add(pdc);
                }

                if (queryPrivateDashboardComponent.done)
                {
                    done = true;
                }
                else
                {
                    queryPrivateDashboardComponent = this.connect.queryMore(queryPrivateDashboardComponent.queryLocator);
                }

            }
            return true;
        }

        public List<PrivateDashboardComponent> getPrivateDashboardComponent()
        {
            return this.sfPrivateDashboardComponent;
        }
    }
}
