import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { Form, useParams } from "react-router-dom";
    
const Detail = (props) => {
    const [Form, setForm] = useState({})
    const { _id } = useParams();
    
    useEffect(() => {
        axios.get('http://localhost:8000/api/form/' +_id)
            .then(res => setForm(res.data.Form))
            .catch(err => console.error(err));
    }, []);
    
    return (
        <div>
            <p>Product :{Form.Title}</p>
            <p>Price :{Form.Price}</p>
            <p>Description :{Form.Description}</p>
        </div>
    )
}

export default Detail;