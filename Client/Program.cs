
using Azure.Messaging.ServiceBus;
using Client;
using Newtonsoft.Json;

var serviceBusClient = new ServiceBusClient("CONN_STRING");

var sender = serviceBusClient.CreateSender("QUEUE_NAME");

var order = new Order { ProductId = Guid.NewGuid(), Customer = "Bob", CreationDate = DateTime.Now };
var message = new ServiceBusMessage(JsonConvert.SerializeObject(order));

Console.WriteLine("Press enter to send an order");
Console.ReadLine();
await sender.SendMessageAsync(message);

Console.WriteLine($"Order with product id {order.ProductId} created!");

List<ServiceBusMessage> messages = [
    new(JsonConvert.SerializeObject(new Order { ProductId = Guid.NewGuid(), Customer = "Anna", CreationDate = DateTime.Now })),
    new(JsonConvert.SerializeObject(new Order { ProductId = Guid.NewGuid(), Customer = "Paul", CreationDate = DateTime.Now })),
    new(JsonConvert.SerializeObject(new Order { ProductId = Guid.NewGuid(), Customer = "John", CreationDate = DateTime.Now })),
    ];

Console.WriteLine("Press enter to send a batch of orders");
Console.ReadLine();
await sender.SendMessagesAsync(messages);
Console.ReadKey();