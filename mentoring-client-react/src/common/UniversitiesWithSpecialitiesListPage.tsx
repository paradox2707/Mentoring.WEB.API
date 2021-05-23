import React from 'react';
import { getUniversitiesWithSpecialities } from '../repository/UniversityRepository';
import { University } from '../interfaces/University';

interface IProps {
}

interface IState {
  data: University[];
}

export class UniversitiesWithSpecialitiesListPage extends React.Component<IProps, IState> {
    constructor(props: any) {
      super(props);
      this.state = { data: [] };
    }

    componentDidMount() {
      getUniversitiesWithSpecialities()
        .then(universities => this.setState({ data: universities }));
    }

    render() {
      return(
      <div>
        <ul>
          {this.state.data.map(
              u => { return <li key={u.id.toString()}>{u.name}
              <ul>
              {u.specialities.map(s => <li key={s.id.toString()}>{s.name}</li> )}
              </ul>
              </li>
                }
              )}
        </ul>
      </div>)
    }
};

export default UniversitiesWithSpecialitiesListPage;