import React from "react";
import ReactDOM from "react-dom";
import { useForm } from "react-hook-form";
import { Region } from "../interfaces/Region";
import { ProfessionalDirection } from "../interfaces/ProfessionalDirection";
import { UserApplication } from "../interfaces/UserApplication";
import { getRegions } from "../repository/RegionRepository";
import { getProfessionalDirections } from "../repository/ProfessionalDirectionRepository";
import { postUserApplication } from "../repository/UserApplicationRepository";

type FormData = {
  firstName: string;
  secondName: string;
  phoneNumber: number;
  averageMark:number;
  regions: string[];
  professionalDirections: string[];
};

export const AnketaPage = () => {
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);

  const [regions, setRegions] = React.useState<Region[]>([]);
  const [directions, setDirections] = React.useState<ProfessionalDirection[]>([]);

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
    data.regions.map(e => userApp.regions.push({id:0,name: e}))
    data.professionalDirections.map(e => userApp.professionalDirections.push({id:0,name: e}))
    console.log(userApp);
    const result = await postUserApplication(userApp);
    console.log("result" + result);
    setSuccessfullySubmitted(result ? true : false);
  };

  return (
    <form onSubmit={handleSubmit(submitForm)}>
      <label>Ім'я:
        <input
          id="firstName"
          type="text"
          disabled={successfullySubmitted}
          {...register('firstName', { required: true })} 
        />
        {errors.firstName?.type === "required" && <p>This field is required</p>}
      </label>
      <label>Прізвище:
        <input
          id="secondName"
          type="text"
          disabled={successfullySubmitted}
          {...register('secondName', { required: true })} 
        />
        {errors.secondName?.type === "required" && <p>This field is required</p>}
      </label>
      <label>Телефон:
        <input
          id="phoneNumber"
          type="number"
          disabled={successfullySubmitted}
          {...register('phoneNumber', { required: true })} 
        />
        {errors.phoneNumber?.type === "required" && <p>This field is required</p>}
      </label>
      <label>Середній бал ЗНО:
        <input
          id="averageMark"
          type="phone"
          disabled={successfullySubmitted}
          {...register('averageMark', { required: true })} 
        />
        {errors.averageMark?.type === "required" && <p>This field is required</p>}
      </label>
      {regions?.map(e => 
      <label key={e.id}>{e.name}
        <input disabled={successfullySubmitted} type="checkbox" value={e.name} key={e.id} id={e.name} {...register('regions')} />
      </label>)}    
      {directions?.map(e => 
      <label key={e.id}>{e.name}
        <input  disabled={successfullySubmitted} type="checkbox" value={e.name} key={e.id} id={e.name} {...register('professionalDirections')} />
      </label>)}    
      <input type="submit" value="Надіслати" hidden={successfullySubmitted} />   
    </form>
  );
};

export default AnketaPage;
