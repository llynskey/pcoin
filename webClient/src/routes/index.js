var express = require('express');
var router = express.Router();
//var axios = require('axios')

//axios.get('pcoin/')


/* GET home page. */
router.get('/', function(req, res, next) {
  console.log("requestLog");
  res.render('index', { title: 'P Coin' });
});

module.exports = router;

