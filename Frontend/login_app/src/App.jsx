import React from "react";
import LoginAttemptForm from "./components/Auth/LoginAttemptForm";
import { QueryClient, QueryClientProvider } from "react-query";

const queryClient = new QueryClient();

const App = () => {
  return (
    <QueryClientProvider client={queryClient} contextSharing={true}>
      <div className="text-center">
        <LoginAttemptForm />
      </div>
    </QueryClientProvider>
  );
};

export default App;
