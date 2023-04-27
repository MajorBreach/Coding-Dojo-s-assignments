import React from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
    
const ProductList = (props) => {
    const { removeFromDom } = props;
    
    const deleteProduct = (Id) => {
        axios.delete('http://localhost:8000/api/people/' + Id)
            .then(res => {
                removeFromDom(Id)
            })
            .catch(err => console.error(err));
    }
    
    return (
        <div>
            {props.form.map((Form ,idx) => {
                return <p key={idx}>
                    <Link to={"/" + Form._id}>
                        {Form.Title}, {Form.Price}{Form.Description}
                    </Link>
                    |
                    <button onClick={(e)=>{deleteProduct(Form._id)}}>
                        Delete
                    </button>
                </p>
            })}
        </div>
    )
}
    
export default ProductList;