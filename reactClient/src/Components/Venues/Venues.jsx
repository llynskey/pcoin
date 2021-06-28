import React, { Component } from 'react';
import Venue from '../Venue/Venue';
import axios from 'axios';
import JWT from 'jsonwebtoken';

export default class Venues extends Component {

    constructor(props){
        super(props);
        var user = JWT.decode(localStorage.getItem('jwt'))
        this.state ={
            User: user,
            Venues:[]
        }
        this.setVenues = this.setVenues.bind(this);

    }

    componentDidMount(){
        this.getVenues();
    }

    getVenues() {
        switch (this.state.User.Type) {
            case "Customer":
                axios.get("http://retrieve-venue.pcoin.life/all", {
                    params: { ownerId: this.state.User.sub }
                }).then((res) => {
                    this.setVenues(res.data);
                    console.log(this.state.Venues);
                }).catch((err) => {
                    alert(err);
                    throw (err);
                });
                break;
            case "Vendor":
                    axios.get("http://retrieve-venue.pcoin.life/byOwner",{
                        params: {ownerId: this.state.User.sub}
                    }).then((res) => {
                        this.setVenues(res.data);
                        console.log(this.state.Venues);
                    }).catch((err) => {
                        alert(err);
                        throw(err);
                    });
            default:
                
                break;
        }
      
    }

    setVenues(venues){
        this.setState({"Venues": venues})
    }


    render() {
        if (this.state.Venues != null) {
            return(
            this.state.Venues.map((venue) => {
                console.log(venue)
                return <Venue venueValue={venue} />
            }))
        } else {
            return (
                <div>
                <h2>No Venues Found</h2>
                </div>
            )
        }
    }
}
