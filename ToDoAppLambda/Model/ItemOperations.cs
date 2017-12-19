using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppLambda.Model
{
    interface ItemOperations
    {
        PutItemRequest PutItem(Item item);
        GetItemRequest GetItem(string tableName, int itemId);
        UpdateItemRequest UpdateItem(string tableName, int itemId);
        DeleteItemRequest DeleteItem(string tableName, int itemId);
    }
}
