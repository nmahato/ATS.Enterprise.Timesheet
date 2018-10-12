using System;
using System.Collections.Generic;
using System.Text;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace ATS.AWS.SQS
{
   public class ProcessQueue
    {
        public void SendMessage()
        {
            IAmazonSQS sqs = new AmazonSQSClient(RegionEndpoint.USEast1);

            var sqsRequest = new CreateQueueRequest
            {
                QueueName = "CartQueue"
            };

            var createQueueResponse = sqs.CreateQueueAsync(sqsRequest).Result;

            var queueUrl = createQueueResponse.QueueUrl;

            var listQueueRequest = new ListQueuesRequest();

            var listQueueResponse = sqs.ListQueuesAsync(listQueueRequest);

            Console.WriteLine($"List of amazon queue url. \n");

            foreach (var item in listQueueResponse.Result.QueueUrls)
            {
                Console.WriteLine($"Queue URL{item}");
            }

            Console.WriteLine($"Sending Message. \n");

            var sqsMessageRequest = new SendMessageRequest
            {

                QueueUrl = queueUrl,
                MessageBody = "Message Bodykkkkk"

            };

            sqs.SendMessageAsync(sqsMessageRequest);
        }
    }
}
