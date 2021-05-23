import React from "react";
import ReactDOM from "react-dom";
import { useForm } from "react-hook-form";
import { Region } from "../interfaces/Region";
import { getRegions } from "../repository/RegionRepository";

type FormData = {
  firstName: string;
  secondName: string;
  phoneNumber: string;
  averageMark:number;
  regions: Region[];
  professionalDirections: string[];
};

export const AnketaPage = () => {
  const [successfullySubmitted, setSuccessfullySubmitted] =
    React.useState(false);

  const [regions, setRegions] = React.useState<Region[]>([]);

  const {
    register,
    formState: { errors },
    handleSubmit,
    formState,
  } = useForm<FormData>();

  React.useEffect(() => {
    getRegions().then((result) =>
      setRegions(result)
    );
  });

  const submitForm = async (data: FormData) => {
    console.log(data);
    // const result = await postQuestion({
    //   title: data.title,
    //   content: data.content,
    //   userName: "Fred",
    //   created: new Date(),
    // });
    //setSuccessfullySubmitted(result ? true : false);
  };

  

  return (
    <form onSubmit={handleSubmit(submitForm)}>
      <label>Ім'я:
        <input
          id="firstName"
          type="text"
          {...register('firstName', { required: true })} 
        />
        {errors.firstName?.type === "required" && <p>This field is required</p>}
      </label>
      <label>Прізвище:
        <input
          id="secondName"
          type="text"
          {...register('secondName', { required: true })} 
        />
        {errors.secondName?.type === "required" && <p>This field is required</p>}
      </label>
      <label>Телефон:
        <input
          id="phoneNumber"
          type="text"
          {...register('phoneNumber', { required: true })} 
        />
        {errors.phoneNumber?.type === "required" && <p>This field is required</p>}
      </label>
      <label>Середній бал ЗНО:
        <input
          id="averageMark"
          type="text"
          {...register('averageMark', { required: true })} 
        />
        {errors.averageMark?.type === "required" && <p>This field is required</p>}
      </label>
      {regions?.map(e => 
      <label key={e.id}>{e.name}
        <input type="checkbox" value={e.name} key={e.id} id={e.name} {...register('regions')} />
      </label>)}    
      <input type="submit" value="Надіслати" />
    </form>
  );
};

export default AnketaPage;
