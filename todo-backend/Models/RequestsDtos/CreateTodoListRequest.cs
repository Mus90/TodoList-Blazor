namespace todo_backend.Models.RequestsDtos
{
    public class CreateTodoListRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
