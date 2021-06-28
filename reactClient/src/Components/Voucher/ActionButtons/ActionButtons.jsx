import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import JWT from 'jsonwebtoken';

export default class ActionButtons extends Component {
    constructor(props){
        super(props);
        var user = JWT.decode(localStorage.getItem('jwt'))
        this.state ={
            User: user
        }

    }

    render() {
        switch (this.state.User.Type) {
            case "Customer":
                return(
                <Button>Buy</Button>
                )
                break;
            case "Vendor":
                return(
                    <Button>Edit</Button>
                )
                break;
            default:
                break;
        }
    }
}
