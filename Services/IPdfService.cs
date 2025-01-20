namespace Suivi_Colis_Back.Services
{
    public interface IPdfService
    {
        byte[] GenerateInvoicePdf(string clientName, string document, string date, string tableRowsHtml, decimal totalAmount);
    }
}
//@https://www.youtube.com/watch?v=L2gUMDfkeK8
//@https://www.youtube.com/watch?v=xS489r_yKGw
//@https://www.youtube.com/watch?v=hjK_MMV06k4
//@https://blog.aspose.com/fr/pdf/create-pdf-documents-using-csharp-with-.net-pdf-library/