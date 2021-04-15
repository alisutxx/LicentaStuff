using LicentaStuff.Migrations;
using LicentaStuff.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicentaStuff.Controllers
{
    public class RoomController : Controller
    {
        private ApplicationDbContext _context;
        public RoomController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            if (User.Identity.Name != "admin@admin.com")
                return HttpNotFound();
            string asgf;
            var rooms = _context.Rooms.ToList();

            if (TempData.ContainsKey("message"))
                ViewBag.message = TempData["message"].ToString();

            return View(rooms);
            
        }
        //Create
        public ActionResult New(int id)
        {
            var viewModel = new NewRoomViewModel
            {
                Room = new Room
                {
                    Id = 0
                },
                ProjectId = id
            };
            return View("RoomForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(NewRoomViewModel newRoomViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("RoomForm", newRoomViewModel);
            }
            if (newRoomViewModel.Room.Id == 0)
            {
                newRoomViewModel.Room.ProjectId = newRoomViewModel.ProjectId;
                _context.Rooms.Add(newRoomViewModel.Room);
            }
            else
            {
                var roomInDb = _context.Rooms.SingleOrDefault(m => m.Id == newRoomViewModel.Room.Id);

                if (roomInDb == null)
                    return HttpNotFound();
                roomInDb.Name = newRoomViewModel.Room.Name;
            }
            _context.SaveChanges();
            return View("Show", newRoomViewModel);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {//la fel
            var room = _context.Rooms.SingleOrDefault(m => m.Id == id);
            var project = _context.Projects.SingleOrDefault(p => p.Id == room.ProjectId);
            if ((room == null || project == null)||(User.Identity.Name != "admin@admin.com" && User.Identity.GetUserId() != project.UserId))
                return HttpNotFound();
            

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("Show","Project", new { id = project.Id});
        }
        public ActionResult Edit(int id)
        {//la fel
            var viewModel = new NewRoomViewModel
            {
                Room = _context.Rooms.SingleOrDefault(m => m.Id == id)
            };
            var project = _context.Projects.SingleOrDefault(m => m.Id == viewModel.Room.ProjectId);

            if (viewModel.Room == null || (User.Identity.Name != "admin@admin.com" && User.Identity.GetUserId() != project.UserId))
                return HttpNotFound();

            return View("RoomEdit", viewModel);
        }
        public ActionResult SavedR(string str)
        {
            int id = 0;

            if (str[0] == '0')
            {
                id = Convert.ToInt32(str.Substring(1, 2));
                id = id / 10;
                str = str = str.Substring(str.IndexOf('|', 0) + 1);
            }

            else
            {
                id = Convert.ToInt32(str.Substring(0, str.IndexOf('|', 0)));
                str = str.Substring(str.IndexOf('|', 0) + 1);
            } 

       
            //var url = Request.Url.ToString();
            var camera = _context.Rooms.SingleOrDefault(c => c.Id == id);
            if(camera == null)
                return HttpNotFound();

            camera.Camera = str;
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = id });
        }
    }
}