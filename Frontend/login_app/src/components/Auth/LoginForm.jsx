import React, { useState } from "react";

const LoginForm = ({ onSubmit }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [usernameWarning, setUsernameWarning] = useState("");
  const [passwordWarning, setPasswordWarning] = useState("");
  const [isLoggingIn, setIsLoggingIn] = useState(false);

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
        setIsLoggingIn(true);

        // Pass login details to the parent component after a brief delay
        setTimeout(() => {
          onSubmit({ username: username, password: password });
          setUsername("");
          setPassword("");
          setIsLoggingIn(false);
        }, 1000); // Adjust the delay as needed
    }
  };

  const handleUsernameChange = (e) => {
    setUsername(e.target.value);
    setUsernameWarning(""); // Clear the warning when the user types
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
    setPasswordWarning(""); // Clear the warning when the user types
  };

  return (
    <div className="mt-10 mx-auto w-full max-w-sm p-4 bg-white rounded-md shadow-md">
      <form className="space-y-4" onSubmit={handleSubmit}>
        <label className="block text-sm font-medium text-gray-800">
          Username
        </label>
        {usernameWarning && <p className="text-red-500">{usernameWarning}</p>}
        <input
          type="text"
          id="username"
          value={username}
          disabled={isLoggingIn}
          onChange={handleUsernameChange}
          className={`w-full p-2 border rounded ${
            usernameWarning ? "border-red-500" : "border-gray-300"
          }`}
        />

        <label className="block text-sm font-medium text-gray-800">
          Password
        </label>
        {passwordWarning && <p className="text-red-500">{passwordWarning}</p>}
        <input
          type="password"
          id="password"
          value={password}
          disabled={isLoggingIn}
          onChange={handlePasswordChange}
          className={`w-full p-2 border rounded ${
            passwordWarning ? "border-red-500" : "border-gray-300"
          }`}
        />

        <button
          type="submit"
          disabled={isLoggingIn}
          className="w-full bg-indigo-600 text-white p-2 rounded-md hover:bg-indigo-500 focus:outline-none focus:ring focus:border-indigo-300"
        >
          {isLoggingIn ? "Logging in..." : "Log in"}
        </button>
      </form>
    </div>
  );
};

export default LoginForm;
