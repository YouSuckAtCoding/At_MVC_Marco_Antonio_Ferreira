using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp3MVC.Models
{
    public class GuitarraPresentationModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string EquipNome { get; set; }
        [Required]
        [StringLength(50)]
        public string MarcaEquip { get; set; }
        [Required]
        [StringLength(50)]
        public string EquipType { get; set; }

        public int GuitarristaId { get; set; }
        public GuitarristaPresentationModel Guitarrista { get; set; }
    }
}
