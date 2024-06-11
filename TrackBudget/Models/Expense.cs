﻿using System.ComponentModel.DataAnnotations;

namespace TrackBudget.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
