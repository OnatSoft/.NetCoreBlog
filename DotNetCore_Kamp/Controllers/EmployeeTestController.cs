using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Controllers
{
    public class EmployeeTestController : Controller  //Proje üzerinden uzaktaki API ile bağlantı kurup CRUD işlemleri yapma
    {
        public async Task<IActionResult> Index() //* Verileri listeleme işlemi
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:5001/api/Employee");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(Class1 p) //* Yeni veri kaydetme işlemi
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:5001/api/Employee", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> EmployeeEdit(int id) //* Kayıtlı verinin bilgilerini güncelleme işleminde getirme
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:5001/api/Employee/" + id);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeEdit(Class1 p) //* Kayıtlı verinin bilgilerini güncelleme işlemi
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:5001/api/Employee", content);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(p);
        }

        public async Task<IActionResult> EmployeeDelete(int id) //* Kayıtlı bir veriyi silme işlemi
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:5001/api/Employee/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }

        public class Class1
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
}
