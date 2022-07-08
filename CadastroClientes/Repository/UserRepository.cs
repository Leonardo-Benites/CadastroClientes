using CadastroClientes.Context;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task<string> GetUserPasswordById(int id)
        {
            return await _context.User.Where(x => x.Id == id).Select(x => x.Password).FirstOrDefaultAsync();                ;
        }
        public async Task<List<User>> GetAll()
        {
            var date = DateTime.Now;
            return await _context.User.ToListAsync();
        }
        public async Task Insert(User obj)
        {
            _context.User.Add(obj);
            await _context.SaveChangesAsync();
            }
        public async Task Update(User obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(User obj)
        {
            _context.User.Remove(obj);
            await _context.SaveChangesAsync();
        }


    }
}
