import React from 'react';
import { getUniversities, filterUniversities } from '../repository/microservice-university-and-speciality/UniversityRepositoryUsMs';
import { University } from '../interfaces/University';
import { UniversityFilter } from '../interfaces/UniversityFilter';
import { UniversitySearch } from '../common/UniversitySearchControl';
import { useSearchParams } from 'react-router-dom';

import { createStyles, Theme, makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem, { ListItemProps } from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import SchoolRoundedIcon from '@material-ui/icons/SchoolRounded';
import ListSubheader from '@material-ui/core/ListSubheader';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
    },
  }),
);



export const  UniversitiesListPage = () => {
  const classes = useStyles();
  const [searchParams] = useSearchParams();
  const [universities, setUniversities] = React.useState<University[]>([]);

  const searchText = searchParams.get('text') || '';
  console.log("in root")
  var filter: any = {};
  searchParams.forEach((value, key) => {
    filter[key] = value === "undefined" ? "" : value;
  });

  React.useEffect(() => {
    let cancelled = false;
    const doSearch = async (filter: UniversityFilter) => {
      const foundResults = await filterUniversities(filter);
      if (!cancelled) {
        setUniversities(foundResults);
      }
    };

    
    console.log(filter);
    // if(search == null || search.trim() === '')
    //   getUniversities().then((result) => setUniversities(result));
    // else 
    doSearch(filter as UniversityFilter);
    
    return () => {
      cancelled = true;
    };
  }, [searchParams]);

    return(
    <div className={classes.root}>
      
      <List component="nav" 
            aria-label="main mailbox folders" 
            subheader={
              <ListSubheader component="div" id="nested-list-subheader">
                УНІВЕРСИТЕТИ
              </ListSubheader>
          }>
          <UniversitySearch></UniversitySearch>
          {universities.map(e => 
          <ListItem key={e.id.toString()} button>
            <ListItemIcon>
              <SchoolRoundedIcon />
            </ListItemIcon>
            <ListItemText primary={e.name} />
          </ListItem>)}
      </List>
    </div>
    );
};

export default UniversitiesListPage;