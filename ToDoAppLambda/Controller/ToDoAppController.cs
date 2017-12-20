using Newtonsoft.Json;
using Amazon.Lambda.Core;
using ToDoAppLambda.Model;
using System.Threading.Tasks;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ToDoAppLambda.Controller
{
    class ToDoAppController
    {
        private static readonly JsonSerializer _jsonSerializer = new JsonSerializer();
        private DatabaseRequest dbRequest;

        // message example
        //{"TableName":"ToDoTable","Operation":1,"Data":{"Id":0,"Title":null,"Message":null,"Date":null,"Status":0}}
        //{"TableName":"ToDoTable","Operation":2,"Data":{"Id":1,"Title":"rower","Message":"zbiornik z rowerami","Date":"11/11/2019","Status":0}}
    public async Task<ItemResponse> FunctionHandler(ItemRequest request, ILambdaContext context)
        {
            dbRequest = new DatabaseRequest(request.TableName);
            switch (request.Operation)
            {
                case OperationType.Delete:
                    return await dbRequest.DeleteItem(request.Data);
                case OperationType.Get:
                    return await dbRequest.GetItem(request.Data);
                case OperationType.Put:
                    return await dbRequest.PutItem(request.Data);
                case OperationType.Update:
                    return await dbRequest.UpdateItem(request.Data);
                default:
                    return null;
            }
        }
    }
}
