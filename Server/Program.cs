
using Azure.Messaging.ServiceBus;
using Client;
using Newtonsoft.Json;

var serviceBusClient = new ServiceBusClient("CONN_STRING");

var receiver = serviceBusClient.CreateReceiver("QUEUE_NAME");

var message = await receiver.ReceiveMessageAsync();

var order = JsonConvert.DeserializeObject<Order>(message.Body.ToString());

await receiver.CompleteMessageAsync(message);
Console.WriteLine($"The order with product id {order.ProductId} is completed!");

Console.WriteLine("-----------------------");

var messages = await receiver.ReceiveMessagesAsync(maxMessages: 3);
foreach (var msg in messages)
{
    var item = JsonConvert.DeserializeObject<Order>(msg.Body.ToString());
    Console.WriteLine($"The order with product id {item.ProductId} is completed!");
    await receiver.CompleteMessageAsync(msg);
}

Console.ReadKey();