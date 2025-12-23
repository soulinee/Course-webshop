import React from 'react'


type AddToCartProps = {
  onClick: () => void;
  label?: string;
};
const AddToCartButton = ({ onClick, label = "Add to cart" }: AddToCartProps) => {
  return (
     <button className="add-to-cart-button" onClick={onClick}>
      {label}
    </button>
    
  );
}

export default AddToCartButton