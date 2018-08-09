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
using System.Text;
using iTextSharp.text.pdf.draw;
using System.Data;
using Microsoft.AspNet.Identity;

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
          
            //var shops = _Context.Shop.ToList();


            var viewModel = new RentFormViewModel
            {
                Tenants = tenants,        
                //Shops = shops



            };

            return View("leaseUnit", viewModel);
        }


        [HttpPost]
        public ActionResult Save(Rent Rent, Models.FileUpload upload, HttpPostedFileBase file )
        {
            //if (_Context.Rent.Any(u => u.Id != Rent.Id && u.shopId == Rent.shopId))
            //{
            //    return Content("shop already occupied");



            //}

            Rent.totalAmount = 0;

           Rent.totalAmount  = Rent.Amount - ((Rent.Amount * Rent.Discount) / 100);

                if (Rent.Id == 0) {
                _Context.Rent.Add(Rent);
            }

            else
            {
               
                var rentInDb = _Context.Rent.Single(c => c.Id == Rent.Id);

                rentInDb.tenantId = Rent.tenantId;
                //rentInDb.unitId = Rent.unitId;
                rentInDb.startDate = Rent.startDate;
                rentInDb.endDate = Rent.endDate;
                rentInDb.Amount = Rent.Amount;
                rentInDb.leaseStatus = Rent.leaseStatus;
                rentInDb.totalAmount = Rent.totalAmount;
                rentInDb.IsDiscountGiven = Rent.IsDiscountGiven;
                //rentInDb.shopId = Rent.shopId;
                                      }

            _Context.SaveChanges();

            var rent = _Context.Rent.Single(r => r.Id == Rent.Id);

            var up = Request.Files["file"];
            if (up.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
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

        [Authorize(Roles = "CanManageLeaseStatus")]
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
        [Authorize(Roles = "CanManageLeaseStatus")]
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

            var Details = _Context.Rent/*.Include(u => u.Unit)*/.Include(t => t.Tenant).SingleOrDefault(d => d.Id == id);

            return View(Details);


        }


        //protected void Print(object sender, EventArgs e)
        //{
        //    var invoice = _Context.Invoice.FirstOrDefault();

        //    //Dummy data for Invoice (Bill).
        //    string heading = "Vikram";
        //    int InvoiceNo = 2303;
        //    DataTable dt = new DataTable();
        //    dt.Columns.AddRange(new DataColumn[5] {
        //                    new DataColumn("Tenant", typeof(string)),
        //                    new DataColumn("Start Month", typeof(string)),
        //                    new DataColumn("End Month", typeof(int)),
        //                    new DataColumn("Discount", typeof(int)),
        //                    new DataColumn("Total Amount", typeof(int))});
        //    dt.Rows.Add(101,invoice.InvoiceStatus, 200, 5, 1000);
        //    dt.Rows.Add(102, invoice.startMonth, 400, 2, 800);
        //    dt.Rows.Add(103, invoice.endMonth, 300, 3, 900);
        //    dt.Rows.Add(104, invoice.invoiceDiscount, 550, 2, 1100);

        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //        {
        //            StringBuilder sb = new StringBuilder();

        //            //Generate Invoice (Bill) Header.
        //            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
        //            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Invoice Has Been Generated</b></td></tr>");
        //            sb.Append("<tr><td colspan = '2'></td></tr>");
                   
        //            sb.Append("</td><td align = 'right'><b>Date: </b>");
        //            sb.Append(DateTime.Now);
        //            sb.Append(" </td></tr>");
        //            sb.Append("<tr><td colspan = '2'><b>Invoice By: </b>");
        //            sb.Append(heading);
        //            sb.Append("</td></tr>");
        //            sb.Append("</table>");
        //            sb.Append("<br />");

        //            //Generate Invoice (Bill) Items Grid.
        //            sb.Append("<table border = '1'>");
        //            sb.Append("<tr>");
        //            foreach (DataColumn column in dt.Columns)
        //            {
        //                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
        //                sb.Append(column.ColumnName);
        //                sb.Append("</th>");
        //            }
        //            sb.Append("</tr>");
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                sb.Append("<tr>");
        //                foreach (DataColumn column in dt.Columns)
        //                {
        //                    sb.Append("<td>");
        //                    sb.Append(row[column]);
        //                    sb.Append("</td>");
        //                }
        //                sb.Append("</tr>");
        //            }
        //            sb.Append("<tr><td align = 'right' colspan = '");
        //            sb.Append(dt.Columns.Count - 1);
        //            sb.Append("'>Total</td>");
        //            sb.Append("<td>");
        //            sb.Append(dt.Compute("sum(Total)", ""));
        //            sb.Append("</td>");
        //            sb.Append("</tr></table>");

        //            //Export HTML String as PDF.
        //            StringReader sr = new StringReader(sb.ToString());
        //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //            XMLWorker htmlparser = new XMLWorkerH(pdfDoc);
        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //            pdfDoc.Open();
        //            htmlparser.Parse(sr);
        //            pdfDoc.Close();
        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + InvoiceNo + ".pdf");
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.Write(pdfDoc);
        //            Response.End();
        //        }
        //    }
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public FileResult Print(string GridHtml)
        //{

        //    using (MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        StringReader sr = new StringReader(GridHtml);
        //        Document pdfDoc = new Document(PageSize.A4, 50f, 100f, 100f, 0f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        //        pdfDoc.Open();

        //        Paragraph para = new Paragraph("YOUR INVOICE HAS BEEN GENERATED", new Font(Font.FontFamily.HELVETICA, 22));
        //        para.Alignment = Element.ALIGN_CENTER;
        //        pdfDoc.Add(para);

        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //        pdfDoc.Close();
        //        return File(stream.ToArray(), "application/pdf", "Details.pdf");
        //    }

        //}



        public ActionResult GenrateInvoice(int id)
        {
            {



                TempData["ID"] = id;

                var rent = _Context.Rent./*Include(s=>s.Shop).*/Include(t => t.Tenant).SingleOrDefault(d => d.Id == id);
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
        public ActionResult Create(Invoice Invoice,Rent Rent)
        {

            int id = Convert.ToInt32(TempData["ID"]);
            


            Invoice.totalAmount = 0;

            Invoice.totalAmount = Rent.Amount - ((Rent.Amount* Invoice.invoiceDiscount ) / 100);

            Invoice.rentId = id;

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
                invoiceInDb.invoiceDiscount = Invoice.invoiceDiscount;
                Invoice.rentId = id;




            }
            
            _Context.SaveChanges();


            return RedirectToAction("invoiceList", "Home");



        }

        
        public ActionResult GenratePrint(int id)
        {
            TempData["InvoiceID"] = id;

            var invoice = _Context.Invoice.Include(u => u.Rent.Tenant).SingleOrDefault(d => d.Id == id);

            return View(invoice);
            

        }


        [HttpPost]
        [ValidateInput(false)]

        public FileResult Genrate(string GridHtml )
        {
           
            using (MemoryStream stream = new MemoryStream())
            {

                int id = Convert.ToInt32(TempData["InvoiceID"]);
                var invoiceDetails = _Context.Invoice.Include(r => r.Rent.Tenant).ToList().SingleOrDefault(i => i.Id == id);

                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // BARCODE AND DATE

                //Table
                PdfPTable codeAndDate = new PdfPTable(2);
                codeAndDate.WidthPercentage = 100;
                //0=Left, 1=Centre, 2=Right
                codeAndDate.HorizontalAlignment = 0;
                codeAndDate.SpacingBefore = 20f;
                codeAndDate.SpacingAfter = 30f;


                //Cell no 1
                Chunk dating = new Chunk("Invoice Date : " +DateTime.Now.ToString("MM/dd/yyyy"));
                PdfPCell info = new PdfPCell();
                info.Border = 0;              
                info.AddElement(dating);
                codeAndDate.AddCell(info);

                //Cell no 2
                info = new PdfPCell();
                info.Border = 0;
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/bar.jpg"));
                image.ScaleAbsolute(100, 50);
                info.PaddingLeft = 180;
                info.AddElement(image);
                codeAndDate.AddCell(info);

                pdfDoc.Add(codeAndDate);
                ////Cell no 2
                //chunk = new Chunk("Name: Mrs. Salma Mukherji,\nAddress: Latham Village, Latham, New York, US, \nOccupation: Nurse, \nAge: 35 years", FontFactory.GetFont("Arial", 15, Font.NORMAL, BaseColor.PINK));
                //cell = new PdfPCell();
                //cell.Border = 0;
                //cell.AddElement(chunk);
                //table.AddCell(cell);



                //INVOICE GENERATED HERE
                int invoiceNo = 4231;

                if (invoiceNo == 4231)
                {
                    int index = new Random().Next(0, invoiceNo);
                    Paragraph para = new Paragraph();
                    para.Add("Invoice Number : " + index);
                    pdfDoc.Add(para);
                }


                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);

                //INTRO DONE
                Chunk chunk = new Chunk("Your Monthly Invoice has been Generated", FontFactory.GetFont("Arial", 20, Font.BOLDITALIC, BaseColor.BLACK));
                pdfDoc.Add(chunk);

                Paragraph line = new Paragraph(new Chunk(new LineSeparator(0.0F, 60.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                pdfDoc.Add(line);

                //********PIC AND DETAILS*******//
                //Table
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                //Cell no 1
                PdfPCell cell = new PdfPCell();
                cell.Border = 0;
                chunk = new Chunk("Mall Rent System,\nAddress: Kirti Nagar, West Delhi,India  "
                   , FontFactory.GetFont("Arial", 15, Font.NORMAL, BaseColor.BLACK));
                cell = new PdfPCell();
                cell.Border = 0;
                cell.AddElement(chunk);
                table.AddCell(cell);


                //Cell no 3

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/vs.jpg"));
                image.ScaleAbsolute(80, 50);
                cell = new PdfPCell();
                cell.Border = 0;
                cell.PaddingLeft = 200;
                cell.AddElement(img);
                table.AddCell(cell);

               
                pdfDoc.Add(table);

                //LINE 
                Paragraph line0 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                pdfDoc.Add(line0);

                //Table
                table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.HorizontalAlignment = 0;
                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;


                //Cell
                cell = new PdfPCell();
                chunk = new Chunk("This is your monthly lease details");
                cell.AddElement(chunk);
                cell.Colspan = 5;
                cell.Border = 0;
                cell.BackgroundColor = BaseColor.YELLOW;
                table.AddCell(cell);


                pdfDoc.Add(table);

                //PdfPTable tablee = new PdfPTable(4);
                //tablee.TotalWidth = 510f;//table size
                //tablee.LockedWidth = true;
                //tablee.SpacingBefore = 10f;//both are used to mention the space from heading
                //tablee.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                //tablee.DefaultCell.Border = PdfPCell.ALIGN_LEFT | PdfPCell.ALIGN_RIGHT;
                //tablee.AddCell(new Phrase(" TENANT "));
                //tablee.AddCell(new Phrase(" START MONTH "));
                //tablee.AddCell(new Phrase(" END MONTH"));
                //tablee.AddCell(new Phrase(" STATUS "));
                //pdfDoc.Add(tablee);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                //pdfDoc.Add(Chunk.NEWLINE);
                ////CELL 2 

                //tablee.AddCell(invoiceDetails.Rent.Tenant.shopName);
                //tablee.AddCell("NYC Junction");
                //tablee.AddCell("Item");
                //tablee.AddCell(invoiceDetails.InvoiceStatus);

                //LINE

                //PdfPTable final = new PdfPTable(2);
                //final.TotalWidth = 550f;//table size
                //final.LockedWidth = false;
                ////final.SpacingBefore = 200f;//both are used to mention the space from heading
                //final.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //final.DefaultCell.Border = Rectangle.NO_BORDER;
                ////final.DefaultCell.Border = PdfPCell.ALIGN_LEFT | PdfPCell.ALIGN_RIGHT;
                //final.AddCell("Discount :" + invoiceDetails.invoiceDiscount.ToString());
                //final.AddCell("Discount :" + invoiceDetails.invoiceDiscount.ToString());
                //  final.AddCell("Discount :" + invoiceDetails.invoiceDiscount.ToString());
                //final.AddCell("Total Amount :" + invoiceDetails.totalAmount.ToString());


                //pdfDoc.Add(final);

                ////Table
                //table = new PdfPTable(3);
                //table.WidthPercentage = 100;
                //table.HorizontalAlignment = 0;
                //table.SpacingBefore = 20f;
                //table.SpacingAfter = 30f;

                //table.AddCell("Tenant Name");
                //table.AddCell("Start Month");
                //table.AddCell("End Month");
                ////table.AddCell("Discount");
                ////table.AddCell("Total Amount");

                //table.AddCell(invoiceDetails.Rent.Tenant.shopName);
                //table.AddCell(invoiceDetails.invoiceDiscount.ToString("MM/dd/yyyy"));
                //table.AddCell("$100.00");
                ////table.AddCell(invoiceDetails.invoiceDiscount.ToString());
                ////table.AddCell(invoiceDetails.totalAmount.ToString());
                //pdfDoc.Add(table);



                //TENANT DETAILS HERE : 
                PdfPTable details = new PdfPTable(4);
                details.TotalWidth = 500f;//table size
                details.LockedWidth = true;

                details.SpacingBefore = 20f;//both are used to mention the space from heading
                details.SpacingAfter = 100f;
                //details.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                //details.DefaultCell.Border = PdfPCell.ALIGN_LEFT | PdfPCell.ALIGN_RIGHT;
                details.DefaultCell.Border = Rectangle.RIGHT_BORDER;
                details.DefaultCell.Border = Rectangle.LEFT_BORDER;
                
               
                details.AddCell(new Phrase("TENANT"));
                details.AddCell(new Phrase("START MONTH"));
                details.AddCell(new Phrase("END MONTH"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase(invoiceDetails.Rent.Tenant.shopName));
                details.AddCell(new Phrase(invoiceDetails.startMonth.ToString("MM/dd/yyyy")));
                details.AddCell(new Phrase(invoiceDetails.endMonth.ToString("MM/dd/yyyy")));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                
                details.AddCell(new Phrase("STATUS : " + invoiceDetails.InvoiceStatus));
                details.AddCell(new Phrase("DISCOUNT: " + invoiceDetails.invoiceDiscount.ToString() + " %"));
                details.AddCell(new Phrase("AMOUNT : " + invoiceDetails.totalAmount.ToString() + " Rs"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));
                details.AddCell(new Phrase("\n"));


                pdfDoc.Add(details);


              //  PdfPTable money = new PdfPTable(3);
              //  money.TotalWidth = 510f;//table size
              //  money.LockedWidth = true;
              //  money.SpacingBefore = 10f;//both are used to mention the space from heading
              //  money.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
              //money.DefaultCell.Border = PdfPCell.ALIGN_LEFT | PdfPCell.ALIGN_RIGHT;
              //  money.DefaultCell.Border = Rectangle.NO_BORDER;
              //  money.AddCell(new Phrase("STATUS : " + invoiceDetails.InvoiceStatus));
              //  money.AddCell(new Phrase("DISCOUNT: " + invoiceDetails.invoiceDiscount.ToString() +" %"));
              //  money.AddCell(new Phrase("AMOUNT : " + invoiceDetails.totalAmount.ToString() + " Rs"));

              //  pdfDoc.Add(money);


                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Details.pdf");
                //   Chunk chunk = new Chunk("Your Invoice has been Generated", FontFactory.GetFont("Arial", 20, Font.BOLDITALIC, BaseColor.BLUE));
                //   pdfDoc.Add(chunk);
                //   Paragraph underline = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));


                //   pdfDoc.Add(underline);
                //   PdfPTable table0 = new PdfPTable(1);
                //   table0.WidthPercentage = 100;
                //   table0.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                //   table0.SpacingBefore = 20f;
                //   table0.SpacingAfter = 30f;

                //   //Cell no 1
                //   PdfPCell cell = new PdfPCell();
                //   cell.Border = 0;
                //   iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/vs.jpg"));
                //   image.ScaleAbsolute(80, 60);
                //   cell.AddElement(image);
                //   table0.AddCell(cell);   
                //   //Cell No 2       
                //Chunk  chunk1 = new Chunk("Name: Vikram Mall System ,\nAddress: Kirti Nagar, West Delhi,India", FontFactory.GetFont("Arial", 15, Font.NORMAL, BaseColor.BLACK));
                //   PdfPCell cell2 = new PdfPCell();
                //   cell2.Border = 0;
                //   cell2.AddElement(chunk1);
                //  table0.AddCell(cell2);



                //   Paragraph line = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));


                //   pdfDoc.Add(line);
                //   Paragraph para = new Paragraph("Monthly invoice ", new Font(Font.FontFamily.HELVETICA, 15));
                //   para.Alignment = Element.ALIGN_CENTER;
                //   pdfDoc.Add(para);

                //   //Table
                //   PdfPTable table1 = new PdfPTable(5);
                //   table1.WidthPercentage = 100;
                //   table1.HorizontalAlignment = 0;
                //   table1.SpacingBefore = 20f;
                //   table1.SpacingAfter = 30f;

                //   //Cell
                //   PdfPCell cell1 = new PdfPCell();
                //   chunk = new Chunk("This is the monthly rent details");
                //   cell1.AddElement(chunk);
                //   cell1.Colspan = 5;
                //   cell1.BackgroundColor = BaseColor.PINK;
                //   table1.AddCell(cell1);

                //   pdfDoc.Add(table1);


            }

        }

        [Authorize(Roles = "CanManageLeaseStatus")]
        public ActionResult EditInvoice(int id)

        {
            
            int Id = Convert.ToInt32(TempData["ID"]);

            var invoice = _Context.Invoice.SingleOrDefault(i => i.Id == id);


            if (invoice == null)
                return HttpNotFound();

            var viewModel = new InvoiceViewModel
            {
               Rents= _Context.Rent.ToList(), 
               Invoice = invoice,
               rentId=Id

            };


            return View("EditInvoice", viewModel);
        }
        [Authorize(Roles = "CanManageLeaseStatus")]
        public ActionResult DeleteInvoice(int id)
        {
            _Context.Invoice.Remove(_Context.Invoice.Find(id));

            _Context.SaveChanges();

            return RedirectToAction("invoiceList", "Home");
        }

        public ActionResult ExamineReports ()
        {

            var invoice = _Context.Invoice.Include(r => r.Rent.Tenant).Include(u=>u.Rent/*.Unit*/).ToList();
            

            return View("ExamineReports" ,invoice);

        }

        

     
        }
    }



