using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
namespace Trainer.Controllers
{
    public class LoginSignUpController : Controller
    {
        Data.Repository.Trainer user;
        Data.Repository.Experience exp;
        Data.Repository.Skills skill;
        public LoginSignUpController()
        {
            user = new Data.Repository.Trainer(new Data.Entities.TrainerContext());
            exp = new Data.Repository.Experience(new Data.Entities.TrainerContext());
            skill = new Data.Repository.Skills(new Data.Entities.TrainerContext());
        }
        [HttpGet]
        public ActionResult Index(Models.UserViewModel model)
        {
            Data.Entities.TrainerContext db = new Data.Entities.TrainerContext();
            List<SelectListItem> items = new()
            {
                new SelectListItem { Value = "0", Text = "Select Role", Disabled = true },
                new SelectListItem { Value = "1", Text = "Client" },
                new SelectListItem { Value = "2", Text = "Trainer" },
            };

            ViewBag.Roles = items;
            return View(new Models.UserViewModel
            {
                Login = new Models.Login(),
                Register = new Models.Register()
            });
        }
        [HttpPost]
        public ActionResult Register(Models.Register register, int role)
        {

            var userid = user.addUser(Trainer.Mapper.UserMapper.Map(register, role));
            TempData["userid"] = userid;
            if (role == 2)
            {
                return RedirectToAction("Skills");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            TempData["loginerrormessage"] = null;
            var result = user.userLogin(login.Email, Trainer.EncryptionDecryption.EncryptionDecryption.EncryptString(login.Password));
            if (result == null)
            {
                TempData["loginerrormessage"] = "Invalid Credentials";
                return RedirectToAction("Index");
            }
            var role = result.RoleId;
            if (role == 1)
            {
                HttpContext.Session.SetInt32("UserId", result.UserId);
                HttpContext.Session.SetString("Name", result.Name);

                return RedirectToAction("Index", "Customer");
            }
            else if (role == 2)
            {
                HttpContext.Session.SetInt32("UserId", result.UserId);
                HttpContext.Session.SetString("Name", result.Name);
                return RedirectToAction("Index", "Trainer");

            }
            return null;
        }
        [HttpGet]
        public ActionResult Skills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Skills(Trainer.Models.Education edu)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(TempData["userid"]);
                exp.addEducation(Trainer.Mapper.EducationMapper.Map(edu, id));
            }
            return RedirectToAction("Skills");
        }
        [HttpGet]
        public ActionResult Experience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Experience(Trainer.Models.Experience exp)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(TempData["userid"]);
                skill.addSkill(Trainer.Mapper.SkillsMapper.Map(exp, id));
            }
            return RedirectToAction("Experience");
        }
    }
}
