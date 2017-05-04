config = {
    version: Math.random(),
    //version: 3.0,
    
    // ServiceBase
    serviceBase: {        
        navigatorList: '/api/Menu/Navigator',
        dashboardList: '/api/Menu/Dashboard',        
        logOut: '/api/Authenticated/Logout',
    },
    
    // Html Files
    html: {
        system: '/js/template/common.html'        
    },
    
    // Id From Html File
    template: {        
        dashboardByUser: 'tpl-list-dashboard-by-user'
    }
};

common = {
    // Dashboard
    dynamicDashboard: function () {        
        $.ajax({ url: config.serviceBase.dashboardList, type: 'POST' }, function() { })
            .done(function(res) {
                if (res.Success && res.Data.length > 0) {
                    $.Mustache.load(config.html.system + '?v=' + config.version)
                        .done(function() {
                            $('.info-blocks').html('');
                            $('.info-blocks').mustache(config.template.dashboardByUser, res);
                        });
                }
            });
    },

    // Navigator
    dynamicNavigator: function () {
        $.when(
            $.ajax({ url: config.serviceBase.navigatorList, type: 'POST' }, function () { })
            .done(function (res) {                
                if (res.Success)                                     
                    $('.navigation').html(res.Data);                                    
            })
        ).then(function () {            
            $('.navigation li:first').before("<li><a href='/bang-dieu-khien'><span>Bảng điều khiển</span> <i class='icon-laptop'></i></a></li>");

            // Init Navigator
            $('.navigation').find('li.active').parents('li').addClass('active');
            $('.navigation').find('li').not('.active').has('ul').children('ul').addClass('hidden-ul');
            $('.navigation').find('li').has('ul').children('a').parent('li').addClass('has-ul');
            $('.navigation').find('li').has('ul').children('a').on('click', function (e) {
                e.preventDefault();

                if ($('body').hasClass('sidebar-narrow')) {
                    $(this).parent('li > ul li').not('.disabled').toggleClass('active').children('ul').slideToggle(250);
                    $(this).parent('li > ul li').not('.disabled').siblings().removeClass('active').children('ul').slideUp(250);
                }

                else {
                    $(this).parent('li').not('.disabled').toggleClass('active').children('ul').slideToggle(250);
                    $(this).parent('li').not('.disabled').siblings().removeClass('active').children('ul').slideUp(250);
                }
            });

            // Active Navigator
            common.activeNavigator();
        });        
    },
    
    activeNavigator: function () {
        var currentNavigator = '';
        var lstNavigator = ['bang-dieu-khien', 'he-thong', 'booking', 'hop-dong-cong-no', 'thuc-chay'];
        var splitUrl = document.URL.split('/');

        $.each(splitUrl, function (i, val) {
            if ($.inArray(val, lstNavigator) > -1)
                currentNavigator = val;
        });

        if (currentNavigator != '') {
            $.each($('.navigation li a'), function () {
                var aElement = $(this);
                var arrHref = aElement.attr('href').split('/');

                if (arrHref != null && arrHref.length > 0) {
                    $.each(arrHref, function (i, val) {
                        if (val != '' && currentNavigator == val)
                            aElement.parent().addClass('active');
                    });
                }
            });
        }
    },
    
    logOut: function() {
        $.ajax({ url: config.serviceBase.logOut, type: 'POST' }, function () { })
            .done(function(res) {
                if (res.Success)
                    window.location.href = '/';
            });
    },

    // Confirm Delete
    confirm: function (action, message) {
        var html = '';
        html += '<div class="modal-header">';
        html += '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>';
        html += '<h4 class="modal-title"><i class="icon-question"></i> Thông báo</h4>';
        html += '</div>';

        html += '<div class="modal-body with-padding">';
        html += message != undefined ? String.format('<p>{0}</p>', message) : '<p>Bạn có muốn xóa bản ghi này?</p>';
        html += '</div>';

        html += '<div class="modal-footer">';
        html += '<button class="btn btn-default" tabindex="2" data-dismiss="modal">Đóng</button>';
        html += String.format('<button onclick="{0}" tabindex="1" class="btn btn-success">Đồng ý</button>', action);
        html += '</div>';

        $(config.modal.dialog).removeClass('modal-lg').addClass('modal-sm');
        $(config.modal.content).html(html);
        $(config.modal.id).modal('show');
    },
                
    scrollToTop: function() {        
        $('body,html').animate({ scrollTop: 0 }, 800);
        return false;
    }    
};