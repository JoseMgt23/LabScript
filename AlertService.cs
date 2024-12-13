using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

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

        
    }
}
