import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from 'axios';
import '../Login.css';

export default function CustomerLogin(props) {

    // login obj
    const [user, setUser] = useState({});


    function onSubmit(event) {

        event.preventDefault()
        axios.post('http://login.pcoin.life/customer', {
            Username: user.username,
            Pass: user.password
        },{headers:{ 'Content-Type': 'application/json'}}).then((res) => {
            if(res.status === 200){
                console.log(res.data);
                localStorage.setItem('jwt', res.data);
                document.location.href ='/home';
            }
        }).catch(err => alert(err));
    }


return (
    //login form
    <div className="Login">
                <h1>Customer Login</h1>
        <Form onSubmit={onSubmit}>
            <Form.Group size="lg" controlId="Username">
                <Form.Label>Username</Form.Label>
                <Form.Control
                    autoFocus
                    type="text"
                    onChange={(event) => setUser({ ...user, username: event.target.value })} // calling event handler   
                    defaultValue={user.username}  // global variable 
                    required
                />
            </Form.Group>
            <Form.Group size="lg" controlId="Password">
                <Form.Label>Password</Form.Label>
                <Form.Control
                    type="password"
                    onChange={(event) => setUser({ ...user, password: event.target.value })} // calling event handler   
                    defaultValue={user.password}  // global variable 
                    required
                />
            </Form.Group>
            <Button block size="lg" type="submit">Login</Button>
        </Form>
    </div>
)
}
