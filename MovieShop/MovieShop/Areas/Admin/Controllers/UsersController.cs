using MovieShop.Data.Interfaces;
using MovieShop.ViewModels.Admin.Users;
using System.Linq;
using System.Web.Mvc;

namespace MovieShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Users
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult ListUsers()
        {
            var users = _unitOfWork.User.GetUsers();
            var model = users.Select(u => new ListUsersViewModel
            {
                UserId = u.Id,
                Name = u.Name,
                Email = u.Email
            });

            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        }
    }
}