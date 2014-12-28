using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mongodbProvider.Infrastructure
{
    public abstract class MongoControllerBase : Controller
    {
        public MongoControllerBase()
        {
            TempDataProvider = new MongoTempDataProvider("test", "MongoTempData");
        }
    }
}