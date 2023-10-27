import React from "react";
import LoginAttemptForm from "./components/LoginAttemptForm";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

const App = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <div className="text-center">
        <LoginAttemptForm />
      </div>
    </QueryClientProvider>
  );
};

export default App;
