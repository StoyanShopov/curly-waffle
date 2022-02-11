import './CardCourse.css';

const CardCourse = () => {
    return (
        <section>
            <div className="card">
                <div className="image-course">
                    <img className="card-image" src="./Rectangle 1221.png" alt="" />
                    <h2 className="course-name">Course name</h2>
                    <a className="pencil" href="#popup-Edit"><img src="./Group 81.svg" alt="" /></a>
                </div>
                <div className="info-course">
                    <p className="card-name">Course name</p>
                    <p className="card-coach">Coach name</p>
                    <p className="card-price">Price per session</p>
                    <span className="card-company">Google</span>
                    <div className="card-button-div">
                        <button className="card-delete-btn" type="submit">Delete</button>
                    </div>
                </div>
            </div>
            <div className="card">
                <div className="image-course">
                    <img className="card-image" src="./Rectangle 1221.png" alt="" />
                    <a className="pencil" href="#popup-Edit"><img src="./Group 81.svg" alt="" /></a>
                    <h2 className="course-name">Course name</h2>
                </div>
                <div className="info-course">
                    <p className="card-name">Course name</p>
                    <p className="card-coach">Coach name</p>
                    <p className="card-price">Price per session</p>
                    <span className="card-company">Google</span>
                    <div className="card-button-div">
                        <button className="card-delete-btn" type="submit">Delete</button>
                    </div>
                </div>
            </div>
        </section>

    )
}

export default CardCourse;