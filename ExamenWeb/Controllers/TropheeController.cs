using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWeb.Controllers
{
    public class TropheeController : Controller
    {
        IServiceTrophee st;
        IServiceEquipe se;
        public TropheeController(IServiceTrophee st, IServiceEquipe se)
        {
            this.st = st;
            this.se = se;
        }

        // GET: TropheeController
        public ActionResult Index()
        {
            return View(st.GetMany());
        }

        // GET: TropheeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TropheeController/Create
        public ActionResult Create()
        {
            ViewBag.EquipeFK = new SelectList(se.GetMany(),"EquipeId", "NomEquipe");
            return View();
        }

        // POST: TropheeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trophee collection)
        {
            try
            {
                st.Add(collection);
                st.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TropheeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TropheeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TropheeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TropheeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
