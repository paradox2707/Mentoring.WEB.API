import { createStyles, makeStyles, Theme } from "@material-ui/core";
import React from "react";

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
    },
  }),
);

export const  DashBoardPage = () => {
    const classes = useStyles();
    const [userApp, setUserApp] = React.useState<UserApplication[]>([]);
    React.useEffect(() => {
      let cancelled = false;
      const getStatistic = async () => {
        const foundResults = await getUserApplication();
        if (!cancelled) {
          setUserApp(foundResults);
        }
      };
      getStatistic();
      return () => {
        cancelled = true;
      };
    });
  
    return(
        <div className={classes.root}>
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
        </div>
        );
  };
  
  export default DashBoardPage;