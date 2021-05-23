import React from 'react';
import { University } from '../interfaces/University';
import { webAPIUrl } from '../AppSetting';

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

  export const filterUniversities = async (filter: string): Promise<University[]> => {
    const request = new Request(`${webAPIUrl}/University?filter=${filter}`, {
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