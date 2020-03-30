using SimpleBlazorServer.Queries;
using Microsoft.AspNetCore.Components;
using System;

namespace SimpleBlazorServer.Web.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static void SetQueryString<T>(this NavigationManager navigationManager, T query) where T : BaseQuery 
        {
            var uri = new Uri(navigationManager.Uri);

            var baseUrl = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Authority}{uri.AbsolutePath}";

            navigationManager.NavigateTo($"{baseUrl}?{query.ToQueryString()}");
        }

        public static T GetQuery<T>(this NavigationManager navigationManager) where T : BaseQuery, new()
        {
            var uri = new Uri(navigationManager.Uri);

            return QueryStringHelpers.ParseQuery<T>(uri.Query);
        }
    }
}
