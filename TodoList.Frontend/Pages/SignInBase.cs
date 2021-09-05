using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Frontend.Pages
{
    public class SignInBase:ComponentBase
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
