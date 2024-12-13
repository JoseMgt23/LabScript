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
            ijsRuntime.InvokeAsync<IJSObjectReference>("import","").AsTask());
        }

        public ValueTask DisposeAsync()
        {
            
        }

        
    }
}
