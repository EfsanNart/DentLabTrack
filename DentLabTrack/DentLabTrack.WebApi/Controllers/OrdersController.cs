using DentLabTrack.Business.Operations.Order;
using DentLabTrack.Business.Operations.Order.Dtos;
using DentLabTrack.Business.Operations.Patient;
using DentLabTrack.Data.Enums;
using DentLabTrack.WebApi.Filters;
using DentLabTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentLabTrack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //Dependency injection for the order service
        private readonly IOrderService _orderService;
       
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,LabTechnician")]
        public async Task<IActionResult> Get(int id)
        {

            var order = await _orderService.GetOrder(id);
            if (order is null)
            {
                return NotFound("Order not found.");
            }
            else
            {
                return Ok(order);
            }
        }
        [HttpGet("test-exception")]
        [AllowAnonymous] 
        public IActionResult ThrowTestException()
        {
            throw new Exception("Bilinçli olarak fırlatılan test hatası!");
        }


        [HttpPost]
        [Authorize(Roles = "Admin,LabTechnician")] 
        [TimeControllerFilter] //This filter will be applied to this action so that it will be checked if the action is called within the allowed time range.
        public async Task<IActionResult> AddOrder( AddOrderRequest request)
        {
            var dto = new AddOrderDto
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                TreatmentType = request.TreatmentType,
                EstimatedDeliveryDate = request.EstimatedDeliveryDate,
                TechnicianIds = request.TechnicianIds
            };

            var result = await _orderService.AddOrder(dto);

            if (result.IsSucceed)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }
        [HttpGet("{doctorId}/orders")] 
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetOrdersByDoctorId(int doctorId)
        {

            var result = await _orderService.GetOrdersByDoctorId(doctorId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No orders found for this doctor.");
            }
        }
        [HttpPatch("adjust-order-status")] //This endpoint is used to adjust the order status.
        [Authorize(Roles = "Admin,LabTechnician")]
        public async Task<IActionResult> AdjustOrderStatus(int id, OrderStatus newStatus)
        {
            var result = await _orderService.AdjustOrderStatus(id, newStatus);
            if (result.IsSucceed)
                return Ok(result);
            return BadRequest(result);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,LabTechnician")]
    
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (!result.IsSucceed)
                return NotFound(result);

            return Ok(result);
        }

       
        
    }
}
