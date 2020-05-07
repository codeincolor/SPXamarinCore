using Plugin.Connectivity.Abstractions;
using SocietyPass.Mobile.Core.Contracts.Services;
using Plugin.Connectivity;


namespace SocietyPass.Mobile.Core.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectivity _connectivity;

        public ConnectionService()
        {
            _connectivity = CrossConnectivity.Current;
            _connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityChanged?.Invoke(this, new ConnectivityChangedEventArgs() { IsConnected = e.IsConnected });
        }

        public bool IsConnected => throw new System.NotImplementedException();

        public event ConnectivityChangedEventHandler ConnectivityChanged;
    }
}