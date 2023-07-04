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


namespace API_TASKS.Controllers
{


    public class ProductController : ApiController
    {
        ShopStoreEF.ApplicationDbContext db = new ShopStoreEF.ApplicationDbContext();

        //2.(A) Create API to (add) product to category
        [HttpPost]
        [Route("api/product/AddProducts")]
        public IHttpActionResult AddProducts([FromBody] productViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product();

            product.Arabic_Name = model.Arabic_Name;
            product.English_Name = model.English_Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Manufacturer = model.Manufacturer;
            product.State = Convert.ToString(true);
            product.Creation_user_id =model.Creation_user_id;
            product.Creation_date = DateTime.Now;   
            product.Cate_ID = model.Cate_ID;

            db.Products.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        //2.(B) Create API to (Edit) product to category

        [HttpPut]
        [Route("api/product/UpdateProduct/{id}")]
        public IHttpActionResult UpdateProduct(int id, [FromBody] productViewModel updatedProduct)
        {
            var product = db.Products.Where(p => p.ID == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            // Update the product properties
            product.Arabic_Name = updatedProduct.Arabic_Name;
            product.English_Name = updatedProduct.English_Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            product.Manufacturer = updatedProduct.Manufacturer;
            product.State = Convert.ToString(true);
            product.Update_user = updatedProduct.Update_user;
            product.Update_date = DateTime.Now;
            product.Cate_ID = updatedProduct.Cate_ID;
            db.SaveChanges();

            return Ok(product);
        }
        //2.(C) Create API to (Delete) product to category
        [HttpDelete]
        [Route("api/product/DeleteProduct/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = db.Products.Where(p => p.ID == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);

            return Ok();
        }


        // 3.(A)Create API to(GetAll) product By category ID

        [HttpGet]
        [Route("api/product/GetProductsByCategoryId/{categoryId}")]
        public IHttpActionResult GetProductsByCategoryId(int categoryId)
        {
            var filteredProducts = db.Products.Where(p => p.Cate_ID == categoryId).ToList();

            if (filteredProducts.Count == 0)
            {
                return NotFound();
            }

            return Ok(filteredProducts);
        }

        //4- Create API to search by name for product / by categoryId & name for product
        //If(category Id = 0 and name = null) get all products

        [HttpGet]
        [Route("api/product/SearchForAllProducts")]
        public IHttpActionResult SearchForAllProducts(int categoryId = 0, string name = null)
        {
            var filteredProducts = new List<Product>();

            if (categoryId == 0 && string.IsNullOrEmpty(name))
            {
                filteredProducts = db.Products.ToList();
            }
            else if (categoryId != 0 && !string.IsNullOrEmpty(name))
            {
                filteredProducts = db.Products
                    .Where(p => p.Cate_ID == categoryId && (p.Arabic_Name.ToLower().Contains(name.ToLower()) || p.English_Name.ToLower().Contains(name.ToLower())))
                    .ToList();
            }
            else if (categoryId != 0 && string.IsNullOrEmpty(name))
            {
                filteredProducts = db.Products.Where(p => p.Cate_ID == categoryId).ToList();
            }
            else if (categoryId == 0 && !string.IsNullOrEmpty(name))
            {
                filteredProducts = db.Products
                    .Where(p => p.Arabic_Name.ToLower().Contains(name.ToLower()) || p.English_Name.ToLower().Contains(name.ToLower()))
                    .ToList();
            }

            if (filteredProducts.Count == 0)
            {
                return NotFound();
            }
            return Ok(filteredProducts);
        }

    }
}
