// UpdateUser.jsx

import React, { useState } from 'react';
import axios from 'axios';
import './UpdateUser.css';

function UpdateUser() {
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [searchError, setSearchError] = useState('');
  const thisUserName = localStorage.getItem('thisUserName');

  const checkUpdateUser = () => {
    if (userName === '') {
      setSearchError('User name cannot be empty');
      return false;
    }
    return true;
  };

  const handleSearch = (event) => {
    event.preventDefault();
    setSearchError('');

    const isValidData = checkUpdateUser();

    if (!isValidData) {
      return;
    }

    axios
      .put('http://localhost:5290/api/Customer/UpdateUser', {
        userName: localStorage.getItem(userName),
        email: email,
        password: password,
      })
      .then((response) => {
        console.log(response.data);
        alert('Updated Successfully!!');
      })
      .catch((err) => {
        console.error(err);
        setSearchError('Error updating the user details. Please try again.');
      });
  };

  return (
    <form className="update-form">
      <h2>Update User</h2>
      <h4>Hi {thisUserName}</h4>

      <label className="form-label">Email</label>
      <input
        type="text"
        className="form-input"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <label className="form-label">Password</label>
      <input
        type="text"
        className="form-input"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      {searchError && <p className="error-message">{searchError}</p>}

      <div className="button-container">
        <button className="btn btn-primary update-button" onClick={handleSearch}>
          Update Details
        </button>
        <button className="btn btn-danger cancel-button" onClick={() => alert('Cancelled')}>
          Cancel
        </button>
      </div>
    </form>
  );
}

export default UpdateUser;
