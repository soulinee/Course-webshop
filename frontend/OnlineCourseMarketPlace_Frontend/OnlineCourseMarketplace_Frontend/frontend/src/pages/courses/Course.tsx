console.log("COURSE COMPONENT IS MOUNTING");


import  { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
 

 
const generateRandomPrice = () => {
  const min = 14.99;
  const max = 69.99;
  return Number((Math.random() * (max - min) + min).toFixed(2));
};




const Course = () => {
  const { courseId } = useParams();
  const [course, setCourse] = useState<Course>();
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
   if (!courseId) return;

    const fetchPlaylist = async () => {
      setIsLoading(true);
      try {
    const response = await fetch(
        `http://localhost:5263/api/courses/${courseId}`
      );

      if (!response.ok) {
        throw new Error("Failed to load course");
      }

      const course = await response.json();

      setCourse({
        ...course,
        price: generateRandomPrice(),
      });
            } catch (error) {
              console.error(error);
            } finally {
              setIsLoading(false);
            }
          };

          fetchPlaylist();
        }, [courseId]);

        if (isLoading) return <p>Loading...</p>;

  return (
    <>
    <div className="courseComponent">

      <h1>{course?.title}</h1>
      <img src={course?.thumbnail} alt={course?.title} />
      <p>{course?.description}</p>
      <p>Videos in playlist: {course?.itemCount}</p>
    </div>
      
    </>
  );
};

export default Course;
