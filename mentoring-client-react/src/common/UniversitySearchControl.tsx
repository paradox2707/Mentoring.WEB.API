import React from 'react';
import { useSearchParams, useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import {InputBase,  IconButton, Paper } from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      padding: '1px 4px',
      display: 'flex',
      alignItems: 'center',
      width: 200,
      marginLeft: theme.spacing(8),
      marginTop: theme.spacing(1)
    },
    input: {
      marginLeft: theme.spacing(1),
      flex: 1,
    },
    iconButton: {
      padding: 10,
    },
    divider: {
      height: 28,
      margin: 4,
    },
  }),
);

type FormData = {
    search: string;
  };

export const UniversitySearch = () => {
    const classes = useStyles();
    const { register, handleSubmit } = useForm<FormData>();
    const [searchParams] = useSearchParams();
    const criteria = searchParams.get('criteria') || '';
    const navigate = useNavigate();
    const submitForm = ({ search }: FormData) => {
      if (search == null || search.trim() === '')
        navigate(`/Universities`);
      else navigate(`/Universities/search?criteria=${search}`);
    };
  
    return (
        <div>
            <Paper component="form" onSubmit={handleSubmit(submitForm)} className={classes.root}>
              <InputBase
                placeholder="Пошук...."
                inputProps={{ 'aria-label': 'search' }}
                {...register('search')}
              />
              <IconButton type="submit"  aria-label="search">
                <SearchIcon />
              </IconButton>
            </Paper>
        </div>
    );
  };