import { Route, Routes } from 'react-router-dom';
import Homepage from './components/Homepage/Homepage';
import Test from './components/Test/Test';

function App() {
  return (
    <div className="App"> 
      <Routes>
        <Route path="/" element={<Test/>}/>
      </Routes>    
    </div>
  );
}

export default App;
