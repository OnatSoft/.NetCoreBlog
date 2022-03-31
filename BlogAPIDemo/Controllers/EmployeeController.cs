using BlogAPIDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase  //Swagger ve Postman API ile statik olarak verileri db'den listeleme, ekleme, silme, güncelleme, id'ye göre getirme işlemleri
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee E)
        {
            using var c = new Context();
            c.Add(E);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeWithByGet(int id)
        {
            using var c = new Context();
            var values = c.Employees.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var value = c.Employees.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee E)
        {
            using var c = new Context();
            var value = c.Employees.Find(E.ID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.Name = E.Name;
                c.Update(value);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}

/*** Swagger ve Postman ile API'lerle işlem yapmak için ActionResult metodlarına gerekli Attribute yazılmalıdır.
 * C - HTTPPOST: Bir verinin ekleme işlemini yapmaktadır.
 * R - HTTPGET: Verilerin tümünü veya id'ye göre getiriyor. 
 * U - HTTPPUT: Verinin id'sini kontrol ederek geçerli listeden ilgili değerlerinin güncellenmesini sağlamaktadır.
 * D - HTTPDELETE: Verinin id'sini kontrol ederek geçerli listeden silinmesini sağlamaktadır. ***/