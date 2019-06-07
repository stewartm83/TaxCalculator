import React, { Component } from 'react';


export class Calculations extends Component {
    static displayName = Calculations.name;

    constructor(props) {
        super(props);
        this.state = { calculations: [], loading: true };      
    }

    loadCalculationsFromServer = () => {
        fetch('api/Calculations/')
        .then(response => response.json())
        .then(data => {
            this.setState({ calculations: data, loading: false });
        });
    };

    componentDidMount() {
        window.setInterval(this.loadCalculationsFromServer, 5000);
    }

    static renderCalculations(calculations) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Postal Code</th>
                        <th>Annual Salary</th>
                        <th>Tax Calculated</th>
                    </tr>
                </thead>
                <tbody>
                    {calculations.map(calculation =>
                        <tr key={calculation.dateFormatted}>
                            <td>{calculation.dateFormatted}</td>
                            <td>{calculation.temperatureC}</td>
                            <td>{calculation.temperatureF}</td>
                            <td>{calculation.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : Calculations.renderCalculations(this.state.calculations);
  
      return (
        <div>
          <h1>Weather forecast</h1>
          <p>This component demonstrates fetching data from the server.</p>
          {contents}
        </div>
      );
    }
}