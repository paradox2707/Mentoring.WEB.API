export const server =
  process.env.REACT_APP_ENV === 'production'
    ? 'https://your-backend.azurewebsites.net'
    : process.env.REACT_APP_ENV === 'staging'
    ? 'https://your-backend-staging.azurewebsites.net'
    : 'https://localhost:44386';

export const serverMsUserApplication =
  process.env.REACT_APP_ENV === 'production'
      ? 'https://your-backend.azurewebsites.net'
      : process.env.REACT_APP_ENV === 'staging'
      ? 'https://your-backend-staging.azurewebsites.net'
      : 'https://localhost:44382';

export const webAPIUrl = `${server}/api`;
export const webAPIUrlMsUserApplication = `${serverMsUserApplication}/api`;