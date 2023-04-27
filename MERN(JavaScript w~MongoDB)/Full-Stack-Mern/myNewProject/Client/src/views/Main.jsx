import React, { useEffect, useState } from 'react'
import ProductList from '../Componets/ProductList';
import Form from '../Componets/Product';
import axios from 'axios';
import ProductList from './Delete';


const Main = (props) => {
    const [pForm, setpForm] = useState([]);
    const [loaded, setLoaded] = useState(false);

    useEffect(() => {
        axios.get('http://localhost:8000/api/form')
            .then(res => {
                console.log(res.data.Form)
                setpForm(res.data.Form);
                setLoaded(true);
            })
            .catch(err => console.error(err));
    }, []);
    const removeFromDom = FormId => {
        setPeople(people.filter(Form => Form._id != FormId));
    }
    

    return (
        <div>
            <Form/>
            <hr />
            {loaded && <ProductList Form = {pForm} removeFromDom = {removeFromDom}/>}
        </div>
    )
}

export default Main;