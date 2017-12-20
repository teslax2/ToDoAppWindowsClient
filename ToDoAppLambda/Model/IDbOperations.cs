using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppLambda.Model
{
    interface IDbOperations
    {
        AmazonDynamoDBClient client { get; set; }
        string tableName { get; set; }

        Task<ItemResponse> PutItem(Item item);
        Task<ItemResponse> GetItem(Item item);
        Task<ItemResponse> UpdateItem(Item item);
        Task<ItemResponse> DeleteItem(Item item);
    }
}
