import {
  Autocomplete,
  Box,
  Container,
  TextField,
  Typography,
} from "@mui/material";
import { useHistory } from "react-router";
import { useGetAirports } from "../useGetAirports";

const Main = () => {
  const { data: airports } = useGetAirports();
  const history = useHistory();
  return (
    <Container
      sx={{
        display: "grid",
        placeItems: "center",
        height: "100vh",
        bgcolor: "primary.light",
        minWidth: "100%",
      }}
    >
      <Box
        sx={{
          height: "80%",
          width: "100%",
          display: "grid",
          placeItems: "center",
        }}
      >
        <Box>
          <Typography variant="h3" color="primary.contrastText">
            Select airport
          </Typography>
          <Autocomplete
            disablePortal
            id="airports"
            onChange={(e, entry) => {
              if (entry) {
                history.push(`/airports/${entry.id}/flights`);
              }
            }}
            options={
              airports
                ? airports.map((a) => {
                    return {
                      id: a.code,
                      label: a.name,
                    };
                  })
                : []
            }
            sx={{ width: 300 }}
            renderInput={(params) => <TextField {...params} label="Airport" />}
          />
        </Box>
      </Box>
    </Container>
  );
};

export default Main;
