﻿using EntityLayer;
using BusinessLayer;
using Red_software.Views;
using Red_software.Model;
using System;
using Red_software.Notifications;

namespace Red_software.ViewModel
{
    public class PartnersViewModel : TableModel<PartnerEntity>
    {
        public PartnersViewModel()
        {
            ItemName = "partner";
            TableName = "Partners";
        }
        protected override void DeleteItem(object parameter)
        {

            if (ManagePartners.DeletePartner(SelectedItem))
                RefreshList(parameter);
            else
            {
                NotificationProvider.Error("Delete partner error", "This partner is set to one or more transactions.");
            }
        }

        protected override void EditItem(object parameter)
        {
            PartnerEntity Item = new PartnerEntity();
            EntityCloner.CloneProperties<PartnerEntity>(Item, SelectedItem);
            EditPartnerViewModel EPVM = new EditPartnerViewModel(Item, false, ItemName);
            EditItemWindow EIV = new EditItemWindow() { DataContext = EPVM };
            EIV.ShowDialog();
            if (EPVM.SaveEdit)
            {
                Item = EPVM.Item;
                RefreshList(parameter);
                foreach (var p in List)
                    if (Item.Id == p.Id)
                        SelectedItem = p;
            }
        }

        protected override void NewItem(object parameter)
        {
            PartnerEntity Item = new PartnerEntity();
            EditPartnerViewModel EPVM = new EditPartnerViewModel(Item, true, ItemName);
            EditItemWindow EIV = new EditItemWindow() { DataContext = EPVM };
            EIV.ShowDialog();
            if (EPVM.SaveEdit)
            {
                Item = EPVM.Item;
                RefreshList(parameter);
                foreach (var p in List)
                    if (Item.Id == p.Id)
                        SelectedItem = p;
            }
        }

        protected override void RefreshList(object parameter)
        {
            List = ManagePartners.ListPartners();
        }
    }
}
