import './CreateCourse.css';

const CreateCourse = () => {

    const onCourseCreate = (e) => {
        e.preventDefault();

        //let formData = new FormData(e.currentTarget);

        console.log('click');
    }

    return (
        <section className="create-page">
            <h2 className="heading-course">Create course</h2>
            <a className="close" href="/">&times;</a>

            <form id="create-form" onSubmit={onCourseCreate} method="POST">
                <div>
                    <input type="text" className="input-container" name="title" placeholder="Title" />
                    <textarea type="text" className="input-container" name="description" placeholder="Description" ></textarea>
                    <input type="number" className="input-container" name="pricePerPerson" placeholder="Price" />
                    <input type="text" className="input-container" name="pictureUrl" placeholder="PictureUrl" />
                    <input type="text" className="input-container" name="videoUrl" placeholder="VideoUrl" />

                    <select className="select-container" name="coach">
                        <option value="fullname">Niki Kostov</option>
                        <option value="fullname">Stoyan Shopov</option>
                        <option value="fullname">Ivan Ivanov</option>
                    </select>

                    <select className="select-container" name="category">
                        <option value="marketing">Marketing</option>
                        <option value="design">Design</option>
                        <option value="art">Art</option>
                    </select>

                    <select className="select-container" name="language">
                        <option className="input-language" value="english">English</option>
                        <option value="french">French</option>
                        <option value="spanish">Spanish</option>
                    </select>

                    <div className="button-container">
                        <input type="button" className="btn-cancel" value="Cancel" />
                        <input type="submit" className="btn-submit" value="Submit" />
                    </div>
                </div>
            </form>
        </section >
    )
}

export default CreateCourse;
