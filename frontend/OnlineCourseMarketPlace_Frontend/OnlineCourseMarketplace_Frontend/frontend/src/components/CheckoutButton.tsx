 
 

import toast from "react-hot-toast";
 

type CheckoutButtonProps = {
  cartItems: Course[];
};

const CheckoutButton = ({ cartItems }: CheckoutButtonProps) => {

  const handleProceedToCheckout = async () => {
    try {
      const response = await fetch("http://localhost:5268/api/checkout", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          items: cartItems.map(item => ({
            id: item.id,
            title: item.title,
            price: item.price,
          })),
        }),
      });

      if (!response.ok) {
        throw new Error("Failed to create checkout session");
      }

      const data = await response.json();
      window.location.href = data.url;
    } catch (err) {
      console.error(err);
      toast.error("Something went wrong starting checkout");
    }
  };

  return (
    <button
      className="checkout-btn"
      onClick={handleProceedToCheckout}
      disabled={!cartItems.length}
    >
      Proceed to Checkout →
    </button>
  );
};

export default CheckoutButton;

