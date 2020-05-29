using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Donor.Models;
using WebGrease.Css.Ast;

namespace Donor.Controllers
{
    public class HomeController : Controller
    {
        DonorDBEntities dc = new DonorDBEntities();
       // DataClasses1DataContext dc = new DataClasses1DataContext();
        public ActionResult Index()
        {
            ViewBag.Message = "View Page";
            var selec = dc.donordatas.ToList();
            return View(selec);
            
        }

        //public JsonResult GetSearchingData(string SearchBy,string SearchValue)
        //{
        //    List<donordata> DList = new List<donordata>();
        //     DList = dc.donordatas.Where(x => x.name.Contains(SearchValue) || SearchValue == null).ToList();
        //        return Json(DList, JsonRequestBehavior.AllowGet);


        //}
        //public ActionResult category()
        //{
        //    string b = Request["cat"];
        //    var selec = dc.donordatas.Where(c=> c.bloodtype.Equals(b));
        //    return View(Request["cat"].ToString());

        //}
        public ActionResult vieww()
        {
            string bloodtype = Request["blood"];
            //ViewBag.Message = "View Page";
            var selec = dc.donordatas.Where(x => x.bloodtype.Contains(bloodtype));
            return View(selec);

            // dc.donordatas.InsertOnSubmit(d);


           // return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            ViewBag.Message = "Add Page";

            return View();
        }

        public ActionResult Edit()
        {
            dc.SaveChanges();
           // dc.SubmitChanges();
            ViewBag.Message = "Edit Page";
            var selec = dc.donordatas.ToList();
            return View(selec);
            
        }

        public ActionResult EditV(int id)
        {
            Session["check"] = id;
            var selec = dc.donordatas.First(c => c.Id==id);
            // dc.SubmitChanges();
            dc.SaveChanges();
            return View(selec);

        }
        public ActionResult EditConfirm(int id)
        {
            if(Session["check"].Equals(id))
            {
                var selec = dc.donordatas.First(c => c.Id == id);
                string name = Request["name"];
                string bloodtype = Request["blood"];
                int phNo = Int32.Parse(Request["phoneNo"]);

                selec.name = name;
                selec.bloodtype = bloodtype;
                selec.phNo = phNo;
                //dc.SubmitChanges();
                dc.SaveChanges();
            }
            return RedirectToAction("Edit");
        }

        public ActionResult Addd()
        {
            string name = Request["name"];
            string bloodtype = Request["blood"];
            int phNo = Int32.Parse(Request["phoneNo"]);
            donordata d = new donordata();
            d.name = name;
            d.bloodtype = bloodtype;
            d.phNo = phNo;
            // dc.donordatas.InsertOnSubmit(d);
            dc.Entry(d);
            dc.SaveChanges();
           // dc.SubmitChanges();
            
          return  RedirectToAction("Index");
        }

        

       
       

        public ActionResult editt()
        { int id = Int16.Parse(Request["ID"]);
            
            String newName = Request["NewName"];
            String bt = Request["BT"];
            int ph = Int32.Parse(Request["PH"]);
            var selec = dc.donordatas.First(c=> c.Equals(id));
            selec.name = newName;
            selec.phNo = ph;
            selec.bloodtype = bt;
            //  dc.SubmitChanges();
            dc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}