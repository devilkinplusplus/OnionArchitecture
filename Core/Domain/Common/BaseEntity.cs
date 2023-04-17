using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
