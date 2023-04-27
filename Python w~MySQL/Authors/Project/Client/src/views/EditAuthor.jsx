import { useEffect,useState } from "react";
import React from "react";
import axios from 'axios';

import AuthorForm from "../componets/AuthorForm";
import { useNavigate, useParams } from "react-router-dom";




const EditAuthor = () => {
    const[author,setauthor] = useState('')
    const nav = useNavigate();
    const { id } = useParams();
    const [ formErrors, setFormErrors ] = useState();

    useEffect(() => {
        axios
            .get(`http://localhost:8000/api/author/${id}`)
            .then((res) => {
                setauthor(res.data.author)
                console.log(author)
            
            })
            .catch((err) => console.log(err));
    }, [])


    const UpdateAuthor = (UpdatedAuthor) => {
        axios
            .put(`http://localhost:8000/api/author/${id}`,UpdatedAuthor)
            .then((results) => {
                console.log(results);
                nav(`/`);
            })
            .catch((err) => {
                console.log(err)
                const errorArr = Object.values(err.response.data.error.errors);
                setFormErrors(errorArr.map(err => err.message));
                
            })
    };

    return (
        <div>
            <h2>Edit Author</h2>
            { author && <AuthorForm formSubmit={UpdateAuthor} authorname={author} formErrors = {formErrors}/>}
        </div>
    );
};


export default EditAuthor;