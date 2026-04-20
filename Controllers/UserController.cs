using LKM.Contexts;
using LKM.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LKM.Controllers
{
    public class UserController : Controller
    {
        private string __constr;

        public UserController(IConfiguration config)
        {
            __constr = config.GetConnectionString("WebApiDatabase");
        }

        [HttpGet("api/user")]
        public ActionResult GetAll()
        {
            try
            {
                var ctx = new UserContext(__constr);
                var data = ctx.ListUser();

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

        [HttpGet("api/user/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var ctx = new UserContext(__constr);
                var data = ctx.GetById(id);

                if (data == null)
                    return NotFound(new { status = "error", message = "User tidak ditemukan" });

                return Ok(new { status = "success", data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

        [HttpPut("api/user/{id}")]
        public ActionResult Update(int id, [FromBody] User u)
        {
            try
            {
                var ctx = new UserContext(__constr);
                ctx.Update(id, u);

                return Ok(new { status = "success", message = "User berhasil diupdate" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

        [HttpDelete("api/user/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ctx = new UserContext(__constr);
                ctx.Delete(id);

                return Ok(new { status = "success", message = "User berhasil dihapus" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }
    }
}
