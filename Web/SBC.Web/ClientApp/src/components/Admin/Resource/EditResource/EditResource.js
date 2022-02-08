function EditResource(){
    return(
        <section className="section">
            <form>
                <div>
                    <p className="p">Edit Resource</p>
                </div>
                <div>
                <input className="imput" placeholder="Id*"></input>
                    <input className="imput" placeholder="Name*"></input>
                    <input className="imput" placeholder="FileUrl*"></input>
                    <input className="imput" placeholder="Size*"></input>
                    <select className="imput" >
                    <option value="One">One</option>
                    <option value="Two">Two</option>
                    <option value="Three">Three</option>
                    </select>
                    <input className="imput" placeholder="LectureId*"></input>
                    <input type="submit" value="Edit" className="btn" />
                </div>
            </form>
        </section>
    )
}
export default EditResource();
