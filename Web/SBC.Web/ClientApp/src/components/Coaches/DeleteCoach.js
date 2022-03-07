import styles from './DeleteCoach.module.css';
import { deleteCoachById } from '../../services/adminCoachesService';


const DeleteCoach = (props) => {    

    const coaches = props.coaches.filter(x=>x.id !== props.id)

    const onDeleteCoachHandler = (e) =>
    {
        e.preventDefault(); 	

        deleteCoachById(props.id)
        .then(() =>{
            props.setCoaches(coaches)
            props.closeModal();
        })
    }

    return (
        <div className={styles.container}>
            <div className={styles.modalContainer}>

                <div className={styles.header}>
                    <button className={styles.closeBtn} onClick={() => props.closeModal()}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="21.92" height="21.92" viewBox="0 0 21.92 21.92">
                            <g id="Group_46" data-name="Group 46" transform="translate(-1484.379 -241.379)">
                                <line id="Line_59" data-name="Line 59" y2="25" transform="translate(1504.178 243.5) rotate(45)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3" />
                                <line id="Line_60" data-name="Line 60" y2="25" transform="translate(1504.178 261.178) rotate(135)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3" />
                            </g>
                        </svg>
                    </button>
                    <h3 className={styles.title}>Are you sure you want to delete this coach?</h3>
                </div>

                <div className={styles.footer}>
                    <div className={styles.buttons}>
                        <button className={styles.btnCancel} onClick={() => props.closeModal()} type="button">Cancel</button>
                        <button className={styles.btnSave} type="submit" onClick={onDeleteCoachHandler}>Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default DeleteCoach;