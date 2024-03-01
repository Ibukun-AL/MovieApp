import React, { useState, useEffect} from 'react';
import { Link } from 'react-router-dom'; 

function SearchMovie() {
    const [movie, setMovie] = useState(null);
    const [searchQuery, setSearchQuery] = useState('');
    const [isLoading, setIsLoading] = useState(false); // State to track loading
  
    const fetchMovie = async (title) => {
        setIsLoading(true); 
        try {
            const response = await fetch(`https://localhost:44440/movie/${title}`);
            if (!response.ok) {
                throw new Error('Failed to fetch movie');
            }
            const movieData = await response.json();
            console.log('Movie Data:', movieData);
            setMovie(movieData);
        } catch (error) {
            console.error('Error fetching movie:', error);
        }
        finally {
            setIsLoading(false); // Always set loading to false (success or failure)
          }
    };

    

    const handleInputChange = (event) => {
        setSearchQuery(event.target.value);
    };

    const handleSearch = () => {
        fetchMovie(searchQuery);
    };

    return (
        <div>
            <h1>Search Movie</h1>
            <input
                type="text"
                placeholder="Enter movie title"
                value={searchQuery}
                onChange={handleInputChange}
            />
            <button onClick={handleSearch}>Search</button>
            {isLoading && <p>Loading...</p>} {/* Show loading indicator only when fetching */}
      {movie ? (
        <div className="movie-card">
        <h3>{movie.title}</h3>
        <h3>{movie.imdbId}</h3>
        <Link to={`/movie-details/${movie.imdbId}`}>
          <button>View Details</button>
        </Link>
      </div>
      ) : !isLoading && <p></p>} {/* Show "No movie found" if movie is null and not loading */}
    </div>
    );
}

export default SearchMovie;

