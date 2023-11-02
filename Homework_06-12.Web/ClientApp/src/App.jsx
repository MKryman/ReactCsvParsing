import React from 'react';
import './App.css';
import {Route, Routes} from 'react-router-dom';
import Home from './Pages/Home';
import Upload from './Pages/Upload';
import Generate from './Pages/Generate';
import Layout from './Components/Layout';

const App = () => {

    return (
        <Layout>
            <Routes>
                <Route exact path='/home' element={<Home />} />
                <Route exact path='/upload' element={<Upload />} />
                <Route exact path='/generate' element={<Generate />} />
            </Routes>
        </Layout>
    )
}

export default App;