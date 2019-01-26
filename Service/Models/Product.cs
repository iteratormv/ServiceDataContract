using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    [DataContract(Namespace ="http://itstep.org")]
    class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Category { set; get; }
    }

}
