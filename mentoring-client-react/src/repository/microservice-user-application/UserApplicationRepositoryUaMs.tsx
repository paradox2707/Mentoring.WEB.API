import React from 'react';
import { UserApplication } from '../../interfaces/UserApplication';
import { WebApiResponse } from '../../interfaces/WebApiResponse';
import { webAPIUrlMsUserApplication } from '../../AppSetting';
import { UserApplicationFilter } from '../../interfaces/UserApplicationFilter';

export const postUserApplication = async (data: UserApplication): Promise<WebApiResponse> => {
    console.log("enter postUserApplication");
    const request = new Request(`${webAPIUrlMsUserApplication}/UserApplication`, {
        method: 'post',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
      });
    console.log(JSON.stringify(data));
    console.log("before call fetch");
    const result = await fetch(request);
    console.log("after call fetch");
    
    console.log(result);
    if (result.ok) {
      return { success: true, errors: undefined };
    } else {
      const body = await result.json();
      return { success: false, errors: body.errors };;
    }
  };

  export const getUserApplications = async (): Promise<UserApplication[]> => {
    const request = new Request(`${webAPIUrlMsUserApplication}/UserApplication`, {
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

  export const filterUserApplications = async (filter: UserApplicationFilter): Promise<UserApplication[]> => {
    const request = new Request(`${webAPIUrlMsUserApplication}/UserApplication?SearchText=${filter.text ?? ''}&Region=${filter.region ?? ''}&ProfessionalDirection=${filter.direction ?? ''}`, {
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