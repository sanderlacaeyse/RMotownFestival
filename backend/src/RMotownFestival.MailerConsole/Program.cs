using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

namespace RMotownFestival.MailerConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // receive message from the queue
            await ReceiveMessagesAsync();
        }

        static async Task ReceiveMessagesAsync()
        {
            var connectionString = "<connection_string>";
            var queueName = "mails";
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a processor that we can use to process the messages
                ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

                // add handler to process messages
                processor.ProcessMessageAsync += MessageHandler;

                // add handler to process any errors
                processor.ProcessErrorAsync += ErrorHandler;

                // start processing 
                await processor.StartProcessingAsync();

                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                // stop processing 
                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
        }

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Mail to send: {body}");

            // complete the message. messages is deleted from the queue. 
            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
