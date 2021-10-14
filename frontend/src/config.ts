type Config = {
  flightAPI: string;
};

const config: Config = {
  flightAPI:
    process.env.NODE_ENV === "development"
      ? "https://localhost:6001/api"
      : (process.env.REACT_APP_FLIGHT_API_URL as string),
};

export { config };
