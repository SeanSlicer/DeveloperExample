import React, { useState } from "react";
import "./css/LoginAttemptList.css";

const LoginAttempt = ({ username, password }) => (
  <li className="Login-Attempt">{`Login: ${username} Password: ${password}`}</li>
);

const LoginAttemptList = (props) => {
  const [filter, setFilter] = useState("");

  const filteredAttempts = props.attempts.filter(
    (attempt) =>
      attempt.username.includes(filter) || attempt.password.includes(filter)
  );

  return (
    <div className="Attempt-List-Main">
      <p>Recent activity</p>
      <input
        type="input"
        placeholder="Filter..."
        value={filter}
        onChange={(e) => setFilter(e.target.value)}
      />
      <ul className="Attempt-List">
        {filteredAttempts.map((attempt, index) => (
          <LoginAttempt key={index} {...attempt} />
        ))}
      </ul>
    </div>
  );
};

export default LoginAttemptList;
