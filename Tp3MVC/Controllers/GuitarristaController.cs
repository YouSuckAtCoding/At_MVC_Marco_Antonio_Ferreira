using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Tp3MVC.Services;
using Tp3MVC.Models;

namespace Tp3MVC.Controllers
{
    [Authorize]
    public class GuitarristaController : Controller
    {
        private readonly IGuitarristaHttpService _guitarristaHttpService;
        public GuitarristaController(IGuitarristaHttpService guitarristaHttpService)
        {
            _guitarristaHttpService = guitarristaHttpService;
        }




        // GET: Guitarrista
        public async Task<IActionResult> Index(string orderAscendant, string search = null)
        {
            return View(await _guitarristaHttpService.GetAll(orderAscendant, search));
        }


        // GET: Guitarrista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitarrista = await _guitarristaHttpService.GetById(id.Value);
            if (guitarrista == null)
            {
                return NotFound();
            }

            return View(guitarrista);
        }

        // GET: Guitarrista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guitarrista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GuitarristaPresentationModel guitarrista)
        {
            if (ModelState.IsValid)
            {
                await _guitarristaHttpService.Create(guitarrista);
                return RedirectToAction(nameof(Index));
            }
            return View(guitarrista);
        }

        // GET: Guitarrista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitarrista = await _guitarristaHttpService.GetById(id.Value);
            if (guitarrista == null)
            {
                return NotFound();
            }
            return View(guitarrista);
        }

        // POST: Guitarrista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GuitarristaPresentationModel guitarrista)
        {
            if (id != guitarrista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _guitarristaHttpService.Edit(guitarrista);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GuitarristaExists(guitarrista.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(guitarrista);
        }

        // GET: Guitarrista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitarrista = await _guitarristaHttpService.GetById(id.Value);
            if (guitarrista == null)
            {
                return NotFound();
            }

            return View(guitarrista);
        }

        // POST: Guitarrista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _guitarristaHttpService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GuitarristaExists(int id)
        {
            var guitarrista = await _guitarristaHttpService.GetById(id);
            var exists = guitarrista != null;

            return exists;
        }

        public async Task<IActionResult> IsNameValid(string Nome)
        {
            if (await _guitarristaHttpService.IsNameValid(Nome))
            {
                return Json(true);
            }
            return Json($"Nome {Nome} já está sendo utilizado");
        }

    }


}
