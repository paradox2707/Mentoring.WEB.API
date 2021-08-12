import React from "react";
import { Card, CardContent, createStyles, makeStyles, Theme, Typography } from "@material-ui/core";
import { getSummaryUserApplicationDashboard } from "../../repository/StatisticsRepository";
import { SummaryUserApplicationDashboard } from "../../interfaces/SummaryUserApplicationDashboard";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
    },
    cardRoot: {
      width: 350,
      height: 350
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

export const  DashboardPage = () => {
    const classes = useStyles();
    const [summaryUserApplication, setSummaryUserApplication] = React.useState<SummaryUserApplicationDashboard>();
    React.useEffect(() => {
      let cancelled = false;
      const getStatistics = async () => {
        const foundResults = await getSummaryUserApplicationDashboard();
        if (!cancelled) {
          setSummaryUserApplication(foundResults);
        }
      };
      getStatistics();
      return () => {
        cancelled = true;
      };
    });
  
    return(
        <div className={classes.root}>
          <h1>Статистика</h1>
            <Card className={classes.cardRoot} variant="outlined">
                <CardContent>
                <Typography variant="h5" component="h2">
                Анкети абітуріентів
                </Typography>
                <Typography variant="body2" component="p">
                  <br />
                  Загальна кількість анкет: {summaryUserApplication?.totalAmount}
                  <br />
                  <br />
                  Середній бал анкет: {summaryUserApplication?.avarageMark}
                  <br />
                  <br />
                  Мінімальний бал анкети: {summaryUserApplication?.minMark}
                  <br />
                  <br />
                  Максимальний бал анкети: {summaryUserApplication?.maxMark}
                </Typography>
                </CardContent>
            </Card>
        </div>
        );
  };
  
  export default DashboardPage;