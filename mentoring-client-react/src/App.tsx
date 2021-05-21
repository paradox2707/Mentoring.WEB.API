
import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Switch, Route, NavLink, Link } from 'react-router-dom';
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
        <Switch>          
          <Route exact path="/Universities">
            <UniversitiesListPage />
          </Route>
          <Route exact path="/UniversitiesWithSpecialities">
            <UniversitiesWithSpecialitiesListPage />
          </Route>
          <Route exact path="/Specialities">
            <SpecialitiesListPage />
          </Route>
          <Route exact path="/Anketa">
            <AnketaPage />
          </Route>
          <Route path="">
            <HomePage />
          </Route>
        </Switch>
      </BrowserRouter>
  );
}

export default App;
