using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebBanHang.Controllers;
using WebBanHang.Models.Entities;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : BaseController
    {
        public PaymentController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
            //public ActionResult Index()
            //{
            //    if (Session["idUser"] == null)
            //    {
            //        return RedirectToAction("Login", "Home");
            //    }
            //    else
            //    {
            //        var lstCart = (List<CartModel>)Session["cart"];
            //        Order objOrder = new Order();
            //        objOrder.Name = "DonHang" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            //        objOrder.UserId = int.Parse(Session["idUser"].ToString());
            //        objOrder.CreatedOnUtc = DateTime.Now;
            //        objOrder.Status = 1;
            //        obj.Order.Add(objOrder);
            //        obj.SaveChanges();
            //        int intOrderId = objOrder.Id;
            //        List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
            //        foreach (var item in lstCart)
            //        {
            //            OrderDetail obj = new OrderDetail();
            //            obj.Quantity = item.Quantity;
            //            obj.OrderId = intOrderId;
            //            obj.ProductId = item.Product.Id;
            //            lstOrderDetail.Add(obj);
            //        }
            //        obj.OrderDetail.AddRange(lstOrderDetail);
            //        obj.SaveChanges();

            //        // Retrieve the user's email
            //        var userId = int.Parse(Session["idUser"].ToString());
            //        var user = obj.Users.FirstOrDefault(u => u.Id == userId);
            //        if (user == null)
            //        {
            //            // Handle the case where the user is not found
            //            // Return an appropriate response or redirect
            //        }
            //        var email = user.Email;

            //        // Save the email in the session
            //        Session["email"] = email;

            //        // Clear the cart in session
            //        Session.Remove("cart");

            //        return RedirectToAction("PaymentSuccess");
            //    }
            //}

            //public ActionResult PaymentSuccess()
            //{
            //    Session["count"] = 0;
            //    return View();
            //}
        }
    }