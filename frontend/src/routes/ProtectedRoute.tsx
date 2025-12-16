import React from 'react'
import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";


type ProtectedRouteProps = {
  requiredRole?: "User" | "Admin";
};

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ requiredRole })=> {


   const { user, isLoading } = useAuth();
  const location = useLocation();

  // still loading auth state
  if (isLoading) return <div>Loading...</div>;

  // not authenticated
  if (!user) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  // role check
  if (requiredRole && user.role !== requiredRole) {
    return <Navigate to="/forbidden" replace />;
  }

  // all good
  return <Outlet />;
};

export default ProtectedRoute