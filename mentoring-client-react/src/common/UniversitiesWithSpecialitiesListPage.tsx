import React from 'react';
import { getUniversitiesWithSpecialities } from '../repository/UniversityRepository';
import { University } from '../interfaces/University';

import { makeStyles, Theme, createStyles } from '@material-ui/core/styles';
import ListSubheader from '@material-ui/core/ListSubheader';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Collapse from '@material-ui/core/Collapse';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import DraftsIcon from '@material-ui/icons/Drafts';
import SchoolRoundedIcon from '@material-ui/icons/SchoolRounded';
import ImportContactsRoundedIcon from '@material-ui/icons/ImportContactsRounded';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import StarBorder from '@material-ui/icons/StarBorder';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
    },
    nested: {
      paddingLeft: theme.spacing(12),
    },
  }),
);

interface IProps {
}

interface IState {
  data: University[];
}

export const UniversitiesWithSpecialitiesListPage = () => {
    const classes = useStyles();
    const [universities, setUniversities] = React.useState<University[]>([]);
    const [open, setOpen] = React.useState(true);

    React.useEffect(() => {
      if(universities.length === 0)
        getUniversitiesWithSpecialities().then((result) => setUniversities(result));
    });

    const handleClick = () => {
      setOpen(!open);
    };

    return(
      <div>
        <List
          component="nav"
          aria-labelledby="nested-list-subheader"
          subheader={
            <ListSubheader component="div" id="nested-list-subheader">
              УНІВЕРСИТЕТИ З СПЕЦІАЛЬНОСТЯМИ
            </ListSubheader>
          }
          className={classes.root}
        >
          {universities.map(u => 
          <div>
            <ListItem key={u.id.toString()} button onClick={handleClick}>
              <ListItemIcon>
                <SchoolRoundedIcon />
              </ListItemIcon>
              <ListItemText primary={u.name} />
              {open ? <ExpandLess /> :  <ExpandMore />}
            </ListItem>
            <Collapse in={open} timeout="auto" unmountOnExit>
            <List component="div" disablePadding>
              {u.specialities.map(s => 
                <ListItem key={s.id.toString()} button className={classes.nested}>
                  <ListItemIcon>
                    <ImportContactsRoundedIcon />
                  </ListItemIcon>
                  <ListItemText primary={s.name} />
                </ListItem> )}
            </List>
            </Collapse>
          </div>
          )}
        </List>
      </div>)
};

export default UniversitiesWithSpecialitiesListPage;