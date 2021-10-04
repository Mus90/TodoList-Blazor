using System.Threading.Tasks;
using todo_backend.Models.RequestsDtos;

namespace todo_backend.Commands
{
    public interface IItemCommandsHandler
    {
        Task CreateItem(CreateItemRequest input);
        Task UpdateItem(UpdateItemRequest input);
    }
}