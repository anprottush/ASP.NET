var app = angular.module('my-app', []);
app.controller('packageAddCtrl',function($scope,$http){
  $scope.createPackage = function(){
      var data = {Name:$scope.name, AgencyId:$scope.agencyid, Country:$scope.country, Details:$scope.details, Duration:$scope.duration, Price:$scope.price};
      $http.post("https://localhost:44373/api/packages/add",data).then(function(resp){
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