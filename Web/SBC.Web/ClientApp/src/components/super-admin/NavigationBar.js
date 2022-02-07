import css from './NavigationBar.module.css';

export default function NavigationBar() {

    return (
        <div className={css.vertical}>
            <div className={css.iconPen}>
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 25 25">
                    <path id="iconmonstr-pencil-2" d="M19.075,2.946l2.981,2.98L6.4,21.585l-3.732.752L3.417,18.6,19.075,2.946Zm0-2.946L1.5,17.576,0,25l7.424-1.5L25,5.926,19.075,0Z" />
                </svg>
            </div>
            <div className={css.circleContainer}>
                <div className={css.circleFloatChild}>
                    <span className={css.nameVisualizer}> I </span>
                </div>
                <div className={css.floatChild2}>
                    <label className={css.lable}>Ivan Dimitrov</label>
                    <label className={css.lableColored}>Motion Software</label>
                </div>
                <br />
            </div>
            <div className={css.Navigation}>
                <svg></svg>
                <a>Dashboard</a>
                <svg></svg>
                <a>Clients</a>
                <svg></svg>
                <a>Revenue</a>
                <svg></svg>
                <a className={css.logOut}>Log Out</a>
            </div>
        </div>
    )
}