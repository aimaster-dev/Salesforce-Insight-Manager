using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceWindowsForms.CollectionObjects
{
    public class PrivateDashboard
    {
        String _id;
        String _isDeleted;
        String _folderId;
        String _folderName;
        String _title;
        String _description;
        String _createdDate;
        String _createdById;
        String _lastModifiedDate;
        String _lastModifiedById;
        String _type;

        public string Id { get => _id; set => _id = value; }
        public string IsDeleted { get => _isDeleted; set => _isDeleted = value; }
        public string FolderId { get => _folderId; set => _folderId = value; }
        public string FolderName { get => _folderName; set => _folderName = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public string CreatedDate { get => _createdDate; set => _createdDate = value; }
        public string CreatedById { get => _createdById; set => _createdById = value; }
        public string LastModifiedDate { get => _lastModifiedDate; set => _lastModifiedDate = value; }
        public string LastModifiedById { get => _lastModifiedById; set => _lastModifiedById = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
