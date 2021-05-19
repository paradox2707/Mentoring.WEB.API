
import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Switch, Route, NavLink, Link } from 'react-router-dom';
import './App.css';
import { Header } from './common/Header';
import { HomePage } from './common/HomePage';
import { UniversitiesListPage } from './common/UniversitiesListPage';

function App() {
  return (      
      <BrowserRouter>
        <Link to="/test">TEST</Link>
        <Header />
        <Switch>          
          <Route exact path="/Universities">
            <UniversitiesListPage />
          </Route>
          <Route path="">
            <HomePage />
          </Route>
        </Switch>
      </BrowserRouter>
  );
}

export default App;
