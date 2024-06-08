using CoralSafe.Data;
using CoralSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoralSafe.Controllers
{
    public class FeedController : Controller
    {
        private readonly DataContext _context;

        public FeedController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new FeedView
            {
                Produtos = await _context.produtos.ToListAsync(),
                Campanhas = await _context.campanhas.ToListAsync()
            };

            return View(viewModel);
        }
    }
}
