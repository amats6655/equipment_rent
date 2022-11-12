﻿using Equipment_rent.Model;
using Equipment_rent.Utilites;
using System.Windows;

namespace Equipment_rent.ViewModel
{
    internal class EditUserVM : UsersVM
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public User user { get; set; }

        #region Commands to add
        private RelayCommand editUser;
        public RelayCommand EditUser(User user)
        {
            get
            {
                return editUser ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;

                    if (UserFirstName == null || UserFirstName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl.RedBlockControl(window, "tb_lastname");
                        SetRedBlockControl.RedBlockControl(window, "tb_firstname");
                    }
                    else if (UserPhone == null)
                    {
                        SetRedBlockControl.RedBlockControl(window, "tb_phone");
                    }
                    else
                    {
                        DataWorker.EditUser(user, UserFirstName + " " + UserLastName, UserPhone);
                        UpdateAllUsersView();
                        window.Close();
                    }
                });
            }
        }
        #endregion
    }
}