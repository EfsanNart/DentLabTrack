using DentLabTrack.Business.Operations.Order.Dtos;
using DentLabTrack.Business.Types;
using DentLabTrack.Data.Context;
using DentLabTrack.Data.Entities;
using DentLabTrack.Data.Enums;
using DentLabTrack.Data.Repositories;
using DentLabTrack.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentLabTrack.Business.Operations.Order
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IRepository<OrderTechnician> _orderTechnicianRepository;
        private readonly DentLabTrackDbContext _context;

        public OrderManager(
            IRepository<OrderEntity> orderRepository,
            IRepository<OrderTechnician> orderTechnicianRepository,
            DentLabTrackDbContext context, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderTechnicianRepository = orderTechnicianRepository;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceMessage> AddOrder(AddOrderDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var order = new OrderEntity
                {
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    TreatmentType = dto.TreatmentType,
                    OrderDate = DateTime.Now,
                    EstimatedDeliveryDate = dto.EstimatedDeliveryDate,
                    OrderStatus = dto.OrderStatus,
                };

                _orderRepository.Add(order);
                await _unitOfWork.SaveChangesAsync();

                foreach (var techId in dto.TechnicianIds)
                {
                    var orderTechnician = new OrderTechnician
                    {
                        OrderId = order.Id,
                        TechnicianId = techId
                    };
                    _orderTechnicianRepository.Add(orderTechnician);
                }

                await _unitOfWork.SaveChangesAsync();
                await transaction.CommitAsync();

                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Sipariş başarıyla eklendi."
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<ServiceMessage> AdjustOrderStatus(int id, OrderStatus newStatus)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu ID ile eşleşen bir sipariş bulunamadı."
                };
            }

            order.OrderStatus = newStatus;
            _orderRepository.Update(order);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Sipariş durumu başarıyla güncellendi."
                };
            }
            catch (Exception)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Sipariş durumu güncellenirken bir hata oluştu."
                };
            }

        }


        public async Task<ServiceMessage> DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Sipariş bulunamadı."
                };
            }
            await _unitOfWork.BeginTransaction();

            order.IsDeleted = true;
            order.UpdatedAt = DateTime.Now;

            _orderRepository.Update(order);
            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw new Exception("Sipariş silinirken bir hata oluştu");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Sipariş başarıyla silindi."
            };
        }




        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _orderRepository.GetAll(x => x.Id == id)
       .Select(x => new OrderDto
       {
           Id = x.Id,
           PatientId = x.PatientId,
           DoctorId = x.DoctorId,
           TreatmentType = x.TreatmentType,
           OrderDate = x.OrderDate,
           EstimatedDeliveryDate = x.EstimatedDeliveryDate,
           OrderStatus = x.OrderStatus,
           Technicians = x.OrderTechnicians.Select(ot => new OrderTechnicianDto
           {
               TechnicianId = ot.TechnicianId,
               FirstName = ot.Technician.FirstName,
               LastName = ot.Technician.LastName,
           }).ToList()
       }).FirstOrDefaultAsync();
            return order;
        }

        public async Task<List<OrderDto>> GetOrdersByDoctorId(int doctorId)
        {

            var orders = _orderRepository.GetAll(x => x.DoctorId == doctorId && !x.IsDeleted).ToList();

            var orderDtos = orders.Select(x => new OrderDto
            {
                Id = x.Id,
                PatientId = x.PatientId,
                DoctorId = x.DoctorId,
                TreatmentType = x.TreatmentType,
                OrderDate = x.OrderDate,
                EstimatedDeliveryDate = x.EstimatedDeliveryDate,
                OrderStatus = x.OrderStatus,
            }).ToList();
            return orderDtos;
        }



    }
}