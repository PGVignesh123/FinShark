using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDtos ToStockDtos(this Stock stockModel)
        {
            return new StockDtos
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Price = stockModel.Price,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
            };
        }
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDtos)
        {
            return new Stock
            {
                Symbol = stockDtos.Symbol,
                CompanyName = stockDtos.CompanyName,
                Price = stockDtos.Price,
                LastDiv = stockDtos.LastDiv,
                Industry = stockDtos.Industry,
            };
        }
    }
}