var app = angular.module('my-app', []);
app.controller('packagelistCtrl',function($scope,$http){
    $http.get("https://localhost:44373/api/packages").then(function(resp){
        $scope.packages = resp.data;
    },function(err){
        console.log(err);
    });
  });

  app.controller('packageDeleteCtrl',function($scope,$http){   
    $scope.deletePackage = function(id){
      $http.get("https://localhost:44373/api/packages/delete/"+id).then(function(resp){
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












       


  