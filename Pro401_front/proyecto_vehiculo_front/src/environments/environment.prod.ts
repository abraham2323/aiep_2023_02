export const environment = {
  production: true,
  //API_URL:"https://localhost:7107",
  API_URL:"https://pro401-2.azurewebsites.net/",
  //PASSWORD_REGEX: "/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/"
  PASSWORD_REGEX: "^(?=.*[A-Za-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,}$"
};
