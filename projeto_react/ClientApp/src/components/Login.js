import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import jwtDecode from "jwt-decode";

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: ''
        };
    }

    handleInputChange = (event) => {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    handleSubmit = (event) => {
        event.preventDefault();

        localStorage.removeItem('token');
        localStorage.removeItem('user');

        const request = {
            name: this.state.username,
            password: this.state.password
        }

        fetch('/api/logins/loga', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        })
            .then(response => response.json())
            .then(data => {
                var tokenDecode = jwtDecode(data.token);
                localStorage.setItem('token', data.token);
                localStorage.setItem('user', tokenDecode.nameid);

                console.log(tokenDecode.nameid)

                alert(data.mensagem)
            })
            .catch(error => {
                
                console.error('Houve um problema com a requisição fetch:', error);
            });
       
    }

    render() {
        return (
            <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
                <div className="card" style={{ width: '30rem' }}>
                    <div className="card-body">
                        <h1 className="card-title text-center">Login</h1>
                        <form onSubmit={this.handleSubmit}>
                            <div className="mb-3">
                                <label className="form-label">Nome de usuário:</label>
                                <input
                                    type="text"
                                    name="username"
                                    className="form-control"
                                    value={this.state.username}
                                    onChange={this.handleInputChange}
                                />
                            </div>
                            <div className="mb-3">
                                <label className="form-label">Senha:</label>
                                <input
                                    type="password"
                                    name="password"
                                    className="form-control"
                                    value={this.state.password}
                                    onChange={this.handleInputChange}
                                />
                            </div>
                            
                            <div className="text-center">
                                <button type="submit" className="btn btn-primary">Entrar</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>

        );
    }
}
