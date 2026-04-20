console.log("COURSE COMPONENT IS MOUNTING");


import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Axios from "axios";

const YT_PLAYLIST_URL = "https://www.googleapis.com/youtube/v3/playlists";
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
   // if (!courseId) return;

    const fetchPlaylist = async () => {
      setIsLoading(true);
      try {
        const response = await Axios.get<CourseResponse>(YT_PLAYLIST_URL, {
          params: {
            part: "snippet,contentDetails",
            id: courseId,
            key: import.meta.env.VITE_YOUTUBE_API_KEY,
          },
        });
        console.log(import.meta.env.VITE_YOUTUBE_API_KEY);



        const playlist = response.data.items[0];

        setCourse({
          id: playlist.id,
          title: playlist.snippet.title,
          description: playlist.snippet.description,
          thumbnail: playlist.snippet.thumbnails.medium.url,
          itemCount: playlist.contentDetails.itemCount,
          price: generateRandomPrice()  
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
