using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces.Services
{
    public interface IGuitarraService
    {
        Task<IEnumerable<Guitarras>> GetAll(string orderAscendant, string search = null);
        Task<Guitarras> GetById(int id);
        Task<Guitarras> Create(Guitarras Guitarras);
        Task<Guitarras> Edit(Guitarras Guitarras);
        Task Delete(int id);
        
    }
}
