namespace PdfReporting.Models
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal Total => Items.Sum(i => i.Total);
    }
}
