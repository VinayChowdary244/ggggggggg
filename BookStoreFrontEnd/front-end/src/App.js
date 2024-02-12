import { useState, useEffect } from 'react';
import './App.css';
import { BrowserRouter, Route, Routes ,Switch} from 'react-router-dom';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';
import MainMenu from './Components/MainMenu';
import { AuthProvider } from './Components/AuthContext';

import UpdateUser from './Components/UpdateUser';
import Home from './Components/Home';
import AddBook from './Components/AddBook';
import Books from './Components/Books';
import Users from './Components/Users';
import UpdateBook from './Components/UpdateBook';


function App() {
  return (
    <AuthProvider>
    <BrowserRouter>
    <div>
      
      <MainMenu/>
      <Routes>
      
      <Route path='/' element={<RegisterUser />} />
        <Route path="/UserLogin" element={<UserLogin   />} />
        <Route path="/updateUser" element={<UpdateUser   />} />
        <Route path="/MainMenu" element={<MainMenu   />} />
        <Route path="/Home" element={<Home   />} />
        <Route path="/AddBook" element={<AddBook   />} />
        <Route path="/Books" element={<Books   />} />
        <Route path="/Users" element={<Users   />} />
        <Route path="/UpdateBook" element={<UpdateBook   />} />


       

       


        
      </Routes>
      </div>
    </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
