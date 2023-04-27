import React from 'react';
import Main from './views/Main';
import Detail from './views/Details';
import { Routes, Route, Link } from 'react-router-dom';



function App() {
    return (
        <div className="App">
            <h1>Products!</h1>
            <div>
                <Link to='/'>dashboard</Link> |
                <Link to='/form/new'>Create</Link>
            </div>
            <div>
                <Routes>
                    <Route element={<Main />} path="/" />
                    <Route element={<Detail />} path="/form" />
                </Routes>
            </div>
        </div>
    );
}



export default App;