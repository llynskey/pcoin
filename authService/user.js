const mongoose = require('mongoose');

mongoose.model("User",{
   // UserID,FirstName, LastName, DOB, Email, Password, points
    
   FirstName: {
       type: String,
       require: true
   },
   LastName: {
       type: String,
       require: true
   },
  /* DOB:{
       type: Date,
       require: true
   },*/
   Email:{
       type: String,
       require: true
   },
   Password:{
       type: String,
       require: true
   },
   Points:{
       type: Number,
       require: true
   }

    
});