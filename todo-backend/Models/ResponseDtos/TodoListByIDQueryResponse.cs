using System.Collections.Generic;

namespace todo_backend.Models
{
    public class TodoListByIDQueryResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection <Item> Tasks{ get; set; }
    }
}
