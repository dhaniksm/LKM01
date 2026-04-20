using LKM.Contexts;
using LKM.Helpers;
using LKM.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKM.Controllers
{
    public class RiwayatController : Controller
    {
        private string __constr;

        public RiwayatController(IConfiguration config)
        {
            __constr = config.GetConnectionString("WebApiDatabase");
        }

        [HttpGet("api/riwayat")]
        public ActionResult GetAll()
        {
            try
            {
                var ctx = new RiwayatContext(__constr);
                var data = ctx.ListRiwayat();

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

        [HttpGet("api/riwayat/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var ctx = new RiwayatContext(__constr);
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

        [HttpPut("api/riwayat/{id}")]
        public ActionResult Update(int id, [FromBody] Riwayat r)
        {
            var ctx = new RiwayatContext(__constr);
            ctx.Update(id, r);
            return Ok(new
            {
                status = "success",
                message = "Data berhasil diupdate"
            });
        }

        [HttpDelete("api/riwayat/{id}")]
        public ActionResult Delete(int id)
        {
            var ctx = new RiwayatContext(__constr);
            ctx.Delete(id);

            return Ok(new
            {
                status = "success",
                message = "Data berhasil dihapus"
            });
        }
    }
}
