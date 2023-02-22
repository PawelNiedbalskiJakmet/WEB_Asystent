function UserFunct(scop,Wspolne,cook) {

    var date = new Date();
    //add 20 minutes to date
    date.setTime(date.getTime() + (20 * 60 * 1000)); // czas uruchomienia cookiesa

    //if (cook.getObject('username') != null) {
    //    scop.user = cook.getObject('username')
    //    scop.users = cook.getObject('usernames')
    //} else {
    //    scop.user = Wspolne.getUser();
    //    scop.users = Wspolne.getUsers();
    //}

   // scop.user = Wspolne.getUser();
   // scop.users = Wspolne.getUsers();

  //  cook.getObject('username')

 //   cook.putObject('username', scop.user);
  //  scop.ups = cook.getObject('username')

    scop.$watch('user', function (newValue, oldValue) {
        if (newValue !== oldValue) {
            Wspolne.setUser(newValue);
            cook.putObject('username', scop.user, { 'expires': date })
        }
    });

    scop.$watch('users', function (newValue, oldValue) {
        if (newValue !== oldValue) Wspolne.setUsers(newValue);
    });

    var dataOut = {};
    $.post("Shared/Init", dataOut, function (data) {
        scop.users = data;
        if (cook.getObject('username') != null) {
            scop.user = data[cook.getObject('username').id - 1];
            cook.putObject('usernames', scop.users, { 'expires': date })
          
        } else {
            scop.user = data[0];
        }
        scop.$apply();
    });

   
}