export const serverMsUniversityAndSpeciality =
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

export const serverMsStatistics =
  process.env.REACT_APP_ENV === 'production'
      ? 'https://your-backend.azurewebsites.net'
      : process.env.REACT_APP_ENV === 'staging'
      ? 'https://your-backend-staging.azurewebsites.net'
      : 'https://localhost:44383';

export const webAPIUrlMsUniversityAndSpeciality = `${serverMsUniversityAndSpeciality}/api`;
export const webAPIUrlMsUserApplication = `${serverMsUserApplication}/api`;
export const webAPIUrlMsStatistics = `${serverMsStatistics}/api`;