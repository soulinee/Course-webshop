import { useState, type PropsWithChildren } from "react";
import { CourseContext } from "./CourseContext";
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