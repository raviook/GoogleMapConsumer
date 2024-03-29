using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapConsumer.Models;
namespace GoogleMapConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController: ControllerBase
    {
        private const int V = 404;
        private readonly GoogleMapConsumerContext _context;

        public TodoController(GoogleMapConsumerContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        // GET: api/Todo
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
{
    return await _context.TodoItems.ToListAsync();
}

// GET: api/Todo/5
[HttpGet("{id}")]
public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
{
    var todoItem = await _context.TodoItems.FindAsync(id);

    if (todoItem == null)
    {
        NotFoundResult nf=new NotFoundResult();
        return nf;
    }
    return todoItem;
}
}

}

