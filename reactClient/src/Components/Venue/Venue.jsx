import React, { Component } from 'react';
import { Card, Col, Button } from 'react-bootstrap';
import './Venue.css';

const Venue = (props) => {

    const id = props.venueValue._id;
    const name = props.venueValue.name;
    const address = props.venueValue.address;
    const city = props.venueValue.city;

    function viewVenue() {
        document.location.href = `/viewVenue:id=${id}`;
    }
    
        return (
            <div className="Venue">
                <Col>
                <Card>
                    <Card.Title>{name}</Card.Title>
                    <Card.Body>
                        <p>{address}</p>
                        <p>{city}</p>
                    </Card.Body>
                    <Button onClick={viewVenue}>View Venue</Button>
                </Card>
                </Col>
            </div>
        )
    }

    export default Venue;
