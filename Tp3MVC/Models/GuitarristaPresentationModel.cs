using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3MVC.Models
{
    public class GuitarristaPresentationModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Remote(action: "IsNameValid", controller: "Guitarrista")]
        public string Nome { get; set; }
        [Required]
        [Range(maximum: 999, minimum: 1)]
        public int GuitarrasPossuídas { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        [StringLength(50)]
        public string GuitarristaFav { get; set; }
        public List<GuitarraPresentationModel> Guitarras { get; set; }
    }
}
