using BussinesErrorDashboard.Models;
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
    class elasticSearchRepository
    {


        public void getData()
        {
            var settings = new ConnectionSettings(new Uri("http://nks01480.nykreditnet.net:9201"))
            .DefaultIndex("default-2020.03").DisableDirectStreaming();

            var client = new ElasticClient(settings);

            var searchResponse = client.Search<LogModel>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Match(m => m
            .Field(f => f.transactionId)
            .Query("D82B0157-EE1D-445D-AB6B-C0F234FE4E0B")
            )).TypedKeys(null));

            var test = searchResponse.Documents;
        }
    }
}
