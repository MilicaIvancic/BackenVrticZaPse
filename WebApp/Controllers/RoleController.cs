using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role

        private IGetRolesCommand getCommand;
        private IGetRoleCommand getOneCommand;
        private IAddRoleCommand addRole;
        private IUpdateRoleCommand updateRoleCommand;
        private IDeleteRoleCommand deleetRoleCommand;

        public RoleController(IGetRolesCommand getCommand, IGetRoleCommand getOneCommand, IAddRoleCommand addRole, IUpdateRoleCommand updateRoleCommand, IDeleteRoleCommand deleetRoleCommand)
        {
            this.getCommand = getCommand;
            this.getOneCommand = getOneCommand;
            this.addRole = addRole;
            this.updateRoleCommand = updateRoleCommand;
            this.deleetRoleCommand = deleetRoleCommand;
        }

        public ActionResult Index(RoleSearch search)
        {
            var resalt = getCommand.Execute(search);
            return View(resalt);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {

            try
            {
                var result = getOneCommand.Execute(id);
                return View(result);
            }
            catch (EntitynotFoundException)
            {

                TempData["error"] = "Entity not found";
            }
            catch (EntityAlreadyDeleted)
            {
                TempData["error"] = "Entity is deleted";
            }

            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add insert logic here

                addRole.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Role with this name already exist";

            }
            catch (Exception )
            {
                TempData["error"] = "An error has occurred";

            }
            return View();
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var role = getOneCommand.Execute(id);
                return View(role);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoleDto dto)
        {
            if (!ModelState.IsValid)
            {

                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                updateRoleCommand.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (EntitynotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Role with this name already exist";
                return View(dto);
            }
            catch (EntityAlreadyDeleted)
            {
                TempData["error"] = "You can not update deleted Role";
                return View(dto);
            }
        }


        // POST: Role/Delete/5
        //[HttpGet]
        //[ValidateAntiForgeryToken]
        //method not allowed za post, delete ili put..... brisanje preko geta?? ...
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                deleetRoleCommand.Execute(id);


                return RedirectToAction(nameof(Index));
            }
            catch (EntitynotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}