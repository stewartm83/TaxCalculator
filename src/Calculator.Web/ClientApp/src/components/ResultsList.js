import React, { Component } from 'react';


export class ResultsList extends Component {
    static displayName = ResultsList.name;

    constructor(props) {
        super(props);
        this.state = { calculations: [], loading: true };
    }

    loadCalculationsFromServer = () => {
        fetch('http://localhost:5000/api/Calculations')
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
                        <th>Postal Code</th>
                        <th>Annual Salary</th>
                        <th>Tax Calculated</th>
                        <th>Date Created</th>
                    </tr>
                </thead>
                <tbody>
                    {calculations.map(calculation =>
                        <tr key={calculation.id}>
                            <td>{calculation.postalCode}</td>
                            <td>{calculation.annualSalary}</td>
                            <td>{calculation.calculatedTax}</td>
                            <td>{calculation.createdOn}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ResultsList.renderCalculations(this.state.calculations);

        return (
            <div className="text-center align-center">
                <h2>Results List</h2>
                {contents}
            </div>
        );
    }
}