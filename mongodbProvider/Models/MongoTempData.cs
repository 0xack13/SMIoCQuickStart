using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mongodbProvider.Models
{
    public class MongoTempData
    {
        public string SessionIdentifier { get; set; }

        public string Key { get; set; }

        public object Value { get; set; }
    }
}