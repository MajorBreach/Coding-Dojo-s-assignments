import React, { useState } from "react";
import axios from "axios";

import { Link, useNavigate } from "react-router-dom";
import AuthorForm from "../componets/AuthorForm";


const NewAuthor = () => {
    const nav = useNavigate();
    const [ formErrors, setFormErrors ] = useState();

    const formSubmit = (author) => {
        axios
            .post('http://localhost:8000/api/author', author)
            .then((res) => {
                nav('/');
                console.log(res)
            })
            .catch((resError) => {
                console.log(resError);
                const errorArr = Object.values(resError.response.data.error.errors);
                setFormErrors(errorArr.map(err => err.message));
            });
    };


    return (
        <div>
            <div>
                <h2>New Author</h2>
                <Link to="/">Back to Dashboard</Link>
            </div>
            <div>
                <AuthorForm
                    authorname={{name:''}}
                    formSubmit={formSubmit}
                    formErrors ={formErrors}
                />
            </div>
        </div>

    );
};


export default NewAuthor;