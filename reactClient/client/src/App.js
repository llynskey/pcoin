import './App.css';
import Login from './Pages/Login/Login';
import Home from './Pages/Home/Home';
import CreateAccount from './Pages/CreateAccount/CreateAccount';
import { BrowserRouter, Route, Switch} from 'react-router-dom';
import Nav from './Component/Nav/Nav';

function App() {
  return (
    <div className="App">
      <Nav/>
      <BrowserRouter>
        <Switch>
            <Route exact path="/"><Login/></Route>
            <Route exact path="/home"><Home/></Route>
            <Route exact path="/createAccount"><CreateAccount/></Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
