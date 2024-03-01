import React, { useState, useEffect } from 'react';
import { useParams} from 'react-router-dom';


function MovieDetails() {
  const { imdbId} = useParams(); // Access movie ID from route parameters
  const [movieDetails, setMovieDetails] = useState(null);
  
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchDetails = async () => {
        setIsLoading(true);
      try {
        const response = await fetch(`https://localhost:44440/movie/details/${imdbId}`); // Adjust URL based on your API endpoint configuration
        if (!response.ok) {
          throw new Error('Failed to fetch movie details');
        }
        const details = await response.json();
        console.log('Movie Data:', details.imdbId);
        setMovieDetails(details);
      } catch (error) {
        console.error('Error fetching movie details:', error);
        // Redirect to home if details fetch fails
      }
      finally {
        setIsLoading(false);
    }
    };

    fetchDetails();
  }, [imdbId]); // Re-fetch details when ID changes

  return (
    <div>
    {isLoading && <p>Loading...</p>}
    {movieDetails && (
        <div>
            <h1>{movieDetails.title}</h1>
            <p>Year: {movieDetails.year}</p>
            <img src={movieDetails.poster} alt={movieDetails.title} />
            <p>ImdbScore: {movieDetails.imdbRating}</p>
            <p>Plot: {movieDetails.plot}</p>
            
            {/* Render other movie details */}
        </div>
    )}
    {!isLoading && !movieDetails && <p>No movie details found</p>}
</div>
  );
}

export default MovieDetails;
