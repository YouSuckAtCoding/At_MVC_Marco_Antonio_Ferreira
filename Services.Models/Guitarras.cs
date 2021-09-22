namespace Domain.Models
{
    public class Guitarras
    {
        public int Id { get; set; }
        
        public string EquipNome { get; set; }
        
        public string MarcaEquip { get; set; }
        
        public string EquipType { get; set; }

        public int GuitarristaId { get; set; }
        public Guitarrista Guitarrista { get; set; }
    }
}
