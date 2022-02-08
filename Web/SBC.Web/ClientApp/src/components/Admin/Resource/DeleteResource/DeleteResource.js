function DeleteResource() {
    return (
        <section className="section">
            <div className="topDiv">
                <span className="close">&times;</span>
                <p className="p">Are you sure you want to remove this resource?</p>
            </div>
            <div className="bottomDiv">
            <button className="btnCancel">Cancel</button>
            <button className="btnRemove">Remove</button>
            </div>
        </section>
    )
}
export default DeleteResource();