﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TodoApp.ModelBinders;
using TodoModels.Models;

namespace TodoApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; }

        [ModelBinder(typeof(TrimModelBinder))]
        [StringLength(64, ErrorMessage = "Category name cannot be longer than 64 characters!")]
        public string? NewCategoryName { get; set; }
        public bool NewCategoryHasError { get; set; } = false;

        public HomeViewModel(IEnumerable<CategoryModel> categories)
        {
            Categories = categories;
        }

    }
}
