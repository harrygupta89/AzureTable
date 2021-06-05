using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace AzureTable
{
    class Program
    {
        private static string Connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore200089;AccountKey=SGnsTS1c1IT6cYeBWsNu3LYywQ/cYj9WtKWjudpUzRRNjIekbj1gx53thQQHZ6dDryuym2kQd3GKWmHs8rA9Og==;EndpointSuffix=core.windows.net";
        private static string table_name = "Customer";
        private static string partition_key = "Chicago";
        private static string row_key = "UserB";


        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(Connection_string);
            CloudTableClient _table_client = _account.CreateCloudTableClient();
            CloudTable _table = _table_client.GetTableReference(table_name);

            List<Customer> _customers = new List<Customer>()
            {
                new Customer("userB", "Chicago", "C2"),
                new Customer("userC", "Chicago", "C3"),
                new Customer("userD", "Chicago", "C4"),
            };

            TableBatchOperation _operation = new TableBatchOperation();
            foreach (Customer c in _customers)
            {
                _operation.Insert(c);
            }

            TableBatchResult _result = _table.ExecuteBatch(_operation);
            Console.WriteLine("Batch of Entity has been added");
            Console.ReadKey();
        }
    }
}

