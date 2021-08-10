import React from 'react';
import { UserApplication } from '../interfaces/UserApplication';
import { WebApiResponse } from '../interfaces/WebApiResponse';
import { webAPIUrl } from '../AppSetting';

export const postUserApplication = async (data: UserApplication): Promise<WebApiResponse> => {
    console.log("enter postUserApplication");
    const request = new Request(`${webAPIUrl}/UserApplication`, {
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

  export const getUserApplication = async (): Promise<UserApplication[]> => {
    const request = new Request(`${webAPIUrl}/UserApplication`, {
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