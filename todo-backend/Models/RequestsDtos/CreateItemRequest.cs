using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_backend.Models.RequestsDtos
{
    public class CreateItemRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int TodoListId { get; set; }
    }
}
