import React from 'react';
import { Region } from './Region';
import { ProfessionalDirection } from './ProfessionalDirection';

export interface UserApplication {
    id: number;
    firstName: string;
    secondName: string;
    phoneNumber: number;
    averageMark: number;
    regions: Region[];
    professionalDirections: ProfessionalDirection[];
  }