import React from 'react';
import './Header.css';
import { Link } from 'react-router-dom';
import { createStyles, makeStyles, Theme } from '@material-ui/core/styles';
import {AppBar, Toolbar, Typography,  Button } from '@material-ui/core';
import { red } from '@material-ui/core/colors';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    title: {
      flexGrow: 1,
      color: "white"
    },
  }),
);

export const Header = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            <Button href="./" className={classes.title}>UnitED</Button>
          </Typography> 
          <Button href="/Universities">Університети</Button>
          <Button href="/UniversitiesWithSpecialities">Університети зі спеціальностями</Button>
          <Button href="/Specialities">Спеціальності</Button>
          <Button href="/Anketa">Анкета</Button> 
        </Toolbar>
      </AppBar>
    </div>
  );
};