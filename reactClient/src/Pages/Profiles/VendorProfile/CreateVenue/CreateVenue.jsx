import React from "react";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import JWT from 'jsonwebtoken';
import './CreateVenue.css'

class CreateVenue extends React.Component {
  constructor(props) {
    super(props);
    var jwt = JWT.decode(localStorage.getItem('jwt'));
    this.state = {
      user: jwt,
      name:"",
      address:"",
      city:""
    }

    this.registerPost = this.registerPost.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  async registerPost() {
      axios.post('http://manage-venue.pcoin.life',{
        ownerId: this.state.user.sub,
        name: this.state.name,
        address: this.state.address,
        city: this.state.city,
      }).then((res)=>{
        if(res.status === 200){
          alert('Venue Created Successfully');
          document.location.href='/vendor';
        }
      }).catch((err)=>{
        alert('An Error has occured: ' + err);
        document.location.href='/vendor';
      });
  }

  async handleSubmit(e) {
    e.preventDefault();
    const token = await this.registerPost();
  }

  setName(name){
      this.setState({"name":name});
  }

  setAddress(FirstName) {
      this.setState({"address": FirstName });
  }

  setCity(city){
      this.setState({"city":city});
  }

  render() {
    return (
      <div className="CreateVenue">
                  <h1>New Venue</h1><br></br>
        <Form onSubmit={this.handleSubmit}>
          <Form.Group size="lg" controlId="Name">
            <Form.Control
              type="text"
              value={this.state.name}
              onChange={(e) => this.setName(e.target.value)}
              placeholder="Venue Name"
              required
            />
          </Form.Group>
          <Form.Group size="lg" controlId="address">
            <Form.Control
              type="text"
              value={this.state.address}
              onChange={(e) => this.setAddress(e.target.value)}
              placeholder="Address"
              required
            />
          </Form.Group>
          <Form.Group size="lg" controlId="City">
            <Form.Control
              type="Text"
              value={this.state.city}
              onChange={(e) => this.setCity(e.target.value)}
              placeholder="City"
              required
            />
          </Form.Group>
          

          <Button block size="lg" type="submit">
            Create Venue
        </Button>
        </Form>
      </div>

    );
  }
}

export default CreateVenue;