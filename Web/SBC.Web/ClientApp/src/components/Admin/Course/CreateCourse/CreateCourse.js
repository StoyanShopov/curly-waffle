import './CreateCourse.css';

const CreateCourse = () => {

    const onCourseCreate = (e) => {
        e.preventDefault();

        //let formData = new FormData(e.currentTarget);

        console.log('click');
    }

    return (
        <section className="create-page">
            <img src="assets/images/Group 5.svg" className="arrow" alt="" />
            <form id="create-form" onSubmit={onCourseCreate} method="POST">
                <div>


                    <input type="text" className="input-container" name="title" placeholder="Title" />
                    <textarea type="text" className="input-container" name="description" placeholder="Description"></textarea>
                    <input type="number" className="input-container" name="pricePerPerson" placeholder="Price" />
                    <input type="text" className="input-container" name="pictureUrl" placeholder="PictureUrl" />
                    <input type="text" className="input-container" name="videoUrl" placeholder="VideoUrl" />

                    <select className="input-container" name="coach">
                        <option value="fullname">Niki Kostov</option>
                        <option value="fullname">Stoyan Shopov</option>
                        <option value="fullname">Pesho Petrov</option>
                    </select>

                    <select className="input-container" name="category">
                        <option value="marketing">Marketing</option>
                        <option value="design">Design</option>
                        <option value="art">Art</option>
                    </select>

                    <select className="input-container" name="language">
                        <option value="english">English</option>
                        <option value="french">French</option>
                        <option value="spanish">Spanish</option>
                    </select>

                    <div className="button-container">
                        <input type="button" id="btn-cancel" value="Cancel" />
                        <input type="submit" id="btn-submit" value="Submit" />
                    </div>
                </div>
            </form>
        </section >
    )
}

export default CreateCourse;
