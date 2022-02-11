import CardCourse from '../CardCourse/CardCourse.js';
import CreateCourse from '../CreateCourse/CreateCourse.js';
import DeleteCourse from '../DeleteCourse/DeleteCourse';
import './AllCourses.css';

const AllCourses = () => {
    return (
        <div>
            <section>
                <h2 className="header-courses">Courses</h2>

            </section>
            <section>
                <div>
                    <CardCourse />
                    <CardCourse />
                    <a href="#popup-Add"><img src="./Group 78.svg" alt="" /></a>
                </div>
                <div id="popup-Add" className="overlay">
                    <section className="popup">
                        <CreateCourse />
                    </section>
                </div>
                <div id="popup-Edit" className="overlay">
                    <section className="popup">
                        <DeleteCourse />
                    </section>
                </div>
            </section>
        </div>
    )
}

export default AllCourses;