using CoralSafe.Data;
using CoralSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoralSafe.Controllers
{
    public class DonateController : Controller
    {
        private readonly DataContext _dataContext;

        public DonateController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var donate = _dataContext.donates.ToList();
            return View(donate);
        }

        public IActionResult Criar()
        {
            int? userId = HttpContext.Session.GetInt32("_Id");
            if (userId == null)
            {
                // Redirecionar o usuário ou mostrar uma mensagem de erro se não estiver logado como ONG
                return Unauthorized("Você precisa estar logado com um usuario para criar uma doacao.");
            }


            ViewBag.UserId = userId; // Armazena o ID da ONG no ViewBag
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Valor,DataDonate,idUserDonate, User")] Donate donate)
        {

            if (ModelState.IsValid)
            {
                _dataContext.Add(donate);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donate);
        }

        public IActionResult Detalhes(int id)
        {
            var donate = _dataContext.donates.Include(d => d.User).FirstOrDefault(d => d.Id == id);
            if (donate == null)
            {
                return NotFound();
            }
            return View(donate);
        }

        public IActionResult Editar(int id)
        {
            var donate = _dataContext.donates.Find(id);
            if (donate == null)
            {
                return NotFound();
            }
            return View(donate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Valor,DataDonate,idUserDonate")] Donate donate)
        {
            if (id != donate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(donate);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonateExists(donate.Id))
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
            return View(donate);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var donate = await _dataContext.donates.FindAsync(id);
            if (donate == null)
            {
                return NotFound();
            }
            _dataContext.donates.Remove(donate);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonateExists(int id)
        {
            return _dataContext.donates.Any(d => d.Id == id);
        }
    }
}

