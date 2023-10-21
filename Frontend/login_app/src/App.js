import React, { useState } from "react";
import "./App.css";
import LoginForm from "./LoginForm";
import LoginAttemptList from "./LoginAttemptList";

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);

  const handleLoginAttempt = ({ username, password }) => {
    // Log the login attempt
    const newLoginAttempts = [...loginAttempts, { username, password }];
    setLoginAttempts(newLoginAttempts);
  };

  return (
    <div className="App">
      <LoginForm onSubmit={handleLoginAttempt} />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;
