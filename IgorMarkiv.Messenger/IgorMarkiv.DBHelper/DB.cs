using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBHelper.Model;
using System.Data.Entity;

namespace DBHelper
{
    public class DB
    {
        public List <Categories> GetListOfCategories()
        {
            using (var context = new AmwayProductManagerHelperDBEntities())
            {
                List <Categories> categories = context.Categories.ToList();
                return categories;
            }
        }

        public List<Products> GetListOfProducts()
        {
            using (var context = new AmwayProductManagerHelperDBEntities())
            {
                List<Products> products = context.Products.ToList();
                return products;
            }
        }

        public bool TryAddProduct(string productName, int productPrice, int productPv, int productCategory, string saveImagePath)
        {
            using (var context = new AmwayProductManagerHelperDBEntities())
            {
                Categories categories = context.Categories.Where(ctgr => ctgr.id == productCategory).SingleOrDefault();

                Products product = new Products()
                {
                    name = productName,
                    price = productPrice,
                    PV = productPv,
                    category = productCategory,
                    Categories = categories,
                    PreviewImage = saveImagePath,
                };

                categories.Products.Add(product);
                context.Products.Add(product);
                context.SaveChanges();

                return true;
            }
        }

        public Categories GetCategoryByName(string name)
        {
            using (var context = new AmwayProductManagerHelperDBEntities())
            {
                Categories categories = context.Categories.Where(ct => ct.name == name).FirstOrDefault();
                if (categories != null){return categories;}return categories; ///////////////////////////////////////////////////////////////////////
            }
        }


    }
}

        