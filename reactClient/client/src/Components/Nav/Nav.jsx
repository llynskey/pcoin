import React from 'react';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import JWT from 'jsonwebtoken';
import axios from 'axios';
import Logout from '../Logout/Logout';




class NavbarClass extends React.Component {



  constructor(props) {
   super(props);
    var jwt = localStorage.getItem('jwt');
    if (jwt) {
     // var token = jwt.split(' ')[1];
      var user = JWT.decode(jwt);
      this.state = {
        user: user
      }
    }
  }

  Actions() {
    if (this.state != null) {
      var user = this.state.user;
      if(user.Type === 'Vendor'){
        return(
          <div>

          </div>
        )
      }
      if(user.Type === 'Customer'){
        return(
          <div>
                        <NavDropdown.Item href="/venues">View Venues</NavDropdown.Item>
                        <NavDropdown.Item href="/vouchers">View Vouchers</NavDropdown.Item>

          </div>
        )
      }
    }
  }




loggedIn() {
  if (this.state != null) {
    return (
      <Nav.Link>Welcome {this.state.user.username}</Nav.Link>,
      <Logout />
    );
  } else {
    return (<Nav.Link href="/">Login</Nav.Link>);
  }
}




render() {
  return (
    <Navbar class="navbar-dark" fluid>
      <Navbar.Brand href="/">Pcoin</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
          <Nav.Link href="/">Home</Nav.Link>
          <Nav.Link href="/createAccount">Create Account</Nav.Link>
          <NavDropdown title='Actions'>
          {this.Actions()}
          </NavDropdown>
          {this.loggedIn()}
          
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}
}

export default NavbarClass;


