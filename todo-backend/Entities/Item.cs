

namespace todo_backend.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public int TodoListId { get; set; }
    }
}
