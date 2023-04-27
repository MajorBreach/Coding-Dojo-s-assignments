import React, { useState, useEffect } from "react";
import axios from 'axios'
import { Link } from "react-router-dom";
import DeleteButton from "../componets/DeleteButton";

// import Author from "../componets/Author";

const Dashboard = () => {
    const [authorList, setAuthorList] = useState([]);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/author')
            .then((res) => {
                setAuthorList(res.data.author);
            })
            .catch((err) => console.log(err));
    }, []);

    const removefromdom = (authordelete) =>{
        console.log(authordelete)
        setAuthorList(authorList.filter((author)=> author._id !== authordelete))
    };

    return (
        <div>
            <div>
                <h2>Favorite Authors</h2>
                <Link to='/new'>Add a new Author!</Link>
                
            </div>
            <div>
                {
                    authorList && authorList.map((author, i) => (
                        <><p>{author.name}</p>
                            <div>
                                <Link key={i}  to={`/author/${author._id}`}>Edit</Link> |
                                <DeleteButton authorId={author._id} successCallback={() => removefromdom(author._id)} />
                            </div></>
                    ))
                }
            </div>

        </div>
    );
};


export default Dashboard;