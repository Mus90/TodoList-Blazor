using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Models.RequestsDtos;
using todo_backend.Models.ResponseDtos;

namespace todo_backend.Models
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateTodoListRequest, TodoList>();
            CreateMap<CreateTodoListRequest, TodoList>();
            CreateMap<TodoList, TodoListByIDQueryResponse>();
            CreateMap<TodoList, TodoListQueryResponse>();
            CreateMap<UpdateItemRequest, Item>();
            CreateMap<CreateItemRequest, Item>();

        }
    }
}
