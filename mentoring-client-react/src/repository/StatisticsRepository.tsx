import React from "react";
import { WebApiResponse } from '../interfaces/WebApiResponse';
import { webAPIUrl } from '../AppSetting';
import { SummaryUserApplicationDashboard } from "../interfaces/SummaryUserApplicationDashboard";

export const getSummaryUserApplicationDashboard = async (): Promise<SummaryUserApplicationDashboard | undefined> => {
    const request = new Request(`${webAPIUrl}/Statistics/SummaryUserApplicationDashboard`, {
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
      return undefined;
    }
  };