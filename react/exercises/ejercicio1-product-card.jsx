// Ejercicio 1: Componente ProductCard
// Objetivo: Crear un componente de tarjeta de producto reutilizable con GitHub Copilot

// INSTRUCCIONES:
// 1. Crear componente ProductCard que muestre información del producto
// 2. Implementar estados de loading, error y éxito
// 3. Agregar interactividad: agregar al carrito, wishlist, vista rápida
// 4. Hacer el componente responsive y accesible
// 5. Incluir animaciones suaves

// PROMPTS SUGERIDOS PARA COPILOT:
// "Componente ProductCard responsive con estados de loading y error"
// "Agregar funcionalidad de carrito y wishlist con animaciones"
// "Implementar accessibility y keyboard navigation"

import React, { useState } from 'react';
import styled from 'styled-components';

// TODO: Definir interfaces/tipos para las props
// Prompt: "Definir tipos TypeScript para producto y funciones de callback"

// Styled Components
// TODO: Crear styled components para el diseño
// Prompt: "Styled components para ProductCard responsive con hover effects"

const Card = styled.div`
  // TODO: Implementar estilos base
`;

const ImageContainer = styled.div`
  // TODO: Estilos para contenedor de imagen
`;

const ProductImage = styled.img`
  // TODO: Estilos para imagen responsive
`;

const Content = styled.div`
  // TODO: Estilos para contenido de la tarjeta
`;

const Title = styled.h3`
  // TODO: Estilos para título del producto
`;

const Description = styled.p`
  // TODO: Estilos para descripción
`;

const Price = styled.div`
  // TODO: Estilos para precio
`;

const Actions = styled.div`
  // TODO: Estilos para botones de acción
`;

const Button = styled.button`
  // TODO: Estilos para botones con variantes
`;

// Loading Component
// TODO: Crear componente de loading skeleton
// Prompt: "Componente skeleton loader para ProductCard"

const ProductCardSkeleton = () => {
  return (
    // TODO: Implementar skeleton
    <div>Loading...</div>
  );
};

// Main Component
const ProductCard = ({ 
  product, 
  onAddToCart, 
  onToggleWishlist, 
  onQuickView,
  isInWishlist = false,
  loading = false,
  className 
}) => {
  // TODO: Implementar estados locales
  // Prompt: "Estados para loading, quantity, error, y animations"
  const [quantity, setQuantity] = useState(1);
  const [isAdding, setIsAdding] = useState(false);
  const [error, setError] = useState(null);

  // TODO: Implementar handlers de eventos
  // Prompt: "Handlers para agregar al carrito, wishlist, y vista rápida con validación"
  
  const handleAddToCart = async () => {
    // TODO: Implementar lógica de agregar al carrito
  };

  const handleWishlistToggle = async () => {
    // TODO: Implementar lógica de wishlist
  };

  const handleQuickView = () => {
    // TODO: Implementar vista rápida
  };

  const handleImageError = () => {
    // TODO: Manejar error de carga de imagen
  };

  // TODO: Implementar keyboard navigation
  // Prompt: "Keyboard navigation y accessibility para ProductCard"

  if (loading) {
    return <ProductCardSkeleton />;
  }

  if (!product) {
    return null;
  }

  return (
    <Card 
      className={className}
      role="article"
      aria-labelledby={`product-${product.id}`}
    >
      {/* TODO: Implementar estructura del componente */}
      {/* Prompt: "Estructura completa de ProductCard con imagen, título, descripción, precio y botones" */}
      
      <ImageContainer>
        {/* Imagen del producto con lazy loading */}
      </ImageContainer>

      <Content>
        {/* Información del producto */}
      </Content>

      <Actions>
        {/* Botones de acción */}
      </Actions>

      {/* TODO: Agregar badge de descuento si aplica */}
      {/* TODO: Agregar indicador de stock bajo */}
      {/* TODO: Agregar rating de estrellas si existe */}
    </Card>
  );
};

// TODO: Crear variantes del componente
// Prompt: "Variantes de ProductCard: compact, detailed, grid, list"

export const ProductCardCompact = (props) => {
  // TODO: Versión compacta para listas
  return <ProductCard {...props} />;
};

export const ProductCardDetailed = (props) => {
  // TODO: Versión detallada con más información
  return <ProductCard {...props} />;
};

// TODO: Implementar PropTypes o TypeScript interfaces
// Prompt: "PropTypes completos para ProductCard con validación"

ProductCard.propTypes = {
  // TODO: Definir PropTypes
};

ProductCard.defaultProps = {
  // TODO: Definir props por defecto
};

export default ProductCard;

// TODO: Crear stories para Storybook
// Prompt: "Stories de Storybook para ProductCard con todos los estados"

// TODO: Crear tests unitarios
// Prompt: "Tests unitarios para ProductCard con React Testing Library"