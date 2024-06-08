using CoralSafe.Data;
using CoralSafe.DTO;
using CoralSafe.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoralSafe.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("name,password,email")] User user)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(user);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        public IActionResult Login()
        {
            var session = HttpContext.Session.GetInt32("_Id");

            if (_dataContext.users.Find(session) != null)
            {
                return RedirectToAction("PerfilPage");
            }
            return View();
        }

        public IActionResult EfetuarLogin(LoginDTO request)
        {
            var getUser = _dataContext.users.FirstOrDefault(x => x.email == request.email);

            if (getUser == null)
            {

                return BadRequest();
            }
            if ((request.password != getUser.password))
            {
                //TODO: Ajustar retorno para compor card de responsta
                return BadRequest();
            }

            HttpContext.Session.SetString("_Email", getUser.email);
            HttpContext.Session.SetInt32("_Id", getUser.id);

            return RedirectToAction("PerfilPage");
        }
        public IActionResult PerfilPage()
        {
            // Tenta recuperar o ID do usuário da sessão.
            var id = HttpContext.Session.GetInt32("_Id");

            if (id == null)
            {
                // Se o ID não estiver na sessão, redireciona para a página de login ou outra página adequada.
                return RedirectToAction("Login");
            }

            try
            {
                // Busca o usuário no banco de dados usando o ID encontrado.
                var user = _dataContext.users.Find(id);

                if (user == null)
                {
                    // Se não encontrou nenhum usuário com o ID, mostra uma mensagem de erro ou redireciona.
                    ViewBag.ErrorMessage = "Usuário não encontrado!";
                    return View("Error");
                }

                // Passa o usuário para a view através do ViewBag.
                ViewBag.User = user;

                // Retorna a view PerfilPage.
                return View();
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage($"Erro ao acessar a página de perfil: {ex.Message}");

                // Configura uma mensagem de erro e retorna uma página de erro.
                ViewBag.ErrorMessage = "Ocorreu um problema ao processar sua solicitação.";
                return View("Error");
            }
        }

        public IActionResult UpdatePerfil(int id, UpdatePerfilDTO request)
        {
            var getUser = _dataContext.users.Find(id);

            getUser.name = request.name != null ? request.name : getUser.name;
            getUser.email = request.email != null ? request.email : getUser.email;


            _dataContext.users.Update(getUser);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPage");
        }

        public async Task<IActionResult> Delete()
        {
            var userId = HttpContext.Session.GetInt32("_Id");
            var user = await _dataContext.users.FindAsync(userId);
            if (user != null)
            {
                _dataContext.users.Remove(user);
            }
            else
            {
                return BadRequest("Usuario não existe");
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
