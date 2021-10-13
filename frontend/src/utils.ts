export const formateTime = (date: string) => {
  return new Date(date).toLocaleTimeString("en-GB");
};

export const getStatusTitle = (status: string) => {
  switch (status) {
    case "A":
      return "Arrived";
    case "D":
      return "Departed";
    case "E":
      return "New time";
    default:
      return "-";
  }
};
