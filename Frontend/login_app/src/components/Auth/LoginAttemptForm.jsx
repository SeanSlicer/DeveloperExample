import LoginForm from "./LoginForm";
import LoginAttemptList from "./LoginAttemptList";
import React, { useState } from "react";

const LoginAttemptForm = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);

  const handleLoginAttempt = ({ username, password }) => {
    const newLoginAttempts = [...loginAttempts, { username, password }];
    setLoginAttempts(newLoginAttempts);
  };
  return (
    <>
      <LoginForm onSubmit={handleLoginAttempt} />
      <LoginAttemptList attempts={loginAttempts} />
    </>
  );
};

export default LoginAttemptForm;
