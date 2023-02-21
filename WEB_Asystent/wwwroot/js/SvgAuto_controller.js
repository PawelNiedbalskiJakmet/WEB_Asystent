


var ob=angular.module('app', []);
ob.controller('CtrlSVG', function ($scope) {
     $scope.title = 'controller2';

        SvgFunct($scope);
        //function SvgFunct(scop) {
        //    scop.bloki = [{ _x: 0, _y: 0, _width: 100, _height: 100 }];
        //    scop.Pokazane = false;
        //    scop.DataBlokuKliknietego = { _x: 0, _y: 0, _width: 0, _height: 0 };
        //    scop.FormBlok = { N: 0, Orientacja: "Poz" };
        //    var stop;
        //    $("#okno").hide();

        //    scop.hideForm = function (eventy) { // 

        //        if (scop.Pokazane == true) {
        //            $("#okno").hide();
        //            scop.Pokazane = false;

        //        } //   $scope.model.count++;
        //    };
        //    scop.myFunction = function (eventy) { // przesuwanie tooltipa nad maszyanami

        //        scop.DataBlokuKliknietego = { _x: eventy.target.x.animVal.valueInSpecifiedUnits, _y: eventy.target.y.animVal.valueInSpecifiedUnits, _width: eventy.target.width.animVal.valueInSpecifiedUnits, _height: eventy.target.height.animVal.valueInSpecifiedUnits };
        //        if (scop.Pokazane == false) {
        //            $("#okno").show();
        //            scop.Pokazane = true;

        //        }


        //        //   $scope.model.count++;
        //    };

        //    scop.Klikniety = function (eventy) { // przesuwanie tooltipa nad maszyanami

        //        var dataOut = { _x: scop.DataBlokuKliknietego._x, _y: scop.DataBlokuKliknietego._y, _width: scop.DataBlokuKliknietego._width, _height: scop.DataBlokuKliknietego._height, N: scop.FormBlok.N, Orientacja: scop.FormBlok.Orientacja };
        //        $.post("PostDodajBloki", dataOut, function (data) {
        //            scop.bloki = data.bloki;
        //            if (scop.Pokazane == true) {
        //                $("#okno").hide();
        //                scop.Pokazane = false;

        //                scop.FormBlok = { N: 0, Orientacja: "Poz" };
        //            } //   $scope.model.count++;
        //            scop.$apply();
        //        });
        //    };

        //}
}); // SVG konfig budowy



