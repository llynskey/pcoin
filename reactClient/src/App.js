import './App.css';
import React from 'react';
import Login from './Pages/Login/Login';
import VendorLogin from './Pages/Login/VendorLogin/VendorLogin';
import CustomerLogin from './Pages/Login/CustomerLogin/CustomerLogin';
import Home from './Pages/Home/Home';
import CreateAccount from './Pages/CreateAccount/CreateAccount';
import LandingPage from './Pages/LandingPage/LandingPage';
import { BrowserRouter, Route, Switch} from 'react-router-dom';
import Nav from './Components/Nav/Nav';
import CreateVenue from './Pages/Profiles/VendorProfile/CreateVenue/CreateVenue';
import ViewVenue from './Pages/Profiles/VendorProfile/ViewVendor/ViewVenue'
import CreateVoucher from './Pages/Profiles/VendorProfile/CreateVoucher/CreateVoucher';

function App() {
  return (
    <div className="App">
      <Nav/>
      <BrowserRouter>
        <Switch>
            <Route exact path="/"><Login/></Route>
            <Route exact path="/home"><Home/></Route>
            <Route exact path="/vendor-login"><VendorLogin/></Route>
            <Route exact path="/customer-login"><CustomerLogin/></Route>
            <Route exact path="/createAccount"><CreateAccount/></Route>
            <Route exact path="/createVoucher"><CreateVoucher/></Route>
            <Route exact path="/createVenue"><CreateVenue/></Route>
            <Route path="/viewVenue:id"><ViewVenue/></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
