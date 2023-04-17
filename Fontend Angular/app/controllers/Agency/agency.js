var app = angular.module('my-app', []);
app.controller('agencyAddCtrl',function($scope,$http){
  $scope.createAgency = function(){
      var data = {Name:$scope.name, IsInternational:$scope.international, UserId:$scope.userid};
      $http.post("https://localhost:44373/api/agencies/add",data).then(function(resp){
          //localStorage.setItem("_token","ABCD");
          //localStorage.getItem("_token");
          
          //logout
          //localStorage.removeItem("_token");
          debugger;
      },function(err){
          debugger;
          
      })
  };
});