import { Link } from "react-router-dom";

const NavBar = () => {
  return (
    <nav className="flex items-center space-x-8">
      <Link
        to="/courses"
        className="coursess"
      >
        Courses
      </Link>
      <Link
      to="/cart"
      className="cart">
      Cart
      </Link>
      <Link
        to="/about"
        className="about"
      >
        About
      </Link>
      <Link
        to="/login"
        className="login"
      >
        Login
      </Link>
    </nav>
  );
};

export default NavBar;
