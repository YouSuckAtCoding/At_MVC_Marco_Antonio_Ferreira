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
    public class GuitarraService : IGuitarraService
    {
        private readonly IGuitarraRepository _guitarraRepository;
        public GuitarraService(IGuitarraRepository guitarraRepository)
        {
            _guitarraRepository = guitarraRepository;
        }
        public async Task<Guitarras> Create(Guitarras Guitarras)
        {
            return await _guitarraRepository.Create(Guitarras);
        }

        public async Task Delete(int id)
        {
            await _guitarraRepository.Delete(id);
        }

        public async Task<Guitarras> Edit(Guitarras Guitarras)
        {
            return await _guitarraRepository.Edit(Guitarras);
        }

        public async Task<IEnumerable<Guitarras>> GetAll(string orderAscendant, string search = null)
        {
            return await _guitarraRepository.GetAll(orderAscendant, search);

        }

        public async Task<Guitarras> GetById(int id)
        {
            return await _guitarraRepository.GetById(id);
        }

        
    }
}
