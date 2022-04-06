import { Link, NavLink } from "react-router-dom";

import styles from "./NavBar/NavBar.module.css";

export const Links = (props) => {

    switch (props.role) {
        case 'Administrator': return (<ul>
            <li><NavLink tag={Link} to="/super-admin">Super AdminProfile</NavLink></li>
            
        </ul>);
            case 'Owner': return (<ul>
                <li><NavLink tag={Link} to="/profileOwner">Owner</NavLink></li>
                <li><NavLink tag={Link} to="/ownerEmployees">Owner Employees</NavLink></li>
            </ul>);
            case 'Employee': return (<ul>
                <li> <NavLink
                    tag={Link}
                    to="/courses"
                    className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
                >
                    Courses
                </NavLink> </li>
                <li><NavLink
                    tag={Link}
                    to="/coaches"
                    className={({ isActive }) => (isActive ? styles.coursesActive : styles.coursesNotActive)}
                >
                    Coaches
                </NavLink> </li>
            </ul>);
            default: return (<ul>
                <li><NavLink tag={Link} to="/loginasemployee">Welcome guest</NavLink></li>
                );
            </ul>);
        };
}