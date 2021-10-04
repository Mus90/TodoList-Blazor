using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_backend.Commands;
using todo_backend.Data;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;

namespace todo_backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemCommandsHandler _commands;
        public ItemsController( ItemCommandsHandler commands)
        {
           
            _commands = commands;
        }


        // PUT: api/Items
        [HttpPut]
        public async Task<IActionResult> PutItem(UpdateItemRequest input)
        {
            await _commands.UpdateItem(input);
            return Ok(input);

           }

        // POST: api/Items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(CreateItemRequest input)
        {
            await _commands.CreateItem(input);
            return Ok();
        }

    }
}
