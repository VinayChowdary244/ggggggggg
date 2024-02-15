import './App.css';
import { BrowserRouter, Route, Routes ,Switch} from 'react-router-dom';
import { AuthProvider } from './Components/AuthContext';
import RegisterUser from './Components/RegisterUser';
import UserLogin from './Components/UserLogin';
import MainMenu from './Components/MainMenu';
import UpdateUser from './Components/UpdateUser';
import AddEvent from './Components/AddEvent';
import Events from './Components/Events';
import UpdateEvent from './Components/UpdateEvent';
import DeleteEvent from './Components/DeleteEvent';




function App() {
  return (
    <AuthProvider>
    <BrowserRouter>
    <div>
      
      <MainMenu/>
      <Routes>
      
        <Route path='/' element={<RegisterUser />} />
        <Route path="/UserLogin" element={<UserLogin/>} />
        <Route path="/UpdateUser" element={<UpdateUser/>} />
        <Route path="/AddEvent" element={<AddEvent/>} />
        <Route path="/Events" element={<Events/>} />
        <Route path="/UpdateEvent" element={<UpdateEvent/>} />
        <Route path="/DeleteEvent" element={<DeleteEvent/>} />




        
  </Routes>
      </div>
    </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
