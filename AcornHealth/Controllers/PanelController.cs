using AcornHealth.Api;
using AcornHealth.Models.Panel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AcornHealth.Controllers {
    public class PanelController : Controller {
        private Database Database { get; }

        public PanelController(Database database) {
            Database = database;
        }

        public IActionResult Login() {
            Debug.WriteLine("Loaded");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authenticate(LoginModel model) {

            var query = "select loginUserName, loginPassword from Logins where loginUserName = @username and loginPassword = @password";
            //var query = "INSERT into EMPLOYEES (Username, Password) VALUES (@username, @password)";
            var result = Database.ExecuteQuery(query, model.Username, model.Password);
            bool validLogin = result.HasRows;
            if (validLogin)
            {
                return RedirectToAction("Profile","Home");
            

            }
          
            Debug.WriteLine("Recived post.");
            return new ContentResult();
        }
    }
}