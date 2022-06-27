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

namespace CinemaApp.userControls
{
    /// <summary>
    /// Логика взаимодействия для AuthControl.xaml
    /// </summary>
    public partial class AuthControl : UserControl
    {
        public AuthControl()
        {
            InitializeComponent();
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
                MainWindow main = new MainWindow();
                main.mainMenu.IsEnabled = true;
                UserControl userControl = null;
                if (user.RoleId == 1)
                {
                    userControl = new userControls.FilmsControl();
                    main.MainGrid.Children.Add(userControl);    
                }
                if (user.RoleId == 2)
                {                   
                    
                }
            }
        }
    }
}
