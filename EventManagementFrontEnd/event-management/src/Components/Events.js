import React, { useState, useEffect } from "react";
import "./Events.css";
import { useNavigate } from 'react-router-dom';

function Events() {
  const [eventList, setEventList] = useState([]);
  const [searchPerformed, setSearchPerformed] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    getEvents();
  }, []); 

  const DeleteEve = () =>{navigate('./DeleteEvent')}
  const UpdateEve = (eve) =>{navigate('./UpdateEvent')}

  var getEvents = () => {
    fetch("http://localhost:5290/api/Event/GetAllEvents", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
    })
      .then(async (data) => {
        var myData = await data.json();
        console.log(myData);
        await setEventList(myData);
        await setSearchPerformed(true);
        var EventId = data.BookId;
        localStorage.setItem("EventId", EventId);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  return (
    <div className="books-container">
      <h1 className="page-title">Events</h1>
      {searchPerformed && (
        <div className="book-tiles">
          {eventList.map((event, index) => (
            <div key={event.bookId} className="book-tile">
              <h2>{event.title}</h2>
              <p><strong>Event Id:</strong> {event.eventId}</p>

              <p><strong>Description:</strong> {event.description}</p>
              <p><strong>Date:</strong> {event.date}</p>
              <p><strong>Location :</strong> {event.location}</p>
              <p><strong>Max Attendies:</strong> {event.maxAttendies}</p>
              <p><strong>Registration Fee:</strong> ${event.registrationFee}</p>
              <div className="btn-container">
          <button className="btn-primary button" onClick={UpdateEve}>
            Edit
          </button>

          <button className="btn-danger button" onClick={DeleteEve}>Delete</button>
        </div>

        
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default Events;
