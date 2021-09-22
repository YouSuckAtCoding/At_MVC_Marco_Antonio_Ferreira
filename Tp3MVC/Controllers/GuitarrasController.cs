using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Tp3MVC.Services;
using Tp3MVC.Models;

namespace Tp3MVC.Controllers
{
        [Authorize]
    public class GuitarrasController : Controller
    {
        
        private readonly IGuitarraHttpService _guitarrasHttpService;
        private readonly IGuitarristaHttpService _guitarristaHttpService;
        public GuitarrasController(IGuitarraHttpService guitarrasHttpService, IGuitarristaHttpService guitarristaHttpService)
        {
            _guitarrasHttpService = guitarrasHttpService;
            _guitarristaHttpService = guitarristaHttpService;
        }

        // GET: Guitarras
        public async Task<IActionResult> Index(string orderAscendant, string search)
        {
            return View(await _guitarrasHttpService.GetAll(orderAscendant, search));
        }

        // GET: Guitarras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitarras = await _guitarrasHttpService.GetById(id.Value);
            if (guitarras == null)
            {
                return NotFound();
            }

            return View(guitarras);
        }
        private async Task SelectGuitarrists(int? GuitarristaId = null)
        {
            var guitarrists = await _guitarristaHttpService.GetAll("true");
            ViewBag.Guitarristas = new SelectList(guitarrists, nameof(GuitarristaPresentationModel.Id), nameof(GuitarristaPresentationModel.Nome), GuitarristaId);
        }
        // GET: Guitarras/Create
        public async Task<IActionResult> Create()
        {
            await SelectGuitarrists ();
            return View();
        }

        // POST: Guitarras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GuitarraPresentationModel guitarras)
        {
            if (ModelState.IsValid)
            {
                await _guitarrasHttpService.Create(guitarras);
                return RedirectToAction(nameof(Index));
            }
            await SelectGuitarrists(guitarras.GuitarristaId);
            return View(guitarras);
        }

        // GET: Guitarras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitarras = await _guitarrasHttpService.GetById(id.Value);
            if (guitarras == null)
            {
                return NotFound();
            }
            await SelectGuitarrists(guitarras.GuitarristaId);
            return View(guitarras);
        }

        // POST: Guitarras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  GuitarraPresentationModel guitarras)
        {
            if (id != guitarras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _guitarrasHttpService.Edit(guitarras);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await GuitarrasExists(guitarras.Id))
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
            await SelectGuitarrists(guitarras.GuitarristaId);
            return View(guitarras);
        }

        // GET: Guitarras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guitarras = await _guitarrasHttpService.GetById(id.Value); 
            if (guitarras == null)
            {
                return NotFound();
            }

            return View(guitarras);
        }

        // POST: Guitarras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _guitarrasHttpService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> GuitarrasExists(int id)
        {
            var guitarras = await _guitarrasHttpService.GetById(id);
            var any = guitarras != null;
            return any;
        }
    }
}
