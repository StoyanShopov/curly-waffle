import style from './EditModal.module.css';

const EditCourse = ({ setEditModal }) => {

    const onCourseEdit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        console.log('submit');
    }

    return (
        <section className={style.editPage}>
            <h2 className={style.headingCourse}>Edit course</h2>
            <button className={style.closeCreate} onClick={() => { setEditModal(false); }}>&times;</button>

            <form id="create-form" onSubmit={onCourseEdit} method="POST">
                <div>
                    <input type="text" className={style.inputContainer} required = "required" name="title" placeholder="Title" />
                    <textarea type="text" className={style.inputContainer} required = "required" name="description" placeholder="Description" ></textarea>
                    <input type="number" className={style.inputContainer} required = "required" name="pricePerPerson" placeholder="Price" />
                    <input type="text" className={style.inputContainer} required = "required" name="pictureUrl" placeholder="PictureUrl" />
                    <input type="text" className={style.inputContainer} required = "required" name="videoUrl" placeholder="VideoUrl" />

                    <select className={style.selectContainer} value="Pesho" name="coach">
                        <option value="fullname">Niki Kostov</option>
                        <option value="fullname">Stoyan Shopov</option>
                        <option value="fullname">Ivan Ivanov</option>
                    </select>

                    <select className={style.selectContainer} name="category" value="3">
                        <option value="marketing">Marketing</option>
                        <option value="design">Design</option>
                        <option value="3">Art</option>
                    </select>

                    <select className={style.selectContainer} name="language">
                        <option className="input-language" value="english">English</option>
                        <option value="french">French</option>
                        <option value="spanish">Spanish</option>
                    </select>

                    <div className={style.buttonContainer}>
                        <input type="button" className={style.btnCancel} value="Cancel" onClick={() => { setEditModal(false); }} />
                        <input type="submit" className={style.btnSubmit} value="Submit" />
                    </div>
                </div>
            </form>
        </section >
    )
}

export default EditCourse;
