using Microsoft.Azure.Cosmos.Table;
using System;

namespace AzureTable
{
    class Program
    {
        private static string Connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore200089;AccountKey=SGnsTS1c1IT6cYeBWsNu3LYywQ/cYj9WtKWjudpUzRRNjIekbj1gx53thQQHZ6dDryuym2kQd3GKWmHs8rA9Og==;EndpointSuffix=core.windows.net";
        private static string table_name = "Customer";
        private static string partition_key = "Chicago";
        private static string row_key = "C2";

        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(Connection_string);
            CloudTableClient _table_client = _account.CreateCloudTableClient();
            CloudTable _table = _table_client.GetTableReference(table_name);

            TableOperation _operation = TableOperation.Retrieve<Customer>(partition_key, row_key);
            TableResult _result = _table.Execute(_operation);
            Customer _customer = _result.Result as Customer;

            Console.WriteLine($"The Customer name is :  { _customer.customername}");
            Console.WriteLine($"The Customer city is :  { _customer.PartitionKey}");
            Console.WriteLine($"The Customer id is :  { _customer.RowKey}");
            Console.ReadKey();
        }
    }
}


