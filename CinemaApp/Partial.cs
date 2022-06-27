using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp
{
    
        public partial class Films
        {
            public ICollection genreFilm
            {
                get
                {
                    return GenreFilms.Select(p => new { title = p.Genre.Name}).ToList();
                }
            }
            public ICollection actrorFilm
            {
                get
                {
                    return ActerFilm.Select(p => new { title = p.Actors.Name }).ToList();
                }
            }
            public ICollection directorsFilm
            {
                get
                {
                    return DirectorFilm.Select(p => new { title = p.Director.Name }).ToList();
                }
            }
        public ICollection sFilm
        {
            get
            {
                return Session.Select(p => new { Hall = p.Hall.HallName, date = p.date, time = p.Time }).ToList();
            }
        }
        }
    
}
