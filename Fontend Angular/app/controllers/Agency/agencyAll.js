var app = angular.module('my-app', []);
app.controller('agencylistCtrl',function($scope,$http){
    $http.get("https://localhost:44373/api/agencies").then(function(resp){
        $scope.agencies = resp.data;
    },function(err){
        console.log(err);
    });
  });

  app.controller('agencyDeleteCtrl',function($scope,$http){   
    $scope.deleteAgency = function(id){
      $http.get("https://localhost:44373/api/agencies/delete/"+id).then(function(resp){
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












       


  