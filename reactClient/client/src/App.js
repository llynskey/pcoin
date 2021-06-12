import './App.css';
import React from 'react';
import Login from './Pages/Login/Login';
import Home from './Pages/Home/Home';
import CreateAccount from './Pages/CreateAccount/CreateAccount';
import LandingPage from './Pages/LandingPage/LandingPage';
import { BrowserRouter, Route, Switch} from 'react-router-dom';
import Nav from './Components/Nav/Nav';

function App() {
  return (
    <div className="App">
      <Nav/>
      <BrowserRouter>
        <Switch>
            <Route exact path="/"><LandingPage/></Route>
            <Route exact path="/login"><Login/></Route>
            <Route exact path="/home"><Home/></Route>
            <Route exact path="/createAccount"><CreateAccount/></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
