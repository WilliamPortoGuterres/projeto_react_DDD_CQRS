import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Login } from "./components/Login";
import { CreateLogin } from "./components/CreateLogin";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/Login',
    element: <Login />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/CreateLogin',
    element: <CreateLogin />
  }

];

export default AppRoutes;
