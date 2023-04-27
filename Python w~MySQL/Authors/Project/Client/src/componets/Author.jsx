import React from "react";

import { Link } from "react-router-dom";


const Author = ({author}) => {


    return (
        <div>
            <h2>Author:{author.name}</h2>
            <Link to={`/author/${author._id}`} >View</Link>
        </div>
    );
};


export default Author;