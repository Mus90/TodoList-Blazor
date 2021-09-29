using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Controllers;
using todo_backend.Data;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;

namespace todo_backend.Commands.TodosQueries
{
    public class TodoCommandsHandler
    {
        //Calling database Context
        private readonly MyDbContext _context;
        private IMapper _mapper;
        public TodoCommandsHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void UpdateTodoList(UpdateTodoListRequest input)
        {
            var list = _mapper.Map<TodoList>(input);
            _context.TodoLists.Update(list);
            _context.SaveChanges();

        }
        
        public async Task CreateTodoList(CreateTodoListRequest input)
        {
            var list = _mapper.Map<TodoList>(input);
            await _context.TodoLists.AddAsync(list);
            _context.SaveChanges();

        }
    }
}
