using System;
using SocietyPass.Mobile.Services.Contracts.Messaging;
using Xamarin.Forms;

namespace SocietyPass.Mobile.Core.Messaging
{
    public class Messenger : IMessenger
    {
        public void Send<TMessage>(TMessage message, object sender = null) where TMessage : IMessage
        {
            if (sender == null)
                sender = new object();

            MessagingCenter.Send<object, TMessage>(sender, typeof(TMessage).FullName, message);
        }

        public void Subscribe<TMessage>(object subscriber, Action<object, TMessage> callback) where TMessage : IMessage
        {
            MessagingCenter.Subscribe<object, TMessage>(subscriber, typeof(TMessage).FullName, callback, null);
        }

        public void Unsubscribe<TMessage>(object subscriber) where TMessage : IMessage
        {
            MessagingCenter.Unsubscribe<object, TMessage>(subscriber, typeof(TMessage).FullName);
        }
    }
}