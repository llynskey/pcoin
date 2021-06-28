import React, { Component, Fragment } from 'react';
import Select from 'react-select';
import { Modal, Button } from 'react-bootstrap';
import axios from 'axios';

export default class addVoucher extends Component {

    constructor(props) {
        super(props);
        this.state = {
            Show: false,
            Options: [],
            Vouchers: [],
            Selected: {}
        }
        this.handleShow = this.handleShow.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.setVouchers = this.setVouchers.bind(this);
        this.setSelected = this.setSelected.bind(this);
        this.addVoucherToVenue = this.addVoucherToVenue.bind(this);
    }

    componentDidMount() {
        console.log("props")
        console.log(this.props)
        
    }

    setVouchers(vouchers) {
        this.setState({ Vouchers: vouchers });
    }

    setOptions(options) {
        this.setState({ Options: options });
    }

    setShow(value) {
        this.setState({ Show: value });
    }


    setSelected(option) {
        this.setState({ Selected: option });
    }

    handleClose() {
        this.setState({ Show: false });
    }

    handleShow() {
        this.getVendorVouchers();
        this.setState({ Show: true });
    }

    getVendorVouchers() {
        axios.get('http://retrieve-voucher.pcoin.life/ownedBy',{
            params:{"vendorId":this.props.vendorId}
        }).then((res) => {
            this.setVouchers(res.data);
            this.setOptions(this.state.Vouchers.map(voucher => ({ label: voucher.name, value: voucher._id })));
        })
    }

    addVoucherToVenue() {
        console.log(this.state.Selected.value);
        console.log(this.props.venueId);
            axios.put('http://manage-voucher.pcoin.life/offeredBy', {
                _id: this.state.Selected.value,
                OfferedBy: [this.props.venueId]
            }).then((res) =>{
                console.log(res);
                if(res.status === 200){
                    this.handleClose();
                }
            })
    }


    render() {
        //getAllVouchers();

        return (
            <Fragment>
                <Button variant="primary" onClick={this.handleShow}>
                    Add Voucher
                </Button>

                <Modal show={this.state.Show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Add Voucher to Venue</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Select value={this.state.Selected} options={this.state.Options} onChange={this.setSelected} />
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="secondary" onClick={this.handleClose}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={this.addVoucherToVenue}>
                            Add Voucher
                        </Button>
                    </Modal.Footer>
                </Modal>
            </Fragment>
        );
    }
}
