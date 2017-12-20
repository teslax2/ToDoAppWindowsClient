using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppLambda.Model
{
    class ItemRequest
    {
        public string TableName { get; set; }
        public OperationType Operation { get; set; }
        public Item Data { get; set; }

        public ItemRequest()
        {
            TableName = "";
            Operation = OperationType.Get;
            Data = new Item();
        }
    }

    enum OperationType
    {
        Delete,
        Get,
        Put,
        Update,
    }
}
