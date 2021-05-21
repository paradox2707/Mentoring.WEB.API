import React from 'react';
import './Header.css';
import { Link } from 'react-router-dom';

export const Header = () => {
  const handleSearchInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    console.log(e.currentTarget.value);
  };
  return (
    <div className="Header-div">
      <Link to="./">UnitED</Link>
      <Link to="./Universities">Університети</Link>
      <Link to="./UniversitiesWithSpecialities">Університети зі спеціальностями</Link>
      <Link to="./Specialities">Спеціальності</Link>
      <Link to="./Anketa">Анкета</Link>
    </div>
  );
};