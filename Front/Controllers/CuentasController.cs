using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web3ConsoleApp;

namespace Front.Controllers
{
    public class CuentasController : Controller
    {

        BlockChainTXContext data = new BlockChainTXContext();

        // GET: Cuentas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cuentas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuentas/Create
        public ActionResult Create(CuentaBO cuentaBO)
        {
            return View();
        }

        // POST: Cuentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                ProgramServer test = new ProgramServer();
                Cuentas cuenta = new Cuentas();
                cuenta.Nombre = collection["Nombre"];
                cuenta.NumeroDoc = Convert.ToInt32( collection["NumeroDoc"]);
                cuenta.Cuenta = collection["Cuenta"];
                Task<string> cuentaBCRes = test.CreateAccount(collection["Cuenta"]);
                cuenta.CuentaBc =  cuentaBCRes.Result;

                data.Cuentas.Add(cuenta);
                data.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuentas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuentas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}