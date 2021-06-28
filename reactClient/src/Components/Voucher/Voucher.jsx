import React, { Component } from 'react';
import { Card, Col, Button } from 'react-bootstrap';
import ActionButtons from './ActionButtons/ActionButtons';
import './Voucher.css';

const Voucher = (props) => {

    const id = props.voucherValue._id;
    const name = props.voucherValue.name;
    const price = props.voucherValue.price;
    
        return (
            <div className="Voucher">
                <Col>
                <Card>
                    <Card.Title>{name}</Card.Title>
                    <Card.Body>
                        <p>{price} points</p>
                    </Card.Body>
                    <ActionButtons/>
                </Card>
                </Col>
            </div>
        )
    }

    export default Voucher;
