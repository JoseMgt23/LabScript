using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Diagnostics.Metrics;

namespace LabScript
{
    public class AlertService : IAsyncDisposable
    {

        readonly Lazy<Task<IJSObjectReference>>ijSObjectReference;

        public AlertService(IJSRuntime ijsRuntime)
        {
            this.ijSObjectReference = new Lazy<Task<IJSObjectReference>>(()=>
            ijsRuntime.InvokeAsync<IJSObjectReference>("import","./content/LabScript/Pages/Home.razor.js").AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if(ijSObjectReference.IsValueCreated)
            {
                IJSObjectReference moduleJs = await ijSObjectReference.Value;
                await moduleJs.DisposeAsync();
            }
        }

        public async Task CallJsAlertFunction()
        {
            var jsModule = await ijSObjectReference.Value;

            jsModule.InvokeVoidAsync("jsFuncion");
        }        
    }
}
