function CreateResource(){
    return(
        <section className="section">
            <form>
                <div>
                    <p className="p">Add Resource</p>
                </div>
                <div>
                    <input className="imput" placeholder="Name*"></input>
                    <input className="imput" placeholder="FileUrl*"></input>
                    <input className="imput" placeholder="Size*"></input>
                    <select className="imput" >
                    <option value="One">One</option>
                    <option value="Two">Two</option>
                    <option value="Three">Three</option>
                    </select>
                    <input className="imput" placeholder="LectureId*"></input>
                    <input type="submit" value="Add" className="btn" />
                </div>
            </form>
        </section>
    )
}
export default CreateResource();