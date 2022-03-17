import { useState, useEffect } from 'react';

import css from './NotificationModal.module.css';

export default function EditProfile(props) {
return (
        
    <div className={css.NotificationContainer}>
        <div className={css.HeaderDiv}>
            <h3>SuperAdmin:<span> New course added - Art - English</span> </h3>
            <h3 className={css.close}>X</h3>
        </div>
        <div className={css.HeaderDiv}>
            <h3>Admin:<span> New course added - Marketing - French</span> </h3>
            <h3 className={css.close}>X</h3>
        </div>
        <div className={css.HeaderDiv}>
            <h3>Admin:<span> New course added - Skiing - Bulgarian</span> </h3>
            <h3 className={css.close}>X</h3>
        </div>
        <div className={css.HeaderDiv}>
            <h3>SuperAdmin:<span> New course added - Hiking - Polish</span> </h3>
            <h3 className={css.close}>X</h3>
        </div>
        <div className={css.HeaderDiv}>
            <h3>Admin:<span> New course added - Running - German</span> </h3>
            <h3 className={css.close}>X</h3>
        </div>
        <div>
        <button className={css.clearBtn}>Clear All</button>
        </div>
    </div>
    )
}