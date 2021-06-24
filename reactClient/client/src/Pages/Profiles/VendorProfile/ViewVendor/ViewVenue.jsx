import React, { useState, useEffect} from 'react';
import { Row } from 'react-bootstrap';
import axios from 'axios';
import JWT from 'jsonwebtoken';
import Voucher from '../../../../Components/Voucher/Voucher';

var user;

const ViewVenue = (props) => {

const [Venue, setVenue] = useState([]);
const [Vouchers, setVouchers] = useState([]);

useEffect(() => {
    var path = document.location.pathname;
    var id = path.split('=')[1];
    console.log("path" + path)
    console.log(id);
    user = JWT.decode(localStorage.getItem('jwt'));
    getVenue(id);
    getVouchers(id);
}, [])

function getVenue(id){
    axios.get('http://retrieve-venue.pcoin.life',{
        params:{id: id}
    }).then((res) => {
        console.log(user);
        console.log(res.data);
        setVenue(res.data);
    })
}

function getVouchers(id){
    axios.get('http://retrieve-voucher.pcoin.life/offeredBy',{
        params:{venueId: id}
    }).then((res) => {
        console.log("ID: " + id);
        console.log(res.data);
        setVouchers(res.data);
    }).catch((err)=> {

    });
}



    return (
        <div>
            <h1>{Venue.name}</h1>
            <h2>Address: {Venue.address}, {Venue.city}</h2>
            
            <div className="Vouchers">
                <h3>Vouchers</h3>
            <Row>
                    {Vouchers.map((voucher)=>{
                        console.log(voucher)
                    return <Voucher voucherValue={voucher}/>
                    })}
            </Row>
            </div>
        </div>
        )
    }

export default ViewVenue;
