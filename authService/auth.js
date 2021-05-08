const express = require('express');
const app = express();
const bodyParser = require("body-parser");
const port = 4545;

app.use(bodyParser.json());

//load mongoose
const mongoose = require('mongoose');

//user model
require('./user');
const User = mongoose.model('User');

//connect to mongoose
mongoose.connect("mongodb://localhost:27017/userDB", () =>{
    console.log("Database is connected");
});

app.post('/', (req,res)=>{
    console.log("connection made");
    console.log(req.body);


});

app.post('/addPoints', (req, res)=>{
    console.log(req.body.userID);
    console.log(req.body.NOpoints);
});

app.post('/register', (req, res)=>{
   // console.log(req.body);
    var newUser = {
        FirstName: req.body.FirstName,
        LastName: req.body.LastName,
      //  DOB: req.body.DOB,
        Email: req.body.Email,
        Password: req.body.Password,
        Points: 0
    }

    var user = new User(newUser);
    
    user.save().then(() =>{
        console.log("new user created");
    }).catch((err) ={
        if(err){
            throw err;
        }
    });
});

app.listen(port, () =>{
    console.log("Up and runnung on " + port);
});