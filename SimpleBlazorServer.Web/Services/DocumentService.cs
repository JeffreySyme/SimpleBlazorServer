using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SimpleBlazorServer.Web.Services
{
    public interface IDocumentService
    {
        Task SetTitleAsync(string title);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IJSRuntime _jsRuntime;
        public DocumentService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task SetTitleAsync(string title)
        {
            await _jsRuntime.InvokeVoidAsync("App.setDocumentTitle", title);
        }
    }
}
