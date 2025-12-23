import { Link } from "react-router-dom";

const NavBar = () => {
  return (
    <nav className="flex items-center space-x-8">
      <Link
        to="/courses"
        className="text-gray-300 hover:text-white no-underline transition"
      >
        Courses
      </Link>
      <Link
        to="/about"
        className="text-gray-300 hover:text-white no-underline transition"
      >
        About
      </Link>
      <Link
        to="/login"
        className="text-gray-300 hover:text-white no-underline transition"
      >
        Login
      </Link>
    </nav>
  );
};

export default NavBar;
