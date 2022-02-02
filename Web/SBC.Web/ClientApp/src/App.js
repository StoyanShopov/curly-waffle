import logo from "./logo.svg";
import "./App.css";
import { Routes, Route, Link } from "react-router-dom";
import LoginAsEmployee from "./pages/LoginAsEmployee";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="loginAsEmployee" element={<LoginAsEmployee />} />
      </Routes>
    </div>
  );
}

export default App;
