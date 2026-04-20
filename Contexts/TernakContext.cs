using LKM.Models;
using Npgsql;
using LKM.Helpers;

namespace LKM.Contexts
{
    public class TernakContext
    {
        private string __constr;

        public TernakContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<Ternak> ListTernak()
        {
            List<Ternak> list = new List<Ternak>();
            string query = "SELECT * FROM simpedo.ternak";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Ternak
                {
                    id_ternak = int.Parse(reader["id_ternak"].ToString()),
                    nama_ternak = reader["nama_ternak"].ToString(),
                    berat = decimal.Parse(reader["berat"].ToString()),
                    umur = int.Parse(reader["umur"].ToString()),
                    status = reader["status"].ToString(),
                    id_user = int.Parse(reader["id_user"].ToString())
                });
            }

            db.CloseConnection();
            return list;
        }

        public Ternak GetById(int id)
        {
            Ternak t = null;
            string query = "SELECT * FROM simpedo.ternak WHERE id_ternak=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@id", id);

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                t = new Ternak
                {
                    id_ternak = int.Parse(reader["id_ternak"].ToString()),
                    nama_ternak = reader["nama_ternak"].ToString(),
                    berat = decimal.Parse(reader["berat"].ToString()),
                    umur = int.Parse(reader["umur"].ToString()),
                    status = reader["status"].ToString(),
                    id_user = int.Parse(reader["id_user"].ToString())
                };
            }

            db.CloseConnection();
            return t;
        }

        public void Insert(Ternak t)
        {
            string query = @"INSERT INTO simpedo.ternak 
            (nama_ternak, berat, umur, status, id_user) 
            VALUES (@nama, @berat, @umur, @status, @id_user)";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@nama", t.nama_ternak);
            cmd.Parameters.AddWithValue("@berat", t.berat);
            cmd.Parameters.AddWithValue("@umur", t.umur);
            cmd.Parameters.AddWithValue("@status", t.status);
            cmd.Parameters.AddWithValue("@id_user", t.id_user);

            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }

        public void Update(int id, Ternak t)
        {
            string query = @"UPDATE simpedo.ternak SET 
            nama_ternak=@nama, berat=@berat, umur=@umur, status=@status, id_user=@id_user,
            updated_at=CURRENT_TIMESTAMP
            WHERE id_ternak=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@nama", t.nama_ternak);
            cmd.Parameters.AddWithValue("@berat", t.berat);
            cmd.Parameters.AddWithValue("@umur", t.umur);
            cmd.Parameters.AddWithValue("@status", t.status);
            cmd.Parameters.AddWithValue("@id_user", t.id_user);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM simpedo.ternak WHERE id_ternak=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            db.CloseConnection();
        }
    }
}