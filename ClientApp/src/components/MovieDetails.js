import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';


function MovieDetails() {
  const { imdbId} = useParams(); // Access movie ID from route parameters
  const [movieDetails, setMovieDetails] = useState(null);
  const navigate = useNavigate(); // For navigation

  useEffect(() => {
    const fetchDetails = async () => {
      try {
        const response = await fetch(`https://localhost:44440/movie/${imdbId}`); // Adjust URL based on your API endpoint configuration
        if (!response.ok) {
          throw new Error('Failed to fetch movie details');
        }
        const details = await response.json();
        console.log('Movie Data:', details.imdbId);
        setMovieDetails(details);
      } catch (error) {
        console.error('Error fetching movie details:', error);
        navigate('/');// Redirect to home if details fetch fails
      }
    };

    fetchDetails();
  }, [imdbId, navigate]); // Re-fetch details when ID changes

  return (
    <div>
      {movieDetails ? (
        <>
          <h2>{movieDetails.title}</h2>
          {/* <img src={movieDetails.poster} alt={movieDetails.title} /> */}
          <p>Year: {movieDetails.year}</p>
          <p>Director: {movieDetails.director}</p>
          <p>Plot: {movieDetails.plot}</p>
          {/* Add other details and formatting as needed */}
        </>
      ) : (
        <p>Movie details not found.</p>
      )}
    </div>
  );
}

export default MovieDetails;
