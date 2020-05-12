﻿using BussinesErrorDashboard.Models;
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace BussinesErrorDashboard.Repository
{
    class ElasticSearchRepository
    {


        public IReadOnlyCollection<LogModel> getData(string query, DateTime startProcessing)
        {
            var settings = new ConnectionSettings(new Uri("http://nks01480.nykreditnet.net:9201"))
            .DefaultIndex("default-" + startProcessing.Year + "." + startProcessing.ToString("MM"));

            var client = new ElasticClient(settings);

            var searchResponse = client.Search<LogModel>(s => s
            .From(0)
            .Size(1)
            .Query(q => q
            .Match(m => m
            .Field(f => f.TransactionId) 
            .Query(query)
            )).TypedKeys(null));

            IReadOnlyCollection<LogModel> test = searchResponse.Documents;
            return test;
        }
    }
}
