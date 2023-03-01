function SvgFunct(scop, Wspolne) {

  
    scop.user = {
        imie: Wspolne.getUser().imie, nazwisko: Wspolne.getUser().nazwisko, id: Wspolne.getUser().id, formblok: { n: 2, orientacja: "PION" }, datablokukliknietego: { x_display: 0, y_display: 0, width_display: 100, height_display: 100, bg_color: "white", id: 1 }, zakladkiselected: { nazwa: "wom", id: 1, color: "white", calosc: { glebokosc: 0, szerokosc: 0, wysokosc: 0 }, bloki: [{ x_display: 0, y_display: 0, width_display: 100, height_display: 100, bg_color: "white", id: 1 }] }, zakladki: [{ nazwa: "wom", id: 1, calosc: { glebokosc: 0, szerokosc: 0, wysokosc: 0 }, color: "#d1edff", bloki: [{ x: 0, y: 0, width: 100, height: 100, bg_color: "white", id: 1 }] }, { nazwa: "pom", id: 2, calosc: { glebokosc: 0, szerokosc: 0, wysokosc: 0 }, color: "#d1edff", bloki: [{ x_display: 0, y_display: 0, width_display: 100, height_display: 100, bg_color: "white", id: 1 }] }]  };



    scop.myInit = function (val) {
        Wspolne.setPanelBoczny(1);
        Wspolne.setPanelListaDis([0, 0, 1, 1]);


        scop.user = val;
        scop.user.formblok = { n: 2, orientacja: "PION" };
        scop.user.imie = Wspolne.getUser().imie;
        scop.user.nazwisko = Wspolne.getUser().nazwisko;
        scop.user.id = Wspolne.getUser().id;
        scop.user.zakladki[0].color = "#ffffff";

    }

    //PostUpdateWymiaryCalosci

    scop.updatedWymiary = function (eventy) { // potwierdzenie dodanie prostokatow
        //   scop.updateUser();
        //    var dataOut = { x: scop.DataBlokuKliknietego.x, y: scop.DataBlokuKliknietego.y, width: scop.DataBlokuKliknietego.width, height: scop.DataBlokuKliknietego.height, cnt: scop.FormBlok.n, orientacja: scop.FormBlok.orientacja, id: scop.DataBlokuKliknietego.id, userid: scop.user.id, zakladkaid: scop.zakladkiselected.id };
        var dataOut = scop.user;
        $.post("/konfigBudowa/PostUpdateWymiaryCalosci", dataOut, function (data) {
       
        });
    };


    scop.$watch(function () { return Wspolne.getUser(); }, function (newValue, oldValue) { // odczytanie aktualnego usera
    //    if (newValue.id !== oldValue.id) {

            scop.user.id = newValue.id;
            scop.user.imie = newValue.imie;
            scop.user.nazwisko = newValue.nazwisko;

        var dataOut = { imie: Wspolne.getUser().imie, nazwisko: Wspolne.getUser().nazwisko, id: Wspolne.getUser().id }
        if (dataOut.id > 0) {
            $.post("/konfigBudowa/PostUpdateUser", dataOut, function (data) {
                scop.user = data;
                scop.user.zakladki[0].color = "#ffffff";
                scop.user.zakladkiselected = scop.user.zakladki[0];
            //    scop.$apply();
            }); }
          


      //  }
    });

    scop.Pokazane = false;
    scop.svgConfig = { obszar: 0.9, margines: 0.05 };
    scop.calosc = { glebokosc: 100, szerokosc: 100, wysokosc: 100 };
   

    var stop;
    $("#okno").hide();
    if (scop.user.zakladki.length >= 1) { // zaznaczanie pierwszej zakladki
        scop.user.zakladki[0].color = "#ffffff"; // pierwszy zaznaczony
    }

    scop.zakladka_klikniete = function (eventy) {


        //scop.user.zakladkiselected.nazwa = this.x.nazwa;
        //scop.user.zakladkiselected.id = this.x.id;
        //scop.user.zakladkiselected.bloki = this.x.bloki;

        scop.user.zakladkiselected = this.x;
        for (var i = 0; i < scop.user.zakladki.length; i++) {
            scop.user.zakladki[i].color = "#d1edff";
        }
        this.x.color = "#ffffff";


        var dataOut = scop.user;


        $.post("/konfigBudowa/PostZmieniaZakladke", dataOut, function (data) {
            scop.user.zakladkiselected.bloki = data;

            scop.$apply();
        });

    };



    scop.hideForm = function (eventy) { // schowanie okienka

        if (scop.Pokazane == true) {

            $("#okno").hide();
            scop.Pokazane = false;

            for (var i = 0; i < scop.user.zakladkiselected.bloki.length; i++) {
                scop.user.zakladkiselected.bloki[i].bg_color = "white";
            }
        } //   $scope.model.count++;
    };


    scop.functionPion = function (eventy) { // kiedy kliknieto rectangle

        //scop.user.formblok = { n: 2, orientacja: "PION" };
        //scop.user.datablokukliknietego = { x_display: this.x.x_display, y_display: this.x.y_display, width_display: this.x.width_display, height_display: this.x.height_display, id: this.x.id, bg_color: this.x.bg_color };
        //if (scop.Pokazane == false) {
        //    this.x.bg_color = "#00cf2d";
        //    $("#okno").show();
        //    scop.Pokazane = true;

        //}


    };
    scop.functionPoz = function (eventy) { // kiedy kliknieto rectangle

        //scop.user.formblok = { n: 2, orientacja: "POZ" };
        //scop.user.datablokukliknietego = { x_display: this.x.x_display, y_display: this.x.y_display, width_display: this.x.width_display, height_display: this.x.height_display, id: this.x.id, bg_color: this.x.bg_color };
        //if (scop.Pokazane == false) {
        //    this.x.bg_color = "#00cf2d";
        //    $("#okno").show();
        //    scop.Pokazane = true;

        //}


    };

    scop.WcisniecieKlawisza = function (event) {
        if (event.keyCode == 8) {   // '13' is the key code for enter
            //   var i = this.x.id;
            //     this.x.id;
            var dataOut = { id: scop.user.id, formblok: scop.user.formblok, datablokukliknietego: { id: this.x.id }, zakladkiselected: { id: scop.user.zakladkiselected.id } };

            //  var dataOut = scop.user;
            $.post("/konfigBudowa/PostUsunGrupe", dataOut, function (data) {
                scop.user.zakladkiselected.bloki = data;
                if (scop.Pokazane == true) {
                //    $("#okno").hide();
                 //   scop.Pokazane = false;
                //    scop.user.formblok = { n: 2, orientacja: "POZ" };
                } //   $scope.model.count++;
                scop.$apply();
            });
        }
//scop.user.formblok = { n: 2, orientacja: "PION" };
        if (event.keyCode == 86) {   // vertical
            scop.user.formblok = { n: 2, orientacja: "POZ" };
            scop.user.formblok.n = 2;
            scop.user.datablokukliknietego = { x_display: this.x.x_display, y_display: this.x.y_display, width_display: this.x.width_display, height_display: this.x.height_display, bg_color: this.x.width, id: this.x.id };
            //    var dataOut = { x: scop.DataBlokuKliknietego.x, y: scop.DataBlokuKliknietego.y, width: scop.DataBlokuKliknietego.width, height: scop.DataBlokuKliknietego.height, cnt: scop.FormBlok.n, orientacja: scop.FormBlok.orientacja, id: scop.DataBlokuKliknietego.id, userid: scop.user.id, zakladkaid: scop.zakladkiselected.id };
            var dataOut = { id: scop.user.id, formblok: scop.user.formblok, datablokukliknietego: { id: scop.user.datablokukliknietego.id }, zakladkiselected: { id: scop.user.zakladkiselected.id } };

            //  var dataOut = scop.user;
            $.post("/konfigBudowa/PostDodajBloki", dataOut, function (data) {
                scop.user.zakladkiselected.bloki = data;
                // scop.user.formblok = { n: 2, orientacja: "POZ" };
                if (scop.Pokazane == true) {
                    //  $("#okno").hide();
                    // scop.Pokazane = false;
                    //  scop.user.formblok = { n: 2, orientacja: "POZ" };
                } //   $scope.model.count++;
                scop.$apply();
            });
        }
        if (event.keyCode == 72) {   // horisontal
            scop.user.formblok = { n: 2, orientacja: "PION" };
            scop.user.formblok.n = 2;
            scop.user.datablokukliknietego = { x_display: this.x.x_display, y_display: this.x.y_display, width_display: this.x.width_display, height_display: this.x.height_display, bg_color: this.x.width, id: this.x.id };
            //    var dataOut = { x: scop.DataBlokuKliknietego.x, y: scop.DataBlokuKliknietego.y, width: scop.DataBlokuKliknietego.width, height: scop.DataBlokuKliknietego.height, cnt: scop.FormBlok.n, orientacja: scop.FormBlok.orientacja, id: scop.DataBlokuKliknietego.id, userid: scop.user.id, zakladkaid: scop.zakladkiselected.id };
            var dataOut = { id: scop.user.id, formblok: scop.user.formblok, datablokukliknietego: { id: scop.user.datablokukliknietego.id }, zakladkiselected: { id: scop.user.zakladkiselected.id } };

            //  var dataOut = scop.user;
            $.post("/konfigBudowa/PostDodajBloki", dataOut, function (data) {
                scop.user.zakladkiselected.bloki = data;
                // scop.user.formblok = { n: 2, orientacja: "POZ" };
                if (scop.Pokazane == true) {
                    //  $("#okno").hide();
                    // scop.Pokazane = false;
                    //  scop.user.formblok = { n: 2, orientacja: "POZ" };
                } //   $scope.model.count++;
                scop.$apply();
            });
      
        }
        
    }
    //scop.Kasowanie = function (event) {

    //    var dataOut = { id: scop.user.id, formblok: scop.user.formblok, datablokukliknietego: { id: scop.user.datablokukliknietego.id }, zakladkiselected: { id: scop.user.zakladkiselected.id } };

    //    //  var dataOut = scop.user;
    //    //$.post("/konfigBudowa/PostUsunGrupe", dataOut, function (data) {
    //    //    scop.user.zakladkiselected.bloki = data;
    //    //    if (scop.Pokazane == true) {
    //    //        $("#okno").hide();
    //    //        scop.Pokazane = false;
    //    //        scop.user.formblok = { n: 2, orientacja: "POZ" };
    //        } //   $scope.model.count++;
    //        scop.$apply();
    //    });

    //}

    //scop.Klikniety = function (eventy) { // potwierdzenie dodanie prostokatow
    //    //   scop.updateUser();
    //    scop.user.formblok.n = 2;
    //    scop.user.datablokukliknietego = { x_display: this.x.x_display, y_display: this.x.y_display, width_display: this.x.width_display, height_display: this.x.height_display, bg_color: this.x.width, id: this.x.id };
    //    //    var dataOut = { x: scop.DataBlokuKliknietego.x, y: scop.DataBlokuKliknietego.y, width: scop.DataBlokuKliknietego.width, height: scop.DataBlokuKliknietego.height, cnt: scop.FormBlok.n, orientacja: scop.FormBlok.orientacja, id: scop.DataBlokuKliknietego.id, userid: scop.user.id, zakladkaid: scop.zakladkiselected.id };
    //    var dataOut = { id: scop.user.id, formblok: scop.user.formblok, datablokukliknietego: { id: scop.user.datablokukliknietego.id }, zakladkiselected: { id: scop.user.zakladkiselected.id } };
    
    //  //  var dataOut = scop.user;
    //    $.post("/konfigBudowa/PostDodajBloki", dataOut, function (data) {
    //        scop.user.zakladkiselected.bloki = data;
    //       // scop.user.formblok = { n: 2, orientacja: "POZ" };
    //        if (scop.Pokazane == true) {
    //          //  $("#okno").hide();
    //           // scop.Pokazane = false;
    //          //  scop.user.formblok = { n: 2, orientacja: "POZ" };
    //        } //   $scope.model.count++;
    //        scop.$apply();
    //    });
    //};

    scop.funcMouseOver = function (event) {
        if (!scop.Pokazane) {
            $(event.target).focus();
            //   this.x.oznaczone = true;
        } else {
            this.x.oznaczone = false;
        }
        
    }
    scop.funcMouseEnter = function (event) {
        if (!scop.Pokazane) {
            this.x.oznaczone = true;
         //   scop.datablokukliknietego.id = this.x;
            //   this.x.oznaczone = true;
        } else {
            this.x.oznaczone = false;
        }
    }
    scop.funcMouseLeave = function (event) {
        if (!scop.Pokazane) {
            this.x.oznaczone = false;
            //   this.x.oznaczone = true;
        } else {
            this.x.oznaczone = false;
        }
    }
}