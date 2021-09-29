using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Data;
using todo_backend.Models;
using todo_backend.Models.RequestsDtos;

namespace todo_backend.Commands
{
    public class ItemCommandsHandler
    {
        //Calling database Context
        private readonly MyDbContext _context;
        private IMapper _mapper;
        public ItemCommandsHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task UpdateItem(UpdateItemRequest input)
        {
            var list = _mapper.Map<Item>(input);
            _context.Items.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task CreateItem(CreateItemRequest input)
        {
            var list = _mapper.Map<Item>(input);
            await _context.Items.AddAsync(list);
            await _context.SaveChangesAsync();
        }
    }


}

