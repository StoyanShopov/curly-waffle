import styles from './DeleteCoach.module.css';


const DeleteCoach = () => {

    return (
        <div className={styles.container}>
            <div className={styles.modalContainer}>

                <div className={styles.header}>
                    <span className={styles.title}>Are you sure you want to delete this coach?</span>
                </div>

                <div className={styles.footer}>
                    <div className={styles.buttons}>
                        <button className={styles.btnCancel} type="button">Cancel</button>
                        <button className={styles.btnSave} type="submit">Delete</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default DeleteCoach;