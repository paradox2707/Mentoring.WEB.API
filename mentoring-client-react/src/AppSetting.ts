export const serverMsUniversityAndSpeciality =
  process.env.REACT_APP_ENV === 'production'
    ? 'https://your-backend.azurewebsites.net'
    : process.env.REACT_APP_ENV === 'staging'
    ? 'https://your-backend-staging.azurewebsites.net'
    : 'http://20.113.25.99:8081';

export const serverMsUserApplication =
  process.env.REACT_APP_ENV === 'production'
      ? 'https://your-backend.azurewebsites.net'
      : process.env.REACT_APP_ENV === 'staging'
      ? 'https://your-backend-staging.azurewebsites.net'
      : 'http://20.113.25.99:8082';

export const serverMsStatistics =
  process.env.REACT_APP_ENV === 'production'
      ? 'https://your-backend.azurewebsites.net'
      : process.env.REACT_APP_ENV === 'staging'
      ? 'https://your-backend-staging.azurewebsites.net'
      : 'http://20.113.25.99:8083';

export const webAPIUrlMsUniversityAndSpeciality = `${serverMsUniversityAndSpeciality}/api`;
export const webAPIUrlMsUserApplication = `${serverMsUserApplication}/api`;
export const webAPIUrlMsStatistics = `${serverMsStatistics}/api`;