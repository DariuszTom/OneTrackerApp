namespace SharedLibrary.Interfaces
{
    public interface INetworkManager
    {
        public bool IsServiceConnected();

        public bool IsConnectedToNet();
    }
}