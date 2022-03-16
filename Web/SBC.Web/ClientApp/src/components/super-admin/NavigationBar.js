import { useEffect } from 'react';
import { Link, NavLink } from 'react-router-dom';

import css from './NavigationBar.module.css';
import { userService } from '../../services/user.service';
import { TokenManagement } from '../../helpers';

export default function NavigationBar(props) {
    
  
    let userData = TokenManagement.getUserData();
    const onLogout = () => {
        userService.logout();
      
    }

    useEffect(() => {
        userData = TokenManagement.getUserData();
    }, [])

    return (
        <div className={css.vertical}>
            <div className={css.iconPen}>
                <button className={css.openModal} onClick={() => props.showModal()}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" viewBox="0 0 25 25">
                        <path id="iconmonstr-pencil-2" d="M19.075,2.946l2.981,2.98L6.4,21.585l-3.732.752L3.417,18.6,19.075,2.946Zm0-2.946L1.5,17.576,0,25l7.424-1.5L25,5.926,19.075,0Z" />
                    </svg>
                </button>
            </div>
            <div className={css.circleContainer}>
                <div className={css.circleFloatChild}>
                    <span className={css.nameVisualizer}> {userData ? userData.fullname[0] : "N/A"} </span>
                </div>
                <div className={css.floatChild2}>
                    <label className={css.lable}>{userData ? userData.fullname : "N/A"}</label>
                    <label className={css.lableColored}>{!props.adminData.company ? null : props.adminData.company}</label>
                </div>
                <br />
            </div>
            <div className={css.Navigation}>
                <svg xmlns="http://www.w3.org/2000/svg" width="359" height="1" viewBox="0 0 359 1">
                    <line id="Line_28" data-name="Line 28" x2="358" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                </svg>

                <NavLink to="dashboard">Dashboard</NavLink>
                <svg xmlns="http://www.w3.org/2000/svg" width="359" height="1" viewBox="0 0 359 1">
                    <line id="Line_28" data-name="Line 28" x2="358" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                </svg>

                <NavLink to="clients">Clients</NavLink>
                {/* <a href="/super-admin/clients">Clients</a> */}
                <svg xmlns="http://www.w3.org/2000/svg" width="359" height="1" viewBox="0 0 359 1">
                    <line id="Line_28" data-name="Line 28" x2="358" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                </svg>

                <NavLink to="revenue">Revenue</NavLink>
                <svg xmlns="http://www.w3.org/2000/svg" width="359" height="1" viewBox="0 0 359 1">
                    <line id="Line_28" data-name="Line 28" x2="358" transform="translate(0.5 0.5)" fill="none" stroke="#000" strokeLinecap="round" strokeWidth="1" />
                </svg>

                <NavLink to="" onClick={onLogout} className={css.logOut}>Log Out</NavLink>
            </div>
        </div>
    )
}
