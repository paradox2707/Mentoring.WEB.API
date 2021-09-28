import React from "react";
import { WebApiResponse } from '../interfaces/WebApiResponse';
import { webAPIUrlMsUniversityAndSpeciality } from '../AppSetting';
import { SummaryUserApplicationDashboard } from "../interfaces/SummaryUserApplicationDashboard";
import { SummaryUserApplicationByProfessionalDirectionDashboard } from "../interfaces/SummaryUserApplicationByProfessionalDirectionDashboard";

export const getSummaryUserApplicationDashboard = async (): Promise<SummaryUserApplicationDashboard | undefined> => {
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/Statistics/SummaryUserApplicationDashboard`, {
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

  export const getSummaryUserApplicationByProfessionalDirectionDashboard = async (): Promise<SummaryUserApplicationByProfessionalDirectionDashboard[]> => {
    const request = new Request(`${webAPIUrlMsUniversityAndSpeciality}/Statistics/SummaryUserApplicationByProfessionalDirectionDashboard`, {
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