function PanelKonfigBudFunct(scop, Wspolne) {

    scop.user = { id: 0 };


    scop.$watch(function () { return Wspolne.getUser(); }, function (newValue, oldValue) { // odczytanie aktualnego usera
        //    if (newValue.id !== oldValue.id) {

        scop.user.id = newValue.id-1;

    });




}
function PanelBocznyFunct(scop, Wspolne) {

    //scop.style = "transform: translate(-20px, 0px);";
    scop.lista = [];
    scop.listaDis = [];

    scop.$watch(function () { return Wspolne.getPanelBoczny(); }, function (newValue, oldValue) { // odczytanie aktualnego usera
     //   if (newValue !== oldValue) {

            for (var i = 0; i < 4; i++) {
                if (newValue == i) {
                    scop.lista[i] = "transform: translate(10px, 0px);";
                } else {
                    scop.lista[i] = " ";
                }          
            }
    });

    scop.$watch(function () { return Wspolne.getPanelListaDis(); }, function (newValue, oldValue) { // odczytanie aktualnego usera
        //   if (newValue !== oldValue) {

        for (var i = 0; i < newValue.length; i++) {
            if (newValue[i] == 1) {
                scop.listaDis[i] = " opacity:30%";
            } else {
                scop.listaDis[i] = " ";
            }
        }
    });
    //scop.$watch('user', function (newValue, oldValue) {
    //    if (newValue !== oldValue) Wspolne.setUser(newValue);
    //});

    //scop.$watch('users', function (newValue, oldValue) {
    //    if (newValue !== oldValue) Wspolne.setUsers(newValue);
    //});

  

}