using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;
using TodoList.Frontend.Clients;

namespace TodoList.Frontend.Pages
{
    public class TasksBase: ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
        [Inject]
        public Client client { get; set; }
        [Parameter]
        public int id { get; set; }
        public CreateItemRequest item = new CreateItemRequest();
        protected async Task OnSubmitClick()
        {
            item.TodoListId = id;
            await client.CreateTask(item);
            navManager.NavigateTo($"TaskList/{id}", true);
        }
    }
}
