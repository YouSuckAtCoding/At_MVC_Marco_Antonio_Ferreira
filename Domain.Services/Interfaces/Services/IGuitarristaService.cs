using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces.Services
{
    public interface IGuitarristaService
    {
        Task<IEnumerable<Guitarrista>> GetAll(string orderAscendant, string search = null);
        Task<Guitarrista> GetById(int id);
        Task<Guitarrista> Create(Guitarrista Guitarristas);
        Task<Guitarrista> Edit(Guitarrista Guitarristas);
        Task Delete(int id);
        Task<bool> IsNameValid(string nome);
    }
}
