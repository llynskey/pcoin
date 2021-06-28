import React, { useState, useEffect, Fragment } from 'react';
import { Row, Button, Modal } from 'react-bootstrap';
import Select from 'react-select';
import axios from 'axios';
import JWT from 'jsonwebtoken';
import Voucher from '../../../../Components/Voucher/Voucher';
import { render } from 'react-dom';
import AddVoucher from '../../../../Components/addVoucherModal/addVoucher';

const ViewVenue = (props) => {

    const [Venue, setVenue] = useState([]);
    const [Vouchers, setVouchers] = useState([]);
    const [allVouchers, setAllVouchers] = useState([]);
    const User = JWT.decode(localStorage.getItem('jwt'));
    const Path = document.location.pathname;
    const VenueID = Path.split('=')[1];
    useEffect(() => {
        
        getVenue(VenueID);
        getVouchers(VenueID);
    }, [])

    function getVenue(id) {
        axios.get('http://retrieve-venue.pcoin.life', {
            params: { id: id }
        }).then((res) => {
            setVenue(res.data);
        })
    }

    function getVouchers(id) {
        axios.get('http://retrieve-voucher.pcoin.life/offeredBy', {
            params: { venueId: id }
        }).then((res) => {
            setVouchers(res.data);
        }).catch((err) => {

        });
    }

    return (
        <div>
            <h1>{Venue.name}</h1>
            <h2>Address: {Venue.address}, {Venue.city}</h2>

            <div className="Vouchers">
                <h3>Vouchers</h3>
                <div>
                    <Row>
                        {Vouchers.map((voucher) => {
                            return <Voucher voucherValue={voucher} />
                        })}
                    </Row>
                </div>
                <Row>
                   <AddVoucher vendorId={User.sub} venueId={VenueID}/>
                </Row>
            </div>
        </div>
    )
}

export default ViewVenue;
