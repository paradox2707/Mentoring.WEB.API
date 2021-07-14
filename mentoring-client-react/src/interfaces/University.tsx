import React from 'react';
import { Speciality } from '../interfaces/Speciality';

export interface University {
    id: number;
    name: string;
    shortName: string;
    averageMark: number;
    regionName: string;
    specialities: Speciality[];
  }