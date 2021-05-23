import React from 'react';
import { getUniversities } from '../repository/UniversityRepository';
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
      <div>
        <ul>
          {this.state.data.map(e => <li key={e.id.toString()}>{e.name}</li>)}
        </ul>
      </div>)
    }
};

export default UniversitiesListPage;