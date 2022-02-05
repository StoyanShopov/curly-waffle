import "./App.css";
import { Routes, Route } from "react-router-dom";
import LoginAsEmployee from "./components/Login/LoginAsEmployee";
import { Layout } from "./components/Layout/Layout";
import Home from "./components/Home";

function App() {
  return (
    <Layout>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
      </Routes>
    </Layout>
  );
}

export default App;
