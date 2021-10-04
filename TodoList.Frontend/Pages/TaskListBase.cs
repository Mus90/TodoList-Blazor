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

    public class TaskListBase : ComponentBase
    {
        [Inject]
        public Client client { get; set; }
        public bool isDataReady = false;
        public bool isEditMode, showCreate = false;
        public TodoListByIDQueryResponse todo = new TodoListByIDQueryResponse();
        [Parameter]
        public string id { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!isDataReady)
            {
                todo = await client.GetToDoListDetails(new GetTodoListRequest() { id = int.Parse(id) });
                isDataReady = true;
                StateHasChanged();
            }
        }

        protected async Task OnItemChanged(Item input)
        {
            var resquest = new UpdateItemRequest
            {
                ID = input.ID,
                IsDone = !input.IsDone,
                Name = input.Name,
                TodoListId = input.TodoListId
            };

            //var resquest = new UpdateItemRequest();
            //resquest.ID = input.ID;
            //resquest.IsDone = input.IsDone;
            //resquest.Name = input.Name;
            //resquest.TodoListId = input.TodoListId;

            await client.UpdateTask(resquest);
        }

    }
}
