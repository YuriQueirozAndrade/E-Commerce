import * as React from "react";
import * as ReactDOM from "react-dom/client";
import "@assets/global.css";
import {createBrowserRouter, RouterProvider,} from "react-router-dom";
import Home from "@pages/home/home-page";
import Product from "@pages/products/products-page";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
  },
  {
    path: "/product",
    element: <Product />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
