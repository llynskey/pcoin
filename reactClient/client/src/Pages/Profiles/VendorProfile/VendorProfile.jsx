import React, { Component } from 'react';
import {Button, Row,Col} from 'react-bootstrap';
import JWT from 'jsonwebtoken';
import axios from 'axios';
import Venue from '../../../Components/Venue/Venue';

class VendorProfile extends Component {

    constructor(props){
        super(props);
        var jwt = localStorage.getItem('jwt');
        const token = jwt.split(' ')[1];
        var user = JWT.decode(jwt);
        console.log(user);
        this.state ={
            User: user,
            Venues: []
        }   
        this.setVenues = this.setVenues.bind(this);
    }

    componentDidMount(){
        console.log(this.state.User);
        this.getUser();
    }

    getUser(){       
        axios.get("http://retrieve-vendor.pcoin.life",{
            params: {id: this.state.User.sub}
        }).then((res) =>{
            if(res.status === 200){
            this.setFirstname(res.data.firstName);
            this.setLastname(res.data.lastName);
            //this.setDOB(res.data.DOB);
            this.setEmail(res.data.email);
            console.log(this.state.User);
            this.getVenues();
            }else{
                alert(res);
            }
        }).catch((err) => {
            alert(err);
            throw err;
        });
    }

    getVenues(){
        axios.get("http://retrieve-venue.pcoin.life/byOwner",{
            params: {ownerId: this.state.User.sub}
        }).then((res) => {
            this.setVenues(res.data);
            console.log(this.state.Venues);
        }).catch((err) => {
            alert(err);
            throw(err);
        });
    }

    displayVenues(){
        if(this.state.Venues != null){
                this.state.Venues.map((venue)=>{
                    console.log(venue)
                return <Venue venueValue={venue}/>
                })
        }else{
            return(
                <h2>No Venues Found</h2>
            )
        }
    }
    

    setFirstname(firstname){
        this.setState({"FirstName": firstname});
    }

    setLastname(lastname){
        this.setState({"LastName": lastname});
    }

    setEmail(email){
        this.setState({"Email": email});
    }

    setVenues(venues){
        this.setState({'Venues': venues});
    }

    render() {
        return (
            <div>
                <div>
                    <p>Firstname: {this.state.FirstName}</p>
                    <p>Lastname:{this.state.LastName} </p>
                    <p>Email: {this.state.Email}</p>
                </div>
                <div>
                    <h3>Venues</h3>
                <Row>  
                     {this.displayVenues}   
                </Row>
                </div>
                <div>
                    <Button href="/createVenue">Create Venue</Button>
                </div>
            </div>
        )
    }
}

export default VendorProfile;

