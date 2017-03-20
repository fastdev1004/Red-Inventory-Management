﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ManageProducts
    {
        public static List<ProductEntity> ListProducts()
        {
            return ProductProvider.List();
        }

        public static bool NewProduct(ProductEntity product)
        {
            return ProductProvider.Add(product);
        }
        public static bool DeleteProduct(ProductEntity product)
        {
            return ProductProvider.Remove(product);
        }
        public static bool ModifyProduct(ProductEntity product)
        {
            return ProductProvider.Modify(product);
        }

        public static List<ProductCategoryEntity> ListProductCategories()
        {
            return ProductCategoryProvider.List();
        }

        public static bool NewProductCategory(ProductCategoryEntity product)
        {
            return ProductCategoryProvider.Add(product);
        }
        public static bool DeleteProductCategory(ProductCategoryEntity product)
        {
            return ProductCategoryProvider.Remove(product);
        }
        public static bool ModifyProductCategory(ProductCategoryEntity product)
        {
            return ProductCategoryProvider.Modify(product);
        }
    }
}
