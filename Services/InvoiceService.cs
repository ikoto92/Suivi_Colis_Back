//using Suivi_Colis_Back.DTOs;
//using Suivi_Colis_Back.Mappers;
//using Suivi_Colis_Back.Repositories;

//namespace Suivi_Colis_Back.Services
//{
//    public interface IInvoiceService
//    {
//        Task<byte[]> GenerateInvoicePdfAsync(int orderId);
//    }

//    public class InvoiceService : IInvoiceService
//    {
//        private readonly IInvoiceRepository _invoiceRepository;
//        private readonly IPdfService _pdfService;
//        private readonly IInvoiceMapper _invoiceMapper;

//        public InvoiceService(IInvoiceRepository invoiceRepository, IPdfService pdfService, IInvoiceMapper invoiceMapper)
//        {
//            _invoiceRepository = invoiceRepository;
//            _pdfService = pdfService;
//            _invoiceMapper = invoiceMapper;
//        }

//        public async Task<byte[]> GenerateInvoicePdfAsync(int orderId)
//        {
//            var order = await _invoiceRepository.GetOrderDetailsAsync(orderId);
//            if (order == null)
//                throw new Exception("Order not found.");

//            var invoiceDto = _invoiceMapper.MapOrderToInvoiceDto(order);

//            // Vérification des données avant la génération du PDF
//            if (string.IsNullOrEmpty(invoiceDto.CustomerName) || string.IsNullOrEmpty(invoiceDto.OrderDate))
//            {
//                throw new Exception("Invoice data is incomplete.");
//            }

//            try
//            {
//                return _pdfService.GenerateInvoicePdf(
//                    invoiceDto.CustomerName,
//                    $"Invoice-{invoiceDto.OrderId}",  // Document name
//                    invoiceDto.OrderDate,
//                    GenerateTableRows(invoiceDto.Items),
//                    invoiceDto.TotalAmount
//                );
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error generating PDF: " + ex.Message, ex);
//            }
//        }

//        private string GenerateTableRows(List<InvoiceItemDto> items)
//        {
//            string rows = string.Empty;
//            foreach (var item in items)
//            {
//                rows += $"<tr><td>{item.Quantity}</td><td>{item.ProductName}</td><td>{item.UnitPrice:F2}</td><td>{item.TotalPrice:F2}</td></tr>";
//            }
//            return rows;
//        }
//    }
//}
