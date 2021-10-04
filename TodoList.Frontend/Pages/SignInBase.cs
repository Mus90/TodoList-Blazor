using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todo_backend.Controllers;
using TodoList.Frontend.Clients;

namespace TodoList.Frontend.Pages
{
    public class SignInBase:ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }

        [Inject]
        public Client appClient { get; set; }

        public SignInRequest request = new SignInRequest();
        protected async Task OnSubmitClick()
        {
            //authenticate user
            SignInResponse token = await appClient.SignIn(request);
            // redirect user to Todolist page
            navManager.NavigateTo("/TodoList");
        }
    }
}
