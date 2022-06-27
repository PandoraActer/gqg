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
    /// Логика взаимодействия для CountriesControl.xaml
    /// </summary>
    public partial class ReferencesControl : UserControl
    {
        public ReferencesControl()
        {
            InitializeComponent();
            FillCountries();
            FillGenres();
            FillDirectors();
            FillActors();
        }

        //Обновление таблиц
        private void FillCountries()
        {
            DgCountries.ItemsSource = Helper.GetContext().Countries.ToList();
        }
        private void FillGenres()
        {
            DgGenre.ItemsSource = Helper.GetContext().Genre.ToList();
        }
        private void FillDirectors()
        {
            DgDirectors.ItemsSource = Helper.GetContext().Director.ToList();
        }
        private void FillActors()
        {
            DgActors.ItemsSource = Helper.GetContext().Actors.ToList();
        }

        //Переходы
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentTab = ((sender as TabControl).SelectedItem as TabItem).Name;
            switch (currentTab)
            {
                case "CountriesTab":
                    DataContext = new Countries();
                    break;
                case "GenreTab":
                    DataContext = new Genre();
                    break;
                case "DirectorTab":
                    DataContext = new Director();
                    break;
                default:
                    DataContext = null;
                    break;
            }
        }

        //Добавление/изменение страны
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DgCountries.SelectedIndex >= 0)
            {
                //изменение
                var curentCountry = DataContext as Countries;
                
            }
            else
            {
                if (string.IsNullOrEmpty(TbName.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    //добавление
                    var newCountry = DataContext as Countries;
                    Helper.GetContext().Countries.Add(newCountry);

                }
            }
            //сохранение
          
            Helper.GetContext().SaveChanges();
            FillCountries();
            TbName.Clear();
            DgCountries.UnselectAll();
            DataContext = new Countries();
        }

        private void DgCountries_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgCountries.SelectedIndex >= 0)
            {
                TbName.Text = ((Countries)DgCountries.SelectedItem).Name;
                DataContext = DgCountries.SelectedItem as Countries;
            }
        }

        private void DgCountries_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Countries();
        }

        //Добавление/изменение жанра
        private void BtnAddGenre_Click(object sender, RoutedEventArgs e)
        {
            if(DgGenre.SelectedIndex >= 0)
            {
                var curentGenre = DataContext as Genre;
            }
            else
            {
                if (string.IsNullOrEmpty(TbNameGenre.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newGenre = DataContext as Genre;
                    Helper.GetContext().Genre.Add(newGenre);
                }
            }
            Helper.GetContext().SaveChanges();
            FillGenres();
            TbNameGenre.Clear();
            DgCountries.UnselectAll();
            DataContext = new Countries();
        }

        private void DgGenre_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgGenre.SelectedIndex >= 0)
            {
                TbNameGenre.Text = ((Genre)DgGenre.SelectedItem).Name;
                DataContext = DgGenre.SelectedItem as Genre;
            }
        }

        private void DgGenre_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Genre();
        }

        // Добавление/изменение режисера
        private void BtnAddDirectors_Click(object sender, RoutedEventArgs e)
        {
            if (DgDirectors.SelectedIndex >= 0)
            {
                var curentDirector = DataContext as Director;
            }
            else
            {
                if (string.IsNullOrEmpty(TbNameDirectors.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newDirector = DataContext as Director;
                    Helper.GetContext().Director.Add(newDirector);
                }
            }
            Helper.GetContext().SaveChanges();
            FillDirectors();
            TbNameDirectors.Clear();
            DgDirectors.UnselectAll();
            DataContext = new Director();
        }

        private void DgDirectors_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgDirectors.SelectedIndex >= 0)
            {
                TbNameDirectors.Text = ((Director)DgDirectors.SelectedItem).Name;
                DataContext = DgDirectors.SelectedItem as Director;
            }
        }

        private void DgDirectors_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Director();
        }

        // Добавление/изменение актер
        private void BtnAddActors_Click(object sender, RoutedEventArgs e)
        {
            if (DgActors.SelectedIndex >= 0)
            {
                var curentActors = DataContext as Actors;
            }
            else
            {
                if (string.IsNullOrEmpty(TbNameActors.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newActor = DataContext as Actors;
                    Helper.GetContext().Actors.Add(newActor);
                }
            }
            Helper.GetContext().SaveChanges();
            FillActors();
            TbNameActors.Clear();
            DgActors.UnselectAll();
            DataContext = new Actors();
        }

        private void DgActors_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgActors.SelectedIndex >= 0)
            {
                TbNameActors.Text = ((Actors)DgActors.SelectedItem).Name;
                DataContext = DgActors.SelectedItem as Actors;
            }
        }

        private void DgActors_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Actors();
        }

        private void DgTickets_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgTickets.SelectedIndex >= 0)
            {
                TbNameT.Text = ((Tickets)DgTickets.SelectedItem).ToString();
                DataContext = DgTickets.SelectedItem as Tickets;
            }
        }

        private void DgTickets_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Tickets();
        }

      

        private void BtnAddT_Click(object sender, RoutedEventArgs e)
        {
            if (DgTickets.SelectedIndex >= 0)
            {
                var curentActors = DataContext as Tickets;
            }
            else
            {
                if (string.IsNullOrEmpty(TbNameT.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newActor = DataContext as Tickets;
                    Helper.GetContext().Tickets.Add(newActor);
                }
            }
            Helper.GetContext().SaveChanges();
            FillActors();
            TbNameT.Clear();
            DgTickets.UnselectAll();
            DataContext = new Tickets();

        }

        private void DgHall_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgHall.SelectedIndex >= 0)
            {
                TbHall.Text = ((Hall)DgHall.SelectedItem).HallName;
                DataContext = DgHall.SelectedItem as Hall;
            }
        }

        private void DgHall_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Hall();
        }

        private void BtnHall_Click(object sender, RoutedEventArgs e)
        {
            if (DgHall.SelectedIndex >= 0)
            {
                var curentActors = DataContext as Hall;
            }
            else
            {
                if (string.IsNullOrEmpty(TbHall.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newActor = DataContext as Hall;
                    Helper.GetContext().Hall.Add(newActor);
                }
            }
            Helper.GetContext().SaveChanges();
            FillActors();
            TbHall.Clear();
            DgHall.UnselectAll();
            DataContext = new Hall();
        }

        private void DgSess_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgSess.SelectedIndex >= 0)
            {
                TbNameS.Text = ((Session)DgSess.SelectedItem).HallId.ToString();
                DataContext = DgSess.SelectedItem as Session;
            }
        }

        private void DgSess_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Session();
        }

        private void BtnAddS_Click(object sender, RoutedEventArgs e)
        {
            if (DgSess.SelectedIndex >= 0)
            {
                var curentActors = DataContext as Session;
            }
            else
            {
                if (string.IsNullOrEmpty(TbNameS.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newActor = DataContext as Session;
                    Helper.GetContext().Session.Add(newActor);
                }
            }
            Helper.GetContext().SaveChanges();
            FillActors();
            TbNameS.Clear();
            DgSess.UnselectAll();
            DataContext = new Session();
        }

        private void DgFilm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DgFilm.SelectedIndex >= 0)
            {
                TbNameF.Text = ((Films)DgSess.SelectedItem).Name;
                DataContext = DgFilm.SelectedItem as Films;
            }
        }

        private void DgFilm_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender as DataGrid;
            dataGrid.UnselectAll();
            DataContext = new Films();
        }

        private void BtnAddF_Click(object sender, RoutedEventArgs e)
        {
            if (DgFilm.SelectedIndex >= 0)
            {
                var curentActors = DataContext as Films;
            }
            else
            {
                if (string.IsNullOrEmpty(TbNameF.Text))
                {
                    MessageBox.Show("Не заполнено поле", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var newActor = DataContext as Films;
                    Helper.GetContext().Films.Add(newActor);
                }
            }
            Helper.GetContext().SaveChanges();
            FillActors();
            TbNameF.Clear();
            DgFilm.UnselectAll();
            DataContext = new Films();
        }
    }
}
