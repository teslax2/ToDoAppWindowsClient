using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppLambda.Model
{
    class ItemResponse
    {
        public Item Data { get; set; }
        public string Status { get; set; }

        public ItemResponse()
        {
            Data = new Item();
        }
    }
}
