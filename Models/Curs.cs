using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProiectMedii.Models
{
    public class Curs
    {
        public int ID { get; set; }
        [Required, StringLength(70, MinimumLength = 5)]
        public String Denumire { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele profesorului trebuie sa fie de forma ' Nume Prenume'"), Required, StringLength(50, MinimumLength = 6)]
        public String Profesor_Titular { get; set; }


        public int Nr_credite { get; set; }
    }
}
