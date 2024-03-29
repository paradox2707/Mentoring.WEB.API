import React from "react";
import ReactDOM from "react-dom";
import { useForm } from "react-hook-form";
import { Region } from "../interfaces/Region";
import { ProfessionalDirection } from "../interfaces/ProfessionalDirection";
import { UserApplication } from "../interfaces/UserApplication";
import { UserApplicationErrors } from "../interfaces/UserApplicationErrors";
import { getRegions } from "../repository/microservice-user-application/RegionRepositoryUaMs";
import { getProfessionalDirections } from "../repository/microservice-user-application/ProfessionalDirectionRepositoryUaMs";
import { postUserApplication } from "../repository/microservice-user-application/UserApplicationRepositoryUaMs";
import { filterUniversitiesForUserApplication } from "../repository/microservice-user-application/UniversityRepositoryUaMs";
import { UniversityFilterForUserApplication } from "../interfaces/UniversityFilterForUserApplication";
import { University } from "../interfaces/University";
import { createStyles, Theme, makeStyles } from '@material-ui/core/styles';
import { red } from "@material-ui/core/colors";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: '100%',
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
    },
    error: {
      color: red[500],
      fontSize: 12 
    }
  }),
);


type FormData = {
  firstName: string;
  secondName: string;
  phoneNumber: number;
  averageMark:number;
  regions: string[];
  professionalDirections: string[];
};

export const AnketaPage = () => {
  const classes = useStyles();
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);

  const [regions, setRegions] = React.useState<Region[]>([]);
  const [directions, setDirections] = React.useState<ProfessionalDirection[]>([]);
  const [universitiesForApp, setUniversitiesForApp] = React.useState<University[]>([]);

  const [userApplicationErrors, setUserApplicationErrors] = React.useState<UserApplicationErrors>();

  const {
    register,
    formState: { errors },
    handleSubmit,
    formState,
  } = useForm<FormData>();

  React.useEffect(() => {
    if(regions.length == 0) getRegions().then((result) =>
      setRegions(result)
    );
    if(directions.length == 0) getProfessionalDirections().then((result) =>
      setDirections(result)
    );
  });

  const submitForm = async (data: FormData) => {
    let userApp: UserApplication = {
      id: 0,
      firstName: data.firstName,
      secondName: data.secondName,
      phoneNumber: data.phoneNumber,
      averageMark: data.averageMark,
      regions: [],
      professionalDirections: []
    };
    if(data.regions) data.regions.map(e => userApp.regions.push({id:0,name: e}));
    if(data.professionalDirections) data.professionalDirections.map(e => userApp.professionalDirections.push({id:0,name: e}));
    console.log(userApp);
    const result = await postUserApplication(userApp);
    console.log("result" + result);
    if(result.success)
    {
      setUserApplicationErrors(undefined);
      setSuccessfullySubmitted(result.success);
      const filter:UniversityFilterForUserApplication = { regions: userApp.regions.map(r => r.name), averageMark: userApp.averageMark };
      const universities = await filterUniversitiesForUserApplication(filter);
      setUniversitiesForApp(universities);
    }
    else{
      setUserApplicationErrors(result.errors);
    }
  };

  return (
    <div className={classes.root}>
      <form onSubmit={handleSubmit(submitForm)}>
        <label>Ім'я:
          <input
            id="firstName"
            type="text"
            disabled={successfullySubmitted}
            {...register('firstName')} //, { required: true }
          />
          {/* {errors.firstName?.type === "required" && <p>This field is required (client validation)</p>} */}
          {userApplicationErrors?.FirstName && <p className={classes.error}>{userApplicationErrors.FirstName.map((e: string ) => e )} (server validation)</p>}
        </label>
        <br />
        <label>Прізвище:
          <input
            id="secondName"
            type="text"
            disabled={successfullySubmitted}
            {...register('secondName')} //, { required: true } 
          />
          {/* {errors.secondName?.type === "required" && <p>This field is required</p>} */}
          {userApplicationErrors?.SecondName && <p className={classes.error}>{userApplicationErrors.SecondName.map((e: string ) => e )} (server validation)</p>}
        </label>
        <br />
        <label>Телефон:
          <input
            id="phoneNumber"
            type="number"
            disabled={successfullySubmitted}
            {...register('phoneNumber', { required: true } )}  //, { required: true }
          />
          {errors.phoneNumber?.type === "required" && <p className={classes.error}>This field is required (client validation)</p>}
          {userApplicationErrors?.PhoneNumber && <p className={classes.error}>{userApplicationErrors.PhoneNumber.map((e: string ) => e )} (server validation)</p>}
        </label>
        <br />
        <label>Середній бал ЗНО:
          <input
            id="averageMark"
            type="number"
            disabled={successfullySubmitted}
            {...register('averageMark', { required: true } )} //, { required: true }
          />
          {errors.averageMark?.type === "required" && <p className={classes.error}>This field is required (client validation)</p>} 
          {userApplicationErrors?.AverageMark && <p className={classes.error}>{userApplicationErrors.AverageMark.map((e: string ) => e )} (server validation)</p>}
        </label>
        <br />    
        <br />
        <label>Регіони:
        <br />
        {regions?.map(e => 
        <label key={e.id}>{e.name}
          <input disabled={successfullySubmitted} type="checkbox" value={e.name} key={e.id} id={e.name} {...register('regions')} />
          <br />   
        </label>)}    
        </label>
        <br />
        <label>Напрямки:
        <br />
        {directions?.map(e => 
        <label key={e.id}>{e.name}
          <input  disabled={successfullySubmitted} type="checkbox" value={e.name} key={e.id} id={e.name} {...register('professionalDirections')} />
          <br />
        </label>)}    
        </label>
        <br />
        {userApplicationErrors?.RegionsAndProfessionalDirections && <p className={classes.error}>{userApplicationErrors.RegionsAndProfessionalDirections.map((e: string ) => e )} (server validation)</p>}
        <input type="submit" value="Надіслати" hidden={successfullySubmitted} />   
      </form>
      <br />
      <br />
      {successfullySubmitted && universitiesForApp.length>0 && <div>{universitiesForApp.map(e => <div>{e.name} | середній бал: {e.averageMark} | регіон: {e.regionName}<br /></div> )}</div>}
      {successfullySubmitted && universitiesForApp.length===0 && <div>Немає результатів</div>}
      <br />
    </div>
  );
};

export default AnketaPage;
