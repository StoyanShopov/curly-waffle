import "./App.css";
import { Routes, Route } from "react-router-dom";
import LoginAsEmployee from "./components/Login/LoginAsEmployee";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/loginAsEmployee" element={<LoginAsEmployee />} />
      </Routes>
    </div>
  );
}

export default App;
