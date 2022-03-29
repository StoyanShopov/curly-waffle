import React, { useState, useEffect } from "react";

import { EmployeeService } from "../../../services/employee-service";

import Card from '../Courses/EmployeeCourseCard.js';

export default function EmployeeCourses(props) {
    console.log(EmployeeService)

    const [employeeCourses, setEmployeeCourses] = useState([])
    const [courseModalDetails, setCourseModalDetails] = useState({})

    useEffect(() => {
        EmployeeService.getAllCourses()
            .then(response => {
                setEmployeeCourses(response.data);
            });
    }, []);

    return (
        <div>
            {employeeCourses.length > 0 ? employeeCourses.map(x => <Card key={x.id} course={x} courseModalDetails={courseModalDetails} setCourseModalDetails={setCourseModalDetails} />) : <h1>Loading...</h1>}
        </div>
    );
}