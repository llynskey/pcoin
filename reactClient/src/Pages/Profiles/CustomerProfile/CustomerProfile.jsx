import React, { Component } from 'react';
import { Row } from 'react-bootstrap';
import JWT from 'jsonwebtoken';
import axios from 'axios';
import Venues from '../../../Components/Venues/Venues';

class CustomerProfile extends Component {

    constructor(props) {
        super(props);
        var jwt = localStorage.getItem('jwt');
        const token = jwt.split(' ')[1];
        var user = JWT.decode(jwt);
        console.log(user);
        this.state = {
            User: user
        }
    }

    componentDidMount() {
        console.log(this.state.User.sub);
        this.getUser();
        this.getPoints();
    }

    getUser() {
        axios.get('http://retrieve-customer.pcoin.life', {
            /*headers: { 'Authorization': `${localStorage.getItem('jwt')}` }
                , */params: { id: this.state.User.sub }
        }).then((res) => {
            console.log(res);
            this.setFirstname(res.data.firstName);
            this.setLastname(res.data.lastName);
            //this.setDOB(res.data.DOB);
            this.setEmail(res.data.email);
        }).catch((err) => {
            alert(err);
            console.log(err)
            throw err;
        });
    }

    getPoints() {
        axios.get('http://retrieve-points.pcoin.life', {
            params: { id: this.state.User.sub }
        }).then((res) => {
            this.setPoints(res.data.balance);
        }).catch((err) => {
            alert(err);
            console.log(err)
            throw err;
        });
    }

    


    setFirstname(firstname) {
        this.setState({ "Firstname": firstname });
    }

    setLastname(lastname) {
        this.setState({ "Lastname": lastname });
    }

    setDOB(dob) {
        this.setState({ "DOB": dob });
    }

    setEmail(email) {
        this.setState({ "Email": email });
    }

    setDateJoined(dateJoined) {
        this.setState({ "DateJoined": dateJoined });
    }

    setPoints(points) {
        this.setState({ "Points": points });
    }

    render() {
        return (
            <div>
                <div>
                    <p>Firstname: {this.state.Firstname}</p>
                    <p>Lastname: {this.state.Lastname}</p>
                    <p>Email: {this.state.Email}</p>
                </div>
                <div>
                    <p>Account Balance:{this.state.Points} Points</p>
                </div>
                <div>
                    <h2>Available Venues</h2>
                        <Venues/>
                </div>
            </div>
        )
    }
}

export default CustomerProfile;

