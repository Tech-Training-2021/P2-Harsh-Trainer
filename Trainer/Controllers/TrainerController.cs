using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainer.Controllers
{
    public class TrainerController : Controller
    {
        Data.Repository.Trainer user;
        Data.Repository.Experience exp;
        Data.Repository.Skills skill;
        public TrainerController()
        {
            user = new Data.Repository.Trainer(new Data.Entities.TrainerContext());
            exp = new Data.Repository.Experience(new Data.Entities.TrainerContext());
            skill = new Data.Repository.Skills(new Data.Entities.TrainerContext());
        }
        public IActionResult Index()
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var userDetails = user.getUserById(id);
            return View(Trainer.Mapper.UserMapper.Map(userDetails));
        }
        [HttpGet]
        public IActionResult EditProfile()
        {

            TempData["Name"] = HttpContext.Session.GetString("Name");
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var userDetails = user.getUserById(id);
            return View(Trainer.Mapper.UserMapper.Map(userDetails));
        }
        [HttpPost]
        public IActionResult EditProfile(Trainer.Models.User userdata)
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                user.editUser(id, Trainer.Mapper.UserMapper.Map(userdata));
                HttpContext.Session.SetString("Name", userdata.Name);
            }
            return RedirectToAction("EditProfile");
        }
        public IActionResult CreateEducation()
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateEducation(Trainer.Models.Education edu)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = HttpContext.Session.GetString("Name");
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                exp.addEducation(Trainer.Mapper.EducationMapper.Map(edu, id));
            }
            return RedirectToAction("GetExperience");
        }
        public IActionResult GetExperience()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var data = exp.getEducationByUserId(id);
            List<Trainer.Models.Education> dataView = new List<Trainer.Models.Education>();
            foreach (var item in data)
            {
                dataView.Add(Trainer.Mapper.EducationMapper.Map(item));
            }
            return View(dataView);
        }
        public IActionResult EditEducation(int id)
        {
            var data = exp.getEducationByEduId(id);
            return View(Trainer.Mapper.EducationMapper.Map(data));
        }
        [HttpPost]
        public IActionResult EditEducation(int id, Trainer.Models.Education edu)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = HttpContext.Session.GetString("Name");
                int _id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                exp.editEducation(id, Trainer.Mapper.EducationMapper.Map(edu, _id));
            }
            return RedirectToAction("GetExperience");
        }
        [HttpGet]
        public IActionResult EducationDetails(int id)
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");

            var data = exp.getEducationByEduId(id);
            return View(Trainer.Mapper.EducationMapper.Map(data));
        }
        public IActionResult EducationDelete(int id)
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");
            exp.deleteEducationData(id);
            return RedirectToAction("GetExperience");
        }
        public IActionResult GetSkills()
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var data = skill.getExperienceByUserId(id);
            List<Trainer.Models.Experience> dataView = new List<Trainer.Models.Experience>();
            foreach (var item in data)
            {
                dataView.Add(Trainer.Mapper.SkillsMapper.Map(item));
            }
            return View(dataView);
        }

        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExperience(Trainer.Models.Experience exp)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = HttpContext.Session.GetString("Name");
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                skill.addSkill(Trainer.Mapper.SkillsMapper.Map(exp, id));
            }
            return RedirectToAction("GetSkills");
        }


        public IActionResult EditSkills(int id)
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");
            var data = skill.getExperienceById(id);
            return View(Trainer.Mapper.SkillsMapper.Map(data));
        }
        [HttpPost]
        public IActionResult EditSkills(int id, Trainer.Models.Experience exp)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = HttpContext.Session.GetString("Name");
                int _id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                skill.editSkill(id, Trainer.Mapper.SkillsMapper.Map(exp, _id));
            }
            return RedirectToAction("GetSkills");
        }
        [HttpGet]
        public IActionResult DetailsSkills(int id)
        {
            TempData["Name"] = HttpContext.Session.GetString("Name");

            var data = skill.getExperienceById(id);
            return View(Trainer.Mapper.SkillsMapper.Map(data));
        }
        public IActionResult DeleteSkills(int id)
        {

            skill.deleteExp(id);
            return RedirectToAction("GetSkills");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginSignUp");
        }
    }
}
