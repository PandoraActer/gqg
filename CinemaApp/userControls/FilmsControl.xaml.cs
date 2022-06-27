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
    /// Логика взаимодействия для FilmsControl.xaml
    /// </summary>
    public partial class FilmsControl : UserControl
    {
        List<Actors> actorfilm = new List<Actors>();
        List<Genre> genrefilm = new List<Genre>();
        public FilmsControl()
        {
            InitializeComponent();
            lbRatinf.ItemsSource = Helper.GetContext().Ratings.ToList();
            lvFilms.ItemsSource = Helper.GetContext().Films.ToList();
            cbDirector.ItemsSource = Helper.GetContext().Director.ToList();
            cbStatusFilm.ItemsSource = Helper.GetContext().Films.ToList();
            LvGenre.ItemsSource = Helper.GetContext().Genre.ToList();
            lvActorFilm.ItemsSource = Helper.GetContext().ActerFilm.ToList();
        }
        List<Director> directors = new List<Director>();
        private void btnAddDirector_Click(object sender, RoutedEventArgs e)
        {
            var currentDirector = (Director)cbDirector.SelectedItem;
            if (cbDirector.SelectedIndex >= 0)
            {
                if (directors.Where(p => p.Id == currentDirector.Id).FirstOrDefault() == null)
                {
                    directors.Add(new Director()
                    {
                        Name = currentDirector.Name
                    });
                    lvDirectorFilm.ItemsSource = directors.ToList();

                }
                else
                {
                    tbErrorDirector.Visibility = Visibility.Visible;
                    tbErrorDirector.Text = "РЕЖИССЕР УЖЕ В СПИСКЕ";

                }
            }

            else
            {
                tbErrorDirector.Visibility = Visibility.Visible;
                tbErrorDirector.Text = "* выберите режиссера";
            }
        }


        private void btnAddDiractor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbDirector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbErrorDirector.Visibility = Visibility.Hidden;
        }

        private void cMenuDirector_Click(object sender, RoutedEventArgs e)
        {
            var directorfilms = DataContext as DirectorFilm;

            int index = lvDirectorFilm.SelectedIndex;
            if (index > -1)
            {
                lvDirectorFilm.SelectedItem = Helper.GetContext().DirectorFilm.ToList();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNameFilm.Text) ||
                string.IsNullOrEmpty(tbDescritionFilm.Text) ||
                string.IsNullOrEmpty(tbYearFilm.Text) ||
                string.IsNullOrEmpty(tbDurationFilm.Text) ||
                string.IsNullOrEmpty(tbPriceFilm.Text))
            {
                MessageBox.Show("Не заполнены поля", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var newFilm = DataContext as Films;
            newFilm.Id = ((Ratings)lbRatinf.SelectedItem).Id;
            newFilm.Name = tbNameFilm.Text;
            newFilm.Year = int.Parse(tbYearFilm.Text);
            newFilm.Duration = int.Parse(tbDurationFilm.Text);
            newFilm.Price = decimal.Parse(tbPriceFilm.Text);

            Helper.GetContext().Films.Add(newFilm);
            foreach (var direcor in directors)
            {
                DataContext = new DirectorFilm();
                var directors = DataContext as DirectorFilm;
                directors.FilmId = newFilm.Id;
                directors.DirectorId = direcor.Id;
                Helper.GetContext().DirectorFilm.Add(directors);
            }
            Helper.GetContext().SaveChanges();
            lvFilms.ItemsSource = Helper.GetContext().Films.ToList();
        }
        private void filmTabControl_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            string currentTab = ((sender as TabControl).SelectedItem as TabItem).Name;
            switch (currentTab)
            {

            }
        }
        List<Genre> genresFilm = new List<Genre>();
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var genre = sender as CheckBox;
            if (genre.IsChecked == true)
            {
                if (genresFilm.Where(c => c.IdGenre == Helper.GetContext().Genre.Where(p => p.Name == (string)genre.Content).FirstOrDefault().IdGenre).FirstOrDefault() == null)//проверка на отсутсвие элемента в списке
                {
                    genresFilm.Add(new Genre()//добавление в список
                    {
                        IdGenre = Helper.GetContext().Genre.First(p => p.Name == (string)genre.Content).IdGenre
                    });

                }
            }
        }
        private void cbGenre_Unchecked(object sender, RoutedEventArgs e)
        {
            var genre = sender as CheckBox;
            if (genre.IsChecked == false)
            {
                int index = genresFilm.FindIndex(x => x.IdGenre == Helper.GetContext().Genre.Where(p => p.Name == (string)genre.Content).FirstOrDefault().IdGenre);
                genresFilm.RemoveAt(index);//удаление списка
            }
        }

        private void lvNewActorFilm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tbactror = (TextBlock)sender;
            DragDrop.DoDragDrop(tbactror, tbactror.Text, DragDropEffects.Copy);
        }

        private void lvNewActorFilm_Drop(object sender, DragEventArgs e)
        {
            var data = (string)e.Data.GetData(DataFormats.Text);
            actorfilm.Add(new Actors()
            {
                Id = Helper.GetContext().Actors.FirstOrDefault(p => p.Name == data).Id,
                Name = data
            });
            lvNewActorFilm.ItemsSource = actorfilm.ToList();
        }
    }
}
    
    


