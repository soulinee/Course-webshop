interface Course {
  id: string;
  title: string;
  description: string;
  thumbnail: string;
  itemCount: number;
}

interface CourseResponse {
  items: {
    id: string;
    snippet: {
      title: string;
      description: string;
      thumbnails: {
        medium: { url: string };
      };
    };
    contentDetails: {
      itemCount: number;
    };
  }[];
}
