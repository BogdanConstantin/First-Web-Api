﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly Singleton _context;

        public TodoController()
        {
            _context = Singleton.Instance;

        }

        [HttpGet]

        public ActionResult<List<FootBaller>> GetAll()
        {
            return _context.getAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]

        public ActionResult<FootBaller> getItem(long id)
        {
            return _context.SearchItem(id);
        }

    [HttpPost]
        public IActionResult Create([FromBody] FootBaller item)
        {
            _context.add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

       [HttpPut("{id}")]
        public IActionResult Update(long id, FootBaller item)
        {
            var todo = _context.updateItem(id,item);
            if (todo == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _context.deleteItem(id);


            return NoContent();
        }

    }
}