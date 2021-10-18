type Config = {
  flightAPI: string;
  clientId: string;
  tenantId: string;
  apiScope: string;
};

const config: Config = {
  flightAPI: process.env.REACT_APP_FLIGHT_API_URL as string,
  clientId: process.env.REACT_APP_CLIENT_ID as string,
  tenantId: process.env.REACT_APP_TENANT_ID as string,
  apiScope: process.env.REACT_APP_API_SCOPE as string,
};

export { config };
