// UserLogin.js

import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from 'react-router-dom';

function DeleteEvent() {
  const [username, setUsername] = useState("");
  const [eventId, setEventId] = useState("");
  const [thisEventId, setThisEventId] = useState("");

  const navigate = useNavigate();

 

  const Del = (event) => {
    event.preventDefault();
   
    

    axios
      .post("http://localhost:5290/api/event/deleteEvent", {
        eventId: eventId,
       
      })
      .then((userData) => {
        console.log(userData);
        alert("Event Deleted Successfully!!");
       

      
       navigate('/Events');
      })
      .catch((err) => {
        console.log(eventId);
        console.log(err);


      });
  };

  return (
    <div className="login-container">
      <h1 className="login-heading">Delete Event</h1>
      <form className="login-form">
        <label className="form-label">EventId</label>
        <input
          type="number"
          className="form-input"
          value={eventId}
          onChange={(e) => { setEventId(e.target.value) }}
         
        />
        

        <div className="btn-container">
          <button className="btn-primary button" onClick={Del}>
            Delete
          </button>

        </div>

       
      </form>
    </div>
  );
}

export default DeleteEvent;
