import React from 'react';
import { Speciality } from '../../interfaces/Speciality';
import { webAPIUrlMsUniversityAndSpeciality } from '../../AppSetting';

export const getSpecialities = async (): Promise<Speciality[]> => {
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/Speciality`, {
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