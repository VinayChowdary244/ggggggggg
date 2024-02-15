

import React, { useState } from "react";
import './AddEvent.css'
import { redirect } from "react-router-dom";

function AddEvent() {
  const [title, setTitle] = useState("");
  const [eventDescription, setEventDescription] = useState();
  const [date, setDate] = useState("");
  const [location, setLocation] = useState("");
  const [maxAttendies, setMaxAttendies] = useState("");
  const [registrationFee, setRegistrationFee] = useState("");
 

  var eve;

  var clickAdd = () => {
    eve = {
      "title": title,
      "description": eventDescription,
      "date": date,
      "location": location,
      "maxAttendies": maxAttendies,
      "registrationFee": registrationFee,
      
    };

    fetch('http://localhost:5290/api/event', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem("token")
      },
      body: JSON.stringify(eve)
    }).then(
      () => {
        console.log(eve);
        alert('Event Added');
      }
    ).catch((e) => {
      console.log(e)
    });
  }

  return (
    <div className="add">
      <h2>Add Event</h2>

      {/* <label className="form-control" for="pname"><b>Event Title</b></label> */}
      <input id="pname" type="text" placeholder="Event Title" className="form-control" value={title} onChange={(e) => { setTitle(e.target.value) }} />
      {/* <label className="form-control" for="pname"><b>Description</b></label> */}
      <input id="pname" type="text" placeholder="Event Description" className="form-control" value={eventDescription} onChange={(e) => { setEventDescription(e.target.value) }} />
      {/* <label className="form-control" for="pname"><b>Date</b></label> */}
      <input id="pname" type="date" placeholder="Date and Time" className="form-control" value={date} onChange={(e) => { setDate(e.target.value) }} />
      {/* <label className="form-control" for="pprice"><b>Location</b></label> */}
      <input id="pprice" type="text" placeholder="Location" className="form-control" value={location} onChange={(e) => { setLocation(e.target.value) }} />
      {/* <label className="form-control" for="pprice"><b>Maximum No of Attendies </b></label> */}
      <input id="pprice" type="number" placeholder="Maximum No of Attendies" className="form-control" value={maxAttendies} onChange={(e) => { setMaxAttendies(e.target.value) }} />
      {/* <label className="form-control" for="pprice"><b>Registration Fee</b></label> */}
      <input id="pprice" type="number" placeholder="Registration Fee" className="form-control" value={registrationFee} onChange={(e) => { setRegistrationFee(e.target.value) }} />
      
      <button onClick={clickAdd} className="btn btn-primary"><b>Add Event</b></button>
    </div>
  );
}

export default AddEvent;
