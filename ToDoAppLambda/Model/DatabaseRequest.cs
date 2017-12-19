using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;

namespace ToDoAppLambda.Model
{
    class DatabaseRequest : IOperations
    {
        public AmazonDynamoDBClient client { get; set; }
        public string tableName { get; set; }

        public DatabaseRequest(AmazonDynamoDBClient dbClient, string table)
        {
            client = dbClient;
            tableName = table;
        }

        public async Task<DeleteItemResponse> DeleteItem(Item item)
        {
            var id = item.Id;
            var request = new DeleteItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "TaskId", new AttributeValue { N = id.ToString() } }  },
            };
            return await client.DeleteItemAsync(request);
        }

        public async Task<GetItemResponse> GetItem(Item item)
        {
            var id = item.Id;
            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "TaskId", new AttributeValue { N = id.ToString() } } },
            };
            return await client.GetItemAsync(request);
        }

        public async Task<PutItemResponse> PutItem(Item item)
        {
            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = item.GetAttributes()
            };
            return await client.PutItemAsync(request);
        }

        public async Task<UpdateItemResponse> UpdateItem(Item item)
        {
            var id = item.Id;
            var request = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "TaskId", new AttributeValue { N = id.ToString() } } },
            };
            return await client.UpdateItemAsync(request);
        }
    }

}
