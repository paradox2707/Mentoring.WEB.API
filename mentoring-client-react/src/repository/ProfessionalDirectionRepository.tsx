import React from 'react';
import { ProfessionalDirection } from '../interfaces/ProfessionalDirection';
import { webAPIUrl } from '../AppSetting';

export const getSpecialities = async (): Promise<ProfessionalDirection[]> => {
    const request = new Request(`${webAPIUrl}/ProfessionalDirection`, {
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