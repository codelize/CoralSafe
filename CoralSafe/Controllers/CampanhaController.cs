using CoralSafe.Data;
using CoralSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoralSafe.Controllers
{
    public class CampanhaController : Controller
    {
        private readonly DataContext _dataContext;

        public CampanhaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var campanhas = _dataContext.campanhas.ToList();
            return View(campanhas);
        }

        public IActionResult Criar()
        {
            int? ongId = HttpContext.Session.GetInt32("_IdOng");
            if (ongId == null)
            {
                // Redirecionar o usuário ou mostrar uma mensagem de erro se não estiver logado como ONG
                return Unauthorized("Você precisa estar logado como uma ONG para criar uma campanha.");
            }


            ViewBag.OngId = ongId; // Armazena o ID da ONG no ViewBag
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("name,descricao,valorMeta,OngId")] Campanha campanha)
        {
            // Obter o ID da ONG da sessão

            if (campanha.Id == null)
            {
                // Trate o caso em que não há ID da ONG na sessão
                return Unauthorized("Você precisa estar logado como uma ONG para criar uma campanha.");
            }
            if (ModelState.IsValid)
            {

                _dataContext.Add(campanha);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campanha);
        }

        public IActionResult Detalhes(int id)
        {
            var campanha = _dataContext.campanhas.Find(id);
            if (campanha == null)
            {
                return NotFound();
            }
            return View(campanha);
        }

        public IActionResult Editar(int id)
        {
            var campanha = _dataContext.campanhas.Find(id);
            if (campanha == null)
            {
                return NotFound();
            }

            int? ongId = HttpContext.Session.GetInt32("_IdOng");
            if (ongId == null)
            {
                // Redirecionar o usuário ou mostrar uma mensagem de erro se não estiver logado como ONG
                return Unauthorized("Você precisa estar logado como uma ONG para criar uma campanha.");
            }


            ViewBag.OngId = ongId;
            return View(campanha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,name,descricao,valorMeta,OngId")] Campanha campanha)
        {
            if (id != campanha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(campanha);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampanhaExists(campanha.Id))
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
            return View(campanha);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var campanha = await _dataContext.campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }
            _dataContext.campanhas.Remove(campanha);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampanhaExists(int id)
        {
            return _dataContext.campanhas.Any(e => e.Id == id);
        }


    }
}
