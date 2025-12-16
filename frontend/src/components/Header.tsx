import { Link } from "react-router-dom";
import NavBar from "./NavBar";

const Header = () => {
  return (
    <header className="bg-black border-b border-gray-800">
      <div className="max-w-7xl mx-auto px-6 py-4 flex items-center justify-between">
        <Link
          to="/courses"
          className="text-2xl font-bold text-white no-underline"
        >
          CourseMarket
        </Link>

        <NavBar />
      </div>
    </header>
  );
};

export default Header;
