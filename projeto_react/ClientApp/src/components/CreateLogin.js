import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import CryptoJS from 'crypto-js';

export class CreateLogin extends Component {
    static displayName = CreateLogin.name;

    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            passwordSecond: ''
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
        if (this.state.password != this.state.passwordSecond) {

            alert("As senhas devem ser iguais")
            return
        }

        const request = {
            name: this.state.username,
            password: CryptoJS.AES.encrypt(this.state.password, 'secret_key').toString()
        }

        

        fetch('/api/usuario/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
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
                            <div className="mb-3">
                                <label className="form-label">Repita a Senha:</label>
                                <input
                                    type="password"
                                    name="passwordSecond"
                                    className="form-control"
                                    value={this.state.passwordSecond}
                                    onChange={this.handleInputChange}
                                />
                            </div>

                            <div className="text-center">
                                <button
                                    type="submit"
                                    className="btn btn-primary"
                                    disabled={this.state.password !== this.state.passwordSecond ||
                                        !this.state.password || !this.state.passwordSecond || !this.state.username}
                                >
                                    Entrar
                                </button>


                            </div>
                        </form>
                    </div>
                </div>
            </div>

        );
    }
}