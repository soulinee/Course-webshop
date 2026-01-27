
import { useAuth } from "react-oidc-context";

 const Login = () => {
// (isAuthenticated ? "" : "animate-pulse")
  const { isAuthenticated, signinRedirect,
          signoutRedirect, user } = useAuth();

  return (
    <div className="inloggen">
      <div>
        <p className="inloggennaam">
          Geef je naam en wachtwoord
        </p>
      </div>
      <button
        className={`buttonlogin ${isAuthenticated ? "" : "animate-pulse"}`}
          onClick={() => ( isAuthenticated
              ? signoutRedirect()
             : signinRedirect() )}
                
       >
        {isAuthenticated
          ? `Logout userId ${JSON.stringify(user?.profile.sub)}`
          : "Login"}
      </button>
    </div>
  );
};
export default Login;


 