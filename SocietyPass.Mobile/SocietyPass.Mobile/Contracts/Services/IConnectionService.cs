using Plugin.Connectivity.Abstractions;
namespace SocietyPass.Mobile.Core.Contracts.Services
{
   
 public interface IConnectionService
    {
        bool IsConnected { get; }
        event ConnectivityChangedEventHandler ConnectivityChanged;
    }
}