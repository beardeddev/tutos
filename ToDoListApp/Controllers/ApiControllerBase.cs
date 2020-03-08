using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoListApp.Models;
using ToDoListApp.Repositories;

namespace TodoListApp.Controllers
{
    public class ApiControllerBase<TEntity, TKey> : ControllerBase
        where TEntity : class, IEntity<TKey>
    {
        private readonly IRepository<TEntity, TKey> repository;

        public ApiControllerBase(IRepository<TEntity, TKey> repository)
        {
            this.repository = repository;
        }

        public virtual IActionResult Get()
        {
            IEnumerable<TEntity> result = repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(TKey id)
        {
            TEntity entity = repository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public virtual IActionResult Create(TEntity entity)
        {
            TEntity result = repository.Insert(entity);
            return CreatedAtRoute(new { @id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(TKey id, TEntity entity)
        {
            TEntity result = repository.Update(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(TKey id)
        {
            TEntity entity = repository.GetById(id);

            if(entity == null)
            {
                return BadRequest(new { @message = "Entity not found" });
            }

            TEntity result = repository.Delete(entity);
            return NoContent();
        }
    }
}