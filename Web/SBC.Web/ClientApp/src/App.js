import EditLecture from "./components/Admin/Lecture/EditLecture/EditLecture"
import CreateLecture from "./components/Admin/Lecture/CreateLecture/CreateLecture";
import DeleteLecture from "./components/Admin/Lecture/DeleteLecture/DeleteLecture";

function App() {
  return (
    <div className="App">
      <CreateLecture/>
      <EditLecture/>
    </div>
  );
}

export default App;
