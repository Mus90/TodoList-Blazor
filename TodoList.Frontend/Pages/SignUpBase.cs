using Microsoft.AspNetCore.Components;

namespace TodoList.Frontend.Pages
{
    public class SignUpBase : ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
    }
}
