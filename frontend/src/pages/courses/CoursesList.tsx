import { useEffect, useState } from "react";
//import { Link } from "react-router-dom";
import Loading from "../../components/Loading";
import { Link } from "react-router-dom";
import AddToCartButton from "../../components/AddToCartButton";
import { useCourses } from "../../hooks/useCourses";
import toast from "react-hot-toast";


// 👇 Add this near top of CoursesList.tsx
const generateRandomPrice = () => {
  const min = 14.99;
  const max = 69.99;
  return Number((Math.random() * (max - min) + min).toFixed(2));
};

const CoursesList = () => {
  const [courses, setCourses] = useState<Course[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
   
const{addCoursesToCart} = useCourses();
 

 useEffect(() => {
  const fetchCourses = async () => {
    try {
      setIsLoading(true);
        await new Promise(resolve => setTimeout(resolve, 1000));
      const response = await fetch("http://localhost:5263/api/courses");
// url veranderen naar dit http://hogent-youtubewebapi-soulineasaad.azurewebsites.net
      if (!response.ok) {
        throw new Error("Failed to load courses" + error);
      }
      //old version
      
     
      
      const data: CourseResponse = await response.json();
      console.log("🚨 DATA FROM BACKEND:", data);
      console.log("🚨 RAW BACKEND ITEM:", data[0]);


const coursesMapped: Course[] = data.map((item) => ({
  id: item.id,
  title: item.title,
  description: item.description,
  thumbnail: item.thumbnail,
  itemCount: item.itemCount,
  price: generateRandomPrice(),
}));


setCourses(coursesMapped);




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



 return (
  <main>
  <h1 className="page-title">Available Courses</h1>

{
  isLoading ? (
    <Loading />
  ) : (
    <div className="course-grid">
      {courses.map(c => (
        <div key={c.id} className="course-card">
          
          {/* Clickable course content */}
          <Link to={`/course/${c.id}`} className="course-link">
            <img src={c.thumbnail} alt={c.title} />
            <h2>{c.title}</h2>
            
          </Link>

          {/* Non-navigation actions */}
          <AddToCartButton
           onClick={( ) =>{
            addCoursesToCart(c)
              toast.success(`${c.title} added to cart!`);
          }
            } />
          
            

        </div>
      ))}
    </div>
  )
}


</main>

);

};

export default CoursesList;