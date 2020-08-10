using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessEvertecTest.DomainService;
using BusinessEvertecTest.DTO;
using EvertecTest.DBcontext;
using P2P = PlacetoPay.Integrations.Library.CSharp.PlacetoPay;
using UserInterfaceEvertecTest.clases;
using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Message;

namespace UserInterfaceEvertecTest.Controllers
{
    public class loginController : Controller
    {
        private readonly IloginDomainService _loginDomainService;
        public loginController(IloginDomainService loginDomainService)
        {
            _loginDomainService = loginDomainService;
        }

 
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }
        public ActionResult closeSession()
        {
            Session.Abandon();
            return RedirectToAction("Index", "login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "customer_email,password,admin")] loginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var a = _loginDomainService.GetLogin(loginDTO);
                if (a!=null)
                {
                    Session["login"] = a.customer_email;
                    Session["admin"] = a.admin;
                    return RedirectToAction("Index", "orders");
                }
                ViewBag.error = "Error de Autenticacion";
                return View();
            }
            ViewBag.error = "Error con el Modelo";
            return View(loginDTO);
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_email,password,admin")] loginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   _loginDomainService.create(loginDTO);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.error = "Ocurrio un error el crear el usuario, favor validar los campos y que no exista previamente";
                    return View(loginDTO);
                }
                
            }

            return View("Index");
        }
    }
}
