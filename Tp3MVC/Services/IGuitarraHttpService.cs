using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp3MVC.Models;

namespace Tp3MVC.Services
{
    public interface IGuitarraHttpService
    {
        Task<IEnumerable<GuitarraPresentationModel>> GetAll(string orderAscendant, string search = null);
        Task<GuitarraPresentationModel> GetById(int id);
        Task<GuitarraPresentationModel> Create(GuitarraPresentationModel Guitarras);
        Task<GuitarraPresentationModel> Edit(GuitarraPresentationModel Guitarras);
        Task Delete(int id);
    }
}
