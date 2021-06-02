import React from 'react';
import { useSearchParams, useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import {InputBase,  IconButton, Paper, InputLabel, Select, MenuItem, Button, FormControlLabel, Checkbox } from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';
import { Region } from '../interfaces/Region';
import { getRegions } from "../repository/RegionRepository";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      padding: '1px 4px',
      display: 'flex',
      alignItems: 'center',
      width: 600,
      marginLeft: theme.spacing(8),
      marginTop: theme.spacing(1),
      marginBottom: theme.spacing(3)
    },
    input: {
      marginLeft: theme.spacing(1),
      flex: 1,
    },
    iconButton: {
      padding: 10,
    },
    select: {
      width: 100,
      marginLeft: theme.spacing(1),
      marginRight: theme.spacing(2),
    },
    divider: {
      height: 28,
      margin: 4,
    },
  }),
);

type FormData = {
    search: string;
    isgov: any;
    region: string;
  };

export const UniversitySearch = () => {
    const classes = useStyles();
    const { register, handleSubmit } = useForm<FormData>();
    const [searchParams] = useSearchParams();
    const criteriaSearchText = searchParams.get('text') || '';
    const criteriaRegion = searchParams.get('region') || '';
    const criteriaGoverment = searchParams.get('isgov') || false;
    const navigate = useNavigate();
    const submitForm = (data: FormData) => {
      console.log("in submit")
      console.log(data);
      if (data == null)
        navigate(`/Universities`);
      else 
      console.log("to navigate"); navigate(`/Universities/search?text=${data.search ?? ""}&isgov=${data.isgov}&region=${data.region}`);
    };

    const [region, setRegion] = React.useState(criteriaRegion);
    const handleChange = (event: React.ChangeEvent<{ value: unknown }>) => {
      setRegion(event.target.value as string);
    };

    const [regions, setRegions] = React.useState<Region[]>([]);
    React.useEffect(() => {
      if(regions.length == 0) getRegions().then((result) =>
        setRegions(result)
      );
    });
  
    return (
        <div>
            <Paper component="form" onSubmit={handleSubmit(submitForm)} className={classes.root}>
              <InputBase
                placeholder="Пошук...."
                inputProps={{ 'aria-label': 'search' }}
                defaultValue={criteriaSearchText}
                {...register('search')}
              />
              <IconButton type="submit"  aria-label="search">
                <SearchIcon />
              </IconButton>

              <InputLabel id="demo-simple-select-helper-label">Регіон</InputLabel>
              <Select className={classes.select}
                labelId="demo-simple-select-helper-label"
                id="demo-simple-select-helper"
                value={region}
                {...register('region')}
                onChange={handleChange}
              >
                <MenuItem value="">
                  <em>None</em>
                </MenuItem>
                {regions.map(r => 
                  <MenuItem value={r.name}>
                    {r.name}
                  </MenuItem>)}
              </Select>
              {/* <FormControlLabel
                control={<Checkbox checked={IsGoverment}  {...register('isgov')} onChange={(event: React.ChangeEvent<HTMLInputElement>) => {setGovermentValue(event.target.checked);}} name="IsGoverment"  />}
                label="Goverment"
              /> */}
              <FormControlLabel
                control={<input type="checkbox" {...register('isgov')} />}
                label="державний"
              />
              {/* <input type="checkbox" value={"true"} {...register('isgov')} /> */}
              <Button type="submit"  aria-label="search">
                Submit
              </Button>
            </Paper>
        </div>
    );
  };