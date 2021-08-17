import { IconButton, Paper } from "@material-ui/core";
import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';
import React from "react";
import SearchIcon from '@material-ui/icons/Search';
import { useSearchParams, useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      padding: '1px 4px',
      display: 'flex',
      alignItems: 'center',
      width: 750,
      marginLeft: theme.spacing(8),
      marginTop: theme.spacing(1),
      marginBottom: theme.spacing(3)
    },
    input: {
      marginLeft: theme.spacing(1),
      flex: 1,
    }
  }),
);

interface IFormInput {
    search: string;
  };

export const UserApplicationSearch = () => {

    const classes = useStyles();
    const { register, handleSubmit, watch } = useForm<IFormInput>();

    const navigate = useNavigate();
    const submitForm = (data: IFormInput) => {
        console.log("in submit")
        console.log(data);
        if (data == null)
          navigate(`/AllUserApplications`);
        else 
        {
          // navigate(`/`);
          console.log("to navigate"); navigate(`/AllUserApplications/search?text=${data.search ?? ""}`);
        }
        
      };

    return (
        <div>
            <Paper component="form" onSubmit={handleSubmit(submitForm)} className={classes.root}>
              <input
                placeholder="Пошук...."

                //defaultValue={criteriaSearchText}

                {...register('search')}
              />
              <IconButton type="submit"  aria-label="search">
                <SearchIcon />
              </IconButton>
            </Paper>
        </div>
    );
};