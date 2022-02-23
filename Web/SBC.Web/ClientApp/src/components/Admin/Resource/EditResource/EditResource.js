import style from "./EditResource.module.css";

function EditResource({ closeModal }) {
    return (
        <section className={style.section}>
            <div className={style.container}>
                <form>
                    <div>
                        <button className={style.btnClose} onClick={() => { closeModal(false) }}>X</button>
                        <p className={style.p}>Edit Resource</p>
                    </div>
                    <div>
                        <input className={style.imput} required="required" name="Id" placeholder="Id*"></input>
                        <input className={style.imput} required="required" name="Name" placeholder="Name*"></input>
                        <input className={style.imput} required="required" name="Fileurl" placeholder="FileUrl*"></input>
                        <input className={style.imput} required="required" name="Size" placeholder="Size*"></input>
                        <select className={style.imput} name="Select" >
                            <option value="One">One</option>
                            <option value="Two">Two</option>
                            <option value="Three">Three</option>
                        </select>
                        <input className={style.imput} required="required" name="LectureId" placeholder="LectureId*"></input>
                        <button className={style.btnCancel} onClick={() => { closeModal(false) }}>Cancel</button>
                        <input type="submit" value="Edit" className={style.btnSubmit} />
                    </div>
                </form>
            </div>
        </section>
    )
}
export default EditResource;
