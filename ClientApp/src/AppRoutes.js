import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import SearchMovie from "./components/SearchMovie";
import MovieDetails from "./components/MovieDetails";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/search-movie',
    element: <SearchMovie />
  },
  {
    path: '/movie-details/:imdbId',
    element: <MovieDetails />
  },
];

export default AppRoutes;
