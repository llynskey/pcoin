import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from 'axios';

export default function Login(props) {

    // login obj
    const [user, setUser] = useState({});


    function onSubmit(event) {

        event.preventDefault()
        axios.post('http://localhost:1234/login', {
            Username: user.username,
            Pass: user.password
        },{headers:{ 'Content-Type': 'application/json'}}).then((res) => {
            if(res.status === 200){
                alert("woop")
            }
        }).catch(err => console.log(err))
    }


return (
    //login form
    <div className="Login">
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
