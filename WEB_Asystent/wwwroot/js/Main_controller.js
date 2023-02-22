




var ob = angular.module('app', ['ngCookies']);

ob.factory('Wspolne', function () { // serwis ktory zawiera dane ogolnodostepne dla kontrolerow
   var  user= {
        imie: "N",
        nazwisko: "N",
                id: 0
    };
   var users= [{
        imie: "N",
        nazwisko: "N",
        id: 0
    }];
    var panel = -1;
    var listaDisable = [];
    return {
        getPanelListaDis: function () {
            return listaDisable;
        },
        setPanelListaDis: function (_lista) {
            listaDisable = _lista;

        },
        getPanelBoczny: function () {
            return panel;
        },
        setPanelBoczny: function (_id) {
            panel = _id;

        },
        getUser: function () {
            return user;
        }, 
        setUser: function (_user) {
            user = _user;

        },
        getUsers: function () {
            return users;
        },
        setUsers: function (_users) {
            users = _users;

        }
        // Other methods or objects can go here
    };
});

ob.controller('CtrlSVG', function ($scope, Wspolne, $cookies) {
     $scope.title = 'controller2';
 
        SvgFunct($scope,Wspolne);
      
});
ob.controller('CtrlSVG2', function ($scope, Wspolne, $cookies) {
    $scope.title = 'controller2';

    Svg2Funct($scope, Wspolne);

});
ob.controller('CtrlSVG3', function ($scope, Wspolne, $cookies) {
    $scope.title = 'controller2';

    Svg3Funct($scope, Wspolne);

});

ob.controller('CtrlUser', function ($scope, Wspolne, $cookies) {
    $scope.title = 'controller3';

    UserFunct($scope, Wspolne, $cookies);
    
});
ob.controller('CtrlPanelKonfigBud', function ($scope, Wspolne, $cookies) {
    $scope.title = 'controller4';

    PanelKonfigBudFunct($scope, Wspolne);

});

ob.controller('CtrlPanelBoczny', function ($scope, Wspolne) {
    $scope.title = 'controller5';

    PanelBocznyFunct($scope, Wspolne);

});

// SVG konfig budowy



