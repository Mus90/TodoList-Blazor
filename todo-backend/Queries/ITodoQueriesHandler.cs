using System.Collections.Generic;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;
using todo_backend.Models.ResponseDtos;

namespace todo_backend.Queries.TodosQueries
{
    public interface ITodoQueriesHandler
    {
        List<TodoListQueryResponse> GetTodoList();
        TodoListByIDQueryResponse GetTodoListByID(GetTodoListRequest input);
    }
}