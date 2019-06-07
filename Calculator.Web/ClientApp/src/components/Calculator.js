import React, { Component } from 'react';

export class Calculator extends Component {

    static displayName = Calculator.name;
    constructor(props) {
        super(props);
        state = {
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
        var postalCode = this.state.postalCode.trim();
        var annualSalary = this.state.annualSalary.trim();
        if (!postalCode || !annualSalary) {
            return;
        }
        this.props.onCommentSubmit({ postalCode: postalCode, annualSalary: annualSalary });
        this.setState({ postalCode: '', annualSalary: '' });
    };

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <input
                    type="text"
                    placeholder="Postal Code"
                    value={this.state.postalCode}
                    onChange={this.handlePostalCodeChange}
                />
                <input
                    type="text"
                    placeholder="Annual Salary"
                    value={this.state.annualSalary}
                    onChange={this.handleAnnualSalaryChange}
                />
                <input type="submit" value="Post" />
            </form>
        );
    }
}