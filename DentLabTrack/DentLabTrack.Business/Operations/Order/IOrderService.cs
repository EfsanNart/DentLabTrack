using DentLabTrack.Business.Operations.Order.Dtos;
using DentLabTrack.Business.Types;
using DentLabTrack.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Order
{
    public interface IOrderService
    {
        //This interface defines the contract for order management operations.
        //It includes methods for adding a new order, getting orders by doctor ID, getting an order by ID, adjusting the status of an order, and deleting an order.
        Task<ServiceMessage> AddOrder(AddOrderDto addOrderDto);
        Task<List<OrderDto>> GetOrdersByDoctorId(int doctorId);
        Task<OrderDto> GetOrder(int id);
        Task<ServiceMessage> AdjustOrderStatus(int id, OrderStatus newStatus);
        Task<ServiceMessage> DeleteOrder(int id);
       
    }
}
