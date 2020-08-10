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
using BusinessEvertecTest.DTO.Mapping;
using EvertecTest.DBcontext;
using UserInterfaceEvertecTest.clases;

namespace UserInterfaceEvertecTest.Controllers
{
    public class ordersController : Controller
    {
        private readonly IordersDomainService _ordersDomainService;

        public ordersController(IordersDomainService ordersDomainService)
        {
            _ordersDomainService = ordersDomainService;
        }

        public ActionResult Index()
        {
            if (Session["login"]==null)
            {
                return RedirectToAction("index", "login");
            }
            return View(_ordersDomainService.GetByUser((string)Session["login"]));
        }

        public ActionResult GetOrders()
        {
            if (Session["login"] == null || Session["admin"] == null)
            {
                return RedirectToAction("index", "login");
            }
            if((string)Session["admin"] == "Y")
            {
                return View(_ordersDomainService.Get());
            }
            return RedirectToAction("index", "orders");
        }

        public ActionResult Details(int id)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("index", "login");
            }
            string []responsePayment = new string[3];
            ordersDTO ordersDto = _ordersDomainService.GetById(id);
            if (ordersDto == null || ordersDto.user_email!=(string)Session["login"])
            { return HttpNotFound(); }
            if (ordersDto.status=="CREATED")
            {
                paymentProcess p = new paymentProcess();
                responsePayment = p.statusRequest(ordersDto.transaction_id);
                switch (responsePayment[0])
                {
                    case "APPROVED":
                        ordersDto.status = "PAYED"; break;
                    case "REJECTED":
                        ordersDto.status = "REJECTED"; break;
                }
               
                ordersDto.paymentStatus = responsePayment[0];
                _ordersDomainService.update(ordersDto);
               
            }
           
           return View(ordersDto);
        }

      
        public ActionResult Create()
        {
            if(Session["login"]==null)
            {
                return RedirectToAction("index", "login"); 
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,status,customer_name,customer_email,customer_mobile,status,created_at,updated_at,price")] ordersDTO ordersDto)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("index", "login");
            }
            ordersDto.status = "CREATED";
            ordersDto.created_at = DateTime.Now;
            ordersDto.updated_at = DateTime.Now;
            ordersDto.user_email = (string)Session["login"];
            if (ModelState.IsValid)
            {
               ordersDto = _ordersDomainService.Create(ordersDto);
               return RedirectToAction("prePay/"+ordersDto.id);
            }

            return View(ordersDto);
        }

        public ActionResult prePay(int id)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("index", "login");
            }
            ordersDTO ordersDto = _ordersDomainService.GetById(id);
            if (ordersDto == null || ordersDto.user_email!=(string)Session["login"])
            {
                return HttpNotFound();
            }
            switch(ordersDto.status)
            {
                case "PAYED": return RedirectToAction("Details/" + id);
                case "REJECTED":
                    ordersDto.status = "CREATED";
                    ordersDto.updated_at = DateTime.Now;
                    _ordersDomainService.update(ordersDto);
                    break;
                default:
                    if (ordersDto.paymentStatus == "PENDING")
                    { return RedirectToAction("Details/" + id); }break;
               
            }
         
           return View(ordersDto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult prePay([Bind(Include = "id,status,customer_name,user_email,customer_email,customer_mobile,price,updated_at,created_at")] ordersDTO ordersDto)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("index", "login");
            }
            paymentProcess p = new paymentProcess();
            string [] responsePaymentService =new string[3];
        
            if (ModelState.IsValid)
            {
                responsePaymentService = p.CreatePayment("PRODCTO DE EJEMPLO", "Compra de producto de ejemplo con valor  Fijo", ordersDto.price, Request.UserHostAddress, ordersDto.customer_name,ordersDto.id.ToString());
                if(responsePaymentService[3]=="OK")
                {
                    ordersDto.transaction_id = responsePaymentService[1];
                    ordersDto.url_payment = responsePaymentService[2];
                    ordersDto.updated_at = DateTime.Now;
                    _ordersDomainService.update(ordersDto);
                    return Redirect(responsePaymentService[2]);
                }
             }
            return View(ordersDto);
        }
 
    }
}
