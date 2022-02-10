import CreateCourse from '../CreateCourse/CreateCourse.js';
import DeleteCourse from '../DeleteCourse/DeleteCourse';
import './AllCourses.css';

const AllCourses = () => {
    return (
        <div>
            <h1>All Courses</h1>
            <div>
                
            </div>
            <a href="#popup1"><img src="./Group 78.svg" alt="" /></a>
            <a href="#popup2"><img src="./Group 81.svg" alt="" /></a>
            <div id="popup1" className="overlay">
                <section className="popup">
                    <CreateCourse />
                </section>
            </div>
            <div id="popup2" className="overlay">
                <section className="popup">
                    <DeleteCourse />
                </section>
            </div>
        </div>
    )
}

export default AllCourses;