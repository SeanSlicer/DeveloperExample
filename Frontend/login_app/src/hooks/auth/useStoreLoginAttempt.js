import { useMutation } from "react-query";

export const useStoreLoginAttempt = () => {
  return useMutation(({ username, password }) => {
    // Here you would typically make a POST request to your API to store the login attempt
  });
};
