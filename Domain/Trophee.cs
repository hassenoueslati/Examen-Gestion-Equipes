using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public enum TypeTrophee
    {
        [Display(Name ="Coupe")]
        Coupe ,
        [Display(Name = "Championnat")]
        Championnat
    }
    public class Trophee
    {
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public Double Recompense { get; set; }
        public int TropheeId { get; set; }
        public TypeTrophee TypeTrophee { get; set; }
        public virtual Equipe Equipe { get; set; }
        public int EquipeFK { get; set; }
    }
}
