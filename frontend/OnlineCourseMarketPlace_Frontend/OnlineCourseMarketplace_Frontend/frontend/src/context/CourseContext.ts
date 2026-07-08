import { createContext } from "react";

interface CoursesContextType {
  courses: Course[];
  addCoursesToCart: (course: Course) => void;
  clearCart: () => void;
}

export const CourseContext = createContext<CoursesContextType | null>(null);