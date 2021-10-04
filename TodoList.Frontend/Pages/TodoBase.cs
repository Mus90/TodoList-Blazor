using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using todo_backend.Models.RequestsDtos;
using TodoList.Frontend.Clients;

namespace TodoList.Frontend.Pages
{
    public class TodoBase : ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
        [Inject]
        public Client client { get; set; }
        public CreateTodoListRequest todoItem = new CreateTodoListRequest();
        protected async Task OnSubmitClick()
        {
            await client.CreateList(todoItem);
            // redirect user to Todolist page
            navManager.NavigateTo("/");
        }
    }
}
