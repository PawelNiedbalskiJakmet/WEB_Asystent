function SvgFunct(scop) {
    scop.bloki = [{ _x: 0, _y: 0, _width: 100, _height: 100, _bg_color: "white", id: 1 }];
    scop.zakladki = [{ nazwa: "wom", id: 1, color: "#d1edff" }, { nazwa: "pom", id: 2, color: "#d1edff" }];
    scop.Pokazane = false;
    scop.DataBlokuKliknietego = { _x: 0, _y: 0, _width: 0, _height: 0 , ID:0};
    scop.FormBlok = { N: 2, Orientacja: "POZ" };
    scop.svgConfig = { obszar: 0.8, margines: 0.1 };
    scop.calosc = { glebokosc: 100, szerokosc: 100, wysokosc: 100 };
    scop.User = { imie: "Paweł", nazwisko: "Niedbalski", ID: 1 };
    var stop;
    $("#okno").hide();
    if (scop.zakladki.length >= 1) { // zaznaczanie pierwszej zakladki
        scop.zakladki[0].color = "#ffffff"; // pierwszy zaznaczony
    }
    scop.zakladka_klikniete = function (eventy) {

        var zmienna = eventy.target.x;
        for (var i = 0; i < scop.zakladki.length; i++) {
            scop.zakladki[i].color = "#d1edff";
        }
        this.x.color = "#ffffff";

    };
    scop.funcLeaveRect = function (eventy) {
/*        this.x._bg_color = "white";*/
  
    };
    scop.funcEnterRect = function (eventy) {

    /*    this.x._bg_color = "#00992185";*/

    };

    scop.hideForm = function (eventy) { // schowanie okienka

        if (scop.Pokazane == true) {

            $("#okno").hide();
            scop.Pokazane = false;

            for (var i = 0; i < scop.bloki.length; i++) {
                scop.bloki[i]._bg_color = "white";
            }
        } //   $scope.model.count++;
    };
    scop.functionPion = function (eventy) { // kiedy kliknieto rectangle

        scop.FormBlok = { N: 2, Orientacja: "PION" };
        scop.DataBlokuKliknietego = { _x: this.x._x, _y: this.x._y, _width: this.x._width, _height: this.x._height, ID: this.x.id };
        if (scop.Pokazane == false) {
            this.x._bg_color = "#00cf2d";
            $("#okno").show();
            scop.Pokazane = true;

        }


        //   $scope.model.count++;
    };
    scop.functionPoz = function (eventy) { // kiedy kliknieto rectangle

        scop.FormBlok = { N: 2, Orientacja: "POZ" };
        scop.DataBlokuKliknietego = { _x: this.x._x, _y: this.x._y, _width: this.x._width, _height: this.x._height, ID: this.x.id };
        if (scop.Pokazane == false) {
            this.x._bg_color = "#00cf2d";
            $("#okno").show();
            scop.Pokazane = true;

        }


        //   $scope.model.count++;
    };

    scop.Klikniety = function (eventy) { // potwierdzenie dodanie prostokatow

        var dataOut = { x: scop.DataBlokuKliknietego._x, y: scop.DataBlokuKliknietego._y, width: scop.DataBlokuKliknietego._width, height: scop.DataBlokuKliknietego._height, cnt: scop.FormBlok.N, orientacja: scop.FormBlok.Orientacja, ID: scop.DataBlokuKliknietego.ID, UserID: scop.User.ID };
        $.post("konfigBudowa/PostDodajBloki", dataOut, function (data) {
            scop.bloki = data;
            if (scop.Pokazane == true) {
                $("#okno").hide();
                scop.Pokazane = false;
                scop.FormBlok = { N: 0, Orientacja: "POZ" };
            } //   $scope.model.count++;
            scop.$apply();
        });
    };

}