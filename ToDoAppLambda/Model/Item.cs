using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppLambda.Model
{
    class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }

        public Item() { }

        public static int GenerateId()
        {
            var time = System.DateTime.Now.Ticks;
            var random = new System.Random();
            var randomNumber = random.Next(999999);
            return (int)(time * 64 + randomNumber);
        }

        public Dictionary<string, AttributeValue> GetAttributes()
        {
            var row = new Dictionary<string, AttributeValue>()
            {
                {"TaskId",new AttributeValue{ N = Id.ToString()}},
                {"Title", new AttributeValue{ S = Title} },
                {"Message", new AttributeValue{ S = Message} },
                {"Date", new AttributeValue{ S = Date} },
                {"Status", new AttributeValue{ N = Status.ToString()} },
            };
            return row;
        }
    }
}
