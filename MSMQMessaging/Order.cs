﻿using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQMessaging
{
    class Order : BaseQueues, IMessaging.IOrder
    {

        // Path example - FormatName:DIRECT=OS:MyMachineName\Private$\OrderQueueName
        private static readonly string queuePath = ConfigurationManager.AppSettings["OrderQueuePath"];
        private static int queueTimeout = 20;

        public Order() : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }

        /// <summary>
        /// Method to retrieve order messages from Pet Shop Message Queue
        /// </summary>
        /// <returns>All information for an order</returns>
        public new OrderInfo Receive()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (OrderInfo)((Message)base.Receive()).Body;
        }

        public OrderInfo Receive(int timeout)
        {
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            return Receive();
        }

        /// <summary>
        /// Method to send asynchronous order to Pet Shop Message Queue
        /// </summary>
        /// <param name="orderMessage">All information for an order</param>
        public void Send(OrderInfo orderMessage)
        {
            // This method does not involve in distributed transaction and optimizes performance using Single type
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(orderMessage);
        }
    }
}
