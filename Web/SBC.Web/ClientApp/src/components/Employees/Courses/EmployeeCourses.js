import React, { useState, useEffect } from "react";

import { courseService } from "../../../services/EmployeesCoursesService.js"

import Card from '../Courses/EmployeeCourseCard.js';

export default function EmployeeCourses(props) {

    const [employeeCourses,setEmployeeCourses] = useState([])

    useEffect(() => {
        courseService.getAllCourses()
            .then(response => {
                setEmployeeCourses(response.data);
            });
    }, []);

    console.log(employeeCourses);

    return (
        <div>
            { employeeCourses.length > 0 ? employeeCourses.map(x=> <Card key={x.id} course={x} />) : <h1>Loading...</h1> }
        </div>
    );
}