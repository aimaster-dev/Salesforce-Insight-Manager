using SalesforceWindowsForms.CollectionObjects; //directive to clases cretaed to store Data InMemory with QueryResult
using SalesforceWindowsForms.SFDC; // directive that points to the WSDL fro salesforce used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.DAL
{
    public class PublicDashboardComponentFactory
    {

        private List<PublicDashboardComponent> sfpublicDashboardsComponents = new List<PublicDashboardComponent>();
        private SforceService connect;

        

        public PublicDashboardComponentFactory(SforceService con) //method to used the SalesforceConnection to the 
        {
            this.connect = con;
        }

        public bool loadPublicDashboardComponents()
        {
            Boolean done = false;
            String publicDashboardComponent = "Select Id, Name, DashboardId, CustomReportId FROM DashboardComponent";
            QueryResult queryPublicDashboardComponent = this.connect.query(publicDashboardComponent);

            while (!done)
            {
                for (int j = 0; j < queryPublicDashboardComponent.records.Length; j++)
                {
                    sObject publicDashboardComponentRecord = queryPublicDashboardComponent.records[j];// taking the first node or object from XML of the WSDL from SF.
                    PublicDashboardComponent pubdc = new PublicDashboardComponent(); // instance of PublicDashboardComponent.

                    //add value to PublicDashboardComponents properties
                    pubdc.Id = publicDashboardComponentRecord.Any[0].InnerText.ToString();
                    pubdc.Name = publicDashboardComponentRecord.Any[1].InnerText.ToString();
                    pubdc.DashboardId = publicDashboardComponentRecord.Any[2].InnerText.ToString();
                    pubdc.CustomReportId = publicDashboardComponentRecord.Any[3].InnerText.ToString();


                    // add publicDashboardComponent object into publicDashboardComponent list.
                    this.sfpublicDashboardsComponents.Add(pubdc);
                }
                if (queryPublicDashboardComponent.done)
                {
                    done = true;
                }
                else
                {
                    queryPublicDashboardComponent = this.connect.queryMore(queryPublicDashboardComponent.queryLocator);
                }

            }

            return true;
        }

        public List<PublicDashboardComponent> GetPublicDashboardComponent()
        {

            return this.sfpublicDashboardsComponents;

        }
    }
}
