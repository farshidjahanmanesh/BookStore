using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifedBy { get; set; }
        public DateTime? LastModifedDate { get; set; }
    }
}
