var express = require('express');
const app = require('../app');
var router = express.Router();
var axios = require('axios');
const { response } = require('../app');
const jwt = require('jsonwebtoken');
/* GET users listing. */
router.get('/', function(req, res, next) {
    res.render('login', {title: 'Express'})
});

router.post('/', function(req, res,next){
    
    console.log("Username: " + req.body.username);
    console.log("Password: " + req.body.password);

    const username = req.body.username;
    const password = req.body.password;

   axios.post('http://auth.pcoin.life/login',{
          Username: username,
          Password: password
        }).then((response) => {
            console.log(response);
            if(response.data != null)
                jwToken = response.data;
                console.log("jwt: "+jwToken);
                
              // document.cookie = jwToken;
        }, (error) => {
            console.log(error);
      });
    res.redirect('/vendors')
    
});



module.exports = router;