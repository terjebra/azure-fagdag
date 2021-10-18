import { Container, Paper, Box, Avatar, Typography, Chip } from "@mui/material";
import { useParams } from "react-router";
import { useGetFlights } from "../useGetFlights";
import { Direction } from "../types";
import { formateTime, getStatusTitle } from "../utils";
import { useGetAirports } from "../useGetAirports";
import FlightLandIcon from "@mui/icons-material/FlightLand";
import FlightTakeoffIcon from "@mui/icons-material/FlightTakeoff";
import { useSubscribeToFlightChange } from "../useSubscribeToFlightChange";
import FlashOnIcon from "@mui/icons-material/FlashOn";
type RouteParams = {
  airport: string;
};
const Flights = () => {
  const { airport } = useParams<RouteParams>();
  const { data: flights } = useGetFlights(airport);
  const { data: airports } = useGetAirports();
  const { mutate } = useSubscribeToFlightChange();

  return (
    <Container
      sx={{
        display: "grid",
        height: "100%",
        rowGap: "10px",
        bgcolor: "primary.light",
        padding: "10px 0 10px 0",
        minWidth: "100%",
      }}
    >
      <Typography variant="h3" color="primary.contrastText">
        Flights at {airport}
      </Typography>
      {airports &&
        flights &&
        flights.map((x) => {
          return (
            <Paper sx={{ padding: 4 }} key={x.flightId}>
              <Box
                display="grid"
                gridTemplateColumns="repeat(5, 1fr)"
                sx={{ alignItems: "center" }}
              >
                <Box gridColumn="1">
                  <Avatar>
                    {x.direction === Direction.Arrival ? (
                      <FlightLandIcon />
                    ) : x.direction === Direction.Departure ? (
                      <FlightTakeoffIcon />
                    ) : null}
                  </Avatar>
                </Box>
                <Box gridColumn="2">{x.flightId}</Box>
                <Box gridColumn="3">{x.airport}</Box>
                <Box gridColumn="4">{formateTime(x.scheduleTime)}</Box>
                <Box gridColumn="5">
                  {x.statusCode && (
                    <Chip
                      label={getStatusTitle(x.statusCode)}
                      color={x.statusCode === "E" ? "error" : "info"}
                    ></Chip>
                  )}
                </Box>
                <Box gridColumn="6">
                  <FlashOnIcon
                    sx={{ cursor: "pointer" }}
                    onClick={() => {
                      mutate({ airport: airport, flightId: x.flightId });
                    }}
                  />
                </Box>
              </Box>
            </Paper>
          );
        })}
    </Container>
  );
};

export default Flights;
