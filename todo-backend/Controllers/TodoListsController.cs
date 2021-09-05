using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Data;
using todo_backend.Models;

namespace todo_backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[Controller]")]

    public class TodoListController : ControllerBase
    {
        
        //Calling database Context
        private readonly MyDbContext _context;
        public TodoListController (MyDbContext context)
        {
            _context = context;
        }
        // GET: api/TodoLists
        [HttpGet]
        public IActionResult GetTodoList()
        {

            var result = _context.TodoLists.ToList();
            return Ok(result);
        }

        // GET : api/TodoList/id
        [HttpGet("{id}")]
        public IActionResult GetTodoByID (int id)
        {
            var result = _context.TodoLists.Where(x => x.ID == id);
            return Ok(result);
        }

        // PUT : api/TodoList/id
        [HttpPut("{id}")]
        public IActionResult EditTodoList (TodoList todo)
        {
            _context.TodoLists.Add(todo);
            _context.SaveChanges();
            return Ok("Successful");
        }

        //POST : api/TodoList
        [HttpPost]
        public IActionResult PostTodoList (TodoList todo)
        {
            _context.TodoLists.Add(todo);
            _context.SaveChanges();
            return Ok("Successful");
        }

        //Delete : api/TodoList/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList (int id)
        {
            var todo = await _context.TodoLists.FindAsync(id);
            _context.TodoLists.Remove(todo);
            _context.SaveChanges();
            return Ok("sSuccessful");
        }
    }

}