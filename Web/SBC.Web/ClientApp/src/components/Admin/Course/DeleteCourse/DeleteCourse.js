import "./DeleteCourse.css";

export default function DeleteCourse() {
    return (
        <div className="delete-window">
            <div className="top-div">
                <a className="close" href="/">&times;</a>
                <p className="text-question">Are you sure you want to delete this course?</p>
            </div>
            <div className="bottom-div">
                <div className="button-div">
                    <button className="btn-cancel" type="button">Cancel</button>
                    <button className="btn-delete" type="submit">Delete</button>
                </div>
            </div>
        </div>
    )
}