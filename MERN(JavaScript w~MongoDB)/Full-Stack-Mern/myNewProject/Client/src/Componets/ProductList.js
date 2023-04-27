import React from 'react'
import axios from 'axios';
import { Link } from 'react-router-dom';
    
const ProductList = (props) => {
    return (
        <div>
            {props.Form.map( (Form, i) =>
                <p key={i}>
                {Form.Title},
                {Form.Price}, 
                {Form.Description}
                <Link to='/form/:id'>View</Link> |
                <Link to='/form/:id'>Update</Link> |
                <Link to='/form/:id'>delete</Link>
                </p>
                
            )}
        </div>
    )
}
    
export default ProductList;

