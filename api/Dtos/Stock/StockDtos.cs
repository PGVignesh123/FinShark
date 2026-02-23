using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using api.Models;
using api.Dtos;
using api.Dtos.Comment;


namespace api.Dtos.Stock
{
    public class StockDtos
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty; 
        public decimal Price { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        
        public List<CommentDto> Comments { get; set; }
    }
}