import { Link } from "react-router-dom";
import { useAuth } from "react-oidc-context";
const NavBar = () => {

   const { isAuthenticated, signoutRedirect } = useAuth();


  return (
    <nav className="flex items-center space-x-8">
      <Link
        to="/courses"
        className="coursess"> Courses</Link>
      <Link
      to="/cart"
      className="cart">Cart</Link>
      <Link
        to="/about"
        className="about"> About </Link>
         <Link
        to="/dashboard"
        className="dashboard"> Dashboard </Link>



      {/* <Link
        to="/login"
        className="login" >
        Login
      </Link> */}

       {!isAuthenticated ? (
        // ✅ Login blijft een Link naar aparte pagina
        <Link to="/login" className="login">
          Login
        </Link>
      ) : (
        // 🔥 Logout is GEEN Link (moet actie zijn)
        <button
          onClick={() => signoutRedirect()}
          className="login"
        >
          Logout
        </button>
      )}













    </nav>
  );
};

export default NavBar;
