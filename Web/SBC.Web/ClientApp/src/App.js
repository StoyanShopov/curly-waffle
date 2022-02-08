import { Route, Routes } from 'react-router-dom';
import './App.css';
import AdminProfile from './components/AdminProfile';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route exact path='/super-admin/' element={< AdminProfile />}></Route>
        <Route  path='/super-admin/clients' element={< AdminProfile nav="clients" />}></Route>
        <Route  path='/super-admin/revenue' element={< AdminProfile nav="revenue" />}></Route>
        <Route render={() => <h1>Page not found</h1>} />
      </Routes>
    </div>
  );
}

export default App;