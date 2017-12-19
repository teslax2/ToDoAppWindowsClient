using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppLambda.Model
{
    interface IOperations
    {
        AmazonDynamoDBClient client { get; set; }
        string tableName { get; set; }

        Task<PutItemResponse> PutItem(Item item);
        Task<GetItemResponse> GetItem(Item item);
        Task<UpdateItemResponse> UpdateItem(Item item);
        Task<DeleteItemResponse> DeleteItem(Item item);
    }
}
