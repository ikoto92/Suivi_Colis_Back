//using Microsoft.AspNetCore.Mvc;
//using Suivi_Colis_Back.Services;

//namespace Suivi_Colis_Back.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class InvoiceController : ControllerBase
//    {
//        private readonly IInvoiceService _invoiceService;

//        public InvoiceController(IInvoiceService invoiceService)
//        {
//            _invoiceService = invoiceService;
//        }

//        [HttpGet("generate/{orderId}")]
//        public async Task<IActionResult> GenerateInvoice(int orderId)
//        {
//            try
//            {
//                var pdfBytes = await _invoiceService.GenerateInvoicePdfAsync(orderId);
//                return File(pdfBytes, "application/pdf", $"Invoice_{orderId}.pdf");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = ex.Message });
//            }
//        }
//    }
//}
