import React from "react";
import ReactDOM from "react-dom";
import { Card, CardContent, createStyles, makeStyles, Theme, Typography } from "@material-ui/core";
import { getSummaryUserApplicationDashboard, getSummaryUserApplicationByProfessionalDirectionDashboard } from "../../repository/microservice-statistics/StatisticsRepositoryStatMs";
import { SummaryUserApplicationDashboard } from "../../interfaces/SummaryUserApplicationDashboard";
import { SummaryUserApplicationByProfessionalDirectionDashboard } from "../../interfaces/SummaryUserApplicationByProfessionalDirectionDashboard";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
      display: 'flex',
      flexDirection: 'column'
    },
    cardRoot: {
      width: 400,
      height: 550,
      margin: '2%'
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
    cardGroup: {
      display: 'flex'
    }
  }),
);

export const  DashboardPage = () => {
    const classes = useStyles();
    const [summaryUserApplication, setSummaryUserApplication] = React.useState<SummaryUserApplicationDashboard>();
    const [summaryUserApplicationByProfessionalDirection, setSummaryUserApplicationByProfessionalDirection] = React.useState<SummaryUserApplicationByProfessionalDirectionDashboard[]>([]);
    React.useEffect(() => {
      let cancelled = false;
      const getStatistics = async () => {
        const summaryUserApplication = await getSummaryUserApplicationDashboard();
        const summaryUserApplicationByProfessionalDirection = await getSummaryUserApplicationByProfessionalDirectionDashboard();
        if (!cancelled) {
          setSummaryUserApplication(summaryUserApplication);
          setSummaryUserApplicationByProfessionalDirection(summaryUserApplicationByProfessionalDirection);
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
          <div className={classes.cardGroup}>
            <Card className={classes.cardRoot} variant="outlined">
                <CardContent>
                <Typography variant="h5" component="h2">
                Анкети абітуріентів
                </Typography>
                <Typography variant="body2" component="p">
                  <ul>Загальна кількість анкет: {summaryUserApplication?.totalAmount}</ul>
                  <ul>Середній бал анкет: {summaryUserApplication?.avarageMark}</ul>
                  <ul>Мінімальний бал анкети: {summaryUserApplication?.minMark}</ul>
                  <ul>Максимальний бал анкети: {summaryUserApplication?.maxMark}</ul>
                </Typography>
                </CardContent>
            </Card>

            <Card className={classes.cardRoot} variant="outlined">
                <CardContent>
                <Typography variant="h5" component="h2">
                Кількість анкет по напрямках
                </Typography>
                <Typography variant="body2" component="p">
                  {summaryUserApplicationByProfessionalDirection.map((e) => <ul>{`${e.professionalDirection} : ${e.userApplicationAmount}`} </ul> )}
                </Typography>
                </CardContent>
            </Card>
          </div>
        </div>
        );
  };
  
  export default DashboardPage;