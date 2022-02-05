using System.Runtime.InteropServices;

namespace DbDataLibrary.Logger
{
    public interface ILogBase
    {
        void Log(string message, [Optional] bool isErrorLog);
    }
}