using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using todo_backend.Controllers;
using TodoList.Frontend.Clients;

namespace TodoList.Frontend.Pages
{
    public class SignUpBase : ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }

        [Inject]
        public Client appClient { get; set; }

        public SignUpRequest request = new SignUpRequest();
        protected async Task OnSubmitClick()
        {
            //authenticate user
            SignInResponse token = await appClient.SignUp(request);
            // redirect user to Todolist page
            navManager.NavigateTo("/TodoList");
        }
    }
}
