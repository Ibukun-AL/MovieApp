import React from 'react';

function SearchHistory() {
    // Retrieve recent searches from local storage
    const recentSearches = JSON.parse(localStorage.getItem('recentSearches')) || [];
    const recentFiveSearches = recentSearches.slice(0, 5);

    return (
        <div>
            <h1>Recent Searches</h1>
            <ul>
                {recentFiveSearches.map((search, index) => (
                    <li key={index}>{search}</li>
                ))}
            </ul>
        </div>
    );
}

export default SearchHistory;
