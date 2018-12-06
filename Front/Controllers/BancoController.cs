using BlockChainFront.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Web3ConsoleApp;

namespace Front
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            ProgramServer test = new ProgramServer();

            Task<Bank> getStringTask = test.GetAccountBalance();
            Bank bank = getStringTask.Result;

            SaldoModel saldo = new SaldoModel
            {
                IdBC = bank.BankAddress,
                Banco = bank.BankName,
                Saldo = bank.Balance
            };



            return View(saldo);
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
