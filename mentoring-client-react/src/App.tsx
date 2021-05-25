
import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Routes, Route, Navigate, Link } from 'react-router-dom';
import './App.css';
import { Header } from './common/Header';
import { HomePage } from './common/HomePage';
import { UniversitiesListPage } from './common/UniversitiesListPage';
import { SpecialitiesListPage } from './common/SpecialitiesListPage';
import { UniversitiesWithSpecialitiesListPage } from './common/UniversitiesWithSpecialitiesListPage';
import { AnketaPage } from './common/AnketaPage';

function App() {
  return (      
      <BrowserRouter>
        <Header />
        <Routes>          
          <Route path="/Universities">
            <UniversitiesListPage />
          </Route>          
          <Route path="/UniversitiesWithSpecialities">
            <UniversitiesWithSpecialitiesListPage />
          </Route>
          <Route path="/Universities/search" element={<UniversitiesListPage />} />
          <Route path="/Specialities">
            <SpecialitiesListPage />
          </Route>
          <Route path="/Anketa">
            <AnketaPage />
          </Route>
          <Route path="">
            <HomePage />
          </Route>
          <Route path="*">
            <Navigate to="/" />
          </Route>
        </Routes>
      </BrowserRouter>
  );
}

export default App;
