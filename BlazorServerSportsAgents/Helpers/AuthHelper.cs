using Microsoft.JSInterop;

namespace BlazorServerSportsAgents.Helpers
{
    static class AuthHelper
    {
        public static async Task<string[]> GetJWT(IJSRuntime jsr)
        {
            var userdata = await jsr.InvokeAsync<string>("localStorage.getItem", "user").ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(userdata))
            {
                var dataArray = userdata.Split(';', 2);
                if (dataArray.Length == 2)
                {
                    return dataArray;
                }
            }
            return null;
        }

    }
}
