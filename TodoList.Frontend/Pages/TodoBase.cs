using Microsoft.AspNetCore.Components;

namespace TodoList.Frontend.Pages
{
    public class TodoBase : ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
        protected void OnSubmitClick()
        {
            //authenticate user
            // redirect user to Todolist page
            navManager.NavigateTo("/");
        }
    }
}
