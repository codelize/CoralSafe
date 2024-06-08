using CoralSafe.Data;
using CoralSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoralSafe.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DataContext _produtosRepository;





        private readonly DataContext _dataContext;

        public ProdutoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var items = _dataContext.produtos.Include(i => i.User).ToList();
            return View(items);
        }

        public IActionResult Criar()
        {
            int? userId = HttpContext.Session.GetInt32("_Id");
            if (userId == null)
            {
                // Redirecionar o usuário ou mostrar uma mensagem de erro se não estiver logado como usuário
                return Unauthorized("Você precisa estar logado como um usuário para criar um item.");
            }

            ViewBag.UserId = userId; // Armazena o ID do usuário no ViewBag
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Name,Description,QntPontos,UserId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(produto);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _dataContext.produtos.Include(i => i.User).FirstOrDefault(i => i.ID == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        public IActionResult Editar(int id)
        {
            var produto = _dataContext.produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ID,Name,Description,QntPontos,UserId")] Produto produto)
        {
            if (id != produto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(produto);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(produto.ID))
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
            return View(produto);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var item = await _dataContext.produtos.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _dataContext.produtos.Remove(item);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _dataContext.produtos.Any(i => i.ID == id);
        }
    }
}

