import React, { Component } from 'react';

export class Calculator extends Component {
    static displayName = Calculator.name;

    constructor(props) {
        super(props);
        this.state = {
            postalCode: '',
            annualSalary: '',
            taxResult: {},
            editing: true
        };
    }

    handlePostalCodeChange = e => {
        this.setState({ postalCode: e.target.value, editing: true });
    };

    handleAnnualSalaryChange = e => {
        this.setState({ annualSalary: e.target.value, editing: true });
    };

    handleSubmit = e => {
        e.preventDefault();
        const postalCode = this.state.postalCode.trim();
        const annualSalary = this.state.annualSalary.trim();
        if (!postalCode || !annualSalary) {
            return;
        }

        fetch('http://localhost:5000/api/Calculations/calculate', {
            method: 'POST',
            body: JSON.stringify({ postalCode: postalCode, annualSalary: annualSalary }),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(res => res.json())
            .then(response => {
                this.setState({ taxResult: response, editing: false });
            }).catch(error => console.error('Error:', error));


        this.setState({ postalCode: '', annualSalary: '' });
    };

    render() {
        return (
            <div className="card ">
                <div className="card-header text-center">Calculate</div>
                <div className="card-body row">
                    <form className="offset-3 col-8" onSubmit={this.handleSubmit}>
                        <div className="form-group row">
                            <label className="col-4">Postal Code</label>
                            <input
                                type="text"
                                className="form-control col-6"
                                id="postal-code"
                                value={this.state.postalCode}
                                onChange={this.handlePostalCodeChange}
                            />
                        </div>

                        <div className="form-group row">
                            <label className="col-4">Annual Salary</label>
                            <input
                                type="text"
                                className="form-control col-6"
                                id="salary"
                                value={this.state.annualSalary}
                                onChange={this.handleAnnualSalaryChange}
                            />
                        </div>
                        <div className="row">
                            <input type="submit" className="btn btn-primary offset-4 col-6 btn-block" value="Calculate" />
                        </div>
                    </form>

                    {this.state.taxResult.id > 0 && !this.editing &&
                        <div className="offset-3 col-8">
                            <h3>Result</h3>
                            <div id="results-div">
                                <div className="form-group row">
                                    <label className="col-4">Annual Salary</label>
                                    <div className="col-8">
                                        <input type="text" readOnly className="form-control-plaintext" value={this.state.taxResult.annualSalary} />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label className="col-4">Tax Calculated</label>
                                    <div className="col-8">
                                        <input type="text" readOnly className="form-control-plaintext" value={this.state.taxResult.calculatedTax} />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label className="col-4">Postal Code</label>
                                    <div className="col-8">
                                        <input type="text" readOnly className="form-control-plaintext" value={this.state.taxResult.postalCode} />
                                    </div>
                                </div>
                                <div className="form-group row">
                                    <label className="col-4">Date Calculated</label>
                                    <div className="col-8">
                                        <input type="text" readOnly className="form-control-plaintext" value={this.state.taxResult.createdOn} />
                                    </div>
                                </div>

                            </div>
                        </div>
                    }
                </div>
            </div>

        );
    }
}