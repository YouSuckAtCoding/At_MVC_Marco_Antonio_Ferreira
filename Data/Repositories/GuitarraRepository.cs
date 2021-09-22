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
    public class GuitarraRepository : IGuitarraRepository
    {
        private readonly Context _context;
        public GuitarraRepository(Context context)
        {
            _context = context;
        }
        public async Task<Guitarras> Create(Guitarras Guitarras)
        {
            var create = _context.Guitarras.Add(Guitarras);
            await _context.SaveChangesAsync();
            return (create.Entity);
        }

        public async Task Delete(int id)
        {
            var guitarras = await GetById(id);
            _context.Guitarras.Remove(guitarras);
            await _context.SaveChangesAsync();
        }

        public async Task<Guitarras> Edit(Guitarras Guitarras)
        {
            var guitarras = _context.Guitarras.Update(Guitarras);
            await _context.SaveChangesAsync();
            return (guitarras.Entity); ;
        }

        public async Task<IEnumerable<Guitarras>> GetAll(string orderAscendant, string search = null)
        {
            var ordem = orderAscendant;
            if (ordem == "true")
            {
                _context.Guitarras.OrderBy(x => x.EquipNome);

            }
            else
            {
                _context.Guitarras.OrderByDescending(x => x.EquipNome);
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                return await _context.Guitarras.ToListAsync();
            }
            return await _context.Guitarras.Where(x => x.EquipNome == search).ToListAsync();
        }

        public async Task<Guitarras> GetById(int id)
        {
            var guitarras = await _context.Guitarras
                   .Include(x => x.Guitarrista)
                   .OrderBy(x => x.EquipNome)
                   .FirstOrDefaultAsync(m => m.Id == id);

            return guitarras;
        }

        
    }
}
