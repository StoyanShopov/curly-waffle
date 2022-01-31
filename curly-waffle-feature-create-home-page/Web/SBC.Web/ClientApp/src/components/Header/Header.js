import { Link } from "react-router-dom";
import css from './Header.module.css'

export default function Header() {
    return (
            <header className={css.header}>

                <ul >

                    <li className={css.li}>
                        <ul className={css.ulLogo}>
                            <li className={css.li}><img src="/Group 5.jpg" alt="image" /></li>
                            <li className={css.li}>
                                <Link to='/' className={css.pUpSkill }>upskill</Link>
                            </li >
                        </ul>
                    </li>

                    <li className={css.li}>
                        <ul className={css.ul}>
                            <li className={css.li}>
                                <button className={css.loginButton}>
                                    <Link to="/login" className={css.loginLink}>Login</Link>
                                </button>
                            </li>

                            <li className={css.li}>
                                <button className={css.requestDemoBtn}>
                                    <Link to="/Demos" className={css.requestDemo}>Request a Demo</Link>
                                </button>
                            </li>
                        </ul>
                    </li>
                </ul>

            </header>
    );
}