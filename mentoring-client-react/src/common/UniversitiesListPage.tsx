import React from 'react';
import ReactDOM from "react-dom";
import { getUniversities } from '../services/UniversityService';
import { University } from '../interfaces/University';

interface IProps {
}

interface IState {
  data: University[];
}

export class UniversitiesListPage extends React.Component<IProps, IState> {
    constructor(props: any) {
      super(props);
      this.state = { data: [] };
    }

    componentDidMount() {
      getUniversities()
        .then(universities => this.setState({ data: universities }));
    }

    render() {
      return(
      <div >
        text
          {this.state.data.map(e => e.name)}
      </div>
      )}
};

export default UniversitiesListPage;