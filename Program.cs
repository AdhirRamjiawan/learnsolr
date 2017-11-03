using System;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Attributes;

namespace learnsolr
{

    public class Product 
    {
        [SolrUniqueKey("id")]
        public string Id {get;set;}

        [SolrField("manu")]
        public string Manufacturer {get;set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Startup.Init<Product>("http://localhost:8983/solr/learnsolr");

            var p = new Product{
                Id = Guid.NewGuid().ToString(),
                Manufacturer = "Sony"
            };

            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Product>>();
            solr.Add(p);
            solr.Commit();
        }
    }
}
