using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Models
{
    public class Guitarrista
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }
        
        public int GuitarrasPossuídas { get; set; }
       
        public DateTime Nascimento { get; set; }
        
        public string GuitarristaFav { get; set; }
        public List<Guitarras> Guitarras { get; set; }
    }
}
