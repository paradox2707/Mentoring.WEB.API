import React from 'react';
import { Speciality } from '../interfaces/Speciality';
import { getSpecialities } from '../services/SpecialityService';

interface IProps {
}

interface IState {
  data: Speciality[];
}

export class SpecialitiesListPage extends React.Component<IProps, IState> {
    constructor(props: any) {
      super(props);
      this.state = { data: [] };
    }

    componentDidMount() {
      getSpecialities()
        .then(universities => this.setState({ data: universities }));
    }

    render() {
      return(
      <div>
        <ul>
          {this.state.data.map(e => <li key={e.id.toString()}>{e.name}</li>)}
        </ul>
      </div>)
    }
};

export default SpecialitiesListPage;