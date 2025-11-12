
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class TodoController : ControllerBase
    {
        [Route("/api/todo")] // GET /api/todo
        public IActionResult GetAllTodos()
        {
            return Ok(TodoList.Tasks.Values);
        }

        [Route("/api/todo/{id}")] // GET /api/todo/4
        public IActionResult GetTodoById(int id)
        {
            if (!TodoList.Tasks.ContainsKey(id))
            {
                return NotFound();
            }

            return Ok(TodoList.Tasks[id]);
        }

        [HttpPost]
        [Route("/api/todo")] // POST /api/todo
        // Model Binding
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            if (TodoList.Tasks.ContainsKey(todo.Id))
                return Conflict(todo);

            TodoList.Tasks.Add(todo.Id, todo);

            return Created(); //asp.net vai mudar para um No Content.
        }

        [HttpPut]
        [Route("/api/todo/{id}")] // POST /api/todo
        // Model Binding
        public IActionResult CreateTodo([FromBody] Todo todo, int id)
        {
            if (id != todo.Id)
                return BadRequest();

            if (!TodoList.Tasks.ContainsKey(id))
                return NotFound();

            var existing = TodoList.Tasks[id];

            existing.Title = todo.Title;
            existing.Description = todo.Description;
            existing.IsCompleted = todo.IsCompleted;

            return Ok(existing);
        }

        [HttpDelete] 
        [Route("/api/todo/{id}")]
        public IActionResult Delete(int id)
        {
            if (!TodoList.Tasks.ContainsKey(id))
                return NotFound();

            TodoList.Tasks.Remove(id);

            return NoContent();
        }
    }
}
