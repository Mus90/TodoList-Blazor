using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Data;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;
using todo_backend.Models.ResponseDtos;

namespace todo_backend.Queries.TodosQueries
{

    public class TodoQueriesHandler
    {
        //Calling database Context
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public TodoQueriesHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TodoListQueryResponse> GetTodoList()
        {
            var result=  _context.TodoLists.ToList();
            return  _mapper.Map<List<TodoListQueryResponse>>(result);
        }

        public TodoListByIDQueryResponse GetTodoListByID(GetTodoListRequest input)
        {
            var result = _context.TodoLists.Include(x => x.Tasks).FirstOrDefault(x => x.ID == input.id);
            return _mapper.Map<TodoListByIDQueryResponse>(result);
        }
    }
}
