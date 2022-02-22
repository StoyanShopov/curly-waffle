import { useState, useEffect } from 'react';

import styles from './EditCoach.module.css';

const EditCoach = (props) => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('')
    const [price, setPrice] = useState(0);
    const [company, setCompany] = useState('');
    const [description, setDescription] = useState('');
    const [calendlyUrl, setCalendlyUrl] = useState('');
    const [file, setFile] = useState('');
    const [videoUrl, setVideoUrl] = useState('');

    const coach = props.coach;


    return (
        <div className={styles.bodyContainer}>
            <div className={styles.addContainer}>
                <form>
                    <div className={styles.headerContainer}>
                        <div className={styles.titleContainer}>Edit Coach</div>
                        <div className={styles.fileUpload}>
                            <input
                                type="file"
                                className={styles.upload}
                                required />
                            <span>Upload image</span>
                        </div>
                        <button onClick={props.closeModal} className={styles.closeBtn}>
                            <svg xmlns="http://www.w3.org/2000/svg" width="21.92" height="21.92" viewBox="0 0 21.92 21.92">
                                <g id="Group_46" data-name="Group 46" transform="translate(-1484.379 -241.379)">
                                    <line id="Line_59" data-name="Line 59" y2="25" transform="translate(1504.178 243.5) rotate(45)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3" />
                                    <line id="Line_60" data-name="Line 60" y2="25" transform="translate(1504.178 261.178) rotate(135)" fill="none" stroke="#fff" strokeLinecap="round" strokeWidth="3" />
                                </g>
                            </svg>
                        </button>
                    </div>
                    <div className={styles.inputContainer}>
                        <div>
                            <input className={styles.inputField}
                                name="firstName"
                                placeholder='First Name'
                                defaultValue={coach.firstName}
                                onChange={(e) => setFirstName(e.target.value)}
                                type="text"
                                required />
                            <span className={styles.starFirstName}>*</span>
                        </div>

                        <div>
                            <input className={styles.inputField}
                                name="lastName"
                                placeholder='Last Name'
                                type="text"
                                required />
                            <span className={styles.starLastName}>*</span>
                        </div>

                        <div>
                        <input className={styles.inputField}
                                name="videoUrl"
                                placeholder='Video URL'
                                type="text"
                                required />
                                <span className={styles.starVideoUrl}>*</span>
                        </div>
                        
                        <div>
                            <input className={styles.inputField}
                                name="price"
                                placeholder='Price'
                                type="text"
                                required />
                            <span className={styles.starPrice}>*</span>
                        </div>
                        <div>
                            <input className={styles.inputField}
                                name="company"
                                placeholder='Company(optional)'
                                type="text"
                                />
                        </div>
                        <div>
                            <input className={styles.inputField}
                                name="calendlyUrl"
                                placeholder='Calendly URL'
                                type="text"
                                required />
                            <span className={styles.starCalendlyUrl}>*</span>
                        </div>

                        <div>
                            <textarea className={styles.inputField}
                                name="description"
                                placeholder='Description'
                                type="textarea"
                                required />
                            <span className={styles.starDescription}>*</span>
                        </div>
                        <button className={styles.addAnotherCoachBtn}>
                            + Add another coach
                        </button>
                        <div className={styles.footerContainer}>
                            <button className={styles.btnCancel} onClick={props.closeModal} type="button">Cancel</button>
                            <button className={styles.btnSave} type="submit">Save</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    )
}
export default EditCoach;