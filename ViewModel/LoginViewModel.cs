using Poster.Model;
using Poster.Model.DBModels;
using Poster.Model.Tools;
using Poster.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Poster.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private PosterData _model;
        private CommandTemplate _openAdminWindow;
        private CommandTemplate _openLoginUserWindow;
        private Window _window;
        public LoginViewModel(Window window, PosterData model)
        {
            _window = window;
            _model = model;
        }

        public CommandTemplate CreateLoginUserWindow
        {
            get
            {
                if (_openLoginUserWindow == null)
                    _openLoginUserWindow = new CommandTemplate(AddLoginUserWindow);
                return _openLoginUserWindow;
            }

        }
        public CommandTemplate CreateAdminWindow
        {
            get
            {
                if (_openAdminWindow == null)
                    _openAdminWindow = new CommandTemplate(AddAdminWindow);
                return _openAdminWindow;
            }
        }

        public void AddLoginUserWindow(object obj)
        {
            LoginUserWindow loginUserWindow = new LoginUserWindow();
            LoginUserVeiwModel loginUserWindowViewModel = new LoginUserVeiwModel(loginUserWindow, _model);

            _window.Hide();

            loginUserWindow.DataContext = loginUserWindowViewModel;
            loginUserWindow.ShowDialog();
            _window.Show();
        }
        public void AddAdminWindow(object obj)
        {
            AdminManagementWindow adminManagementWindow = new AdminManagementWindow();
            AdminManagementViewModel adminManagementViewModel = new AdminManagementViewModel();

            _window.Hide();

            adminManagementWindow.DataContext = adminManagementViewModel;
            adminManagementWindow.ShowDialog();
            _window.Show();
        }

        public void OnClosing(object sender, System.ComponentModel.CancelEventArgs e) { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
