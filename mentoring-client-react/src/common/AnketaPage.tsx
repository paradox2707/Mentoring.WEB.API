import React from 'react';

interface IProps {
}

interface IState {
    value: any
}

export class AnketaPage extends React.Component<IProps, IState> {
    constructor(props: any) {
      super(props);
      this.state = {value: ''};
  
      this.handleChange = this.handleChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
    }
  
    handleChange(event: any) {
      this.setState({value: event.target.value});
    }
  
    handleSubmit(event: any) {
      alert('Ім\'я, що було надіслано: ' + this.state.value);
      event.preventDefault();
    }
  
    render() {
      return (
        <form onSubmit={this.handleSubmit}>
          <label>
            Ім'я:
            <input type="text" value={this.state.value} onChange={this.handleChange} />
          </label>
          <input type="submit" to="./Universities" value="Надіслати" />
        </form>
      );
    }
  }

  export default AnketaPage;