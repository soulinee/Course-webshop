import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useCourses } from "../hooks/useCourses";

const CheckoutSuccesss = () => {
  const navigate = useNavigate();
  const { courses, clearCart } = useCourses();

  useEffect(() => {
    const confirmPayment = async () => {
      await fetch(" http://localhost:5268/api/checkout/confirm", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          userId: "demo-user-1", // later uit auth
          courseIds: courses.map(c => c.id),
        }),
      });

      clearCart();
       navigate("../my-courses");
    };

    confirmPayment();
  }, []);

  return (
    <h1>Payment successful 🎉</h1>
  );
};

export default CheckoutSuccesss;
