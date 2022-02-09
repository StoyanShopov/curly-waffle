import EditLecture from "./components/Admin/Lecture/EditLecture/EditLecture"
import CreateLecture from "./components/Admin/Lecture/CreateLecture/CreateLecture";

//import logo from './logo.svg';
import './App.css';
import './components/Admin/Course/DeleteCourse/DeleteCourse.js';
import DeleteCourse from './components/Admin/Course/DeleteCourse/DeleteCourse.js';
import CreateCourse from './components/Admin/Course/CreateCourse/CreateCourse.js';

function App() {
  return (
    <div className="App">
      {/* <CreateLecture/>
      <EditLecture/>
      */}
      {/* <DeleteCourse /> */}
      <CreateCourse />
    </div>
  );
}

export default App;
