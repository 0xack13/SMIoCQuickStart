using MongoDB;
using mongodbProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mongodbProvider.Infrastructure
{
    public class MongoTempDataProvider : ITempDataProvider
    {
        private string _collectionName;
        private string _databaseName;

        public MongoTempDataProvider(string databaseName, string collectionName)
        {
            _collectionName = collectionName;
            _databaseName = databaseName;
        }

        public IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            var tempDataDictionary = new Dictionary<string, object>();

            using (Mongo mongo = new Mongo())
            {
                mongo.Connect();

                IMongoCollection<MongoTempData> collection =
                    mongo
                        .GetDatabase(_databaseName)
                        .GetCollection<MongoTempData>(_collectionName);

                IEnumerable<MongoTempData> tempData = collection.Find(item =>
                    item.SessionIdentifier ==
                        controllerContext.HttpContext.Request.UserHostAddress
                ).Documents;

                foreach (var tempDataItem in tempData)
                {
                    tempDataDictionary.Add(tempDataItem.Key, tempDataItem.Value);

                    collection.Remove(tempDataItem);
                }
            }

            return tempDataDictionary;
        }

        public void SaveTempData(ControllerContext controllerContext,
                                    IDictionary<string, object> values)
        {
            using (Mongo mongo = new Mongo())
            {
                mongo.Connect();

                IMongoCollection<MongoTempData> collection =
                    mongo
                        .GetDatabase(_databaseName)
                        .GetCollection<MongoTempData>(_collectionName);

                IEnumerable<MongoTempData> oldItems =
                    collection.Find(item =>
                        item.SessionIdentifier ==
                            controllerContext.HttpContext.Request.UserHostAddress
                    ).Documents;

                foreach (var tempDataItem in oldItems)
                {
                    collection.Remove(tempDataItem);
                }

                if (values != null && values.Count > 0)
                {
                    collection.Insert(
                        values.Select(tempDataValue =>
                            new MongoTempData
                            {
                                SessionIdentifier =
                                    controllerContext.HttpContext.Request.UserHostAddress,
                                Key = tempDataValue.Key,
                                Value = tempDataValue.Value
                            }
                        )
                    );
                }
            }
        }

    }
}