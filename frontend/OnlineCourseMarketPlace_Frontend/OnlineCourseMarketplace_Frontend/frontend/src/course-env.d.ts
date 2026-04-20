interface Course {
  id: string;
  title: string;
  description: string;
  thumbnail: string;
  itemCount: number;
  price: number;
  
}

interface YoutubeItem {
  id: string;
  title: string;
  description: string;
  thumbnail: string;
  itemCount: number;
  items: [];
}

type CourseResponse = YoutubeItem[];