using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Entities
{
    public class Currency
    {
        public int Id { get; set;  }
        public string Name { get; set; }

        public string Url { get; set; }

        public Decimal MaxLimit { get; set; }

    }
}
