import LoginForm from "./Auth/LoginForm";
import LoginAttemptList from "./Auth/LoginAttemptList";
import React, { useState } from "react";
import { useStoreLoginAttempt } from "../hooks/auth/useStoreLoginAttempt";

const LoginAttemptForm = () => {
  const storeLoginAttempt = useStoreLoginAttempt();
  const [loginAttempts, setLoginAttempts] = useState([]);

  const handleLoginAttempt = ({ username, password }) => {
    storeLoginAttempt.mutate({ username, password });
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
