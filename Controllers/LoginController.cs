using API_TASKS.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using API_TASKS.ShopStoreEF;
using System.Web;
using Microsoft.AspNet.Identity;

namespace API_TASKS.Controllers
{
    public class LoginController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Users/Login")]

        public IHttpActionResult Login(UserViewModelcs model)
        {
            if (model == null)
            {
                return BadRequest("Invalid model");
            }

            // Validate the user credentials
            else if (!IsValidUser(model.arabic_name, model.Password))
            {
                return Unauthorized();
            }

          
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(model.arabic_name), null);
            var userId = HttpContext.Current.User.Identity.GetUserId();
            




            return Ok();
        }

        private bool IsValidUser(string username, string password)
        {
            using (var db = new ShopStoreEF.ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.arabic_name == username && u.Password == password);

                if (user != null)
                {
                    return true;
                }
            }

            return false;
        }
           
        
    }
}
