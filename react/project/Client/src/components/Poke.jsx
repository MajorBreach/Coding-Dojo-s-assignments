import React, { useState } from 'react';
import axios from 'axios';

const Poke = () => {
    const [responseData, setResponseData] = useState("");

    const fetchpoke =() => {
        axios.get('https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0')
            .then(response => { 
                setResponseData(response.data.results) })
    };
    
    
    
    
    
    return (
        
        <div>
            <button onClick={fetchpoke}>GET POKE's!</button>
            <h1>{responseData.length > 0 && responseData.map((poke,i)=> {
                return <div key={i}>
                    {poke.name}
                </div>
            
            })}</h1>
        </div>
    )
};
export default Poke;