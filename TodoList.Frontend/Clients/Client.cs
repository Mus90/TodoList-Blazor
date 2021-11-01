using Pathoschild.Http.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todo_backend.Controllers;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;
using todo_backend.Models.ResponseDtos;
using TodoList.Frontend.Services;

namespace TodoList.Frontend.Clients
{
    public class Client
    {
        public FluentClient client { get; set; }
        public ILocalStorageService storage { get; set; }

        public Client(ILocalStorageService storage)
        {
            client = new FluentClient("https://localhost:5021/api");
            this.storage = storage;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            var result = await client.PostAsync("Account/login").WithBody(request).As<SignInResponse>();
            await storage.SetItem<string>("token", result.token);
            return result;
        }

        public async Task<SignInResponse> SignUp(SignUpRequest request)
        {
            var result = await client.PostAsync("Account/SignUp").WithBody(request).As<SignInResponse>();
            await storage.SetItem<string>("token", result.token);
            return result;
        }

        internal async Task<TodoListByIDQueryResponse> GetToDoListDetails(GetTodoListRequest input)
        {
            string token = await storage.GetItem<string>("token");
            var result = await client.GetAsync($"TodoList/GetTodoByID").WithBody(input)
                .WithBearerAuthentication(token)
                .As<TodoListByIDQueryResponse> ();
            return result;
        }

        public async Task UpdateTask(UpdateItemRequest input)
        {
            string token = await storage.GetItem<string>("token");
            var result = await client.PutAsync($"Items").WithBody(input)
                .WithBearerAuthentication(token);
        }

        public async Task<List<TodoListQueryResponse>> GetToDoList()
        {
            string token = await storage.GetItem<string>("token");
            var result = await client.GetAsync("TodoList").WithBearerAuthentication(token).As<List<TodoListQueryResponse>> ();
            return result;
        }

        public async Task CreateTask(CreateItemRequest input)
        {
            string token = await storage.GetItem<string>("token");
            var result = await client.PostAsync($"Items").WithBody(input)
                .WithBearerAuthentication(token);
        }
        
        public async Task CreateList(CreateTodoListRequest input)
        {
            string token = await storage.GetItem<string>("token");
            var result = await client.PostAsync($"TodoList").WithBody(input)
                .WithBearerAuthentication(token);
        }
    }
}
