import React from "react";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import JWT from 'jsonwebtoken';
import './CreateVoucher.css'

class CreateVoucher extends React.Component {
  constructor(props) {
    super(props);
    var jwt = JWT.decode(localStorage.getItem('jwt'));
    this.state = {
      user: jwt
    }

    this.registerPost = this.registerPost.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  async registerPost() {
      axios.post('http://manage-voucher.pcoin.life',{
        ownerId: this.state.user.sub,
        name: this.state.name,
        price: this.state.price,
        OfferedBy: []
      }).then((res)=>{
        if(res.status === 200){
          alert('Voucher Created Successfully');
          document.location.href='/home';
        }
      }).catch((err)=>{
        alert('An Error has occured: ' + err);
        document.location.href='/home';
      });
  }

  async handleSubmit(e) {
    e.preventDefault();
    const token = await this.registerPost();
  }

  setName(name){
      this.setState({"name":name});
  }

  setPrice(price) {
      this.setState({"price": price });
  }



  render() {
    return (
      <div className="CreateVoucher">
                  <h1>New Voucher</h1><br></br>
        <Form onSubmit={this.handleSubmit}>
          <Form.Group size="lg" controlId="Name">
            <Form.Control
              type="text"
              value={this.state.name}
              onChange={(e) => this.setName(e.target.value)}
              placeholder="Voucher Name"
              required
            />
          </Form.Group>
          <Form.Group size="lg" controlId="price">
            <Form.Control
              type="text"
              value={this.state.address}
              onChange={(e) => this.setPrice(e.target.value)}
              placeholder="Price (Number of Points)"
              required
            />
          </Form.Group>
          

          <Button block size="lg" type="submit">
            Create Voucher
        </Button>
        </Form>
      </div>

    );
  }
}

export default CreateVoucher;