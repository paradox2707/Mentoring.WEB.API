import { Card, CardContent, createStyles, List, ListItem, ListItemIcon, ListItemText, ListSubheader, makeStyles, Typography } from "@material-ui/core";
import { Theme } from "@material-ui/core/styles";
import SchoolRoundedIcon from '@material-ui/icons/SchoolRounded';
import React from "react";
import { useSearchParams } from "react-router-dom";
import { UserApplication } from "../../interfaces/UserApplication";
import { UserApplicationFilter } from "../../interfaces/UserApplicationFilter";
import { filterUserApplications, getUserApplications } from "../../repository/microservice-user-application/UserApplicationRepositoryUaMs";
import { UserApplicationSearch } from '../UserApplication/UserApplicationSearch';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
    },
    cardRoot: {
      width: 500,
      height: 200
    },
    cardBullet: {
      display: 'inline-block',
      margin: '0 2px',
      transform: 'scale(0.8)',
    },
    cardTitle: {
      fontSize: 14,
    },
    cardPos: {
      marginBottom: 12,
    }
  }),
);

export const  UserApplicationListPage = () => {
  const classes = useStyles();
  const [searchParams] = useSearchParams();
  const [userApp, setUserApp] = React.useState<UserApplication[]>([]);


  var filter: any = {};
  searchParams.forEach((value, key) => {
    filter[key] = value === "undefined" ? "" : value;
  });

  React.useEffect(() => {
    let cancelled = false;
    const doSearch = async (filter: UserApplicationFilter) => {
      const foundResults = await filterUserApplications(filter);
      if (!cancelled) {
        setUserApp(foundResults);
      }
    };
    doSearch(filter as UserApplicationFilter);
    
    return () => {
      cancelled = true;
    };
  }, [searchParams]);

  return(
      <div className={classes.root}>
        <List  component="nav" 
              aria-label="main mailbox folders" 
              subheader={
                <ListSubheader component="div" id="nested-list-subheader">
                  ВСІ АНКЕТИ
                  <UserApplicationSearch></UserApplicationSearch>
                </ListSubheader>
            }>
            
            {userApp.map(e => 
            <ListItem key={e.id.toString()} button>
               <Card className={classes.cardRoot} variant="outlined">
                <CardContent>
                  <Typography className={classes.cardTitle} color="textSecondary" gutterBottom>
                    # {e.id.toString()}
                  </Typography>
                  <Typography variant="h5" component="h2">
                  {e.firstName} {e.secondName}  {e.averageMark}
                  </Typography>
                  <Typography className={classes.cardPos} color="textSecondary">
                    Телефон: {e.phoneNumber}
                  </Typography>
                  <Typography variant="body2" component="p">
                    Регіон: {e.regions.map(r => r.name + " ")}
                    <br />
                    Професійний напрямок: {e.professionalDirections.map(r => r.name + " ")}
                  </Typography>
                </CardContent>
              </Card>
            </ListItem>)}
        </List>
      </div>
      );
};

export default UserApplicationListPage;