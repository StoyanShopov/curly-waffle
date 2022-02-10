import EditLecture from "./components/Admin/Lecture/EditLecture/EditLecture"
import CreateLecture from "./components/Admin/Lecture/CreateLecture/CreateLecture";

//import logo from './logo.svg';
import './App.css';
import './components/Admin/Course/DeleteCourse/DeleteCourse.js';
import DeleteCourse from './components/Admin/Course/DeleteCourse/DeleteCourse.js';
import CreateCourse from './components/Admin/Course/CreateCourse/CreateCourse.js';
import AllCourses from "./components/Admin/Course/AllCourses/AllCourses";

function App() {
  return (
    <div className="App">
      <AllCourses />
    </div>
  );
}

export default App;
