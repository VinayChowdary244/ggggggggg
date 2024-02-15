import { useState } from "react";
import './UpdateEvent.css';

function UpdateEvent(){
    const [title, setTitle] = useState("");
    const [eventDescription, setEventDescription] = useState();
    const [date, setDate] = useState("");
    const [location, setLocation] = useState("");
    const [maxAttendies, setMaxAttendies] = useState("");
    const [registrationFee, setRegistrationFee] = useState("");
    const [eventId, setEventId] = useState("");

    const clickUpdate = () => {
         const eve = {
            "title": title,
            "description": eventDescription,
            "date": date,
            "location": location,
            "maxAttendies": maxAttendies,
            "registrationFee": registrationFee,
            
          };
        fetch('http://localhost:5167/api/event/Updatevent', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem("token")
            },
            body: JSON.stringify(eve)
        }).then(async (data) => {
            const myData = await data.json();
            console.log(myData);
            alert("Event Details Updated Successfully!!");
        }).catch((e) => {
            console.log(e);
        });
    };

    return (
        <form className="update">
            <div className="form-group">
                <h2>Update Event</h2>
      <input id="pname" type="text" placeholder="Event Title" className="form-control" value={title} onChange={(e) => { setTitle(e.target.value) }} />
      <input id="pname" type="text" placeholder="Event Description" className="form-control" value={eventDescription} onChange={(e) => { setEventDescription(e.target.value) }} />
      <input id="pname" type="date" placeholder="Date and Time" className="form-control" value={date} onChange={(e) => { setDate(e.target.value) }} />
      <input id="pprice" type="text" placeholder="Location" className="form-control" value={location} onChange={(e) => { setLocation(e.target.value) }} />
      <input id="pprice" type="number" placeholder="Maximum No of Attendies" className="form-control" value={maxAttendies} onChange={(e) => { setMaxAttendies(e.target.value) }} />
      <input id="pprice" type="number" placeholder="Registration Fee" className="form-control" value={registrationFee} onChange={(e) => { setRegistrationFee(e.target.value) }} />
      </div>
            <button onClick={clickUpdate} className="btn btn-primary"><b>Update Event</b></button>
        </form>
    );
}

export default UpdateEvent;
