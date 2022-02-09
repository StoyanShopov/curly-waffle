import { Route, Routes } from 'react-router-dom';
import './App.css';
import AdminProfile from './components/AdminProfile';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route  path='/super-admin/*' element={<AdminProfile />} />
        <Route  path='*' element={() => <h1>Page not found</h1>} />
      </Routes>
    </div>
  );
}

export default App;