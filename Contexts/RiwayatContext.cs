using LKM.Helpers;
using LKM.Models;

namespace LKM.Contexts
{
    public class RiwayatContext
    {
        private string __constr;

        public RiwayatContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<Riwayat> ListRiwayat()
        {
            List<Riwayat> list = new List<Riwayat>();
            string query = "SELECT * FROM simpedo.riwayat";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Riwayat
                {
                    id_riwayat = int.Parse(reader["id_riwayat"].ToString()),
                    id_ternak = int.Parse(reader["id_ternak"].ToString()),
                    berat = decimal.Parse(reader["berat"].ToString()),
                    status = reader["status"].ToString(),
                    tanggal = DateTime.Parse(reader["tanggal"].ToString())
                });
            }

            db.CloseConnection();
            return list;
        }
        public Riwayat GetById(int id)
        {
            Riwayat r = null;
            string query = "SELECT * FROM simpedo.riwayat WHERE id_riwayat=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                r = new Riwayat
                {
                    id_riwayat = int.Parse(reader["id_riwayat"].ToString()),
                    id_ternak = int.Parse(reader["id_ternak"].ToString()),
                    berat = decimal.Parse(reader["berat"].ToString()),
                    status = reader["status"].ToString(),
                    tanggal = DateTime.Parse(reader["tanggal"].ToString())
                };
            }

            db.CloseConnection();
            return r;
        }

        public void Update(int id, Riwayat r)
        {
            string query = @"UPDATE simpedo.riwayat SET 
                            id_ternak=@id_ternak, berat=@berat, status=@status, tanggal=@tanggal,
                            updated_at=CURRENT_TIMESTAMP
                            WHERE id_riwayat=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@id_ternak", r.id_ternak);
            cmd.Parameters.AddWithValue("@berat", r.berat);
            cmd.Parameters.AddWithValue("@status", r.status);
            cmd.Parameters.AddWithValue("@tanggal", r.tanggal);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM simpedo.riwayat WHERE id_riwayat=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            db.CloseConnection();
        }
    }
}
