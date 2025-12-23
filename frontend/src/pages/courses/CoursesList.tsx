import { useEffect, useState } from "react";
//import { Link } from "react-router-dom";
import Loading from "../../components/Loading";

const CoursesList = () => {
  const [courses, setCourses] = useState<Course[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
 useEffect(() => {
  const fetchCourses = async () => {
    try {
      setIsLoading(true);
        await new Promise(resolve => setTimeout(resolve, 1000));
      const response = await fetch("http://localhost:5263/api/courses");

      if (!response.ok) {
        throw new Error("Failed to load courses");
      }

      const data = await response.json();
      setCourses(data);

    } catch (error) {
      if (error instanceof Error) {
        setError(`Error: ${error.message}`);
      } else {
        setError("Unexpected error occurred");
      }
    } finally {
      setIsLoading(false);
    }
  };

  fetchCourses();
}, []);


// conditionele rendering

  //if(isLoading){
   // return <Loading/>;
  //}
 return (
  <main>
  <h1 className="page-title">Available Courses</h1>
  
     
   

       

{
  isLoading ? <Loading/> : <div className="course-grid">
    {courses.map(c => (
      <a key={c.id} href={`/course/${c.id}`} className="course-card">
        <img src={c.thumbnail} alt={c.title} />
        <h2>{c.title}</h2>
        <p>{c.itemCount} lessons</p>
      </a>
    ))}
  </div>
}
   
</main>

);

};

export default CoursesList;