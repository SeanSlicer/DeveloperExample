import React, { useState } from "react";
import "./css/LoginForm.css";

const LoginForm = ({ onSubmit }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [usernameWarning, setUsernameWarning] = useState("");
  const [passwordWarning, setPasswordWarning] = useState("");
  const [isButtonDisabled, setIsButtonDisabled] = useState(false);

  const handleSubmit = (event) => {
    event.preventDefault();

    setUsernameWarning("");
    setPasswordWarning("");

    switch (true) {
      case !username && !password:
        setUsernameWarning("Username field cannot be blank");
        setPasswordWarning("Password field cannot be blank");
        break;
      case !username:
        setUsernameWarning("Username field cannot be blank");
        break;
      case !password:
        setPasswordWarning("Password field cannot be blank");
        break;
      default:
        // Both fields are non-empty, proceed with the login
        setIsButtonDisabled(true);

        // Pass login details to the parent component after a brief delay
        setTimeout(() => {
          onSubmit({ username: username, password: password });
          setUsername("");
          setPassword("");
          setIsButtonDisabled(false);
        }, 1000); // Adjust the delay as needed
    }
  };

  return (
    <form className="form" onSubmit={handleSubmit}>
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      {usernameWarning ? <p>{usernameWarning}</p> : <></>}
      <input
        type="text"
        id="name"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />
      <label htmlFor="password">Password</label>
      {passwordWarning ? <p>{passwordWarning}</p> : <></>}
      <input
        type="password"
        id="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit" disabled={isButtonDisabled}>
        {isButtonDisabled ? "Logging in..." : "Log in"}
      </button>
    </form>
  );
};

export default LoginForm;
