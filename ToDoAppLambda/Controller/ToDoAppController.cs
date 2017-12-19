using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ToDoAppLambda.Controller
{
    class ToDoAppController
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();
        public void FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
        {

        }
    }
}
