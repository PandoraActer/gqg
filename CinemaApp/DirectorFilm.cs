//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class DirectorFilm
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public int FilmId { get; set; }
    
        public virtual Director Director { get; set; }
        public virtual Films Films { get; set; }
    }
}
