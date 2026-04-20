using LKM.Contexts;
using LKM.Helpers;
using LKM.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKM.Controllers
{
    public class TernakController : Controller
    {
        private string __constr;

        public TernakController(IConfiguration config)
        {
            __constr = config.GetConnectionString("WebApiDatabase");
        }

        [HttpGet("api/ternak")]
        public ActionResult GetAll()
        {
            try
            {
                var ctx = new TernakContext(__constr);
                var data = ctx.ListTernak();

                return Ok(new
                {
                    status = "success",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpGet("api/ternak/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var ctx = new TernakContext(__constr);
                var data = ctx.GetById(id);

                if (data == null)
                {
                    return NotFound(new
                    {
                        status = "error",
                        message = "Data tidak ditemukan"
                    });
                }

                return Ok(new
                {
                    status = "success",
                    data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpPut("api/ternak/{id}")]
        public ActionResult Update(int id, [FromBody] Ternak t)
        {
            var ctx = new TernakContext(__constr);
            ctx.Update(id, t);

            return Ok(new
            {
                status = "success",
                message = "Data berhasil diupdate"
            });
        }

        [HttpPost("api/ternak")]
        public ActionResult Insert([FromBody] Ternak t)
        {
            var ctx = new TernakContext(__constr);
            ctx.Insert(t);

            return Ok(new
            {
                status = "success",
                message = "Data berhasil ditambahkan"
            });
        }

        [HttpDelete("api/ternak/{id}")]
        public ActionResult Delete(int id)
        {
            var ctx = new TernakContext(__constr);
            ctx.Delete(id);

            return Ok(new
            {
                status = "success",
                message = "Data berhasil dihapus"
            });
        }

        [HttpGet("api/ternak-with-user")]
        public ActionResult GetJoin()
        {
            string query = @"SELECT t.nama_ternak, u.nama 
                     FROM simpedo.ternak t
                     JOIN simpedo.users u ON t.id_user = u.id_user";

            DBHelper db = new DBHelper(__constr);
            var cmd = db.GetNpgsqlCommand(query);
            var reader = cmd.ExecuteReader();

            var result = new List<object>();

            while (reader.Read())
            {
                result.Add(new
                {
                    nama_ternak = reader["nama_ternak"].ToString(),
                    nama_user = reader["nama"].ToString()
                });
            }

            db.CloseConnection();

            return Ok(new
            {
                status = "success",
                data = result
            });
        }
    }
}