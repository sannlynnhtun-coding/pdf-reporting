using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfReporting.Models;
using PdfReporting.Services;

namespace PdfReporting.Controllers
{
    [Route("api/generate-pdf")]
    [ApiController]
    public class GeneratePdfController : ControllerBase
    {
        private readonly PdfService _pdfService;

        public GeneratePdfController(PdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet]
        public async Task<IActionResult> ExecuteAsync()
        {
            var invoice = new Invoice
            {
                InvoiceNumber = 12345,
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                CompanyName = "My Company",
                CompanyAddress = "123 Main St, Anytown, USA",
                ClientName = "John Doe",
                ClientAddress = "456 Oak Ave, Othertown, USA",
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem { Description = "Item 1", Quantity = 2, Price = 50 },
                    new InvoiceItem { Description = "Item 2", Quantity = 1, Price = 100 },
                    new InvoiceItem { Description = "Item 3", Quantity = 3, Price = 20 }
                }
            };

            var pdfData = await _pdfService.GeneratePdfAsync(invoice);

            return File(pdfData, "application/pdf", "invoice.pdf");
        }
    }
}
