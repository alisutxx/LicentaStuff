using LicentaStuff.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicentaStuff.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;
        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        //[Authorize(Roles = "User,Admin")]
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            var projects = _context.Projects.Where(m => m.UserId == userId).ToList();

            if (userName == "admin@admin.com")
            {
                projects = _context.Projects.ToList();
            }
            if (TempData.ContainsKey("message"))
                ViewBag.message = TempData["message"].ToString();

            return View(projects);
        }

        // Create
        public ActionResult New()
        {
            var ViewModel = new Project
            {
                UserId = User.Identity.GetUserId(),
                Id = 0,
                DateTime = DateTime.Now
            };
            return View("ProjectForm", ViewModel);
        }

        [HttpPost]
        public ActionResult SaveNew(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View("ProjectForm", project);
            }
            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDb = _context.Projects.SingleOrDefault(m => m.Id == project.Id);

                if (projectInDb == null)
                    return HttpNotFound();
                projectInDb.Name = project.Name;
                projectInDb.Description = project.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SaveEdit(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View("EditForm", project);
            }
            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDb = _context.Projects.SingleOrDefault(m => m.Id == project.Id);

                if (projectInDb == null)
                    return HttpNotFound();
                projectInDb.Name = project.Name;
                projectInDb.Description = project.Description;
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            //verifica daca nu esi admin sau owner si dai return HttpNotFound();
            var viewModel = _context.Projects.SingleOrDefault(m => m.Id == id);
            var userId = User.Identity.GetUserId();
            if (viewModel == null || User.Identity.Name != "admin@admin.com" && userId != viewModel.UserId)
                return HttpNotFound();

            return View("EditForm", viewModel);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //verifica daca nu esi admin sau owner si dai return HttpNotFound();
            var project = _context.Projects.SingleOrDefault(m => m.Id == id);
            var userId = User.Identity.GetUserId();
            if (project == null || (User.Identity.Name != "admin@admin.com" && userId != project.UserId))
                return HttpNotFound();


            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Show(int id)
        {
            //verifica daca nu esi admin sau owner si dai return HttpNotFound();
            var viewModel = new ShowProjectViewModel
            {
                Project = _context.Projects.SingleOrDefault(m => m.Id == id)
            };
            var userId = User.Identity.GetUserId();
            if (viewModel.Project == null||(User.Identity.Name != "admin@admin.com" && userId != viewModel.Project.UserId))
                return HttpNotFound();
         
            viewModel.Rooms = _context.Rooms.Where(r => r.ProjectId == id).ToList();
            viewModel.Project.NrRooms = viewModel.Rooms.Count;

            return View("Show", viewModel);
        }
    }
}