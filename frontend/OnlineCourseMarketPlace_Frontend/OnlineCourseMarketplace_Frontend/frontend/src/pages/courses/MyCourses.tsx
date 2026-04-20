import { useEffect, useState } from "react";

type Course = {
  id: string;
  title: string;
  thumbnailUrl?: string;
};

const MyCourses = () => {
  const [courses, setCourses] = useState<Course[]>([]);

  useEffect(() => {
    fetch("http://localhost:5268/api/courses/my")
      .then(res => {
        if (!res.ok) throw new Error("Failed to load courses");
        return res.json();
      })
      .then(data => {
        // 🔥 data IS de array
        setCourses(data);
      })
      .catch(err => console.error(err));
  }, []);

  if (!courses.length) {
    return <h2>You can find your courses in Dashboard</h2>;
  }

  return (
    <div>
      <h1>My Courses</h1>
      {courses.map(course => (
        <div key={course.id}>
          <h3>{course.title}</h3>
        </div>
      ))}
    </div>
  );
};

export default MyCourses;

