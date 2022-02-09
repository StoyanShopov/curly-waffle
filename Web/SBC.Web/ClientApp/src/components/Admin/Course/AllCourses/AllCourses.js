import CreateCourse from '../CreateCourse/CreateCourse';
import './AllCourses.css';

const AllCourses = () => {
    return (
        <div>
            <h1>All Courses</h1>

            <a href="#popup1"><img src="./Group 78.svg" alt="snimka" /></a>
            <div id="popup1" className="overlay">
                <section className="popup">
                    <CreateCourse />
                </section>
            </div>
        </div>
    )
}

export default AllCourses;