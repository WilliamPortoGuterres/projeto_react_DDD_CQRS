import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1 class="border border-primary rounded">Bem vindos!</h1>
                <div class="shadow">
                <p>Este projeto tem o intuito de demonstrar conhecimentos em:</p>
                <ul>
                    <li><a href='#'>ASP.NET Core</a> </li>
                    <li><a href='#'>React</a> </li>
                    <li><a href='#'>Bootstrap</a> </li>
                    <li><a href='#'>CQRS</a> </li>
                    <li><a href='#'>DDD</a> </li>
                    <li><a href='#'>Entity framework</a> </li>
                    <li><a href='#'>Dapper</a> </li>
                    <li><a href='#'>JWT</a> </li>
                    <li><a href='#'>MicroService</a> </li>
                </ul>
                </div>
                
            </div>
        );
    }
}
