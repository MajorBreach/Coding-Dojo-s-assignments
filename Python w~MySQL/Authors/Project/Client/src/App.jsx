import React from 'react';
import { Routes, Route } from 'react-router-dom';

import Dashboard from './views/Dashboard';
import EditAuthor from './views/EditAuthor';
import NewAuthor from './views/NewAuthor';

function App() {
    return (
        <div className="App">
            <Routes>
                <Route path='/' element={< Dashboard/>} />
                <Route path='/new' element={< NewAuthor/>} />
                <Route path='/author/:id' element={< EditAuthor/>} />
            </Routes>
        </div>
    );
}



export default App;