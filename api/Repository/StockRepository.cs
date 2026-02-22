using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Interfaces;
using api.Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Stock;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBcontext _context;
        public StockRepository(ApplicationDBcontext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateStockAsync(Stock stockMdodel)
        {
            await _context.Stocks.AddAsync(stockMdodel);
            await _context.SaveChangesAsync();
            return stockMdodel;
        }

        public async Task<Stock?> DeleteStockAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllStocksAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto updateDto)
        {
            var existingStockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (existingStockModel == null)
            {
                return null;
            }
            existingStockModel.Symbol = updateDto.Symbol;
            existingStockModel.CompanyName = updateDto.CompanyName;
            existingStockModel.LastDiv = updateDto.LastDiv;
            existingStockModel.Industry = updateDto.Industry;

            await _context.SaveChangesAsync();
            return existingStockModel;
        }
    }
}