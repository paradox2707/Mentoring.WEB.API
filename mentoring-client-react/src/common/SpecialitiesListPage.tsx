import React from 'react';
import { Speciality } from '../interfaces/Speciality';
import { getSpecialities } from '../repository/SpecialityRepository';

import { createStyles, Theme, makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem, { ListItemProps } from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ImportContactsRoundedIcon from '@material-ui/icons/ImportContactsRounded';
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

export const  SpecialitiesListPage = () => {
  const classes = useStyles();
  const [specialities, setSpecialities] = React.useState<Speciality[]>([]);

  React.useEffect(() => {
    if(specialities.length === 0)
    getSpecialities().then((result) => setSpecialities(result));
  });

    return(
    <div className={classes.root}>
      
      <List component="nav" 
            aria-label="main mailbox folders" 
            subheader={
              <ListSubheader component="div" id="nested-list-subheader">
                СПЕЦІАЛЬНОСТІ
              </ListSubheader>
          }>
          {specialities.map(e => 
          <ListItem key={e.id.toString()} button>
            <ListItemIcon>
              <ImportContactsRoundedIcon />
            </ListItemIcon>
            <ListItemText primary={e.name} />
          </ListItem>)}
      </List>
    </div>
    );
};

export default SpecialitiesListPage;