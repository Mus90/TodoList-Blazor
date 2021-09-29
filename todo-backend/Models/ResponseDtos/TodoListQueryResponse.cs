using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_backend.Models.ResponseDtos
{
    public class TodoListQueryResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
