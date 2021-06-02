import React from 'react';
import { University } from '../interfaces/University';
import { webAPIUrl } from '../AppSetting';
import { UniversityFilter } from '../interfaces/UniversityFilter';

export const getUniversities = async (): Promise<University[]> => {
    const request = new Request(`${webAPIUrl}/University`, {
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
    const request = new Request(`${webAPIUrl}/University/Specialities`, {
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
    const request = new Request(`${webAPIUrl}/University?SearchText=${filter.text ?? ''}&Region=${filter.region ?? ''}&IsGoverment=${filter.isgov?? ''}`, {
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