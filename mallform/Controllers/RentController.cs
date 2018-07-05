using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using mallform.Models;
using mallform.ViewModel;
using System.IO;
using System.Web.UI.WebControls; //for word document grid view
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

namespace mallform.Controllers
{
    public class RentController : Controller
    {
        private ApplicationDbContext _Context;


        public RentController()
        {
            _Context = new ApplicationDbContext();
        }
        //GET VALUES FROM THE DATABASE
        public ActionResult leaseUnit()
        {

            var tenants = _Context.Tenant.ToList();
            var units = _Context.Unit.ToList();


            var viewModel = new RentFormViewModel
            {
                Tenants = tenants,
                Units = units,



            };

            return View("leaseUnit", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Rent Rent, Models.FileUpload upload, HttpPostedFileBase file)
        {

            if (Rent.Id == 0)
                _Context.Rent.Add(Rent);

            else
            {
                var rentInDb = _Context.Rent.Single(c => c.Id == Rent.Id);

                rentInDb.tenantId = Rent.tenantId;
                rentInDb.unitId = Rent.unitId;
                rentInDb.startDate = Rent.startDate;
                rentInDb.endDate = Rent.endDate;
                rentInDb.Amount = Rent.Amount;
                rentInDb.leaseStatus = Rent.leaseStatus;


            }

            _Context.SaveChanges();

            var rent = _Context.Rent.Single(r => r.Id == Rent.Id);

            var up = Request.Files["file"];
            if (up.ContentLength > 0)
            {



                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/Rent"), fileName);
                file.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = newpath;
                upload.length = imagepath;
                upload.Rent = rent;
                _Context.FileUpload.Add(upload);
                _Context.SaveChanges();

            }
            return RedirectToAction("leaseStatus", "Home");
        }


        public ActionResult Edit(int id)

        {

            var Rent = _Context.Rent.SingleOrDefault(r => r.Id == id);


            if (Rent == null)
                return HttpNotFound();

            var viewModel = new RentFormViewModel
            {
                Tenants = _Context.Tenant.ToList(),
                Units = _Context.Unit.ToList(),
                Rent = Rent

            };


            return View("editLease", viewModel);
        }

        public ActionResult Delete(int id)
        {
            _Context.Rent.Remove(_Context.Rent.Find(id));

            _Context.SaveChanges();

            return RedirectToAction("leaseStatus", "Home");
        }


        //  public ActionResult Details (int id)
        // {

        //    var Details = _Context.Rent.Include(u => u.Unit).Include(t => t.Tenant).SingleOrDefault(d => d.Id == id);

        //    return View(Details);


        // }

        public ActionResult Downloads(int id)
        {
            var fl = _Context.FileUpload.Where(f => f.rentId == id);
            var up = Request.Files["file"];




            return View(fl);
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = Server.MapPath("" + ImageName);

            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));


        }


        public ActionResult Details(int id)
        {

            var Details = _Context.Rent.Include(u => u.Unit).Include(t => t.Tenant).SingleOrDefault(d => d.Id == id);

            return View(Details);


        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Print(string GridHtml)
        {

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 50f, 100f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                Paragraph para = new Paragraph("INVOICE", new Font(Font.FontFamily.HELVETICA, 22));
                para.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(para);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Details.pdf");
            }

        }



        public ActionResult GenrateInvoice(int id)
        {
            {

                var rent = _Context.Rent.Include(t => t.Tenant).First();
                var rental = _Context.Rent.ToList();

                if (rent== null)
                    return HttpNotFound();

                var viewModel = new InvoiceViewModel
                {
                    
                   
                    Rents=rental,
                    Rent=rent

                   
                };


                return View("GenrateInvoice", viewModel);
            }
        }

        [HttpPost]
        public ActionResult Create(Invoice Invoice)
        {

            if (Invoice.Id==0)
 
                _Context.Invoice.Add(Invoice);

            else
            {
              

                var invoiceInDb = _Context.Invoice.Single(r => r.Id == Invoice.Id);
                invoiceInDb.startMonth = Invoice.startMonth;
                invoiceInDb.endMonth = Invoice.endMonth;
                invoiceInDb.InvoiceStatus = Invoice.InvoiceStatus;
                invoiceInDb.Discription = Invoice.Discription;
                invoiceInDb.CreatedDate = Invoice.CreatedDate;
                invoiceInDb.Rent = Invoice.Rent;
               
            }
            
            _Context.SaveChanges();


            return RedirectToAction("invoiceList", "Home");



        }
        public ActionResult GenratePrint(int id)
        {

            var invoice = _Context.Invoice.Include(u => u.Rent).SingleOrDefault(d => d.Id == id);

            return View(invoice);


        }


        [HttpPost]
        [ValidateInput(false)]
        public FileResult Genrate(string GridHtml)
        {

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 50f, 100f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                Paragraph para = new Paragraph("INVOICE", new Font(Font.FontFamily.HELVETICA, 22));
                para.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(para);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Details.pdf");
            }

        }
    }
}
