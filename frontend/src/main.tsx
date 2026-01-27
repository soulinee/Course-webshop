import {  StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import {  createBrowserRouter, RouterProvider } from 'react-router-dom';
import CoursesList from './pages/courses/CoursesList';
import RootLayout from './layouts/RootLayout';
import Course from './pages/courses/Course';
import CoursesCart from './pages/courses/CoursesCart';
import { CourseProvider } from './context/CourseContext';
import About from './pages/About';
import Login from './components/Login';
import { Toaster } from "react-hot-toast";
import { AuthProvider } from "react-oidc-context"; 
import type { UserManagerSettings } from "oidc-client-ts";
import Callback from './pages/auth/Callback';
import CheckoutSuccesss from "./components/CheckoutSuccesss";
import CheckoutCancel from "./components/CheckoutCancel";
import MyCourses from "./pages/courses/MyCourses";
import Dashboard from './pages/admin/Dashboard';



const settings: UserManagerSettings = { 
  authority:  "http://hogent-identityserver-soulineasaad.azurewebsites.net",
  client_id: "coursemarket-frontend",
  //client_secret: "webapp-secret",
  redirect_uri: "http://localhost:5173/callback",
   post_logout_redirect_uri: "http://localhost:5173/",
  response_type: "code",
  scope:  "openid profile coursegateway",
  monitorSession: true,
};

const onSigninCallback = (): void => { 
  window.history.replaceState({},
  document.title,
  window.location.pathname);
};
const browserRouter = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />, // contains Header + Nav + Footer
    children: [
      {
        index: true,
        element: <CoursesList />, // default page
      },
      {
        path: "courses",
        element: <CoursesList />,
      },
      {
        path: "course/:courseId",
        element: <Course />,
      },
      {
        path: "about",
        element: <About />,
      },
      {
        path: "login",
        element: <Login />,
      },
      {
        path:"cart",
        element:<CoursesCart/>
      },
      {
        path:"callback",
        element:<Callback/>,
      },
      {
      path: "checkout/success",
      element: <CheckoutSuccesss />
      },
      {
      path: "checkout/cancel",
      element: <CheckoutCancel />
      },
      {
        path:"dashboard",
        element:<Dashboard/>
      },

      {
      path: "/my-courses",
      element: <MyCourses />,
      }


    ],
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <AuthProvider {...settings} onSigninCallback={onSigninCallback}>

    <CourseProvider>
    <RouterProvider router={browserRouter}/>
     <Toaster position="top-right" />
    </CourseProvider>
    </AuthProvider>

    {/* <App /> */}
     
  </StrictMode>,
)
