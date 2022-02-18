import css from "./LectureCard.module.css"
export default function LectureCard(props){
    return(
        <div>
            <div className={css.btnsDiv}>
                <h3 className={css.lectureTitle}>{props.index +1}. {props.lecture.name}</h3>
                <button className={css.btnDelete}>Delete</button>
                <button className={css.pencil}>Edit</button>
            </div>
            <div>
                
            </div>
        </div>
    )
}