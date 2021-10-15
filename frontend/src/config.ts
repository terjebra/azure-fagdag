type Config = {
  flightAPI: string;
  clientId: string;
  tenantId: string;
};

const config: Config = {
  flightAPI:
    process.env.NODE_ENV === "development"
      ? "https://localhost:6001/api"
      : (process.env.REACT_APP_FLIGHT_API_URL as string),
  clientId: process.env.REACT_APP_CLIENT_ID as string,
  tenantId: process.env.REACT_APP_TENANT_ID as string,
};

export { config };
