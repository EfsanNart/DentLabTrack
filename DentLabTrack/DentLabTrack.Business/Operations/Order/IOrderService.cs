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
        Task<ServiceMessage> AddOrder(AddOrderDto addOrderDto);
        Task<List<OrderDto>> GetOrdersByDoctorId(int doctorId);
        Task<OrderDto> GetOrder(int id);
        Task<ServiceMessage> AdjustOrderStatus(int id, OrderStatus newStatus);
        Task<ServiceMessage> DeleteOrder(int id);
       
    }
}
