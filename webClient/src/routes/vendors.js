var express = require('express');
const app = require('../app');
var router = express.Router();
var axios = require('axios');
const { json, static } = require('express');
var vendors = [
    vendors={
    "id": 0,
    "name": "Adam's Bakery",
    "type": "Bakery",
    "vouchers": [1212,1333]
    },
    {"id": 0,
    "name": "Jimmy's Coffee",
    "type": "Coffee House"
    }
    ]

/* GET users listing. */

router.get('/venues', function(req, res, next) {
   

       Vendors = JSON.stringify(vendors);
       
    res.render('vendors', {title: 'Pcoin Vendors', vendors: vendors})
    //axios.get('vendors.pcoin.life/getVendors');
});

router.post('/venues', function(req,res,next) {
   // vendors.push(vendorreq.body);
    console.log(req.body);
    console.log(vendors.length)
    vendor = req.body;
    vendor.id = vendors.length+1;
    console.log(vendor.id);
    vendors.push(vendor);
    console.log(vendors)
})

router.get('/addVenue', function(req,res,next) {
    res.render('vendorPage');
})

/*router.post('/addPoints', function(req, res, next){
    
    const userId = req.body.userId;
    const NOpoints = req.body.NOpoints;

    axios.post('http://api.points.pcoin.life/',{
          userID: userId,
          NOpoints: NOpoints
        }).then((response) => {
            console.log(response);
        }, (error) => {
            console.log(error);
      });
    res.end();
});*/


module.exports = router;