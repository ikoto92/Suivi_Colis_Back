using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using System.IO;

namespace Suivi_Colis_Back.Services
{
    public class PdfService : IPdfService
    {
        //Source ppur le code
        //@https://www.youtube.com/watch?v=Z47eF35t7E8&t=152s
        public byte[] GenerateInvoicePdf(string clientName, string document, string date, string tableRowsHtml, decimal totalAmount)
        {
            try
            {
                string htmlTemplate = @"
                    <html>
                    <head>
                        <style>
                            table { width: 100%; border-collapse: collapse; }
                            th, td { border: 1px solid black; padding: 8px; text-align: left; }
                            th { background-color: #f2f2f2; }
                        </style>
                    </head>
                    <body>
                        <h1>Facture</h1>
                        <p><strong>Client :</strong> @CLIENTE</p>
                        <p><strong>Document :</strong> @DOCUMENTO</p>
                        <p><strong>Date :</strong> @FECHA</p>
                        <table>
                            <thead>
                                <tr>
                                    <th>Quantité</th>
                                    <th>Description</th>
                                    <th>Prix Unitaire</th>
                                    <th>Montant</th>
                                </tr>
                            </thead>
                            <tbody>
                                @FILAS
                            </tbody>
                        </table>
                        <h2>Total : @TOTAL</h2>
                    </body>
                    </html>";

                htmlTemplate = htmlTemplate.Replace("@CLIENTE", clientName);
                htmlTemplate = htmlTemplate.Replace("@DOCUMENTO", document);
                htmlTemplate = htmlTemplate.Replace("@FECHA", date);
                htmlTemplate = htmlTemplate.Replace("@FILAS", tableRowsHtml);
                htmlTemplate = htmlTemplate.Replace("@TOTAL", totalAmount.ToString("F2"));

                using (MemoryStream memoryStream = new MemoryStream())
                {
                   
                    using (var ms = new MemoryStream())
                    {
                        PdfWriter writer = new PdfWriter(ms);
                        PdfDocument pdf = new PdfDocument(writer);
                        Document documentPdf = new Document(pdf, PageSize.A4);
                        documentPdf.Add(new Paragraph(htmlTemplate));

                        
                        documentPdf.Close();
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("PdfException: " + ex.Message, ex);
            }
        }
    }
}
