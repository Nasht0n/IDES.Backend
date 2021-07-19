using System;
using System.Collections.Generic;
using Domain.Models.Documents.DocumentObjects;

namespace Domain.Models.Documents.Requisites
{
    public class DateRequisite:BaseObject
    {
        public DateTime Value { get; set; }

        public IList<OrderDocument> OrderDocuments { get; set; }
    }
}
