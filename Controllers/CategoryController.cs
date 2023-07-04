using API_TASKS.DataSecurity;
using API_TASKS.Models;
using API_TASKS.ShopStoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Threading;
using Microsoft.AspNet.Identity;

namespace API_TASKS.Controllers
{
    [BasicAuthentication]
 

    public class CategoryController : ApiController
    {
        ShopStoreEF.ApplicationDbContext db = new ShopStoreEF.ApplicationDbContext();
       

        //1.(A) Create API to (getAll) for categories
        [HttpGet]
        [Route("api/category/GetAll")]

        public IHttpActionResult GetAll()
        {
            var Category = db.Categories.Where(e => e.state == true).ToList();
            return Ok(Category);
        }

        //1.(B) Create API to(getAll) for categories
        [HttpGet]
        [Route("api/category/GetCategory/{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            var category = db.Categories.Where(c => c.ID == id && c.state == true).FirstOrDefault();
            if (category == null)
                return NotFound();

            return Ok(category);
        }
        //1.(C) Create API to(Add) for categories
        [HttpPost]
        [Route("api/category/AddCategory")]
        public IHttpActionResult AddCategory([FromBody] categoryViewModel model)
        {


            try
            {
                var category = new Category();

                category.Arabic_name = model.Arabic_name;
                category.English_name = model.English_name;
                category.Start_date = model.Start_date;
                category.End_date = model.End_date;
                category.state = true;
                string id = RequestContext.Principal.Identity.GetUserId();
                category.creation_user_id = int.Parse(id);
                category.creation_date = DateTime.Now;
                db.Categories.Add(category);
                db.SaveChanges();
                    
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();  
        }
        //1.(D) Create API to(Edit) for categories


        [HttpPut]
        [Route("api/category/EditCategory/{id}")]
        public IHttpActionResult EditCategory([FromUri]int id,[FromBody] categoryViewModel updatedCategory)
        {
            var category = db.Categories.Where(c => c.ID == id).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }

            category.Arabic_name = updatedCategory.Arabic_name;
            category.English_name = updatedCategory.English_name;
            category.Start_date = updatedCategory.Start_date;
            category.End_date = updatedCategory.End_date;
            category.state = true;
            var userid = HttpContext.Current.User.Identity.Name;
            category.update_user_ID = int.Parse(userid);
            category.update_Date= DateTime.Now;
            db.SaveChanges();

            return Ok(category);
        }

        //1.(E) Create API to(Delete) for categories
        [HttpDelete]
        [Route("api/Category/DeleteCategory/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Where(c => c.ID == id).FirstOrDefault();

            if (category == null)
                return NotFound();
            var CategoryProducts = db.Products.Where(e => e.Cate_ID == id).Select(c => c.ID).FirstOrDefault();
            if (CategoryProducts == 0)
            {
                category.state = false;
                db.SaveChanges();
            }
            else
                return BadRequest("Category have Products");
            return Ok();
        }

    }
}
