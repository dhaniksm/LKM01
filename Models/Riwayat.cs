namespace LKM.Models
{
    public class Riwayat
    {
        public int id_riwayat { get; set; }
        public int id_ternak { get; set; }
        public decimal berat { get; set; }
        public string status { get; set; }
        public DateTime tanggal { get; set; }
    }
}
