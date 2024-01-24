using Aspose.Pdf;
using LibrarySystem.Core.DTO;
using LibrarySystem.Core.Repository;
using MailKit.Net.Smtp;
using MimeKit;

namespace LibrarySystem.Infra.Repository
{
    public class EmailRepository : IEmailRepository
    {
        public void SendEmail(GetBorrowedBooksDetailsByUserIdDTO borrowedBooks)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Document pdf = new Document();
            Page page = pdf.Pages.Add();
            Aspose.Pdf.Table table = new Aspose.Pdf.Table();
            table.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));
            table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));
            Aspose.Pdf.Row row = table.Rows.Add();

            int lowerLeftX = 100;
            int lowerLeftY = 100;
            int upperRightX = 200;
            int upperRightY = 200;


            FileStream imageStream = new FileStream(currentDirectory + "/files/logo.jpg", FileMode.Open);

            page.Resources.Images.Add(imageStream);

            page.Contents.Add(new Aspose.Pdf.Operators.GSave());

            Aspose.Pdf.Rectangle rectangle = new Aspose.Pdf.Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
            Matrix matrix = new Matrix(new double[] { rectangle.URX - rectangle.LLX, 0, 0, rectangle.URY - rectangle.LLY, rectangle.LLX, rectangle.LLY });

            page.Contents.Add(new Aspose.Pdf.Operators.ConcatenateMatrix(matrix));
            XImage ximage = page.Resources.Images[page.Resources.Images.Count];

            page.Contents.Add(new Aspose.Pdf.Operators.Do(ximage.Name));

            page.Contents.Add(new Aspose.Pdf.Operators.GRestore());



            row.Cells.Add(" Name");
            row.Cells.Add(" Book Name");
            row.Cells.Add(" Day Rented");
            row.Cells.Add(" Last Day");

            Aspose.Pdf.Row row2 = table.Rows.Add();
            row2.Cells.Add("       " + borrowedBooks.First_Name + " " + borrowedBooks.Last_Name);
            row2.Cells.Add("       " + borrowedBooks.Title);
            row2.Cells.Add("       " + borrowedBooks.Borrow_Date_From.Value.ToString("dd/MM/yyyy"));
            row2.Cells.Add("       " + borrowedBooks.Borrow_Date_To.Value.Date.ToString("dd/MM/yyyy"));
            
            page.Paragraphs.Add(table);

            
            pdf.Save(currentDirectory + "/files/Invoice.pdf");

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("booksawforlibraries@gmail.com"));
            email.To.Add(MailboxAddress.Parse(borrowedBooks.Email));
            email.Subject = "Invoice";
            var Body = new BodyBuilder();
            email.Body = Body.Attachments.Add(currentDirectory + "/files/Invoice.pdf");

            

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("booksawforlibraries@gmail.com", "htre ordt wfof zfwj");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
