var app = angular.module('my-app', []);
app.controller('hotellistCtrl',function($scope,$http){
    $http.get("https://localhost:44373/api/hotels").then(function(resp){
        $scope.hotels = resp.data;
    },function(err){
        console.log(err);
    });
  });

  app.controller('hotelDeleteCtrl',function($scope,$http){   
    $scope.deleteHotel = function(id){
      $http.get("https://localhost:44373/api/hotels/delete/"+id).then(function(resp){
          alert("Data Deleted");
      },function(err){
          alert(err);
      });
  }; 
});



// app.controller('agencyEditCtrl',function($scope,$http){
//     $scope.editAgency = function(id){
//         $http.get("https://localhost:44373/api/agencies/"+id).then(function(resp){

//         var data = {Name:$scope.name, IsInternational:$scope.international, UserId:$scope.userid};
//         $http.post("https://localhost:44373/api/agencies/",data).then(function(resp){
//             //localStorage.setItem("_token","ABCD");
//             //localStorage.getItem("_token");
            
//             //logout
//             //localStorage.removeItem("_token");
//             debugger;
//         },function(err){
//             debugger;
            
//         })
//     };
//   });



//             alert("Data Deleted");
//         },function(err){
//             alert(err);
//         });












       


  