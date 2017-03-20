﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red_software.Model;
using EntityLayer;
using BusinessLayer;
using Red_software.Views;
using Red_software.Notifications;

namespace Red_software.ViewModel
{
    public class ProductCategoriesViewModel : TableModel<ProductCategoryEntity>
    {
        protected override void DeleteItem(object parameter)
        {
            ManageProducts.DeleteProductCategory(SelectedItem);
            RefreshList(parameter);
        }

        protected override void EditItem(object parameter)
        {
            ProductCategoryEntity Item = new ProductCategoryEntity();
            EntityCloner.CloneProperties<ProductCategoryEntity>(Item, SelectedItem);
            EditProductCategoryViewModel EPVM = new EditProductCategoryViewModel(Item, false);
            EditItemView EIV = new EditItemView() { DataContext = EPVM };
            EIV.ShowDialog();
            if (EPVM.SaveEdit)
            {
                Item = EPVM.Item;
                ManageProducts.ModifyProductCategory(Item);
                RefreshList(parameter);
                foreach (var p in List)
                    if (Item.Id == p.Id)
                        SelectedItem = p;
            }
        }

        protected override void NewItem(object parameter)
        {
            ProductCategoryEntity Item = new ProductCategoryEntity();
            EditProductCategoryViewModel EPVM = new EditProductCategoryViewModel(Item, true);
            EditItemView EIV = new EditItemView() { DataContext = EPVM };
            EIV.ShowDialog();
            if (EPVM.SaveEdit)
            {
                ManageProducts.NewProductCategory(EPVM.Item);
                RefreshList(parameter);
                foreach (var p in List)
                    if (Item.Id == p.Id)
                        SelectedItem = p;
            }
        }

        protected override void RefreshList(object parameter)
        {
            List = ManageProducts.ListProductCategories();
        }
    }
}
