
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
import UserApplicationListPage from './modules/UserApplication/UserApplicationListPage';
import { Dashboard } from '@material-ui/icons';
import DashboardPage from './modules/Dashboard/DashboardPage';

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
          <Route path="/AllUserApplications">
            <UserApplicationListPage />
          </Route>
          <Route path="/AllUserApplications/search" element={<UserApplicationListPage />} />
          <Route path="/Dashboards">
            <DashboardPage />
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
