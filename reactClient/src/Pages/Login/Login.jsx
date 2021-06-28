import React from 'react'
import { Button, Jumbotron, Row, Col } from 'react-bootstrap'

export default function Login() {
    return (
        <div>
            <Jumbotron><h1>Welcome to Pcoin</h1></Jumbotron>
            <Row>
                <Col>
                    <div><Button href="/customer-login">Customer Login</Button></div>
                </Col>
                <Col>
                    <div><Button href="/vendor-login">Vendor Login</Button></div>
                </Col>
            </Row>
        </div>
    )
}
