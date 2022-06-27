using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void lvMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl userControl = null;
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                //case "MainMenuItem":
                //    userControl = new userControls.MainUserControl();
                //    break;
                case "ReferencesMenuItem":
                    userControl = new userControls.ReferencesControl();
                    break;
                    //case "ThirdMenuItem":
                    //    userControl = new userControls.ThirdUserControl();
                    //    break;
                    //case "FourthMenuItem":
                    //    userControl = new userControls.FourthUserControl();
                    //    break;
            }
            MainGrid.Children.Add(userControl);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("Не заполнены поля", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var user = Helper.GetContext().UserAccount
                .FirstOrDefault(x => x.Password == pbPassword.Password && x.Login == tbLogin.Text);
            if (user == null)
            {
                MessageBox.Show("Неверные логин и пароль", "Ошибка",
                   MessageBoxButton.OK, MessageBoxImage.Error);

                tbLogin.Text = string.Empty;
                pbPassword.Password = string.Empty;
                return;
            }
            else
            {
                Helper.userAccount = user;
             
                mainMenu.IsEnabled = true;
                UserControl userControl = null;
                if (user.RoleId == 1)
                {
                    userControl = new userControls.FilmsControl();
                    MainGrid.Children.Add(userControl);
                }
                if (user.RoleId == 2)
                {

                }
            }
        }
    }
}
