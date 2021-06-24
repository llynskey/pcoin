import React, { Component } from 'react';
import JWT from 'jsonwebtoken';
import VendorProfile from '../Profiles/VendorProfile/VendorProfile';
import CustomerProfile from '../Profiles/CustomerProfile/CustomerProfile';

export default class Home extends Component {

    constructor(props){
        super(props);
        var jwt = localStorage.getItem('jwt');
        var user = JWT.decode(jwt);
        this.state = {
            user: user
        }
    }

    componentDidMount(){
        switch (this.state.user.Type) {
            case "Customer":
                
                break;
            case "Vendor":

                break;
            default:
                break;
        }
    }

    render() {
        switch (this.state.user.Type) {
            case "Customer":
                return(
                    <div>
                        <CustomerProfile/>
                    </div>
                )
               // break;
            case "Vendor":
                return(
                    <div> 
                        <VendorProfile/>
                    </div>
                )
               // break;
            default:
                break;
        }
    }
}
