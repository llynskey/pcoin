import React, { Component } from 'react';
import axios from 'axios';
import Button from "react-bootstrap/Button";
var token = localStorage.getItem('jwt');
class Logout extends React.Component {



    

    logoutPost() {
        console.log("logging out")
        localStorage.removeItem('jwt');
        axios.post("http://localhost:1234/user/logout", {
        }, { headers: { 'Authorization': `${token}` } }).then((res) =>{
            
        //return;
        });   
        document.location.href='/';     
        //console.log(res.status);
    }


    render(){
        console.log("logoutBtn")
        if(token)
            return(
                <Button onClick={this.logoutPost}>Logout</Button>
                 )
        else
            return null;
    }
}

export default Logout;