import "./App.css";
import { Routes, Route } from "react-router-dom";
import LoginAsEmployee from "./pages/LoginAsEmployee";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/Login" element={<LoginAsEmployee />} />
      </Routes>
    </div>
  );
}

export default App;
