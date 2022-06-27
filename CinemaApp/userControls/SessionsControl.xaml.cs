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
using System.Windows.Shapes;

namespace CinemaApp.userControls
{
    /// <summary>
    /// Логика взаимодействия для SessionsControl.xaml
    /// </summary>
    public partial class SessionsControl : Window
    {
        public SessionsControl()
        {
            InitializeComponent();
            lvSessions.ItemsSource = Helper.GetContext().Films.Where(p => p.Statuses.Name == "В прокате").ToList();
            dpDateSession_SelectedDate = DateTime.Now;
        }
        Films currentFilm;

        private void sessionTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentTab = ((sender as TabControl).SelectedItem as TabItem).Name;
            switch(currentTab)
            {
                case "scheduleSessionTab":
                    if (currentFilm!=null)
                    {
                        DataContext = currentFilm;
                    }
                    break;
                case "SessionTab":
                    DataContext = null;
                    currentFilm = null;
                    break;
            }
        }

        private void lvSessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvSessions.SelectedIndex>=0)
            {
                currentFilm = (Films)lvSessions.SelectedItem;
                sessionTabControl.SelectedIndex = 1;
            }
        }
        private void dpDateSession_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvSessions.SelectedIndex>=0)
            {
                var sessionfilm = Helper.GetContext().Session.Where(c => c.date = dateSession.SelectedDate && c.FilmId == currentFilm.Id).ToList();
                if(sessionfilm.Count>0)
                {
                    lvSessionFilm.ItemsSource = sessionfilm.ToList();
                }
                else
                {
                    MessageBox.Show("На текущую дату расписания нет");
                    lvSessionsFilm.OtemsSource = null;
                }
            }
        }
    }
}
