﻿using Microsoft.Azure.Cosmos.Table;
using System;

namespace AzureTable
{
    class Program
    {
        private static string Connection_string = "DefaultEndpointsProtocol=https;AccountName=appstore200089;AccountKey=SGnsTS1c1IT6cYeBWsNu3LYywQ/cYj9WtKWjudpUzRRNjIekbj1gx53thQQHZ6dDryuym2kQd3GKWmHs8rA9Og==;EndpointSuffix=core.windows.net";
        private static string table_name = "Customer";

        static void Main(string[] args)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(Connection_string);
            CloudTableClient _table_client = _account.CreateCloudTableClient();
            CloudTable _table = _table_client.GetTableReference(table_name);
           
            Customer _customer = new Customer("userA", "Chicago", "C1");

            TableOperation _operation = TableOperation.Insert(_customer);

            TableResult _result = _table.Execute(_operation);

            Console.WriteLine("Entity is Added");
            Console.ReadKey();
        }
    }
}

