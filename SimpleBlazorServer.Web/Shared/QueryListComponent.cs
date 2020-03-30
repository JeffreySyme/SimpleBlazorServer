using SimpleBlazorServer.Queries;
using SimpleBlazorServer.Web.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Threading.Tasks;

namespace SimpleBlazorServer.Web.Shared
{
    public abstract class QueryListComponent<T> : ComponentBase, IDisposable where T: BaseQuery, new()
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected int _pageIndex;
        protected int _pageSize;
        protected bool _isDisposed;

        protected override async Task OnAfterRenderAsync(bool firstRender) 
        {
            if (firstRender) 
            {
                NavigationManager.LocationChanged += OnLocationChanged;
                var query = GetQuery();
                _pageIndex = (int)query.Skip;
                _pageSize = (int)query.Take;
                await SearchAsync(GetQuery());
            }
        }

        private async void OnLocationChanged(object sender, LocationChangedEventArgs e) 
        {
            if (_isDisposed)
                return;

            var query = GetQuery();

            await SearchAsync(query);
        }

        protected T GetQuery() 
        {
            return NavigationManager.GetQuery<T>();
        }

        protected void SetQuery(T query) 
        {
            NavigationManager.SetQueryString(query);
        }

        protected abstract Task SearchAsync(T query);

        public void Dispose() 
        {
            if (_isDisposed)
                return;

            NavigationManager.LocationChanged -= OnLocationChanged;

            _isDisposed = true;
        }
    }
}
