using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Models.ResponseDtos;
using TodoList.Frontend.Clients;
using TodoList.Frontend.Services;

namespace TodoList.Frontend.Pages
{
    public class TodoListsBase:ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
        [Inject]
        public Client client { get; set; }
        public bool isDataReady = false;
        public List<TodoListQueryResponse> toDos = new List<TodoListQueryResponse>();


        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!isDataReady)
            {
                toDos = await client.GetToDoList();
                isDataReady = true;
                StateHasChanged();
            }
        }
    }
}
