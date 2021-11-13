import React from 'react';
import { University } from '../../interfaces/University';
import { webAPIUrlMsUniversityAndSpeciality } from '../../AppSetting';
import { UniversityFilter } from '../../interfaces/UniversityFilter';
import { UniversityFilterForUserApplication } from '../../interfaces/UniversityFilterForUserApplication';

export const getUniversities = async (): Promise<University[]> => {
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/University`, {
        method: 'get',
        headers: {
          'Content-Type': 'application/json',
        },
        body: undefined,
      });
    const result = await fetch(request);
    const body = await result.json();
    if (result.ok && body) {
      return body;
    } else {
      return [];
    }
  };

  export const getUniversitiesWithSpecialities = async (): Promise<University[]> => {
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/University/Specialities`, {
        method: 'get',
        headers: {
          'Content-Type': 'application/json',
        },
        body: undefined,
      });
    const result = await fetch(request);
    const body = await result.json();
    if (result.ok && body) {
      return body;
    } else {
      return [];
    }
  };

  export const filterUniversities = async (filter: UniversityFilter): Promise<University[]> => {
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/University?SearchText=${filter.text ?? ''}&Region=${filter.region ?? ''}&IsGoverment=${filter.isgov?? ''}&Conjunction=${filter.conjunction?? ''}`, {
        method: 'get',
        headers: {
          'Content-Type': 'application/json',
        },
        body: undefined,
      });
    console.log(request);
    const result = await fetch(request);
    const body = await result.json();
    if (result.ok && body) {
      return body;
    } else {
      return [];
    }
  };

  export const filterUniversitiesForUserApplication = async (filter: UniversityFilterForUserApplication): Promise<University[]> => {
    let regionsFilter = filter.regions.map(r => `Regions=${r}`);
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/University/UserApplication?${regionsFilter.join("&")}&AverageMark=${filter.averageMark?? ''}`, {
        method: 'get',
        headers: {
          'Content-Type': 'application/json',
        },
        body: undefined,
      });
    console.log(request);
    const result = await fetch(request);
    const body = await result.json();
    if (result.ok && body) {
      return body;
    } else {
      return [];
    }
  };