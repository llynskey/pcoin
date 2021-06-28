import React, { Component } from 'react';
import Voucher from '../Voucher/Voucher';
import axios from 'axios';
import JWT from 'jsonwebtoken';

export default class Vouchers extends Component {

    constructor(props){
        super(props);
        var user = JWT.decode(localStorage.getItem('jwt'))
        this.state ={
            User: user,
            Vouchers:[]
        }
        this.setVouchers = this.setVouchers.bind(this);

    }

    componentDidMount(){
        this.getVouchers();
    }

    getVouchers() {
        switch (this.state.User.Type) {
            case "Customer":
                axios.get("http://retrieve-voucher.pcoin.life/all", {
                    params: { ownerId: this.state.User.sub }
                }).then((res) => {
                    this.setVouchers(res.data);
                    console.log(this.state.Vouchers);
                }).catch((err) => {
                    alert(err);
                    throw (err);
                });
                break;
            case "Vendor":
                    axios.get("http://retrieve-voucher.pcoin.life/ownedBy",{
                        params: {vendorId: this.state.User.sub}
                    }).then((res) => {
                        this.setVouchers(res.data);
                        console.log(this.state.Vouchers);
                    }).catch((err) => {
                        alert(err);
                        throw(err);
                    });
            default:
                
                break;
        }
      
    }

    setVouchers(vouchers){
        this.setState({"Vouchers": vouchers})
    }


    render() {
        if (this.state.Vouchers != null) {
            return(
            this.state.Vouchers.map((voucher) => {
                console.log(voucher)
                return <Voucher voucherValue={voucher} />
            }))
        } else {
            return (
                <div>
                <h2>No Vouchers Found</h2>
                </div>
            )
        }
    }
}
