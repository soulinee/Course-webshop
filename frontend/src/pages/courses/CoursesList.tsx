import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

const CoursesList = () => {
  const [courses, setCourses] = useState<Course[]>([]);

  useEffect(() => {
    (async () => {
      const response = await fetch("http://localhost:5263/api/courses");
      const data = await response.json();
      setCourses(data);
    })();
  }, []);

  return (
    <div className="bg-black min-h-screen text-white">
      <div className="max-w-7xl mx-auto px-6 py-10">
        <h1 className="text-3xl font-bold mb-8">
          Available Courses
        </h1>

        <div
          className="
            grid
            grid-cols-1
            sm:grid-cols-2
            md:grid-cols-3
            lg:grid-cols-4
            gap-8
          "
        >
          {courses.map(c => (
            <div
              key={c.id}
              className="bg-gray-900 rounded-lg overflow-hidden hover:scale-[1.02] transition"
            >
              <Link to={`/course/${c.id}`}>
                <img
                  src={c.thumbnail}
                  alt={c.title}
                  className="w-full h-40 object-cover"
                />
                <div className="p-4">
                  <h2 className="font-semibold text-lg mb-1">
                    {c.title}
                  </h2>
                  <p className="text-sm text-gray-400">
                    {c.itemCount} lessons
                  </p>
                </div>
              </Link>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default CoursesList;