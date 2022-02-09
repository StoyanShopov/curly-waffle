import { Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";

import { store } from "./helpers";

import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import { Layout } from "./components/Layout/Layout";
import Home from "./components/Home";
import Homepage from "./components/Homepage/Homepage";
import Header from "./components/Homepage/Header/Header";
import Main from "./components/Homepage/Main/Main"

import "./App.css";

function App() {
  return (
    <Provider store={store}>
      <Layout>
        <Routes>
          <Route path="/" element={<Homepage />} />
          <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
        </Routes>
      </Layout>
    </Provider>
  );
}

export default App;
