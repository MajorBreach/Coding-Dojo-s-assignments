import React from "react";
import axios from 'axios';


const Deletebutton = (props) =>{
    const { authorId, successCallback } = props;
    const ID = authorId;
console.log(authorId)
const deleteauthor = () => {
    axios
        .delete(`http://localhost:8000/api/author/${authorId}`)
        .then((res) => {
            successCallback ();
            console.log(res);
        })
        .catch((err) => console.log(err))
}

    return (
        <button onClick={() => deleteauthor()}>Delete me</button>
    );
    
}
export default Deletebutton;