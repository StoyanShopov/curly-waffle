import { Routes, Route } from "react-router-dom";
import { Provider } from "react-redux";

import { store } from "./helpers";

import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import { Layout } from "./components/Layout/Layout";
import Home from "./components/Home";
import AddCoach from "./components/Coaches/AddCoach";
import EditCoach from "./components/Coaches/EditCoach";

import "./App.css";
import { StrictMode } from "react";

function App() {
  return (
    <Provider store={store}>
      <Layout>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
          <Route path="/coaches/editCoach" element={<EditCoach />}/>
        </Routes>
      </Layout>
    </Provider>
  );
}

export default App;
