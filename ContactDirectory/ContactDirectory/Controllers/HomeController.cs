using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactDirectory.Models;
using PagedList;

namespace ContactDirectory.Controllers
{
    public class HomeController : Controller
    {  
        private ContactDirectoryDBEntities db = new ContactDirectoryDBEntities();

        //
        // GET: /Contact/
        //implements sorting and filtering
        public ViewResult Index(string sortorder,string currentfilter, string searchstr,int? page)
        {
            ViewBag.Currentsort = sortorder;
           // ViewBag.oldsort = sortorder;
            ViewBag.Companysort=String.IsNullOrEmpty(sortorder) ?"Company_desc":"";
            
            ViewBag.FirstNamesort=sortorder=="FirstNamesort"?"FirstName_desc":"FirstName_asc";
            ViewBag.LastNamesort =sortorder=="LastNamesort"? "LastName_desc" : "LastName_asc";
            ViewBag.Jobsort = sortorder=="Jobsort"? "JobTitle_desc" : "JobTitle_asc";
            ViewBag.OfficePhonesort = sortorder=="OfficePhonesort" ? "OfficePhone_desc" : "OfficePhone_asc";
            ViewBag.CellPhonesort = sortorder=="CellPhonesort" ? "CellPhone_desc" : "CellPhone_asc";
            ViewBag.FaxNosort = sortorder=="FaxNosort" ? "FaxNo_desc" : "FaxNo_asc";
           ViewBag.Emailsort = sortorder=="Emailsort" ? "Email_desc" : "Email_asc";
           ViewBag.Websitesort =sortorder=="Websitesort" ? "Website_desc" : "Website_asc";
            ViewBag.Addresssort = sortorder=="Addresssort" ? "Address_desc" : "Address_asc";

            if (searchstr != null)
            {
                page = 1;
            }
            else
            {       searchstr = currentfilter;
        }
           
            ViewBag.currentfilter = searchstr;


            var contacts = from a in db.Contacts
                           select a;
         
            if (!String.IsNullOrEmpty(searchstr))
            {
                contacts= contacts.Where(a => a.Company.Contains(searchstr)||a.FirstName.Contains(searchstr)
                                       || a.LastName.Contains(searchstr)
                                       || a.JobTitle.Contains(searchstr)
                                       || a.OfficePhone.Contains(searchstr)
                                       || a.CellPhone.Contains(searchstr)
                                       || a.FaxNo.Contains(searchstr)
                                       || a.Email.Contains(searchstr)
                                       || a.Website.Contains(searchstr)
                                       || a.Address.Contains(searchstr));
                                     
            }
         
            switch (sortorder)
            {
                case "Company_desc":
                 //  if (sortorder.Equals(ViewBag.oldsort))
                 contacts = contacts.OrderByDescending(a => a.Company);
                break;
               
                case "FirstName_asc":
            //   //  if (sortorder.Equals(ViewBag.oldsort))
                   contacts = contacts.OrderBy(a => a.FirstName);
                 break;
            
                case "FirstName_desc":
              
                    contacts = contacts.OrderByDescending(a => a.FirstName);
                 break;
            
              case "LastName_desc":
                 contacts = contacts.OrderByDescending(a => a.LastName);
                   break;
                 
                case "LastName_asc":
                  contacts = contacts.OrderBy(a => a.LastName);
                  break;
          
                case "JobTitle_desc":
           
                    contacts = contacts.OrderByDescending(a => a.JobTitle);
                  break;
            
                case "JobTitle_asc":
            
                    contacts = contacts.OrderBy(a => a.JobTitle);
                 break;
              case "OfficePhone_desc":
                 contacts = contacts.OrderByDescending(a => a.OfficePhone);
               break;
              case "OfficePhone_asc":
                contacts = contacts.OrderBy(a => a.OfficePhone);
              break;
              case "CellPhone_desc":
                 contacts = contacts.OrderByDescending(a => a.CellPhone);
                    break;
                case "CellPhone_asc":
                    contacts = contacts.OrderBy(a => a.CellPhone);
                    break;
                case "FaxNo_desc":
                   contacts = contacts.OrderByDescending(a => a.FaxNo);
                   break;
               case "FaxNo_asc":
                   contacts = contacts.OrderBy(a => a.FaxNo);
                  break;

              case "Email_desc":
                  contacts = contacts.OrderByDescending(a => a.Email);
                  break;
              case "Email_asc":
                  contacts = contacts.OrderBy(a => a.Email);
                  break;
              case "Website_desc":
                  contacts = contacts.OrderByDescending(a => a.Website);
                  break;
          
                case "Website_asc":
                  contacts = contacts.OrderBy(a => a.Website);
                break;
                
                case "Address_desc":
                    contacts = contacts.OrderByDescending(a => a.Address);
                   break;
               case "Address_asc":
                   contacts = contacts.OrderBy(a => a.Address);
                   break;   
            default:
               
                   contacts = contacts.OrderBy(a => a.Company);
                   break;
            
            }
            int pagesize = 3;
            int pagenumber = (page ?? 1);
     
            return View(contacts.ToPagedList(pagenumber,pagesize));
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            

            try
            {   

                if (ModelState.IsValid)
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException )
            {
              
                ModelState.AddModelError("", "A problem has occured while saving, please try again");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}