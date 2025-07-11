using PdfReporting.Models;
using Razor.Templating.Core;

namespace PdfReporting.Services
{
    public class PdfService
    {
        public async Task<byte[]> GeneratePdfAsync(Invoice invoice)
        {
            var html = await RazorTemplateEngine.RenderAsync("~/Views/Invoice.cshtml", invoice);

            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderHtmlAsPdf(html);

            return pdf.BinaryData;
        }
    }
}
