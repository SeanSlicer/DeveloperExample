import React, { useState } from "react";
import "./LoginForm.css";

const LoginForm = (props) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();

    props.onSubmit({
      username: username,
      password: password,
    });
  };

  return (
    <form className="form">
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      <input
        type="text"
        id="name"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />
      <label htmlFor="password">Password</label>
      <input
        type="password"
        id="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit" onClick={handleSubmit}>
        Continue
      </button>
    </form>
  );
};

export default LoginForm;
