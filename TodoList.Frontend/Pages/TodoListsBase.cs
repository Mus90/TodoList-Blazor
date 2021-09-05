using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Frontend.Pages
{
    public class TodoListsBase:ComponentBase
    {
        [Inject]
        public NavigationManager navManager { get; set; }
    }
}
