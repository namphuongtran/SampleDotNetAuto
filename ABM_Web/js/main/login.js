loginConfig = {
    version: Math.random(),
    
    regionLogin: '#regionLogin',
    regionOtp: '#regionOtp',

    serviceBase: '/api/Authenticated',
    actionLogin: '/Login',
    
    username: 'form input[name=Username]',
    password: 'form input[name=Password]'
};

login = {
    init: function () {
        $('.tip').tooltip();

        $(loginConfig.regionLogin).show();
        $(loginConfig.regionOtp).hide();        

        login.registerEvent();
    },
    
    validate: function () {
        var params = { Username: $(loginConfig.username).val(), Password: MD5($(loginConfig.password).val()) };
        $.ajax({ url: loginConfig.serviceBase + loginConfig.actionLogin, data: params, type: 'POST' }, function () { })
         .done(function (res) {
             if (res.Success)                                      
                window.location.href = res.Url;
             else                
                $.jGrowl(res.Message, { sticky: false, theme: 'growl-error', header: 'Thông báo' });
         });
    },

    registerEvent: function () {
        $(loginConfig.username).focus();

        $(loginConfig.username + ', ' + loginConfig.password).keypress(function (event) {
            if (event.which == 13) {
                login.validate();
                event.preventDefault();
            }
        });        
    }    
};