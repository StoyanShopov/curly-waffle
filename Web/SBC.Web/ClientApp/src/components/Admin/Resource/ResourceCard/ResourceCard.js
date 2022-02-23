import style from "../ResourceCard/ResourceCard.module.css"

export default function RecourceCard() {
    return (
        <div className={style.container}>
            <p className={style.resourceTitle}>video</p>
            <button className={style.btnEdit}>Edit</button>
            <button className={style.btnDelete}>Delete</button>
        </div>
    )
}
