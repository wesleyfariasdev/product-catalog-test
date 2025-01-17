﻿using ProductCatalog.Domain.AuxModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductCatalog.Application.Dto.Request;

public sealed class ProductRequestDTO
{
    [JsonPropertyName("name")]
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Price { get; set; }

    [JsonPropertyName("description")]
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
    public string? Description { get; set; }

    [JsonPropertyName("product_type")]
    [Required(ErrorMessage = "O tipo do produto é obrigatório.")]
    public ProductType ProductType { get; set; }

    [JsonPropertyName("registration_date")]
    [Required(ErrorMessage = "A data de registro é obrigatória.")]
    public DateTime RegistrationDate { get; set; }

}

