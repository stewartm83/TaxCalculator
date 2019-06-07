import React, { Component } from 'react';

export class Calculator extends Component {

    static displayName = Calculator.name;
    constructor(props) {
        super(props);
        this.state = {
            postalCode: '',
            annualSalary: ''
        };
    }

    handlePostalCodeChange = e => {
        this.setState({ author: e.target.value });
    };

    handleAnnualSalaryChange = e => {
        this.setState({ text: e.target.value });
    };

    handleSubmit = e => {
        e.preventDefault();
        const postalCode = this.state.postalCode.trim();
        const annualSalary = this.state.annualSalary.trim();
        if (!postalCode || !annualSalary) {
            return;
        }

        const url = 'api/Calculations';      

        fetch(url, {
            method: 'POST', 
            body: JSON.stringify({ postalCode: postalCode, annualSalary: annualSalary }), 
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .then(response => console.log('Success:', JSON.stringify(response)))
            .catch(error => console.error('Error:', error));

        
        this.setState({ postalCode: '', annualSalary: '' });       
    };

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div className="form-group row">
                    <label for="postal-code">Postal Code</label>
                    <input
                        type="text"
                        className="form-control"
                        id="postal-code"
                        value={this.state.postalCode}
                        onChange={this.handlePostalCodeChange}
                    />
                </div>

                <div className="form-group row">
                    <label for="salary" >Annual Salary</label>
                    <input
                        type="text"
                        className="form-control"
                        id="salary"
                        value={this.state.annualSalary}
                        onChange={this.handleAnnualSalaryChange}
                    />
                </div>
                <input type="submit" class="btn btn-primary" value="Calculate" />
            </form>
        );
    }
}