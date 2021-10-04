using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Commands.TodosQueries;
using todo_backend.Data;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;
using todo_backend.Queries.TodosQueries;

namespace todo_backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[Controller]")]

    public class TodoListController : ControllerBase
    {
        
        //Calling database Context
        private readonly TodoQueriesHandler _queries;
        private readonly TodoCommandsHandler _commands;
        public TodoListController(TodoQueriesHandler queries, TodoCommandsHandler commands)
        {
            _queries = queries;
            _commands = commands;
        }
        // GET: api/TodoLists
        [HttpGet]
        public IActionResult GetTodoList()
        {
            var result = _queries.GetTodoList();
            return Ok(result);
        }

        // GET : api/TodoList/id
        [HttpGet("GetTodoByID")]
        public IActionResult GetTodoByID (GetTodoListRequest input)
        {
            var result = _queries.GetTodoListByID(input);
            return Ok(result);
        }

        // PUT : api/TodoList/id
        [HttpPut("{id}")]
        public IActionResult UpdateTodoList (UpdateTodoListRequest input)
        {
            _commands.UpdateTodoList(input);
            return Ok("Successful");
        }

        //POST : api/TodoList
        [HttpPost]
        public async Task<IActionResult> PostTodoList (CreateTodoListRequest input)
        {
           await _commands.CreateTodoList(input);
            return Ok("Successful");
        }

    }

}