// Solución: Modelo de Producto Completo
// Este es un ejemplo de cómo GitHub Copilot puede ayudar a crear un modelo robusto

using System;
using System.ComponentModel.DataAnnotations;

namespace ProductosAPI.Models
{
    /// <summary>
    /// Modelo de producto para e-commerce con validaciones completas
    /// </summary>
    public class Producto : IEquatable<Producto>
    {
        /// <summary>
        /// Identificador único del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada del producto
        /// </summary>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio del producto en la moneda base
        /// </summary>
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        /// <summary>
        /// Categoría a la que pertenece el producto
        /// </summary>
        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(50, ErrorMessage = "La categoría no puede exceder 50 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad disponible en inventario
        /// </summary>
        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        /// <summary>
        /// Fecha de creación del producto
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indica si el producto está activo en el catálogo
        /// </summary>
        public bool Activo { get; set; } = true;

        /// <summary>
        /// Imagen principal del producto
        /// </summary>
        [Url(ErrorMessage = "La URL de la imagen no es válida")]
        public string? ImagenUrl { get; set; }

        /// <summary>
        /// SKU (Stock Keeping Unit) único del producto
        /// </summary>
        [StringLength(20, ErrorMessage = "El SKU no puede exceder 20 caracteres")]
        public string? SKU { get; set; }

        /// <summary>
        /// Peso del producto en gramos
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "El peso no puede ser negativo")]
        public decimal? Peso { get; set; }

        /// <summary>
        /// Determina si el producto está disponible para venta
        /// </summary>
        public bool EstaDisponible => Activo && Stock > 0;

        /// <summary>
        /// Determina si el producto tiene stock bajo (menos de 10 unidades)
        /// </summary>
        public bool StockBajo => Stock > 0 && Stock < 10;

        /// <summary>
        /// Calcula el precio con descuento aplicado
        /// </summary>
        /// <param name="porcentajeDescuento">Porcentaje de descuento (0-100)</param>
        /// <returns>Precio con descuento aplicado</returns>
        public decimal CalcularPrecioConDescuento(decimal porcentajeDescuento)
        {
            if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
                throw new ArgumentOutOfRangeException(nameof(porcentajeDescuento), "El descuento debe estar entre 0 y 100");

            return Precio * (1 - porcentajeDescuento / 100);
        }

        /// <summary>
        /// Actualiza el stock del producto
        /// </summary>
        /// <param name="cantidad">Cantidad a agregar (positivo) o quitar (negativo)</param>
        /// <returns>True si la operación fue exitosa</returns>
        public bool ActualizarStock(int cantidad)
        {
            var nuevoStock = Stock + cantidad;
            
            if (nuevoStock < 0)
                return false;

            Stock = nuevoStock;
            return true;
        }

        /// <summary>
        /// Implementación de IEquatable para comparar productos por Id
        /// </summary>
        /// <param name="other">Otro producto a comparar</param>
        /// <returns>True si los productos son iguales</returns>
        public bool Equals(Producto? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        /// <summary>
        /// Override de Equals para comparación con objetos
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si los objetos son iguales</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Producto);
        }

        /// <summary>
        /// Override de GetHashCode para usar en colecciones
        /// </summary>
        /// <returns>Hash code basado en el Id</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Representación en string del producto
        /// </summary>
        /// <returns>String descriptivo del producto</returns>
        public override string ToString()
        {
            var disponibilidad = EstaDisponible ? "Disponible" : "No disponible";
            var stockInfo = StockBajo ? $" (Stock bajo: {Stock})" : $" (Stock: {Stock})";
            
            return $"{Nombre} - {Categoria} - ${Precio:F2} - {disponibilidad}{stockInfo}";
        }

        /// <summary>
        /// Operador de igualdad
        /// </summary>
        public static bool operator ==(Producto? left, Producto? right)
        {
            return EqualityComparer<Producto>.Default.Equals(left, right);
        }

        /// <summary>
        /// Operador de desigualdad
        /// </summary>
        public static bool operator !=(Producto? left, Producto? right)
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Enumeración para categorías de productos
    /// </summary>
    public enum CategoriaProducto
    {
        Tecnologia,
        Ropa,
        Hogar,
        Deportes,
        Libros,
        Belleza,
        Automovil,
        Jardin,
        Electrodomesticos,
        Juguetes
    }

    /// <summary>
    /// DTO para crear/actualizar productos
    /// </summary>
    public class ProductoDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }

        [Required]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Url]
        public string? ImagenUrl { get; set; }

        [StringLength(20)]
        public string? SKU { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Peso { get; set; }

        public bool Activo { get; set; } = true;
    }
}