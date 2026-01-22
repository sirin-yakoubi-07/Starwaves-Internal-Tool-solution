using StarwavesInternalTool.Core.Enums;

public class Invoice
{
    public InvoiceKind InvoiceKind { get; set; }
    public string? ExternalInvoiceId { get; set; }
    public DateTime IssueDate { get; set; }
    public string? CounterpartyName { get; set; }
}
