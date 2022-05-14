using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Membre
    {
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Key]
        public int Identifiant { get; set; }
        [Required(ErrorMessage ="Champs obligatoire")]
        public String Nom { get; set; }
        [Required(ErrorMessage = "Champs obligatoire")]
        public String Prenom { get; set; }

        public virtual List<Contrat> Contrats { get; set; }

    }
}
