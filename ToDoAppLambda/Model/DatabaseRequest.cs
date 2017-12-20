using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;

namespace ToDoAppLambda.Model
{
    class DatabaseRequest : IDbOperations
    {
        public AmazonDynamoDBClient client { get; set; }
        public string tableName { get; set; }

        public DatabaseRequest(string table)
        {
            client = new AmazonDynamoDBClient();
            tableName = table;
        }

        public async Task<ItemResponse> DeleteItem(Item item)
        {
            var id = item.Id;
            var request = new DeleteItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "TaskId", new AttributeValue { N = id.ToString() } }  },
            };
            var result = await client.DeleteItemAsync(request);
            return new ItemResponse() { Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> GetItem(Item item)
        {
            var id = item.Id;
            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "TaskId", new AttributeValue { N = id.ToString() } } },
            };
            var result = await client.GetItemAsync(request);
            return new ItemResponse() {
                Data = new Item()
                {
                    Title = result.Item["Title"].S,
                    Date = result.Item["Date"].S,
                    Message = result.Item["Message"].S,
                    Status = Int32.Parse(result.Item["Status"].N),
                    Id = Int32.Parse(result.Item["TaskId"].N)
                },
                Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> PutItem(Item item)
        {
            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = item.GetAttributes()
            };
            var result = await client.PutItemAsync(request);
            return new ItemResponse() { Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> UpdateItem(Item item)
        {
            var id = item.Id;
            var request = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "TaskId", new AttributeValue { N = id.ToString() } } },
            };
            var result = await client.UpdateItemAsync(request);
            return new ItemResponse() { Status = result.HttpStatusCode.ToString() };
        }

    }

}
