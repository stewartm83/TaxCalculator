import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div className="text-center align-center">
        <h1>Pay space tax calculator</h1>
        <p>Welcome to the Pay space tax calculator application. Click start to calculate</p>
        <div>
          <a className="btn btn-outline-primary mr-4" href='/calculator'>
            Start
        </a>
          <a className="btn btn-outline-primary ml-4" href='/results'>
            View Previous Results
        </a>
        </div>
      </div>
    );
  }
}
