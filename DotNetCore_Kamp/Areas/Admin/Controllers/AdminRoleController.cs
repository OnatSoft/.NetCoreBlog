using DotNetCore_Kamp.Areas.Admin.Models;
using DotNetCore_Kamp.Models;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Kamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]  //** Authorize attribute, burada ki bütün sayfaların erişimine sadece Admin rolüne izin veriyor. **//
    public class AdminRoleController : Controller  //** Admin Paneli için Rol İşlemleri controller sayfası **//
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name
                };

                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id) //Kayıtlı Rolün düzenleme sayfasında bilgilerini getirme
        {
            var updateVal = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                ID = updateVal.Id,
                name = updateVal.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model) //Kayıtlı Rol güncelleme işlemi
        {
            var updatevalue = _roleManager.Roles.Where(x => x.Id == model.ID).FirstOrDefault();

            updatevalue.Name = model.name;
            var result = await _roleManager.UpdateAsync(updatevalue);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id) //Kayıtlı rolü silme işlemi
        {
            var deletevalue = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(deletevalue);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id) //Kullanıcı ve Rol listesinde rolleri getirme7listeleme işlemi
        {
            var role = _roleManager.Roles.ToList();
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            
            TempData["Userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            
            foreach (var item in role)
            {
                RoleAssignViewModel roleAssign = new RoleAssignViewModel();
                roleAssign.RoleID = item.Id;
                roleAssign.Name = item.Name;
                roleAssign.Exists = userRoles.Contains(item.Name);
                model.Add(roleAssign);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model) //Kullanıcı ve Rol listesinden Rol Ataması işlemi
        {
            var userid = (int)TempData["Userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            
            foreach(var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }

            return RedirectToAction("UserRoleList");
        }
    }
}
