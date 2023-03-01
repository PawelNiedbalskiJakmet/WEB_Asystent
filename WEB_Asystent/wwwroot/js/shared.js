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
    if (cook.getObject('usernames', config) != null) {
        scop.users = cook.getObject('usernames', config);
        scop.user = scop.users[cook.getObject('username', config).id - 1];
      

    } else {
        scop.user = Wspolne.getUser();
        scop.users = Wspolne.getUsers();
    }
   // scop.user = Wspolne.getUser();
   // scop.users = Wspolne.getUsers();

  //  cook.getObject('username')

 //   cook.putObject('username', scop.user);
  //  scop.ups = cook.getObject('username')

    scop.$watch('user', function (newValue, oldValue) {
       if (newValue !== oldValue) {
           Wspolne.setUser(newValue);
          // if (cook.getObject('username') != null) {
           cook.remove('username', config);
           cook.putObject('username', newValue, { 'expires': date, 'path': config.path })
          // }
           
        }
    });

    scop.$watch('users', function (newValue, oldValue) {
        if (newValue !== oldValue) Wspolne.setUsers(newValue);
    });

    var dataOut = {};
    $.post("/Shared/Init", dataOut, function (data) {

        if (cook.getObject('username', config) != null) {
            scop.users = cook.getObject('usernames',config)
            scop.user = scop.users[cook.getObject('username',config).id - 1];
           // cook.putObject('usernames', scop.users, { 'expires': date })
          
        } else {
            scop.users = data;
            scop.user = data[0];
        //    cook.putObject('usernames', scop.users, { 'expires': date })
       //     if (cook.getObject('usernames') != null) {
            cook.remove('usernames', config);
            cook.putObject('usernames', scop.users, { 'expires': date, 'path': config.path })
        //    }
        }
     //   scop.$apply();
    });

   
}