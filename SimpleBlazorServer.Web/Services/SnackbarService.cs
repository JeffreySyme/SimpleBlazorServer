using System;

namespace SimpleBlazorServer.Web.Services
{
    public enum SnackbarType
    {
        Success = 1,
        Info = 2,
        Error = 4
    }
    public interface ISnackbarService
    {
        event Action<string, SnackbarType> OnShow;
        void Show(string message, SnackbarType type = SnackbarType.Info);
    }
    public class SnackbarService : ISnackbarService
    {
        public event Action<string, SnackbarType> OnShow;
        public void Show(string message, SnackbarType type = SnackbarType.Info)
        {
            OnShow?.Invoke(message, type);
        }
    }
}
