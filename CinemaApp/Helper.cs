using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp
{
    public class Helper
    {
        public static UserAccount userAccount;
      
        //public static CinemaEntities cinemaEntities;

        //public static CinemaEntities GetContext()
        //{
        //    if (cinemaEntities == null)
        //    {
        //        cinemaEntities = new CinemaEntities();
        //    }
        //    return cinemaEntities;
        //}
        public static ModelCinemaContainer1 cinemaModel;
        public static ModelCinemaContainer1 GetContext()
        {
            if(cinemaModel == null)
            {
                cinemaModel = new ModelCinemaContainer1();
            }
            return cinemaModel;
        }
    }
}
