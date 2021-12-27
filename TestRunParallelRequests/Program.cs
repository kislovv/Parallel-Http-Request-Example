using System.Text;
using Newtonsoft.Json;
using TestRunParallelRequests;

var httpclient = new HttpClient(new HttpClientHandler(), true);


httpclient.BaseAddress = new Uri("http://localhost:8080");

var request1 = new CallbackModel
{
    PartnerOrderId = "31898",
    EventType = DeliveryEventType.OrderCompleted,
    EventTime = 1639240019
};

var request2 = new CallbackModel
{
    PartnerOrderId = "31898",
    EventType = DeliveryEventType.MeetingCompleted,
    EventTime = 1639240019
};

var content = JsonConvert.SerializeObject(request1, Formatting.None);
var content2 = JsonConvert.SerializeObject(request2, Formatting.None);

var tasks = new []{
    Task.Run(()=> httpclient.PostAsync("Provider/BcExpress/callback", new StringContent(content, Encoding.UTF8, "application/json"))),
    Task.Delay(50), 
    Task.Run(()=> httpclient.PostAsync("Provider/BcExpress/callback", new StringContent(content2, Encoding.UTF8, "application/json")))
};

Task.WaitAll(tasks);
Console.ReadKey();