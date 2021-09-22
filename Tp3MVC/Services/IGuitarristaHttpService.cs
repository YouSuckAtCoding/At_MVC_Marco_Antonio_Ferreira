using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp3MVC.Models;

namespace Tp3MVC.Services
{
    public interface IGuitarristaHttpService
    {
        Task<IEnumerable<GuitarristaPresentationModel>> GetAll(string orderAscendant, string search = null);
        Task<GuitarristaPresentationModel> GetById(int id);
        Task<GuitarristaPresentationModel> Create(GuitarristaPresentationModel Guitarristas);
        Task<GuitarristaPresentationModel> Edit(GuitarristaPresentationModel Guitarristas);
        Task Delete(int id);
        Task<bool> IsNameValid(string nome);
    }
}
