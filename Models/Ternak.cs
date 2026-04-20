namespace LKM.Models
{
    public class Ternak
    {
        public int id_ternak { get; set; }
        public string nama_ternak { get; set; }
        public decimal berat { get; set; }
        public int umur { get; set; }
        public string status { get; set; }
        public int id_user { get; set; }
    }
}