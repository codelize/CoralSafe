using CoralSafe.Data;
using CoralSafe.DTO;
using CoralSafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoralSafe.Controllers
{
    public class OngController : Controller
    {
        private readonly DataContext _dataContext;

        public OngController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Login()
        {
            var session = HttpContext.Session.GetInt32("_IdOng");

            if (_dataContext.ongs.Find(session) != null)
            {
                return RedirectToAction("PerfilPage");
            }
            return View();
        }

        public IActionResult EfetuarLogin(LoginOngDTO request)
        {
            var getOng = _dataContext.ongs.FirstOrDefault(x => x.email == request.email);

            if (getOng == null)
            {
                return BadRequest("Email não encontrado");
            }

            HttpContext.Session.SetString("_EmailOng", getOng.email);
            HttpContext.Session.SetInt32("_IdOng", getOng.Id);

            return RedirectToAction("PerfilPageOng");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("Name,Description,CreatedOng,endereco,estado,telefone, email, cnpj")] Ong ong)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(ong);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return BadRequest("Preencha todos os campos");

        }
        public IActionResult PerfilPageOng()
        {
            var id = HttpContext.Session.GetInt32("_IdOng");

            var ong = _dataContext.ongs.Find(id);
            ViewBag.Ong = ong;

            return View();
        }

        public IActionResult UpdateOng(int id, Ong request)
        {
            var getOng = _dataContext.ongs.Find(id);

            getOng.Name = request.Name != null ? request.Name : getOng.Name;
            getOng.email = request.email != null ? request.email : getOng.email;
            getOng.Description = request.Description != null ? request.Description : getOng.Description;
            getOng.estado = request.estado != null ? request.estado : getOng.estado;
            getOng.endereco = request.endereco != null ? request.endereco : getOng.endereco;
            getOng.CreatedOng = request.CreatedOng != null ? request.CreatedOng : getOng.CreatedOng;
            getOng.cnpj = request.cnpj != null ? request.cnpj : getOng.cnpj;
            getOng.telefone = request.telefone != null ? request.telefone : getOng.telefone;

            _dataContext.ongs.Update(getOng);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPageOng");
        }

        public async Task<IActionResult> Delete()
        {
            var OngId = HttpContext.Session.GetInt32("_IdOng");
            var ong = await _dataContext.ongs.FindAsync(OngId);
            if (ong != null)
            {
                _dataContext.ongs.Remove(ong);
            }
            else
            {
                return BadRequest("Ong não existe");
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Cadastrar));
        }
    }
}
