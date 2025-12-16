 
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Axios from "axios";


const BASE_FIND_URL = "https://api.themoviedb.org/3/movie/";
 
const CourseDetail = () => {

   const { courseId } = useParams();

  const [course, setCourse] = useState<Course>();
  const [isLoading, setIsLoading] = useState(false);

   useEffect(() => {
    setIsLoading(true);
    (async () => {
      try {
        const response = await Axios.get<Course>(`${BASE_FIND_URL}${courseId}`, {
          headers: {
            Authorization: import.meta.env.VITE_TMDB_API_KEY,
          },
        });
        setCourse(response.data);
      } catch (error) {
        console.log(error);
      } finally {
        setIsLoading(false);
      }
    })();
  }, [courseId]);
  return (
    <>
    <h1>


    </h1>
    <p>

    </p>
    </>
  )
}

export default CourseDetail