import { List, ListItem, ListItemIcon, ListItemText, ListSubheader } from "@material-ui/core";
import SchoolRoundedIcon from '@material-ui/icons/SchoolRounded';
import React from "react";

export const  UserApplicationListPage = () => {

    return(
        <div className={classes.root}>
          
          <List component="nav" 
                aria-label="main mailbox folders" 
                subheader={
                  <ListSubheader component="div" id="nested-list-subheader">
                    ВСІ АНКЕТИ
                  </ListSubheader>
              }>

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

export default UserApplicationListPage;