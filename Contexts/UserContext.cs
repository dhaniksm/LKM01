using LKM.Helpers;
using LKM.Models;

namespace LKM.Contexts
{
    public class UserContext
    {
        private string __constr;

        public UserContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<User> ListUser()
        {
            List<User> list = new List<User>();
            string query = "SELECT * FROM simpedo.users";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new User
                {
                    id_user = int.Parse(reader["id_user"].ToString()),
                    nama = reader["nama"].ToString(),
                    role = reader["role"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString()
                });
            }

            db.CloseConnection();
            return list;
        }

        public User GetById(int id)
        {
            User u = null;
            string query = "SELECT * FROM simpedo.users WHERE id_user=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u = new User
                {
                    id_user = int.Parse(reader["id_user"].ToString()),
                    nama = reader["nama"].ToString(),
                    role = reader["role"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString()
                };
            }

            db.CloseConnection();
            return u;
        }

        public void Update(int id, User u)
        {
            string query = @"UPDATE simpedo.users SET 
                            nama=@nama, role=@role, email=@email, password=@password,
                            updated_at=CURRENT_TIMESTAMP
                            WHERE id_user=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@nama", u.nama);
            cmd.Parameters.AddWithValue("@role", u.role);
            cmd.Parameters.AddWithValue("@email", u.email);
            cmd.Parameters.AddWithValue("@password", u.password);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            db.CloseConnection();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM simpedo.users WHERE id_user=@id";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            db.CloseConnection();
        }
    }
}
