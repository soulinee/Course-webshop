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
import Login from './pages/Login';



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
      }
    ],
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <CourseProvider>
    <RouterProvider router={browserRouter}/>

    </CourseProvider>

    {/* <App /> */}
     
  </StrictMode>,
)
