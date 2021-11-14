import React from "react";
import ReactDOM from "react-dom";
import { useForm } from "react-hook-form";
import { Region } from "../interfaces/Region";
import { postRegion } from "../repository/microservice-university-and-speciality/RegionRepositoryUsMs";
import { createStyles, Theme, makeStyles } from "@material-ui/core/styles";
import { red } from "@material-ui/core/colors";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      width: "100%",
      maxWidth: 1240,
      backgroundColor: theme.palette.background.paper,
      paddingLeft: theme.spacing(4),
    },
    error: {
      color: red[500],
      fontSize: 12,
    },
  })
);

type FormData = {
  name: string;
};

export const CreateMasterDataPage = () => {
  const classes = useStyles();

  const {
    register,
    formState: { errors },
    handleSubmit,
    formState,
    reset,
  } = useForm<FormData>();

  const submitForm = async (data: FormData) => {
    let region = { id: 0, name: data.name } as Region;
    let result = await postRegion(region);
    if (result.success) {
      reset();
    }
  };

  return (
    <div className={classes.root}>
      <form onSubmit={handleSubmit(submitForm)}>
        <label>
          Регіон:
          <input id="firstName" type="text" {...register("name")} />
        </label>
        <input type="submit" value="Створити" />
      </form>
    </div>
  );
};

export default CreateMasterDataPage;
