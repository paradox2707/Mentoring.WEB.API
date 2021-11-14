import React from "react";
import { Region } from "../../interfaces/Region";
import { webAPIUrlMsUniversityAndSpeciality } from "../../AppSetting";
import { WebApiResponse } from '../../interfaces/WebApiResponse';

export const getRegions = async (): Promise<Region[]> => {
  const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/Region`, {
    method: "get",
    headers: {
      "Content-Type": "application/json",
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

export const postRegion = async (data: Region): Promise<WebApiResponse> => {
  const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/Region`, {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });
  const result = await fetch(request);
  
  if (result.ok) {
    return { success: true, errors: undefined };
  } else {
    const body = await result.json();
    return { success: false, errors: body.errors };;
  }
};
