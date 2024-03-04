﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SegundoParcialMVC.Controllers
{
    public class CreditController : Controller
    {
        private readonly string API = "https://localhost:7007";
        private readonly HttpClient _httpClient;

        public CreditController()
        {
            _httpClient = new HttpClient();
        }
        // GET: categoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: categoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: categoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: categoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: categoryController/Edit/5
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

        // GET: categoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: categoryController/Delete/5
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
