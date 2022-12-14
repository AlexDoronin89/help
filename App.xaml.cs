using Poster.Model;
using Poster.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Poster
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void AppStartup(object sender, StartupEventArgs e)
        {
            PosterData model = new PosterData();
            LoginWindow window = new LoginWindow();
            LoginViewModel viewModel = new LoginViewModel(window, model);

            window.Closing += viewModel.OnClosing;

            window.DataContext = viewModel;
            window.ShowDialog();
            window.Close();
        }
    }
}
