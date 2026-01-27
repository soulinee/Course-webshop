
import CheckoutButton from "../../components/CheckoutButton";
import { useCourses } from "../../hooks/useCourses";

const CoursesCart = () => {
  const { courses } = useCourses();

  const totalCourses = courses.length;

  return (
    <div className="cart-container">

      <h1 className="cart-title">Shopping Cart</h1>
      <p className="cart-subtitle">{totalCourses} Courses in Cart</p>

      {!totalCourses && <p className="empty-text">No courses in cart</p>}

      <div className="cart-content">

        {/* LEFT SIDE: COURSE LIST */}
        <div className="cart-left">
          {courses.map((c) => (
            <div key={c.id} className="cart-item">

              <img src={c.thumbnail} alt={c.title} className="cart-thumb" />

              <div className="cart-details">
                <h2 className="cart-course-title">{c.title}</h2>
                

                <div className="cart-actions">
                  <button className="remove-btn">Remove</button>
                  <button className="save-btn">Save for Later</button>
                </div>
              </div>

              <div className="cart-price">
                €{c.price.toFixed(2)}
              </div>
              
            </div>
          ))}
        </div>

        {/* RIGHT SIDE: CHECKOUT */}
        <div className="cart-right">
          <h3 className="total-title">Total:</h3>
          <p className="total-price">
            €{courses.reduce((t, c) => t + c.price, 0).toFixed(2)}
          </p>

          {/* <button className="checkout-btn">Proceed to Checkout →</button> */}
            <CheckoutButton cartItems={courses}/>
          
        </div>

      </div>
    </div>
  );
};

export default CoursesCart;
