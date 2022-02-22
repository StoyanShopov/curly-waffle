import css from "../ResourceCard/ResourceCard.module.css"

export default function RecourceCard(){
    return(
        <div className={css.container}>
            <p className={css.resourceTitle}>video</p>
            <button className={css.btnEdit}>Edit</button>
            <button className={css.btnDelete}>Delete</button>
        </div>
    )
}