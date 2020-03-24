using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCategoryRepository context;

        /// <summary>
        /// Constructor for the ProductRepository that initilizes that repository
        /// </summary>
        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories); // ***
        }

        #region Create

        /// <summary>
        /// Method to create a product category
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        // Display a page to fill the details of the products
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Edit
        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategoryToEdit.Category = productCategory.Category;
               
                context.Commit();

                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Delete
        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}