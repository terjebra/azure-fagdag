type Config = {
  flightAPI: string;
  clientId: string;
  tenantId: string;
  signalrNegoiateUrl: string;
  userId: string;
};

const config: Config = {
  flightAPI:
    process.env.NODE_ENV === "development"
      ? "https://localhost:6001/api"
      : (process.env.REACT_APP_FLIGHT_API_URL as string),
  clientId: process.env.REACT_APP_CLIENT_ID as string,
  tenantId: process.env.REACT_APP_ID as string,
  signalrNegoiateUrl: process.env.NODE_ENV === "development"
  ? "https://func-flights-fagdag-terje.azurewebsites.net/api/flightnotifications/negotiate/"  ? process.env.REACT_APP_SIGNAL_R_NEGOTIATE_URL as string,
  userId: Math.random().toString(36).substr(2, 9),
};

export { config };
