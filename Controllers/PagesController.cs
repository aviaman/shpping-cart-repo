using CmsShoppingCart.Models.Data;
using CmsShoppingCart.Models.ViewModels;
using CmsShoppingCart.Models.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CmsShoppingCart.Controllers
{
    public class PagesController : Controller
    {
        // GET: /Pages/Index/{page}
        [HttpGet]
        public ActionResult Index(string page = "")
        {
            // get/set page slug
            if (page == "")
                page = "home";

            //declare model and DTO
            PageVM model;
            PageDTO dto;

            //check if page exsist
            using (Db db = new Db())
            {
                if (!db.Pages.Any(x => x.Slug.Equals(page)))
                {
                    return RedirectToAction("Index", new { page = "" });
                }
            }

            //get page DTO
            using (Db db = new Db())
            {
                dto = db.Pages.Where(x => x.Slug == page).FirstOrDefault();
            }

            //set page title
            ViewBag.Pagetitle = dto.Title;

            //check for sidebar
            if (dto.HasSidebar)
            {
                ViewBag.Sidebar = "Yes";
            }
            else
            {
                ViewBag.Sidebar = "No";
            }
            //Init model
            model = new PageVM(dto);
            //Return view with model
            return View(model);
        }

        // GET: /Pages/PagesMenuPartial
        [HttpGet]
        public ActionResult PagesMenuPartial()
        {
            List<PageVM> pageVMList;

            using (Db db=new Db())
            {
                pageVMList = db.Pages.ToArray().OrderBy(x => x.Sorting).Where(x => x.Slug != "home").Select(x => new PageVM(x)).ToList();
            }

            return PartialView(pageVMList);
        }
        // GET: /Pages/SidebarPartial
        public ActionResult SidebarPartial()
        {
            SidebarVM model;

            using (Db db = new Db())
            {
                SidebarDTO dto = db.Sidebar.Find(1);

                model = new SidebarVM(dto);
            }

            return PartialView(model);
        }
    }
}