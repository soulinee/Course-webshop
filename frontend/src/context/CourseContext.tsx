//stap 1 aanmaken van nieuwe context

import { createContext,  useState, type PropsWithChildren } from "react";
import React from 'react'

interface CoursesContextType{
  courses: Course[];
  addCoursesToCart:(item:Course) => void;
   clearCart: () => void;
}

export const CourseContext = createContext<CoursesContextType | null>(null);

// stap 2 provider aanmaken voor deze context


export const CourseProvider = (props:PropsWithChildren) => {
  const [courses, setCourses] = useState<Course[]>([]);
  const addCoursesToCart = (item:Course) =>{

    setCourses([...courses, item]);
  };
    const clearCart = () => {
    setCourses([]);
  };
  return(

    <CourseContext.Provider value={{courses, addCoursesToCart,clearCart}}>
      {props.children}
    </CourseContext.Provider>
  );
}

 