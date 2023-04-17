var app = angular.module('my-app', []);
app.controller('hotelAddCtrl',function($scope,$http){
  $scope.createHotel = function(){
      var data = {Name:$scope.name, Description:$scope.description, Star:$scope.star, Price:$scope.price};
      $http.post("https://localhost:44373/api/hotels/add",data).then(function(resp){
          debugger;
      },function(err){
          debugger;
          
      })
  };
});