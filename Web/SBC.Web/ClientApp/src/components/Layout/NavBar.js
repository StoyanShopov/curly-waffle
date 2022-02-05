import React from 'react';
import { NavLink } from 'react-router-dom';
import { Link } from 'react-router-dom';

const NavBar = () => {

    return(
        <header>
            <nav>
                <ul>
                    <div>
                       <NavLink tag={Link} to="/" >Home</NavLink>
                    </div>
                    <li>
                       <NavLink tag={Link} to="/loginasemployee">Login as Employee</NavLink>
                    </li>
                    <li>
                       <NavLink tag={Link} to="/register">Register</NavLink>
                    </li>
                    <li>
                        <NavLink tag={Link} to="/docs"></NavLink>
                    </li>
                </ul>
            </nav>
        </header>
    )
}

export default NavBar;