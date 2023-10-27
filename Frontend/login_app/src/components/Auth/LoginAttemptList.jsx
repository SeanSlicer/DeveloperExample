import React, { useState } from "react";

const LoginAttempt = ({ username, password }) => (
  <li className="bg-gray-100 border border-gray-300 rounded p-4 mb-2">
    {`Login: ${username} Password: ${password}`}
  </li>
);

const LoginAttemptList = (props) => {
  const [filter, setFilter] = useState("");

  const filteredAttempts = props.attempts.filter(
    (attempt) =>
      attempt.username.includes(filter) || attempt.password.includes(filter)
  );

  return (
    <div className="bg-white border border-gray-300 rounded shadow-md p-8 max-w-2xl mx-auto">
      <p className="text-xl font-bold mb-4">Recent Activity</p>
      <input
        type="input"
        placeholder="Filter..."
        value={filter}
        onChange={(e) => setFilter(e.target.value)}
        className="w-full p-2 mb-4 border border-gray-300 rounded"
      />
      <ul className="list-none p-0 m-0">
        {filteredAttempts.map((attempt, index) => (
          <LoginAttempt key={index} {...attempt} />
        ))}
      </ul>
    </div>
  );
};

export default LoginAttemptList;
