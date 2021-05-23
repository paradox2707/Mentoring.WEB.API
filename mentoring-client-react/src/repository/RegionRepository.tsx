import React from "react";
import { Region } from '../interfaces/Region';
import { webAPIUrl } from '../AppSetting';

export const getRegions = async (): Promise<Region[]> => {
    const request = new Request(`${webAPIUrl}/Region`, {
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