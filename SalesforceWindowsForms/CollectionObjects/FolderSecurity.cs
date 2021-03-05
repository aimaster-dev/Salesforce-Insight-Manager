using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    //The object that represent the final result for the report with shares of folders ( reports and dashboards)
    public class FolderSecurity
    {
        public string folderId { get; set; }
        public string folderName { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string accessType { get; set; }
    }
}
