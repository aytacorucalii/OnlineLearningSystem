﻿using AutoMapper;
using OnlineLearning.Core.Models;
using OnlineLearning.BL.Services.Abstractions;
using OnlineLearning.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Enums;


namespace OnlineLearning.BL.Services.Concretes
{
	public class PaymentService : IPaymentService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public PaymentService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// Bütün ödənişləri alırıq
		public async Task<List<PaymentDTO>> GetAllPaymentsAsync()
		{
			try
			{
				var payments = await _context.Payments.ToListAsync();
				return _mapper.Map<List<PaymentDTO>>(payments);
			}
			catch (Exception)
			{
				// Hər hansı bir xəta baş verərsə, boş siyahı qaytarırıq
				return new List<PaymentDTO>();
			}
		}

		// ID ilə ödənişi tapırıq
		public async Task<PaymentDTO> GetPaymentByIdAsync(int id)
		{
			try
			{
				var payment = await _context.Payments.FindAsync(id);
				return payment == null ? null : _mapper.Map<PaymentDTO>(payment);
			}
			catch (Exception)
			{
				return null; // Xəta baş verərsə null qaytarırıq
			}
		}

		// Yeni ödəniş yaradırıq
		public async Task<PaymentDTO> CreatePaymentAsync(PaymentDTO paymentDto)
		{
			try
			{
				var payment = _mapper.Map<Payment>(paymentDto);
				_context.Payments.Add(payment);
				await _context.SaveChangesAsync();
				return _mapper.Map<PaymentDTO>(payment);
			}
			catch (Exception)
			{
				return null; // Xəta baş verərsə null qaytarırıq
			}
		}

		// Ödənişin statusunu yeniləyirik
		public async Task UpdatePaymentStatusAsync(int id, bool status)
		{
			var payment = await _context.Payments.FindAsync(id);
			if (payment == null)
			{
				throw new ArgumentException("Ödəniş tapılmadı.");
			}

			payment.Status = status ? PaymentStatus.Completed : PaymentStatus.Failed;
			_context.Payments.Update(payment);
			await _context.SaveChangesAsync();
		}


		// Ödənişi silirik
		public async Task<bool> DeletePaymentAsync(int id)
		{
			try
			{
				var payment = await _context.Payments.FindAsync(id);
				if (payment == null) return false;

				_context.Payments.Remove(payment);
				await _context.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		// Ödənişi təsdiqləyirik
		public async Task<bool> ProcessPaymentAsync(PaymentDTO paymentDto)
		{
			try
			{
				if (paymentDto == null || paymentDto.Amount <= 0 || string.IsNullOrEmpty(paymentDto.CardNumber))
				{
					return false; // Əgər məlumatlar qeyri-qanundursa
				}

				if (paymentDto.CardNumber.Length != 16)
				{
					return false; // Kart nömrəsi yanlış olarsa
				}

				// Ödənişin üzərində işlər aparılır (bank API çağırışı və s.)
				await Task.Delay(1000); // Simulyasiya üçün

				var payment = _mapper.Map<Payment>(paymentDto);
				payment.Status = PaymentStatus.Completed; // Ödəniş uğurludur
				_context.Payments.Add(payment);
				await _context.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false; // Xəta baş verərsə
			}
		}
	}
}
