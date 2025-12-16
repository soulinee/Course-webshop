import { BrowserRouter, Routes, Route } from "react-router-dom";
import Header from "./components/Header";
import Footer from "./components/Footer";
import CoursesList from "./pages/courses/CoursesList";
import Course from "./pages/courses/Course";



function App() {
  return (
    <BrowserRouter>
      <Header />
      

  <main className="bg-black min-h-screen">
    <Routes>
      <Route path="/courses" element={<CoursesList />} />
      <Route path="/course/:courseId" element={<Course />} />
    </Routes>
  </main>

  <Footer />
    </BrowserRouter>
  );
}

export default App;
