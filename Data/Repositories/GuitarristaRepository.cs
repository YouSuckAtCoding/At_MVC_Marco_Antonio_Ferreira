using Data.Data;
using Domain.Models;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GuitarristaRepository : IGuitarristaRepository
    {
        private readonly Context _context;
        public GuitarristaRepository(Context context)
        {
            _context = context;
        }
        public async Task<Guitarrista> Create(Guitarrista Guitarristas)
        {
            var create = _context.Guitarrista.Add(Guitarristas);
            await _context.SaveChangesAsync();
            return (create.Entity);
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            _context.Guitarrista.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Guitarrista> Edit(Guitarrista Guitarristas)
        {
            var create = _context.Guitarrista.Update(Guitarristas);
            await _context.SaveChangesAsync();
            return (create.Entity);
        }

        public async Task<IEnumerable<Guitarrista>> GetAll(string orderAscendant, string search = null)
        {
            var ordem = orderAscendant;
            if (ordem == "true")
            {
                _context.Guitarrista.OrderBy(x => x.Nome);

            }
            else
            {
                _context.Guitarrista.OrderByDescending(x => x.Nome);
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                return await _context.Guitarrista.ToListAsync();
            }
            return await _context.Guitarrista.Where(x => x.Nome == search).ToListAsync();
        }

        public async Task<Guitarrista> GetById(int id)
        {
            var guitarrista = await _context.Guitarrista
                  .Include(x => x.Guitarras)
                  .OrderBy(x => x.Nome)
                  .FirstOrDefaultAsync(m => m.Id == id);

            return guitarrista;
        }

        public async Task<Guitarrista> IsNameValid(string nome)
        {
            var guitarrista = await _context.Guitarrista.FirstOrDefaultAsync(x => x.Nome == nome);
            return guitarrista;
        }
    }
}
