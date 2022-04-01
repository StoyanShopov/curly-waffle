import React, { useState, useEffect } from "react";

import { employeeService } from "../../../services/employee-service";

import Card from '../Courses/EmployeeCourseCard.js';

export default function EmployeeCourses(props) {
    const [employeeCourses, setEmployeeCourses] = useState([])
    const [courseModalDetails, setCourseModalDetails] = useState({})

    useEffect(() => {
        employeeService.getAllCourses()
            .then(response => {
                setEmployeeCourses(response.data);
            });
    }, []);

    return (
        <div>
            {employeeCourses.length > 0 ? employeeCourses.map(x => <Card
                key={x.id}
                course={x}
                courseModalDetails={courseModalDetails}
                setCourseModalDetails={setCourseModalDetails}
                openModal={props.modal.openModal} handleClose={props.modal.handleClose}
            />) : <h1>Loading...</h1>}
        </div>
    );
}