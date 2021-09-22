using Domain.Models;
using Domain.Services.Interfaces;
using Domain.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Services
{
    public class GuitarristaService : IGuitarristaService
    {
        private readonly IGuitarristaRepository _guitarristaRepository;
        public GuitarristaService(IGuitarristaRepository guitarristaRepository)
        {
            _guitarristaRepository = guitarristaRepository;
        }
        public async Task<Guitarrista> Create(Guitarrista Guitarristas)
        {
           return await _guitarristaRepository.Create(Guitarristas); 
        }

        public async Task Delete(int id)
        {
             await _guitarristaRepository.Delete(id);
        }

        public async Task<Guitarrista> Edit(Guitarrista Guitarristas)
        {
            return await _guitarristaRepository.Edit(Guitarristas);
        }

        public async Task<IEnumerable<Guitarrista>> GetAll(string orderAscendant, string search = null)
        {
            return await _guitarristaRepository.GetAll(orderAscendant, search);
        }

        public async Task<Guitarrista> GetById(int id)
        {
            return await _guitarristaRepository.GetById(id);
        }

        public async Task<bool> IsNameValid(string nome)
        {
            var user = await _guitarristaRepository.IsNameValid(nome);
            if (user == null)
            {
                return true;
            }
            return false;
        }
    }
}
