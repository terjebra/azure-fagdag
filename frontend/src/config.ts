type Config = {
  flightAPI: string;
  clientId: string;
  tenantId: string;
  signalrNegoiateUrl: string;
  userId: string;
  disableAuth: boolean;
};

const config: Config = {
  flightAPI: process.env.REACT_APP_FLIGHT_API_URL as string,
  clientId: process.env.REACT_APP_CLIENT_ID as string,
  tenantId: process.env.REACT_APP_ID as string,
  signalrNegoiateUrl: process.env.REACT_APP_SIGNAL_R_NEGOTIATE_URL as string,
  userId: Math.random().toString(36).substr(2, 9),
  disableAuth: true,
};

export { config };
