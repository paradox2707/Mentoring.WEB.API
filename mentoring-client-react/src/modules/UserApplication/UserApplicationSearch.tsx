import { Button, IconButton, InputLabel, Paper } from "@material-ui/core";
import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';
import React from "react";
import SearchIcon from '@material-ui/icons/Search';
import { useSearchParams, useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { Region } from "../../interfaces/Region";
import { getRegions } from "../../repository/microservice-user-application/RegionRepositoryUaMs";
import { getProfessionalDirections } from "../../repository/microservice-user-application/ProfessionalDirectionRepositoryUaMs";

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
    },
    select: {
      width: 100,
      marginLeft: theme.spacing(1),
      marginRight: theme.spacing(2),
    }
  }),
);

interface IFormInput {
    search: string;
    region: string;
    direction: string;
  };

export const UserApplicationSearch = () => {

    const classes = useStyles();

    const [searchParams] = useSearchParams();
    const criteriaSearchText = searchParams.get('text') || '';
    const criteriaRegion = searchParams.get('region') || '';
    const criteriaDirection = searchParams.get('direction') || '';

    const [regions, setRegions] = React.useState<Region[]>([]);
    React.useEffect(() => {
      if(regions.length == 0) getRegions().then((result) =>
        setRegions(result)
      );
    });
    const [region, setRegion] = React.useState(criteriaRegion);
    const handleChangeRegion = (event: React.ChangeEvent<{ value: unknown }>) => {
      setRegion(event.target.value as string);
    };

    const [directions, setDirections] = React.useState<Region[]>([]);
    React.useEffect(() => {
      if(regions.length == 0) getProfessionalDirections().then((result) =>
      setDirections(result)
      );
    });
    const [direction, setDirection] = React.useState(criteriaRegion);
    const handleChangeDirection = (event: React.ChangeEvent<{ value: unknown }>) => {
      setDirection(event.target.value as string);
    };

    const { register, handleSubmit, watch } = useForm<IFormInput>();

    const navigate = useNavigate();
    const submitForm = (data: IFormInput) => {
        console.log("in submit")
        console.log(data);
        if (data == null)
          navigate(`/AllUserApplications`);
        else 
        {
          console.log("to navigate"); navigate(`/AllUserApplications/search?text=${data.search ?? ""}&region=${data.region ?? ""}&direction=${data.direction ?? ""}`);
        }
        
      };

    return (
        <div>
            <Paper component="form" onSubmit={handleSubmit(submitForm)} className={classes.root}>
              <input
                placeholder="Пошук...."

                defaultValue={criteriaSearchText}

                {...register('search')}
              />
              <IconButton type="submit"  aria-label="search">
                <SearchIcon />
              </IconButton>

              <InputLabel id="demo-simple-select-helper-label">Регіон</InputLabel>
              <select className={classes.select}
                id="demo-simple-select-helper"
                value={region}
                {...register('region')}
                onChange={handleChangeRegion}
              >
                <option value="">
                  None
                </option>
                {regions.map(r => 
                  <option value={r.name}>
                    {r.name}
                  </option>)}
              </select>

              <InputLabel id="demo-simple-select-helper-label">Напрямки</InputLabel>
              <select className={classes.select}
                id="demo-simple-select-helper"
                value={direction}
                {...register('direction')}
                onChange={handleChangeDirection}
              >
                <option value="">
                  None
                </option>
                {directions.map(r => 
                  <option value={r.name}>
                    {r.name}
                  </option>)}
              </select>

              <Button type="submit"  aria-label="search">
                Search
              </Button>
            </Paper>
        </div>
    );
};