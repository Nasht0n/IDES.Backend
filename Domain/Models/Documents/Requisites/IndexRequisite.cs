using System.Collections.Generic;
using Domain.Models.Documents.DocumentObjects;

namespace Domain.Models.Documents.Requisites
{
    public class IndexRequisite:BaseObject
    {
        public string Value { get; set; }

        public IList<OrderDocument> OrderDocuments { get; set; }
    }
}
