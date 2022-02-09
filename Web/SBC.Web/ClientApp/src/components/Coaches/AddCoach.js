import styles from './AddCoach.module.css';

const AddCoach = () =>
{
    return(
        <body>
            <section>
                <div className={styles.modal}>
                    <div className={styles.modalHead}>
                        <span className={styles.modalBtnClose}>
                            <i className={styles.fa}></i>
                        </span>
                        <h2 className={styles.modalTitle}>Add Coaches</h2>
                    </div>
                    <div className={styles.modalContented}>
                        <form className={styles.formMain}>
                            <div className={styles.formGroup, styles.field}>
                                <input type="input" className={styles.formField} placeholder="First Name *" name="firstname" id="firstName"
                                    required />
                                <label for="firstname" className={styles.formLabel}></label>
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input type="input" className={styles.formField} placeholder="Last Name *" name="lastname" id="lastname"
                                    required />
                                <label for="lastname" className={styles.formLabel}></label>
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input type="input" className={styles.formField} placeholder="Price *" name="price" id="price" required />
                                <label for="price" className={styles.formLabel}></label>
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input type="input" className={styles.formField} placeholder="Description *" name="description"
                                    id="description" required />
                                <label for="description" className={styles.formLabel}></label>
                            </div>

                            <div className={styles.formGroup, styles.field}>
                                <input type="input" className={styles.formField} placeholder="Callendly-URL *" name="calendly" id="calendly"
                                    required />
                                <label for="calendly" className={styles.formLabel}></label>
                            </div>
                        </form>
                    </div>
                    <div className={styles.modalFooter}>
                        <div className={styles.submitBox}>
                            <button className={styles.modalBtnCancel} type="submit">Cancel</button>
                            <button className={styles.modalBtnSave} type="submit">Save</button>
                        </div>
                    </div>
                </div>
            </section>
        </body>
    )
}

export default AddCoach;