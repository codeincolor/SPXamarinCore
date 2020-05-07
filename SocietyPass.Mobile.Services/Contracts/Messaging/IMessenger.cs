using System;

namespace SocietyPass.Mobile.Services.Contracts.Messaging
{
    public interface IMessenger
    {
        void Send<T>(T message, object sender = null) where T : IMessage;
        void Subscribe<T>(object subscriber, Action<object, T> callback) where T : IMessage;
        void Unsubscribe<T>(object subscriber) where T : IMessage;
    }
}