/* # System Config
================================================== */
systemConfig = {
    version: Math.random(),
    //version: 3.0,

    // Common
    defaultPageIndex: 1,
    defaultPageSize: 10,
    defaultMaxPageSize: 100,

    // FAQ
    fixedFaq1: 6,
    fixedFaq2: 8,
    
    // Grid
    loading: '',
    table: '.dataTables_wrapper table',
    tableBody: '.dataTables_wrapper tbody',
    tableBodyTr: '.dataTables_wrapper tbody tr',
    pagerInfo: '.dataTables_info',
    pager: '.dataTables_paginate ul',
    
    // Control
    txtSearch: '#txtSearch',
    txtSearchCategory: '#txtSearchCategory',
    txtSearchArticle: '#txtSearchArticle',
    txtSearchProduct: '#txtSearchProduct',
    txtSearchDeveloper: '#txtSearchDeveloper',
    txtSearchUser: '#txtSearchUser',

    ddlOtp: '#ddlOtp',
    ddlMenu: '#ddlMenu',
    ddlUser: '#ddlUser',
    ddlAdvType: '#ddlAdvType',
    ddlSearchAdvType: '#ddlSearchAdvType',
    ddlCategory: '#ddlCategory',
    ddlProduct: '#ddlProduct',
    ddlReference: '#ddlReference',
    ddlFormCategory: '#ddlFormCategory',
    ddlSearchCategory: '#ddlSearchCategory',
    ddlPosition: '#ddlPosition',
    ddlPriority: '#ddlPriority',
    ddlPageSize: '#ddlPageSize',

    ddlStatus: '#ddlStatus',
    ddlGroupStatus: '#ddlGroupStatus',
    ddlArticleStatus: '#ddlArticleStatus',
    ddlProductStatus: '#ddlProductStatus',
    ddlFormArticleStatus: '#ddlFormArticleStatus',
    ddlDeveloperStatus: '#ddlDeveloperStatus',
    
    ddlMenuType: '#ddlMenuType',    

    // Action
    action: {
        create: 'create',
        save: 'save',
        del: 'delete',
        getById: 'getById',
        published: 'published',
        remove: 'remove',
        back: 'back',
        send: 'send',
        locked: 'locked',
        unLocked: 'unlocked',
        focus: 'focus',
        top: 'top',
        addUserInGroup: 'addUserInGroup',
        removeUserInGroup: 'removeUserInGroup',
        
        groupMenuPermission: 'groupMenuPermission',
        formChangePassword: 'formChangePassword',
        userInGroup: 'userInGroup',
        changePassword: 'changePassword'                
    },
    
    // User Setting
    setting: {
        otp: 2,
        menu: 3,        
        isSettingMenu: 5
    },
    
    // ServiceBase
    serviceBase: {
        groupList: '/api/Group/ListGroup',
        groupAction: '/api/Group/Action',

        userList: '/api/User/ListUser',
        userAction: '/api/User/Action',
        userListByStatus: '/api/User/ListUserByStatus',        
        userListByGroup: '/api/User/ListUserByGroupId',
        userInGroupAction: '/api/User/Action',        
        
        menuList: '/api/Menu/ListAll',
        menuListByTypeIdAndUserId: '/api/Menu/ListByTypeIdAndUserId',
        menuAction: '/api/Menu/Action',
        
        groupMenuPermissionList: '/api/GroupMenuPermission/GetListByGroupId',
        groupMenuPermissionSave: '/api/GroupMenuPermission/SavePermissionByGroupId',

        categoryList: '/api/Category/ListAll',
        categoryAction: '/api/Category/Action',

        articleList: '/api/Article/ListArticle',
        articleAction: '/api/Article/Action',        
        articleListByCategory: '/api/Article/ListByCategory',

        productList: '/api/SKU/ListSKU',
        productAction: '/api/SKU/Action',

        imageList: '/api/SKUImage/ListAll',
        imageAction: '/api/SKUImage/Action',

        fileList: '/api/SKUFile/ListAll',
        fileAction: '/api/SKUFile/Action',

        relatedList: '/api/SKURelated/ListAll',
        relatedAction: '/api/SKURelated/Action',
        
        developerAction: '/api/Developer/Action',
        developerListInMenu: '/api/Developer/ListDeveloperInMenu',

        errorList: '/api/Error/ListError',
        errorAction: '/api/Error/Action',
        errorSend: '/api/Error/Send',
        
        advList: '/api/Adv/ListAdv',
        advAction: '/api/Adv/Action',
        
        menuDeveloperList: '/api/MenuDeveloper/ListByMenuId',
        menuDeveloperAction: '/api/MenuDeveloper/Save',
                
        userSettingMenuList: '/api/UserSetting/ListByUserDefinitionId',
        userSettingAction: '/api/UserSetting/Action'                
    },
    
    // Html Files
    html: {
        group: '/js/template/system/group.html',
        user: '/js/template/system/user.html',
        menu: '/js/template/system/menu.html',
        category: '/js/template/system/category.html',
        article: '/js/template/system/article.html',
        product: '/js/template/system/sku.html',
        developer: '/js/template/system/developer.html',
        error: '/js/template/system/error.html',
        adv: '/js/template/system/adv.html'
    },
    
    // Id From Html File
    template: {
        listGroup: 'tpl-list-group',
        userInGroup: 'tpl-user-in-group',
        createGroup: 'tpl-form-group',
        getGroup: 'tpl-get-group',

        listUser: 'tpl-list-user',
        changePassword: 'tpl-change-password',
        createUser: 'tpl-form-user',
        getUser: 'tpl-get-user',

        listMenu: 'tpl-list-menu',
        listGroupMenuPermission: 'tpl-list-group-menu-permission',
        createMenu: 'tpl-form-menu',
        getMenu: 'tpl-get-menu',

        listCategory: 'tpl-list-category',
        createCategory: 'tpl-form-category',
        getCategory: 'tpl-get-category',

        listArticle: 'tpl-list-article',
        listArticleInMenu: 'tpl-list-article-in-menu',
        listArticleByCategory: 'tpl-list-article-by-category',
        createArticle: 'tpl-form-article',
        getArticle: 'tpl-get-article',

        listProduct: 'tpl-list-product',        
        getProduct: 'tpl-get-product',

        listDeveloperInMenu: 'tpl-list-developer-in-menu',
        createDeveloper: 'tpl-form-developer',
        getDeveloper: 'tpl-get-developer',
        
        listAdv: 'tpl-list-adv',
        createAdv: 'tpl-form-adv',
        getAdv: 'tpl-get-adv',
    },

    // Modal In System
    modal: {
        id: '#formModal',
        content: '#formModal .modal-content',
        form: '#formModal .modal-content form',
        dialog: '#formModal .modal-dialog'
    },
    
    // Data All System
    data: {              
        pageSize: [
            { id: 10, text: '10' },
            { id: 25, text: '25' },
            { id: 50, text: '50' },
            { id: 100, text: '100' }],
        
        advType: [
            { id: 1, text: 'Header' },
            { id: 4, text: 'Ảnh' },            
            { id: 3, text: 'Đối tác' },
            { id: 2, text: 'Footer' }
            ],
        
        statuses: [
            { id: 2, text: 'Kích hoạt' },
            { id: 1, text: 'Tạm dừng' }],

        errorStatus:  [
            { id: 1, text: 'Hoàn thành' },
            { id: 0, text: 'Chờ xử lý' }],
        
        errorPriority: [
            { id: 1, text: 'Cao' },
            { id: 2, text: 'Bình thường' },
            { id: 3, text: 'Thấp' }],
        
        articleStatus: [            
            { id: 2, text: 'Xuất bản' },
            { id: 1, text: 'Chờ xuất bản' },
            { id: 4, text: 'Nổi bật' },
            { id: 8, text: 'Đầu trang' }],
        
        positions: [
            { id: 1, text: 'ASD Division Leader' },
            { id: 2, text: 'Team Leader' },
            { id: 3, text: 'Senior Developer' },
            { id: 4, text: 'Technical Leader' },
            { id: 5, text: 'Developer' },
            { id: 6, text: 'Tester' },
            { id: 7, text: 'Khác' }],
        
        menuType: [
            { id: 0, text: 'Quản trị' },
            { id: 1, text: 'Booking' },
            { id: 2, text: 'Hợp đồng công nợ' },
            { id: 3, text: 'Thực chạy' },
            { id: 4, text: 'Báo cáo kênh' },
            { id: 10, text: 'Khác' } ],
        
        menuIcon: [
            { id: 'icon-file6', text: 'Nhập đầu vào' },
            { id: 'icon-stats2', text: 'Báo cáo' },
            { id: 'icon-archive', text: 'Danh mục' } ]
    }
};

/* # System
================================================== */
system = {
    // Common    
    activeMenu: function() {
        var currentUrl = document.URL;
        var elMenu = $('.info-buttons a');

        for (var i = 0; i < elMenu.length; i++) {
            var menuItem = $(elMenu[i]);
            if (currentUrl.indexOf(menuItem.attr('title')) > -1) {
                menuItem.css({ 'color': '#3792A8' });
                break;
            }
        }
    },

    registerUniform: function() {
        $(".styled, .multiselect-container input").uniform({ radioClass: 'choice', selectAutoWidth: false });
    },

    noData: function(colspan) {
        return String.format('<tr><td valign="top" colspan="{0}">Không có dữ liệu. Vui lòng chọn điều kiện tìm khác.</td></tr>', colspan);
    },

    staticDropDownList: function (ddlName, data, defaultValue, specialValue, width, isMultiple) {
        if (specialValue != null)
            data.unshift(specialValue);

        var options = { width: width == undefined ? "100%" : width, data: data };
        if (isMultiple) 
            options = $.extend(options, { minimumResultsForSearch: "-1" });
        
        $(ddlName).select2(options);

        if (defaultValue != null)
            $(ddlName).select2('val', defaultValue);
    },

    dynamicDropDownList: function (ddlName, defaultValue, specialValue, width, isMultiple) {        
        var options = { width: (width == null) ? "100%" : width };
        //if (isMultiple)
        //    options = $.extend(options, { minimumResultsForSearch: "-1" });

        switch (ddlName) {                            
            case systemConfig.ddlCategory:
            case systemConfig.ddlSearchCategory:
            case systemConfig.ddlFormCategory:
            case systemConfig.ddlReference:
                $.ajax({ url: systemConfig.serviceBase.categoryList, data: { keyword: '' }, type: 'POST' }, function () { })
                    .done(function (res) {
                        //debugger;
                        if (res.Success && res.Data.length > 0) {
                            var categories = $.map(res.Data, function (item) { return { id: item.CategoryID, text: item.CategoryName }; });
                            if (specialValue != null) 
                                categories.unshift(specialValue);

                            options = $.extend(options, { data: categories });
                            $(ddlName).select2(options);
                            
                            if (defaultValue != null)
                                $(ddlName).select2('val', defaultValue);
                        }
                    });
                break;
                
            case systemConfig.ddlMenu:
                $.ajax({ url: systemConfig.serviceBase.menuList, data: { keyword: '' }, type: 'POST' }, function () { })
                    .done(function (res) {                        
                        if (res.Success && res.Data.length > 0) {
                            var menus = $.map(res.Data, function (item) { return { id: item.AdminMenuId, text: item.Name }; });
                            if (specialValue != null)
                                menus.unshift(specialValue);

                            options = $.extend(options, { data: menus });
                            $(ddlName).select2(options);
                            
                            if (defaultValue != null)
                                $(ddlName).select2('val', defaultValue);
                        }
                    });
                break;
                
            case systemConfig.ddlUser:                
                $.ajax({ url: systemConfig.serviceBase.userListByStatus, type: 'POST' }, function () { })
                    .done(function (res) {                        
                        if (res.Success && res.Data.length > 0) {
                            var users = $.map(res.Data, function (item) { return { id: item.AdminUserId, text: String.format('{0} [{1}]', item.Username, item.Email) }; });                            
                            
                            $(ddlName).select2({
                                width: "100%", multiple: true, data: users, minimumInputLength: 2,
                                placeholder: '-- Chọn thành viên vào nhóm --', 
                                formatInputTooShort: function () {
                                    return "Nhập tối thiểu 2 ký tự.";
                                },
                            });

                            if (defaultValue != null)
                                $(ddlName).select2('val', defaultValue);
                        }
                    });
                break;

            case systemConfig.ddlProduct:
                var params = {
                    keyword: '',
                    categoryId: 0,
                    status: -1,
                    pageIndex: systemConfig.defaultPageIndex,
                    pageSize: systemConfig.defaultMaxPageSize
                };
                $.ajax({ url: systemConfig.serviceBase.productList, data: params, type: 'POST' }, function () { })
                    .done(function (res) {                        
                        if (res.Success && res.Data.length > 0) {
                            var products = $.map(res.Data, function (item) { return { id: item.SKUID, text: String.format('{0} - {1}', item.Code, item.Name) }; });

                            $(ddlName).select2({
                                width: "100%", multiple: true, data: products, minimumInputLength: 2,
                                placeholder: '-- Chọn sản phẩm --',
                                formatInputTooShort: function () {
                                    return "Nhập tối thiểu 2 ký tự.";
                                },
                            });

                            if (defaultValue != null)
                                $(ddlName).select2('val', defaultValue);
                        }
                    });
                break;
        }
    },
    
    spinner: function (controlName) {
        $(controlName).spinner();
    },
    
    timeSpinner: function (controlName) {
        $.widget("ui.timespinner", $.ui.spinner, {
            options: {
                // seconds
                step: 60 * 1000,
                // hours
                page: 60
            },
            _parse: function (value) {
                if (typeof value === "string") {
                    // already a timestamp
                    if (Number(value) == value) {
                        return Number(value);
                    }
                    return + Globalize.parseDate(value);
                }
                return value;
            },

            _format: function (value) {
                return Globalize.format(new Date(value), "t");
            }
        });

        Globalize.culture('de-DE');
        $(controlName).timespinner();        
    },
    
    datepicker: function(controlName) {
        $(controlName).datepicker({ showOtherMonths: true });
    },
    
    editor: function(controlEditor) {
        $(controlEditor).wysihtml5({ stylesheets: "/css/wysihtml5/wysiwyg-color.css" });
    },
    
    validate: function(type) {
        
    },       
   
    // Group
    group: {        
        init: function () {
            // DropDownList
            system.staticDropDownList(systemConfig.ddlGroupStatus, systemConfig.data.statuses, -1, { id: -1, text: '-- Trạng thái --' }, '140px', true);
            system.staticDropDownList(systemConfig.ddlPageSize, systemConfig.data.pageSize, systemConfig.defaultPageSize, null, '65px', true);
            
            // List
            system.group.list(systemConfig.defaultPageIndex);

            // Register Event
            $(systemConfig.ddlGroupStatus + ', ' + systemConfig.ddlPageSize).change(function () {
                system.group.list(systemConfig.defaultPageIndex);
            });

            $(systemConfig.txtSearch).keypress(function (event) {
                if (event.which == 13) {
                    system.group.list(systemConfig.defaultPageIndex);
                    event.preventDefault();
                }
            });
        },
        
        // List
        list: function (pageIndex) {            
            var params = { keyword: $(systemConfig.txtSearch).val(), status: $(systemConfig.ddlGroupStatus).val(), pageIndex: pageIndex, pageSize: $(systemConfig.ddlPageSize).val() };
            $.ajax({ url: systemConfig.serviceBase.groupList, data: params, type: 'POST' }, function () { })
                .done(function (res) {                    
                    if (res.Success && res.Data.length > 0) {                        
                        utils.setHiddenField('CurrentPageIndex', pageIndex);
                        $.Mustache.load(systemConfig.html.group + '?v=' + systemConfig.version)
                            .done(function () {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listGroup, res);
                                                                
                                $(systemConfig.pagerInfo).html(res.PagerInfo);
                                $(systemConfig.pager).html(res.Pager);
                                
                                $('.panel-heading span').text(res.PagerInfo);
                                $('[data-hover="dropdown"]').dropdownHover();
                                $('.tip').tooltip();                                
                            });
                    } else {
                        $(systemConfig.tableBody).html(system.noData(4));
                        $(systemConfig.pagerInfo).html('');
                        $(systemConfig.pager).html('');
                    }
                });
        },                      
        
        // Action
        manipulate: function (action, id, name) {            
            var params = { };
            if (id != null) 
                params = { AdminGroupId: id, Action: action };                        

            switch (action) {
                case systemConfig.action.create:
                    
                    $.Mustache.load(systemConfig.html.group + '?v=' + systemConfig.version)
                        .done(function () {
                            $(systemConfig.modal.content).html('');
                            $(systemConfig.modal.content).mustache(systemConfig.template.createGroup);

                            system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, 1, null, null, true);
                            system.spinner(systemConfig.modal.form + ' [name*=Priority]');

                            $(systemConfig.modal.id).modal('show');
                        });
                    break;
                    
                case systemConfig.action.getById:
                    $(systemConfig.modal.content).html('');
                    
                    $.ajax({ url: systemConfig.serviceBase.groupAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {                                
                                $(systemConfig.modal.content).mustache(systemConfig.template.getGroup, res);
                                
                                system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, res.Data.Status, null, null, true);
                                system.spinner(systemConfig.modal.form + ' [name*=Priority]');
                                
                                $(systemConfig.modal.id).modal('show');                                
                            }
                        });                    
                    break;
                
                case systemConfig.action.save:                                                            
                    params = $.extend(params, $(systemConfig.modal.form).serializeObject(), { Status: $(systemConfig.ddlStatus).val() });                    

                    $.ajax({ url: systemConfig.serviceBase.groupAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Lưu thông tin nhóm thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                $(systemConfig.modal.id).modal('hide');                                
                                system.group.list(utils.getHiddenField('CurrentPageIndex'));
                            }
                        });
                    break;

                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.groupAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                if (res.Success) {
                                    $.jGrowl('Xóa nhóm thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });                                    
                                    system.group.list(systemConfig.defaultPageIndex);
                                } else {
                                    $.jGrowl('Bạn cần xóa thông tin thành viên, chức năng trước khi xóa nhóm.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });
                                }
                            });
                    }                    
                    break;
                    
                case systemConfig.action.groupMenuPermission:                    
                    system.groupMenuPermission.list(id, name);
                    break;
                    
                case systemConfig.action.userInGroup:                    
                    system.userInGroup.list(id, name);
                    break;
            }
        }               
    },
    
    // Group Menu Permission
    groupMenuPermission: {
        regionList: '#lstGroupMenuPermission',                

        list: function (groupId, groupName) {
            
            function loadMenu() {                
                var d = $.Deferred();
                $.ajax({ url: systemConfig.serviceBase.menuList, data: { keyword: '' }, type: 'POST' }, function() { })
                    .done(function (res) {                        
                        if (res.Success && res.Data.length > 0) {
                            $.Mustache.load(systemConfig.html.menu + '?v=' + systemConfig.version).done(function() {
                                $(systemConfig.modal.content).html('');
                                $(systemConfig.modal.content).mustache(systemConfig.template.listGroupMenuPermission, res);
                                                                   
                                d.resolve();                                    
                            });
                        }
                    });
                return d.promise();                
            }

            $.when( loadMenu() ).then(function () {
                $.ajax({ url: systemConfig.serviceBase.groupMenuPermissionList, data: { AdminGroupId: groupId }, type: 'POST' }, function () { })
                    .done(function (res) {
                        if (res.Success && res.Data.length > 0) {
                            $.each(res.Data, function (i, val) {                            
                                $.each($(system.groupMenuPermission.regionList + ' table tbody tr'), function () {                                    
                                    var menuId = $(this).attr('id');
                                    var checkBox = $($(this)).find('input[type=checkbox]');
                                        
                                    if (menuId == val.AdminMenuId) {
                                        checkBox.prop('checked', true);
                                        $(checkBox.parent()).addClass('checked');
                                    }                                                                            
                                });
                            });                                                                                                            
                        }
                        
                        system.registerUniform();
                        utils.setHiddenField('GroupPermission', groupId); // Important When Save Group Permission
                        $('#groupPermission').html(String.format('Nhóm {0} <small class="display-block">Bạn hãy chọn chức năng & Nhấn Lưu lại để thiết lập quyền cho nhóm</small>', groupName));

                        $(systemConfig.modal.id).modal('show');
                    });
            });            
        },
        
        save: function () {
            var menuSelection = [];
            
            $.each($($(system.groupMenuPermission.regionList + ' table tbody tr')), function () {                
                var menuId = parseInt($(this).attr('id'));
                var isChecked = $(this).find('td:eq(0) span').hasClass('checked');
                
                if (menuId > 0 && isChecked) 
                    menuSelection.push(menuId);
            });

            if (menuSelection.length > 0) {
                console.log(menuSelection);
                $.ajax({ url: systemConfig.serviceBase.groupMenuPermissionSave, data: { AdminGroupId: utils.getHiddenField('GroupPermission'), LstId: menuSelection }, type: 'POST' }, function () { })
                    .done(function (res) {
                        var message = res.Success ? 'Phân quyền chức năng cho nhóm thành công' : 'Lỗi phân quyền chức năng cho nhóm';
                        var status = res.Success ? 'growl-success' : 'growl-error';
                        $.jGrowl(message, { sticky: false, theme: status, header: 'Thông báo' });
                        
                        $(systemConfig.modal.id).modal('hide');
                    });
            } else 
                $.jGrowl('Bạn cần chọn chức năng cho nhóm', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });            
        }
    },
    
    // User In Group
    userInGroup: {        
        list: function (groupId, groupName) {            
            $.ajax({ url: systemConfig.serviceBase.userListByGroup, data: { AdminGroupId: groupId }, type: 'POST' }, function () { })
                .done(function (res) {
                    $.Mustache.load(systemConfig.html.group + '?v=' + systemConfig.version).done(function () {
                        $(systemConfig.modal.content).html('');
                        $(systemConfig.modal.content).mustache(systemConfig.template.userInGroup, res);

                        $('#userInGroup').html(String.format('Nhóm {0} <small class="display-block">Bạn hãy chọn thành viên & Nhấn Lưu lại. Thành viên đó sẽ được thêm vào nhóm.</small>', groupName));
                        system.dynamicDropDownList(systemConfig.ddlUser, 0, { id: 0, text: '-- Chọn thành viên vào nhóm --' }, null, false);
                        
                        utils.setHiddenField('UserInGroup', groupId); // Important When Save User In Group
                        $('.tip').tooltip();
                        
                        $(systemConfig.modal.id).modal('show');                        
                    });
                });
        },
        
        manipulate: function (action, id) {            
            var params = { Action: action, AdminGroupId: utils.getHiddenField('UserInGroup') };
                
            switch (action) {
                case systemConfig.action.addUserInGroup:                    
                    var lstUserId = JSON.parse('[' + $(systemConfig.ddlUser).val() + ']');

                    if (lstUserId.length > 0) {
                        params = $.extend(params, { LstId: lstUserId });
                        
                        $.ajax({ url: systemConfig.serviceBase.userInGroupAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                var message = res.Success ? 'Phân quyền thành viên cho nhóm thành công' : 'Lỗi phân quyền thành viên cho nhóm';
                                var status = res.Success ? 'growl-success' : 'growl-error';
                                $.jGrowl(message, { sticky: false, theme: status, header: 'Thông báo' });                            
                            });
                
                        $(systemConfig.modal.id).modal('hide');
                    } else 
                        $.jGrowl('Bạn cần chọn thành viên cho nhóm', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });
                    break;
                    
                case systemConfig.action.removeUserInGroup:
                    var confirm = window.confirm('Bạn có chắc chắn muốn xóa?');
                    if (confirm) {
                        params = $.extend(params, { AdminUserId: id });

                        $.ajax({ url: systemConfig.serviceBase.userInGroupAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                var message = res.Success ? 'Xóa thành viên khỏi nhóm thành công' : 'Lỗi xóa thành viên khỏi nhóm';
                                var status = res.Success ? 'growl-success' : 'growl-error';
                                $.jGrowl(message, { sticky: false, theme: status, header: 'Thông báo' });

                                $('#' + id).remove();
                            });
                    }                    
                    break;
            }
        },
    },
    
    // User Setting 
    userSetting: {        
        selectedMenu: [],        
        isSettingMenu: false,

        init: function () {
            // List Menu By Type
            $('#btnSaveSetting').hide();
            $('#regionSetting').hide();

            // Active Tab        
            var currentTab = '';
            var lstTab = ['thong-tin-tai-khoan', 'quan-ly-cong-viec', 'thiet-lap-chuc-nang'];
            var splitUrl = document.URL.split('/');
            
            $.each(splitUrl, function(i, val) {
                if ($.inArray(val, lstTab) > -1) 
                    currentTab = val;                
            });

            if (currentTab != '') {
                $.each($('.tabbable .nav li a'), function () {
                    var hrefVal = $(this).attr('href').replace('#', '');
                    if (hrefVal == currentTab) {
                        $(this).parent().addClass('active');
                        $('#' + currentTab).addClass('in active');
                    }
                });                    
            }

            // Important
            system.userSetting.listMenuByType(systemConfig.data.setting);           
        },
        
        // List Menu By Type And UserId & Event Bootstrap Switch
        listMenuByType: function (lstType) {            
            var lstDeferred = [];
            
            for (var i = 0; i < lstType.length; i++) {                         
                var params = { TypeId: lstType[i].id };                
                var itemMenuByType = (function (i) {
                    var d = $.Deferred();
                    $.ajax({ url: systemConfig.serviceBase.menuListByTypeIdAndUserId, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success && res.Data.length > 0) {
                                $.Mustache.load(systemConfig.html.user + '?v=' + systemConfig.version).done(function () {
                                    $('#' + lstType[i].element).html('');
                                    $('#' + lstType[i].element).mustache(systemConfig.template.userSetting, res);
                                    $('#' + lstType[i].element + ' table tr').find('td:eq(0) , th:eq(0)').hide();                                    
                
                                    system.registerUniform();
                                    $("[data-toggle=popover]").popover().click(function (e) { e.preventDefault(); });
                                    $('.tip').tooltip();

                                    d.resolve(i);
                                });
                            }
                        });
                    return d.promise();
                })(i);
                lstDeferred.push(itemMenuByType);
            }

            // Get Is Setting Menu (True Or False)
            var getIsSettingMenu = $.ajax({ url: systemConfig.serviceBase.userSettingMenuList, data: { UserDefinitionId: systemConfig.setting.isSettingMenu }, type: 'POST' }, function() { })
                                    .done(function (res) {                                        
                                        if (res.Success) 
                                            system.userSetting.isSettingMenu = res.Data[0].Value;                                        
                                    });            
            lstDeferred.push(getIsSettingMenu);
            
            $.when.apply(this, lstDeferred).then(function () {                
                system.userSetting.toogleSwitch();
            });
        },                

        // Save Setting
        save: function () {            
            var count = 0;
            system.userSetting.changeIsSettingMenu(true);
            
            var selectedMenu = [];
            $.each(systemConfig.data.setting, function (i, val) {                                                
                $.each($($('#' + val.element + ' table tbody tr')), function () {
                    var menuId = parseInt($(this).attr('id'));
                    var isChecked = $(this).find('td:eq(0) span').hasClass('checked');

                    if (menuId > 0 && isChecked) {
                        selectedMenu.push(menuId);
                        count++;
                    }                    
                });                                
            });
            
            if (selectedMenu.length > 0) {
                console.log(String.format('Count: {0} | Items: {1}', count, selectedMenu));
                var params = { Action: systemConfig.action.save, UserDefinitionId: systemConfig.setting.menu, LstId: selectedMenu };

                function saveSettingMenu() {
                    var d = $.Deferred();
                    $.ajax({ url: systemConfig.serviceBase.userSettingAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success)
                                d.resolve();
                        });
                    return d.promise();
                }

                $.when(saveSettingMenu()).then(function () {
                    $.jGrowl(String.format("Lưu thiết lập chức năng thành công."), { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                    
                    common.dynamicNavigator(); // Refresh Navigator
                });
            } else
                $.jGrowl("Vui lòng chức năng cần thiết lập", { sticky: false, theme: 'growl-error', header: 'Thông báo' });
        },                
        
        // On/ Off Setting Menu
        toogleSwitch: function () {
            $('#regionSetting').fadeIn().show();

            var isChecked = system.userSetting.isSettingMenu == 'true';            
            if (isChecked) {
                system.userSetting.toogleColumnSetting(system.userSetting.isSettingMenu);
                system.userSetting.selectedSettingMenu();
            } 

            // Register & Manager Event Bootstrap Switch            
            $('.switch').bootstrapSwitch('setState', isChecked);
            $('.switch').bootstrapSwitch().on('switch-change', function (event, state) {
                var isSetting = state.value;
                system.userSetting.toogleColumnSetting(isSetting);

                // Turn On Setting Menu True
                if (isSetting) 
                    system.userSetting.selectedSettingMenu();
                else // Turn Off Setting Menu False
                {
                    $('#btnSaveSetting').hide();
                    system.userSetting.changeIsSettingMenu(false);
                    setTimeout('common.dynamicNavigator();', 5000); // Refresh Navigator
                }
            });
        },
        
        // Set Selected Setting Menu
        selectedSettingMenu: function() {
            $('#btnSaveSetting').show();

            $.when(
                $.ajax({ url: systemConfig.serviceBase.userSettingMenuList, data: { UserDefinitionId: systemConfig.setting.menu }, type: 'POST' }, function () { })
                    .done(function (res) {
                        if (res.Success && res.Data.length > 0)
                            $.each(res.Data, function (i, val) {
                                system.userSetting.selectedMenu.push(val.Value);
                            });
                    })
            ).then(function () {
                // Selected Menu
                $.each(systemConfig.data.setting, function (i, val) {
                    $.each($('#' + val.element + ' table tbody tr'), function () {
                        var menuId = $(this).attr('id');

                        if ($.inArray(menuId, system.userSetting.selectedMenu) > -1) {
                            var checkBox = $($(this)).find('input[type=checkbox]');
                            checkBox.prop('checked', true);
                        }
                    });
                });

                // Update State Checkbox
                $.uniform.update();
            });
        },
              
        // Change Value Is Setting Menu
        changeIsSettingMenu: function (isSettingMenu) {
            $.ajax({
                url: systemConfig.serviceBase.userSettingAction,
                data: { Action: systemConfig.action.save, UserDefinitionId: systemConfig.setting.isSettingMenu, Value: isSettingMenu },
                type: 'POST'
            });
            console.log("IsSettingMenu: " + isSettingMenu);
        },

        // Manipulate Checkbox On Grid
        toogleCheckbox: function (obj) {            
            var classId = $(obj).parents('tr:first').attr('id');
            var isChecked = $(obj).parent().hasClass('checked');

            if (classId == undefined) {
                // All Checkbox
                var element = $(obj).parents('table:first').parent().attr('id');
                if (element != undefined) 
                    $.each($($('#' + element + ' table tbody tr')), function () {
                        $(this).find('td:eq(0) input[type=checkbox]').prop('checked', !isChecked);
                    });    
            } else // Single Or Multiple Checkbox                
                $('.m' + classId).prop('checked', !isChecked);            
            
            $.uniform.update();
        },

        // Show/ Hide Column Checkbox
        toogleColumnSetting: function(isChecked) {
            $.each(systemConfig.data.setting, function (i, val) {
                if (isChecked) 
                    $('#' + val.element + ' table tr').find('td:eq(0), th:eq(0)').show();                    
                else
                    $('#' + val.element + ' table tr').find('td:eq(0), th:eq(0)').hide();
            });
        }                       
    },
   
    // Menu
    menu: {        
        regionForm: '#regionMenuForm',
        regionList: '#regionMenuList',
        formMenu: '#regionMenuForm form',
        developerInMenu: '#developerInMenu',
        
        articleSelection: 0,

        init: function () {
            $(system.menu.regionForm).hide();
            
            // List
            system.menu.list();
            
            // Register Event
            $(systemConfig.txtSearch).keypress(function (event) {
                if (event.which == 13) {
                    system.menu.list();
                    event.preventDefault();
                }
            });                        
        },
        
        // List
        list: function () {
            var params = { keyword: $(systemConfig.txtSearch).val() };
            $.ajax({ url: systemConfig.serviceBase.menuList, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    if (res.Success && res.Data.length > 0) {
                        $.Mustache.load(systemConfig.html.menu + '?v=' + systemConfig.version)
                            .done(function () {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listMenu, res);

                                $('.panel-heading span').text(res.PagerInfo);
                                $('[data-hover="dropdown"]').dropdownHover();
                                $('.tip').tooltip();
                            });
                    }
                });
        },
        
        // Action
        manipulate: function (action, id) {
            var params = {};
            if (id != null)
                params = { AdminMenuId: id, Action: action };
                        
            switch (action) {
                case systemConfig.action.create:
                    $(system.menu.regionForm).show();
                    $(system.menu.regionList).hide();

                    $(system.menu.regionForm).html('');
                    $(system.menu.regionForm).mustache(systemConfig.template.createMenu);
                    
                    // Init                    
                    system.dynamicDropDownList(systemConfig.ddlMenu, 0, { id: 0, text: '-- Gốc --' }, null, true);                    
                    system.dynamicDropDownList(systemConfig.ddlCategory, 0, { id: 0, text: '-- Chuyên mục --' }, null, true);
                                        
                    system.staticDropDownList(systemConfig.ddlMenuType, systemConfig.data.menuType, -1, { id: -1, text: '-- Chọn --'}, null, true);                    
                    system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, 1, null, null, true);
                    
                    system.spinner(system.menu.regionForm + ' input[name=Priority]');

                    // Article & Developer
                    system.menu.articleAndDeveloper(0, 0);
                    break;
                
                case systemConfig.action.getById:
                    $.ajax({ url: systemConfig.serviceBase.menuAction, data: params, type: 'POST' }, function() { })
                        .done(function (res) {                            
                            if (res.Success) {
                                $(system.menu.regionForm).show();
                                $(system.menu.regionList).hide();
                                $(system.menu.regionForm).html('');

                                $(system.menu.regionForm).mustache(systemConfig.template.getMenu, res);

                                system.dynamicDropDownList(systemConfig.ddlMenu, res.Data.ParentId, { id: 0, text: '-- Gốc --' }, null, true);
                                system.dynamicDropDownList(systemConfig.ddlCategory, 0, { id: 0, text: '-- Chuyên mục --' }, null, true);
                                
                                system.staticDropDownList(systemConfig.ddlMenuType, systemConfig.data.menuType, res.Data.TypeId, null, null, true);                                
                                system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, res.Data.Status, null, null, true);
                                
                                system.spinner(system.menu.regionForm + ' input[name=Priority]');
                                
                                // Guide                                
                                var guideId = parseInt(res.Data.GuideLink);
                                system.menu.articleSelection = guideId > 0 ? guideId : 0;
                                
                                // Is Default Menu?
                                if (res.Data.IsDefault == 1) {
                                    $(system.menu.regionForm + ' input[name=FormatIsDefault]').attr('checked', 'checked');
                                    $(system.menu.regionForm + ' input[name=FormatIsDefault]').parent().addClass('class', 'checked');
                                }                                

                                // Article & Developer
                                system.menu.articleAndDeveloper(guideId, params.AdminMenuId);
                            }
                        });                   
                    break;

                case systemConfig.action.save:                    
                    var developerSelection = [];
                    var developerNameSelection = [];
                    
                    // Get Selected Article
                    var selectedGuide = $(system.menu.regionForm + " input[type='radio']:checked");
                    var articleId     = selectedGuide.length > 0 ? selectedGuide.val() : system.menu.articleSelection;
                    
                    // Get Selected Developer
                    $.each($(system.menu.developerInMenu + ' input[type=checkbox]'), function () {
                        if ($(this).prop('checked')) {
                            var elDeveloper = $(this).parents("li:first").clone();
                            elDeveloper.find('.checker').remove();
                            elDeveloper.find('.chat-actions').remove();
                            
                            developerSelection.push($(this).val());
                            developerNameSelection.push(elDeveloper.html());
                        }                        
                    });
                    
                    params = $.extend(params, $(system.menu.formMenu).serializeObject(),
                                {
                                    ParentId: $(systemConfig.ddlMenu).val(), Status: $(systemConfig.ddlStatus).val(), TypeId: $(systemConfig.ddlMenuType).val(),
                                    GuideLink: articleId, LstId: developerSelection, LstName: developerNameSelection                                    
                                });
                    
                    $.ajax({ url: systemConfig.serviceBase.menuAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {                                
                                $.jGrowl('Lưu thông tin chức năng thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                
                                system.menu.backList();                                                                
                            }
                        });
                    break;

                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.menuAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                if (res.Success) {
                                    $.jGrowl('Xóa chức năng thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.menu.list();
                                } 
                            });
                    }
                    break;
                    
                case systemConfig.action.back:
                    system.menu.backList();
                    break;                    
            }
        },        
        
        articleAndDeveloper: function (articleId, menuId) {
            // Article
            system.article.articleInMenu(systemConfig.defaultPageIndex);                        

            $(systemConfig.ddlCategory).change(function () {
                system.article.articleInMenu(systemConfig.defaultPageIndex);
            });

            $(systemConfig.txtSearchArticle).keypress(function (event) {
                if (event.which == 13) {
                    system.article.articleInMenu(systemConfig.defaultPageIndex);
                    event.preventDefault();
                }
            });                        

            // Developer
            system.developer.developerInMenu('', menuId);

            $(systemConfig.txtSearchDeveloper).keypress(function (event) {
                if (event.which == 13) {
                    system.developer.developerInMenu($(this).val());
                    event.preventDefault();
                }
            });
            
            // Guide            
            if (articleId > 0) {                
                var params = { Action: systemConfig.action.getById, ArticleId: articleId };
                $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                .done(function (res) {                    
                    if (res.Success) {
                        var html = '<div class="callout callout-success fade in">';
                        html += '<button class="close" type="button"><i class="icon-radio-checked"></i></button>';
                        html += String.format('<h5>{0}</h5>', res.Data.Title);
                        html += String.format('<p>{0}</p>', res.Data.Sapo);
                        html += '</div>';

                        $('#regionSearchArticleInMenu').prepend(html);
                    }
                });
            }
        },
        
        backList: function() {
            $(system.menu.regionForm).hide();
            $(system.menu.regionList).show();

            $(system.menu.regionForm).html('');

            // List
            system.menu.list();
            
            // Scroll To Top
            common.scrollToTop();
        }
    },
    
    // User
    user: {
        currentSelection: [],

        init: function () {
            // DropDownList
            system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, -1, { id: -1, text: '-- Trạng thái --' }, '140px', true);
            system.staticDropDownList(systemConfig.ddlPageSize, systemConfig.data.pageSize, systemConfig.defaultPageSize, null, '65px', true);
            
            // List
            system.user.list(systemConfig.defaultPageIndex);
            
            // Register Event           
            $(systemConfig.txtSearch).keypress(function (event) {
                if (event.which == 13) {
                    system.user.list(systemConfig.defaultPageIndex);
                    event.preventDefault();
                }
            });
            
            $(systemConfig.ddlStatus + ', ' + systemConfig.ddlPageSize).change(function () {
                system.user.list(systemConfig.defaultPageIndex);
            });
            
            $(systemConfig.table).delegate('tr td', 'click', function () {
                if (!$(this).hasClass('command')) {
                    var row = $(this).parent();
                    var id = parseInt(row.attr('id'));
                    if (id > 0) {
                        var idx = system.user.currentSelection.indexOf(id);
                        if (idx > -1) {
                            system.user.currentSelection.splice(idx, 1);
                            row.removeClass('success');
                        } else {
                            system.user.currentSelection.push(id);
                            row.addClass('success');
                        }
                    }
                }
            });
        },
        
        // List
        list: function (pageIndex) {            
            var params = {
                keyword: $(systemConfig.txtSearch).val(),
                status: $(systemConfig.ddlStatus).val(),
                pageIndex: pageIndex,
                pageSize: $(systemConfig.ddlPageSize).val()
            };
            $.ajax({ url: systemConfig.serviceBase.userList, data: params, type: 'POST' }, function () { })
                .done(function (res) {                    
                    if (res.Success && res.Data.length > 0) {
                        utils.setHiddenField('CurrentPageIndex', pageIndex);
                        
                        $.Mustache.load(systemConfig.html.user + '?v=' + systemConfig.version)
                            .done(function () {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listUser, res);

                                $(systemConfig.pager).html(res.Pager);
                                $(systemConfig.pagerInfo).text(res.PagerInfo);
                                
                                $('.panel-heading span').text(res.PagerInfo);
                                $('[data-hover="dropdown"]').dropdownHover();
                                $('.tip').tooltip();
                            });
                    }
                });
        },
        
        // Action
        manipulate: function (action, id) {            
            var params = {};
            if (id != null)
                params = { AdminUserId: id, Action: action };
            
            switch (action) {
                case systemConfig.action.create:
                    $.Mustache.load(systemConfig.html.user + '?v=' + systemConfig.version)
                        .done(function () {
                            $(systemConfig.modal.content).html('');
                            $(systemConfig.modal.content).mustache(systemConfig.template.createUser);                                                        
                            
                            $(systemConfig.modal.id).modal('show');
                        });
                    break;
                    
                case systemConfig.action.getById:
                    $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $(systemConfig.modal.content).html('');
                                $(systemConfig.modal.content).mustache(systemConfig.template.getUser, res);
                                
                                $(systemConfig.modal.id).modal('show');
                            }
                        });
                    break;                    
                    
                case systemConfig.action.save:                    
                    params = $.extend(params, $(systemConfig.modal.form).serializeObject());

                    $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Lưu thông tin thành viên thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.user.list(utils.getHiddenField('CurrentPageIndex'));
                                
                                $(systemConfig.modal.id).modal('hide');
                            } else {
                                $.jGrowl('Tên đăng nhập đã có trên hệ thống!', { sticky: false, theme: 'growl-error', header: 'Thông báo' });
                            }
                        });
                    break;
                    
                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function() {
                        })
                            .done(function(res) {
                                if (res.Success) {
                                    $.jGrowl('Xóa thành viên thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.user.list(utils.getHiddenField('CurrentPageIndex'));
                                }
                            });
                    }
                    break;
                    
                case systemConfig.action.formChangePassword:
                    params = { AdminUserId: id, Action: systemConfig.action.getById };
                    $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.Mustache.load(systemConfig.html.user + '?v=' + systemConfig.version)
                                    .done(function () {
                                        $(systemConfig.modal.content).html('');
                                        $(systemConfig.modal.content).mustache(systemConfig.template.changePassword, res);

                                        $(systemConfig.modal.id).modal('show');
                                });
                            }
                        });
                    break;
                    
                case systemConfig.action.changePassword:
                    params = $.extend(params, $(systemConfig.modal.form).serializeObject());
                    $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {                                                                
                                $.jGrowl('Đổi mật khẩu thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                $(systemConfig.modal.id).modal('hide');
                            } else 
                                $.jGrowl('Mật khẩu mới và Nhập lại mật khẩu mới chưa khớp nhau.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });                            
                        });
                    break;
                    
                case systemConfig.action.locked:
                    params = $.extend(params, { Action: systemConfig.action.locked, LstId: system.user.currentSelection });
                    if (system.user.currentSelection.length > 0) {
                        $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Khóa thành viên thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.user.list(utils.getHiddenField('CurrentPageIndex'));
                            }
                            system.user.currentSelection.splice(0, system.user.currentSelection.length);
                        });
                    } else 
                        $.jGrowl('Bạn cần chọn thành viên.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });                    
                    
                    break;
                    
                case systemConfig.action.unLocked:
                    params = $.extend(params, { Action: systemConfig.action.unLocked, LstId: system.user.currentSelection });
                    if (system.user.currentSelection.length > 0) {
                    $.ajax({ url: systemConfig.serviceBase.userAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Kích hoạt thành viên thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.user.list(utils.getHiddenField('CurrentPageIndex'));
                            }
                            system.user.currentSelection.splice(0, system.user.currentSelection.length);                            
                        });
                    } else 
                        $.jGrowl('Bạn cần chọn thành viên.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });                    
                    break;
            }
        }            
    },    

    // Category
    category: {
        init: function () {
            // List
            system.category.list();
            
            // Register Event
            $(systemConfig.txtSearchCategory).keypress(function (event) {
                if (event.which == 13) {
                    system.category.list();
                    event.preventDefault();
                }
            });
        },
        
        // List
        list: function () {
            var params = { keyword: $(systemConfig.txtSearchCategory).val() };
            $.ajax({ url: systemConfig.serviceBase.categoryList, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    if (res.Success && res.Data.length > 0) {
                        $.Mustache.load(systemConfig.html.category + '?v=' + systemConfig.version)
                            .done(function () {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listCategory, res);
                                
                                $('.panel-heading span').text(res.PagerInfo);
                                $('[data-hover="dropdown"]').dropdownHover();
                                $('.tip').tooltip();
                            });
                    }
                });
        },       

        // Action
        manipulate: function (action, id) {
            $(systemConfig.modal.dialog).addClass('modal-lg');
            var params = {};
            if (id != null)
                params = { CategoryId: id, Action: action };

            switch (action) {
                case systemConfig.action.create:
                    $.Mustache.load(systemConfig.html.category + '?v=' + systemConfig.version)
                        .done(function () {
                        $(systemConfig.modal.content).html('');
                        $(systemConfig.modal.content).mustache(systemConfig.template.createCategory);
                    
                        system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, 2, null, null, true);
                        system.dynamicDropDownList(systemConfig.ddlCategory, 0, { id: 0, text: '-- Gốc --' }, null, true);
                        system.dynamicDropDownList(systemConfig.ddlReference, 0, { id: 0, text: '-- Gốc --' }, null, true);
                        system.spinner(systemConfig.modal.form + ' [name*=DisplayOrder]');                        
                        CKEDITOR.replace('Description', { height: '200px' });

                        $(systemConfig.modal.id).modal('show');
                    });                    
                    break;

                case systemConfig.action.getById:                    
                    $(systemConfig.modal.content).html('');

                    $.ajax({ url: systemConfig.serviceBase.categoryAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {
                                $(systemConfig.modal.content).mustache(systemConfig.template.getCategory, res);
                                
                                var status = res.Data.isDeleted == true ? 2 : 1; // 2 - Active| 1 - Not Active
                                system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, status, null, null, true);
                                system.dynamicDropDownList(systemConfig.ddlCategory, res.Data.ParentID, { id: 0, text: '-- Gốc --' }, null, true);
                                system.dynamicDropDownList(systemConfig.ddlReference, res.Data.ReferenceID, { id: 0, text: '-- Gốc --' }, null, true);

                                system.spinner(systemConfig.modal.form + ' [name*=DisplayOrder]');                                
                                CKEDITOR.replace('Description', { height: '200px' });
                                CKEDITOR.instances['Description'].setData(res.Data.Description);
                                
                                $(systemConfig.modal.id).modal('show');
                            }
                        });
                    break;

                case systemConfig.action.save:
                    var status = $(systemConfig.ddlStatus).val() == 1 ? false : true; // 2 - Active| 1 - Not Active 
                    params = $.extend(params, $(systemConfig.modal.form).serializeObject(),
                                        {
                                            ParentID: $(systemConfig.ddlCategory).val(), ReferenceID: $(systemConfig.ddlReference).val(),
                                            isDeleted: status, Description: CKEDITOR.instances['Description'].getData()
                                        });
                    
                    $.ajax({ url: systemConfig.serviceBase.categoryAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Lưu chuyên mục thành công', { sticky: false, theme: 'growl-success', header: 'Thông báo' });                                
                                $(systemConfig.modal.id).modal('hide');
                                
                                system.category.list();
                            }
                        });
                    break;

                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.categoryAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                if (res.Success) {
                                    $.jGrowl('Xóa chuyên mục thành công', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.category.list();
                                } else 
                                    $.jGrowl('Bạn cần xóa bài viết liên quan trước khi xóa chuyên mục', { sticky: false, theme: 'growl-success', header: 'Thông báo' });                                
                            });
                    }
                    break;
            }
        },

        openFileManager: function () {
            var finder = new CKFinder();
            finder.selectActionFunction = system.category.setPathToControl;
            finder.popup();
        },

        setPathToControl: function (fileUrl) {
            $('#formCategory [name=ImagePath]').val(fileUrl);
        }
    },        
    
    // Article
    article: {
        currentSelection: [],
        statusPublished: 1,
        countArticleInMenu: 6,
        focus: 4,

        regionArticleInMenu: '#articleInMenu .block',
            
        init: function () {
            // DropDownList
            system.dynamicDropDownList(systemConfig.ddlSearchCategory, -1, { id: -1, text: '-- Chuyên mục --' }, '220px', true);
            
            system.staticDropDownList(systemConfig.ddlPageSize, systemConfig.data.pageSize, systemConfig.defaultPageSize, null, '65px', true);
            system.staticDropDownList(systemConfig.ddlArticleStatus, systemConfig.data.articleStatus, -1, { id: -1, text: '-- Trạng thái --' }, '135px', true);
            
            // List Article
            system.article.list(systemConfig.defaultPageIndex);
            
            // Register Event
            $(systemConfig.ddlPageSize + ', ' + systemConfig.ddlSearchCategory + ', ' + systemConfig.ddlArticleStatus).change(function () {
                system.article.list(systemConfig.defaultPageIndex);
            });
            
            $(systemConfig.txtSearchArticle).keypress(function (event) {
                if (event.which == 13) {                    
                    system.article.list(systemConfig.defaultPageIndex);
                    event.preventDefault();
                }
            });
                        
            $(systemConfig.table).delegate('tr td', 'click', function () {
                if (!$(this).hasClass('command')) {                    
                    var row = $(this).parent();
                    var id = row.attr('id');
                    if (id > 0) {
                        var idx = system.article.currentSelection.indexOf(id);
                        if (idx > -1) {
                            system.article.currentSelection.splice(idx, 1);
                            row.removeClass('success');
                        } else {
                            system.article.currentSelection.push(id);
                            row.addClass('success');
                        }
                    }                    
                }                                 
            });
        },        
        
        // List
        list: function(pageIndex) {
            var params = {
                keyword: $(systemConfig.txtSearchArticle).val(),
                categoryId: $(systemConfig.ddlSearchCategory).val(),
                status: $(systemConfig.ddlArticleStatus).val(),
                pageIndex: pageIndex,
                pageSize: $(systemConfig.ddlPageSize).val()
            };
            
            $.ajax({ url: systemConfig.serviceBase.articleList, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    if (res.Success || res.Data == null) {
                        utils.setHiddenField('CurrentPageIndex', pageIndex);
                        $.Mustache.load(systemConfig.html.article + '?v=' + systemConfig.version)
                            .done(function() {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listArticle, res);
                                    
                                $(systemConfig.pagerInfo).html(res.PagerInfo);
                                $(systemConfig.pager).html(res.Pager);                                
                                $('[data-hover="dropdown"]').dropdownHover();
                                $('.panel-heading span').text(res.PagerInfo);
                                $('.tip').tooltip();

                                /*$.each($(systemConfig.tableBodyTr), function () {
                                    var isFocus = $(this).attr('isFocus');
                                    if (isFocus == system.article.focus) {
                                        $(this).addClass('danger');
                                    }
                                });*/
                            });
                    } else {
                        $(systemConfig.tableBody).html(system.noData(7));
                        $(systemConfig.pagerInfo).html('');
                        $(systemConfig.pager).html('');
                    }                                            
                });
        },
        
        // List Article In Menu
        articleInMenu: function(pageIndex) {
            var params = {                
                keyword: $(systemConfig.txtSearchArticle).val(),
                categoryId: $(systemConfig.ddlCategory).val(),
                pageIndex: pageIndex,
                pageSize: system.article.countArticleInMenu,
                status: system.article.statusPublished,
                action: 'ArticleInMenu'
            };

            $.ajax({ url: systemConfig.serviceBase.articleList, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    if (res.Success && res.Data.length > 0) {                        
                        $.Mustache.load(systemConfig.html.article + '?v=' + systemConfig.version)
                            .done(function () {
                                $(system.article.regionArticleInMenu).html('');
                                $(system.article.regionArticleInMenu).mustache(systemConfig.template.listArticleInMenu, res);
                                system.registerUniform();
                                $('.choice').css({ 'margin-top': '3px' });
                            });
                    } else 
                        $(system.article.regionArticleInMenu).html('Không có bài viết khớp với điều kiện bạn tìm kiếm.');
                });                        
        },
        
        // FAQ
        faq: function (el, categoryId, level) {
            var params = { CategoryId: categoryId, Level: level };
            $.ajax({ url: systemConfig.serviceBase.articleListByCategory, data: params, type: 'POST' }, function () { })
                    .done(function (res) {                        
                        if (res.Success && res.Data.length > 0) {
                            $.Mustache.load(systemConfig.html.article + '?v=' + systemConfig.version)
                               .done(function () {
                                   $(el).html('');
                                   $(el).mustache(systemConfig.template.listArticleByCategory, res);
                               });
                        }
                    });
        },
        
        // Action
        manipulate: function (action, id) {
            $(systemConfig.modal.dialog).addClass('modal-lg');
            var params = {};
            if (id != null)
                params = { ArticleId: id, Action: action };

            switch (action) {
                case systemConfig.action.getById:                    
                    $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {

                            if (res.Success) {
                                $.Mustache.load(systemConfig.html.article + '?v=' + systemConfig.version)
                                    .done(function () {
                                        $('#formArticle .panel-body').mustache(systemConfig.template.getArticle, res);

                                        system.dynamicDropDownList(systemConfig.ddlFormCategory, res.Data.CategoryId, { id: 0, text: '-- Chuyên mục --' }, null, true);
                                        system.staticDropDownList(systemConfig.ddlFormArticleStatus, systemConfig.data.articleStatus, res.Data.Status, null, null, true);

                                        system.datepicker('#formArticle .panel-body [name=PublishedDate]');
                                        system.timeSpinner('#formArticle .panel-body [name=PublishedTime]');

                                        CKEDITOR.replace('Body');
                                        CKEDITOR.instances['Body'].setData(res.Data.Body);
                                    });
                            }
                        });
                    break;

                case systemConfig.action.save:
                    params = $.extend(params, $('#formArticle').serializeObject(),
                                {
                                    CategoryId: $(systemConfig.ddlFormCategory).val(),
                                    Status: $(systemConfig.ddlFormArticleStatus).val(),
                                    Body: CKEDITOR.instances['Body'].getData()
                                });                    
                    $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Lưu bài viết thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                setTimeout("window.location.href = '/he-thong/bai-viet';", 4000);
                            }
                        });
                    break;

                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                if (res.Success) {
                                    $.jGrowl('Xóa bài viết thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.article.list(utils.getHiddenField('CurrentPageIndex'));
                                } 
                            });
                    }
                    break;
                    
                case systemConfig.action.published:
                    params = $.extend(params, { LstId: system.article.currentSelection });                    
                    $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Xuất bản bài viết thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.article.list(utils.getHiddenField('CurrentPageIndex'));
                            }                                
                            else 
                                $.jGrowl('Bạn cần chọn bài viết.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });
                            
                            system.article.currentSelection.splice(0, system.article.currentSelection.length);
                        });
                    break;
                    
                case systemConfig.action.remove:
                    params = $.extend(params, { LstId: system.article.currentSelection });
                    $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Gỡ bài viết thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.article.list(utils.getHiddenField('CurrentPageIndex'));
                            }                                
                            else 
                                $.jGrowl('Bạn cần chọn bài viết.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });

                            system.article.currentSelection.splice(0, system.article.currentSelection.length);                            
                        });
                    break;
                    
                case systemConfig.action.focus:
                    params = $.extend(params, { LstId: system.article.currentSelection });
                    $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Đặt bài viết nổi bật thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.article.list(utils.getHiddenField('CurrentPageIndex'));
                            }
                            else
                                $.jGrowl('Bạn cần chọn bài viết.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });

                            system.article.currentSelection.splice(0, system.article.currentSelection.length);
                        });
                    break;
                    
                case systemConfig.action.top:
                    params = $.extend(params, { LstId: system.article.currentSelection });
                    $.ajax({ url: systemConfig.serviceBase.articleAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Thiết lập bài viết đầu trang(trái) thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.article.list(utils.getHiddenField('CurrentPageIndex'));
                            }
                            else
                                $.jGrowl('Bạn cần chọn bài viết.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });

                            system.article.currentSelection.splice(0, system.article.currentSelection.length);
                        });
                    break;
            }
        },
        
        openFileManager: function () {
            var finder = new CKFinder();
            finder.selectActionFunction = system.article.setPathToControl;
            finder.popup();
        },

        setPathToControl: function (fileUrl) {
            $('#formArticle [name=ImgAvatar]').val(fileUrl);
        }
    },

    product: {
        init: function() {
            // DropDownList            
            system.staticDropDownList(systemConfig.ddlPageSize, systemConfig.data.pageSize, systemConfig.defaultPageSize, null, '65px', true);
            system.staticDropDownList(systemConfig.ddlProductStatus, systemConfig.data.statuses, -1, { id: -1, text: '-- Trạng thái --' }, '135px', true);

            system.dynamicDropDownList(systemConfig.ddlSearchCategory, -1, { id: -1, text: '-- Chuyên mục --' }, '220px', true);

            // List Product            
            system.product.list(systemConfig.defaultPageIndex);

            // Register Event
            $(systemConfig.ddlPageSize + ', ' + systemConfig.ddlSearchCategory + ', ' + systemConfig.ddlProductStatus).change(function () {
                system.product.list(systemConfig.defaultPageIndex);
            });

            $(systemConfig.txtSearchProduct).keypress(function (event) {
                if (event.which == 13) {
                    system.product.list(systemConfig.defaultPageIndex);
                    event.preventDefault();
                }
            });
        },

        list: function(pageIndex) {
            var params = {
                keyword: $(systemConfig.txtSearchProduct).val(),
                categoryId: $(systemConfig.ddlSearchCategory).val(),
                status: $(systemConfig.ddlProductStatus).val(),
                pageIndex: pageIndex,
                pageSize: $(systemConfig.ddlPageSize).val()
            };
            
            $.ajax({ url: systemConfig.serviceBase.productList, data: params, type: 'POST' }, function () { })
                .done(function (res) {                    
                    if (res.Success && res.Data.length > 0) {
                        utils.setHiddenField('CurrentPageIndex', pageIndex);
                        $.Mustache.load(systemConfig.html.product + '?v=' + systemConfig.version)
                            .done(function() {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listProduct, res);

                                $(systemConfig.pagerInfo).html(res.PagerInfo);
                                $(systemConfig.pager).html(res.Pager);
                                $('[data-hover="dropdown"]').dropdownHover();
                                $('.tip').tooltip();
                            });
                    } else {
                        $(systemConfig.tableBody).html(system.noData(9));
                        $(systemConfig.pagerInfo).html('');
                        $(systemConfig.pager).html('');
                    }
                });
        },

        // Action
        manipulate: function (action, id) {            
            var params = {};
            if (id != null)
                params = { SKUID: id, Action: action };
            
            switch (action) {
                case systemConfig.action.save:
                    var status = $(systemConfig.ddlStatus).val() == 1 ? false : true; // 2 - Active| 1 - Not Active 
                    var isHotProduct = $('#formProduct input[type=checkbox]').parent().hasClass("checked");

                    params = $.extend(params, $('#formProduct').serializeObject(),
                                {
                                    CategoryID: $(systemConfig.ddlCategory).val(),                                    
                                    Description: CKEDITOR.instances['Description'].getData(),
                                    isDeleted: status,
                                    IsHotProduct: isHotProduct                                    
                                });

                    $.ajax({ url: systemConfig.serviceBase.productAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {
                                $.jGrowl('Lưu sản phẩm thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                var identitySKUId = parseInt(res.Data);
                                if (identitySKUId > 0)
                                    utils.setHiddenField('SKUId', identitySKUId);
                            }
                        });
                    break;
                    
                case systemConfig.action.getById:                    
                    $.ajax({ url: systemConfig.serviceBase.productAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.Mustache.load(systemConfig.html.product + '?v=' + systemConfig.version)
                                    .done(function () {
                                        $('#formProduct #editProduct').mustache(systemConfig.template.getProduct, res);

                                        var status = res.Data.isDeleted == true ? 2 : 1; // 2 - Active| 1 - Not Active
                                        
                                        system.dynamicDropDownList(systemConfig.ddlCategory, res.Data.CategoryID, { id: 0, text: '-- Danh mục --' }, null, true);                                        
                                        system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.statuses, status, null, null, true);

                                        system.spinner('#formProduct #editProduct' + ' [name*=DisplayOrder]');

                                        if (res.Data.IsHotProduct) 
                                            $('#formProduct input[type=checkbox]').attr('checked', 'checked');

                                        CKEDITOR.replace('Description');

                                        system.product.listImage();
                                        system.product.listDocument();
                                        system.product.listRelated();

                                        system.registerUniform();
                                    });
                            }
                        });
                    break;

                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.productAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {
                                if (res.Success) {
                                    $.jGrowl('Xóa sản phẩm thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.article.list(utils.getHiddenField('CurrentPageIndex'));
                                }
                            });
                    }
                    break;
            }
        },

        // Image & File 
        setFinderManager: function (type) {
            var finder = new CKFinder();
            switch (type) {
                case 'image':
                    finder.selectActionFunction = system.product.getFinderImageManager;
                    break;
                case 'document':
                    finder.selectActionFunction = system.product.getFinderDocumentManager;
                    break;
            }            
            finder.popup();
        },

        // Image
        getFinderImageManager: function (fileLastPath, fileLastInfomation, lstImage) {
            //debugger;
            if (lstImage != null && lstImage.length > 0) {
                var html = '';
                for (var i = 0; i < lstImage.length; i++) {
                    var imagePath = lstImage[i].url;

                    var fileType = '';
                    var ext = /^.+\.([^.]+)$/.exec(imagePath);
                    var currentExt = ext == null ? "" : ext[1].toLowerCase();

                    if (imagePath != null && imagePath.length > 0 && (currentExt === 'jpg' || currentExt === 'png' || currentExt === 'tif' || currentExt === 'GIF')) {
                        html += system.product.getTemplateImageOrDocument(imagePath, '', '', null, 0);
                    }
                }
                $(html).insertAfter(".message-list-header:eq(0)");
                if (html != '')
                    $.jGrowl("Nhấn 'Lưu' để lưu lại ảnh vào hệ thống.", { sticky: false, theme: 'growl-warning', header: 'Thông báo' });
            }            
        },        

        // Document
        getFinderDocumentManager: function (fileLastPath, fileLastInfomation, lstDocument) {            
            if (lstDocument != null && lstDocument.length > 0) {
                var html = '';
                for (var i = 0; i < lstDocument.length; i++) {
                    var filePath = lstDocument[i].url;

                    var fileType = '';
                    var ext = /^.+\.([^.]+)$/.exec(filePath);
                    var currentExt = ext == null ? "" : ext[1];
                    //debugger;
                    if (filePath != null && filePath.length > 0 && (currentExt === 'xls' || currentExt === 'doc' || currentExt === 'pdf')) 
                        html += system.product.getTemplateImageOrDocument('', filePath, currentExt, null, 0);
                }
                $(html).insertAfter(".message-list-header:eq(1)");
                if (html != '')
                    $.jGrowl("Nhấn 'Lưu' để lưu lại tài liệu vào hệ thống.", { sticky: false, theme: 'growl-warning', header: 'Thông báo' });
            }
        },

        listRelated: function() {
            var skuId = parseInt(utils.getHiddenField('SKUId'));
            if (skuId > 0) {                
                $.ajax({ url: systemConfig.serviceBase.relatedList, data: { SKUID: skuId }, type: 'POST' }, function () { })
                 .done(function (response) {
                     if (response.Success) {
                         var html = system.product.getTemplateImageOrDocument('', '', '', response.Data);

                         $('#lstRelated tbody').html(html);
                     }
                 });
            }
        },

        manipulateRelated: function (obj) {
            var action = $(obj).attr('data-action');
            var params = { Action: action, SKUIDMain: parseInt(utils.getHiddenField('SKUId')) };;
            
            switch (action) {
                case systemConfig.action.save:                    
                    var lstSKUId = $(systemConfig.ddlProduct).val();
                    if (lstSKUId != null && lstSKUId.length > 0) {

                        var splitSKUId = lstSKUId.split(',');
                        for (var i = 0; i < splitSKUId.length; i++) {
                            var currentSKUId = parseInt(splitSKUId[i]);
                            if (currentSKUId > 0) {
                                params = $.extend(params, { SKUID: currentSKUId });
                                $.ajax({ url: systemConfig.serviceBase.relatedAction, data: params, type: 'POST' }, function () { })                                
                                    .done(function (res) {
                                        if (res.Success)                                             
                                            system.product.listRelated();                                        
                                    });
                            }
                        }
                        $.jGrowl('Thêm sản phẩm thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                    }
                    break;

                case systemConfig.action.del:
                    params = $.extend(params, { SKUID: $(obj).attr('data-skuId') });
                    $.ajax({ url: systemConfig.serviceBase.relatedAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Xóa sản phẩm thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                $(obj).parents('tr:first').remove();
                            }
                        });                    
                    break;
            }
        },

        listImage: function () {
            var skuId = parseInt(utils.getHiddenField('SKUId'));
            if (skuId > 0) {
                $.ajax({ url: systemConfig.serviceBase.imageList, data: { SKUID: skuId }, type: 'POST' }, function () { })
                 .done(function (response) {                     
                     if (response.Success) {
                         var html = '';
                         for (var i = 0; i < response.Data.length; i++) {                             
                             html += system.product.getTemplateImageOrDocument(response.Data[i].ImagePath, '', '', null, response.Data[i].ImageID);
                         }
                         
                         $(html).insertAfter(".message-list-header:eq(0)");
                     }
                 });
            }            
        },

        listDocument: function () {
            var skuId = parseInt(utils.getHiddenField('SKUId'));
            if (skuId > 0) {
                $.ajax({ url: systemConfig.serviceBase.fileList, data: { SKUID: skuId }, type: 'POST' }, function () { })
                 .done(function (response) {
                     if (response.Success) {
                         var html = '';
                         for (var i = 0; i < response.Data.length; i++) {
                             var fileType = '';
                             var ext = /^.+\.([^.]+)$/.exec(response.Data[i].FilePath);
                             var currentExt = ext == null ? "" : ext[1].toLowerCase();

                             html += system.product.getTemplateImageOrDocument('', response.Data[i].FilePath, currentExt, null, response.Data[i].FileID);
                         }

                         $(html).insertAfter(".message-list-header:eq(1)");
                     }
                 });
            }
        },

        saveImage: function () {            
            var params = '';
            var priority = 0;
            var skuId = utils.getHiddenField('SKUId');

            $.each($(".imageFinderManager"), function () {
                var imagePath = $(this).find('img').attr('src');
                if (imagePath != undefined) {
                    priority++;
                    params += String.format('{0}♥{1}♥{2}✈', skuId, imagePath, priority);
                }
            });

            if (skuId > 0 && params != null && params.length > 0) {
                console.log(params);
                if (params.length > 0) {
                    $.ajax({ url: systemConfig.serviceBase.imageAction, data: { Action: systemConfig.action.save, LstParams: params, SKUID: skuId }, type: 'POST' }, function () { })
                    .done(function (res) {
                        if (res.Success)
                            $.jGrowl(res.Message, { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                        else
                            $.jGrowl('Lỗi không đẩy ảnh lên hệ thống.', { sticky: false, theme: 'growl-error', header: 'Thông báo' });
                    });
                }
            }
        },

        saveDocument: function() {
            var params = '';
            var skuId = utils.getHiddenField('SKUId');            

            $.each($(".documentFinderManager"), function () {                
                var filePath = $(this).find('a').attr('title');
                if (filePath != undefined) 
                    params += String.format('{0}♥{1}✈', skuId, filePath);                
            });
            
            if (skuId > 0 && params != null && params.length > 0) {
                console.log(params);
                if (params.length > 0) {
                    $.ajax({ url: systemConfig.serviceBase.fileAction, data: { Action: systemConfig.action.save, LstParams: params, SKUID: skuId }, type: 'POST' }, function () { })
                    .done(function (res) {
                        if (res.Success)
                            $.jGrowl(res.Message, { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                        else
                            $.jGrowl('Lỗi không đẩy ảnh lên hệ thống.', { sticky: false, theme: 'growl-error', header: 'Thông báo' });
                    });
                }
            }
        },

        removeFinderManager: function (obj, typeId) {
            //debugger;
            var params = {};
            var url = '';
            var id = parseInt($(obj).attr('data-id'));

            if (id == 0) 
                $(obj).parents('li:first').remove();            
            else if (id > 0 && typeId > 0) {
                switch (typeId) {
                    case 1: // 'image'
                        url = systemConfig.serviceBase.imageAction;
                        var skuId = utils.getHiddenField('SKUId');                        
                        params = $.extend(params, { Action: systemConfig.action.del, SKUID: skuId, ImageID: id })
                        break;

                    case 2: // 'document'
                        url = systemConfig.serviceBase.fileAction;
                        params = $.extend(params, { Action: systemConfig.action.del, FileID: id })
                        break;
                }

                $.ajax({ url: url, data: params, type: 'POST' }, function () { })
                 .done(function (res) {
                     //debugger;
                     if (res.Success) {
                         $.jGrowl(res.Message, { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                         $(obj).parents('li:first').remove();
                     }
                 });
            }            
        },

        getTemplateImageOrDocument: function (imagePath, filePath, fileType, listRelated, id) {            
            var element = '';
            if (imagePath != '' && imagePath.length > 0) {
                element += '<li class="imageFinderManager">';
                element += '    <div class="clearfix">';
                element += '        <div class="chat-member">';
                element += String.format('<a href="#"><img src="{0}" alt=""></a>', imagePath);
                element += String.format('<h6>{0}</h6>', imagePath.replace('/Data', '').replace('FileManager/', ''));
                element += '        </div>';
                element += '        <div class="chat-actions">';
                element += String.format('<a data-id="{0}" onclick="system.product.removeFinderManager(this, 1);" class="btn btn-default btn-icon btn-xs tip"><i class="icon-remove3"></i></a>', id);
                element += '        </div>';
                element += '    </div>';
                element += '</li>';
            }
            else if (filePath != '' && fileType != '' && filePath.length > 0 && fileType.length > 0) {
                switch (fileType) {
                    case 'xls':
                        fileType = '<i class="icon-file-excel" style="font-size: 36px;"></i>';
                        break;
                    case 'doc':
                        fileType = '<i class="icon-file-word" style="font-size: 36px;"></i>';
                        break;
                    case 'pdf':
                        fileType = '<i class="icon-file-pdf" style="font-size: 36px;"></i>';
                        break;
                }

                element += '<li class="documentFinderManager">';
                element += '    <div class="clearfix">';
                element += '        <div class="chat-member">';
                element += String.format('<a href="#" title="{0}">{1}</a>', filePath, fileType);
                element += String.format('<h6>{0}</h6>', filePath.replace('/Data', '').replace('FileManager/', ''));
                element += '        </div>';
                element += '        <div class="chat-actions">';
                element += String.format('<a data-id="{0}" onclick="system.product.removeFinderManager(this, 2);" class="btn btn-default btn-icon btn-xs tip"><i class="icon-remove3"></i></a>', id);
                element += '        </div>';
                element += '    </div>';
                element += '</li>';
            }
            else if (listRelated != undefined && listRelated != null){
                if (listRelated.length > 0) {
                    for (var i = 0; i < listRelated.length; i++) {
                        element += '<tr>';
                        element += String.format('<td>{0}</td>', listRelated[i].ProductCode);
                        element += String.format('<td><a title="{0}">{1}</a></td>', listRelated[i].ProductName, listRelated[i].ProductShortName);
                        element += String.format('<td class="text-right">{0}</td>', listRelated[i].NETPrice);
                        element += String.format('<td class="text-right">{0}</td>', listRelated[i].NETPriceNPP);
                        element += String.format('<td class="text-center"><a data-action="delete" data-skuId="{0}" onclick="system.product.manipulateRelated(this);" class="btn btn-default btn-icon btn-xs tip"><i class="icon-remove3"></i></a></td>', listRelated[i].SKUID);
                        element += '</tr>';
                    }
                }                             
            }
            return element;
        }
    },
    
    // Developer
    developer: {        
        regionDeveloperInMenu: '.message-list',
                    
        // List Developer In Menu
        developerInMenu: function (keyword, menuId) {            
            var params = { keyword: keyword };

            function loadDeveloperInMenu() {
                var d = $.Deferred();
                $.ajax({ url: systemConfig.serviceBase.developerListInMenu, data: params, type: 'POST' }, function() { })
                    .done(function(res) {
                        if (res.Success && res.Data.length > 0) {
                            $.Mustache.load(systemConfig.html.developer + '?v=' + systemConfig.version)
                                .done(function() {
                                    $(system.developer.regionDeveloperInMenu).html('');
                                    $(system.developer.regionDeveloperInMenu).mustache(systemConfig.template.listDeveloperInMenu, res);
                                    system.registerUniform();

                                    $(system.developer.regionDeveloperInMenu).slimScroll({ height: '540px' });
                                });                            
                        } else
                            $(systemConfig.tableBody).html('<li>Không có thành viên phát triển chức năng.</li>');

                        d.resolve();
                    });
                return d.promise();
            }

            $.when( loadDeveloperInMenu() ).then(function () {
                if (menuId > 0) {                    
                    // Selected Developer                        
                    var paramsMenuDeveloper = { MenuId: menuId };
                    $.ajax({ url: systemConfig.serviceBase.menuDeveloperList, data: paramsMenuDeveloper, type: 'POST' }, function() { })
                        .done(function(response) {
                            if (response.Success) {                                
                                $.each($(system.menu.developerInMenu + ' input[type=checkbox]'), function () {
                                    var checkBox = $(this);
                                    var developerId = parseInt(checkBox.attr('value'));

                                    $.each(response.Data, function (i, val) {
                                        if (developerId == val.DeveloperId) {
                                            checkBox.attr('checked', 'checkd');
                                            checkBox.parent().addClass('checked');
                                        }
                                    });
                                });
                            }
                        });
                }
            });                      
        },
        
        // Action
        manipulate: function (action, id) {
            var params = {};
            if (id != null) 
                params = { DeveloperId: id, Action: action };
            
            switch (action) {
                case systemConfig.action.create:
                    $(systemConfig.modal.content).html('');
                    $(systemConfig.modal.content).mustache(systemConfig.template.createDeveloper);
                                        
                    system.staticDropDownList(systemConfig.ddlPosition, systemConfig.data.positions, 1, null, null, true);
                    system.staticDropDownList(systemConfig.ddlDeveloperStatus, systemConfig.data.statuses, 1, null, null, true);
                    
                    $(systemConfig.modal.id).modal('show');
                    break;
                    
                case systemConfig.action.getById:                    
                    $(systemConfig.modal.content).html('');
                    $.ajax({ url: systemConfig.serviceBase.developerAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {
                                $(systemConfig.modal.content).mustache(systemConfig.template.getDeveloper, res);                                
                                
                                system.staticDropDownList(systemConfig.ddlPosition, systemConfig.data.positions, res.Data.PositionId, null, null, true);
                                system.staticDropDownList(systemConfig.ddlDeveloperStatus, systemConfig.data.statuses, res.Data.Status, null, null, true);

                                $(systemConfig.modal.id).modal('show');
                            }
                        });
                    break;
                    
                case systemConfig.action.save:
                    params = $.extend(params, $(systemConfig.modal.form).serializeObject(),
                        { PositionId: $(systemConfig.ddlPosition).val() },
                        { Status: $(systemConfig.ddlDeveloperStatus).val() }
                    );
                    
                    $.ajax({ url: systemConfig.serviceBase.developerAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {
                                $.jGrowl('Lưu thông tin nhà phát triển thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                $(systemConfig.modal.id).modal('hide');
                                system.developer.developerInMenu('');
                            }
                        });
                    break;
                                    
                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {
                        $.ajax({ url: systemConfig.serviceBase.developerAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {                                
                                if (res.Success) {
                                    $.jGrowl('Xóa thông tin nhà phát triển thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.developer.developerInMenu('');
                                }
                            });
                    }
                    break;
            }
        }        
    },
    
    // Error
    error: {
        formError: '#formError',
        currentSelection: [],
        
        init: function () {
            // DropDownList
            system.staticDropDownList(systemConfig.ddlPriority, systemConfig.data.errorPriority, -1, { id: -1, text: '-- Ưu tiên --' }, '120px', true);
            system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.errorStatus, -1, { id: -1, text: '-- Trạng thái --' }, '140px', true);            
            system.staticDropDownList(systemConfig.ddlPageSize, systemConfig.data.pageSize, systemConfig.defaultPageSize, null, '65px', true);
                        
            // List
            system.error.list(systemConfig.defaultPageIndex);
            
            // Register Event
            $(systemConfig.txtSearch).keypress(function (event) {
                if (event.which == 13) {
                    system.error.list(systemConfig.defaultPageIndex);
                    event.preventDefault();
                }
            });
            
            $(systemConfig.ddlPageSize + ', ' + systemConfig.ddlStatus + ', ' + systemConfig.ddlPriority).change(function () {
                system.error.list(systemConfig.defaultPageIndex);
            });
                        
            $(systemConfig.table).delegate('tr td', 'click', function () {
                if (!$(this).hasClass('command')) {
                    var row = $(this).parent();
                    var id = row.attr('id');
                    if (id > 0) {
                        var idx = system.error.currentSelection.indexOf(id);
                        if (idx > -1) {
                            system.error.currentSelection.splice(idx, 1);
                            row.removeClass('success');
                        } else {
                            system.error.currentSelection.push(id);
                            row.addClass('success');
                        }
                    }
                    console.log('Current Selection Errors: ' + system.error.currentSelection.length);
                }
            });
        },                
            
        // List
        list: function(pageIndex) {
            var params = {
                keyword: $(systemConfig.txtSearch).val(),                
                status: $(systemConfig.ddlStatus).val(),
                priority: $(systemConfig.ddlPriority).val(),
                pageIndex: pageIndex,
                pageSize: $(systemConfig.ddlPageSize).val()
            };

            $.ajax({ url: systemConfig.serviceBase.errorList, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    if (res.Success && res.Data.length > 0) {
                        utils.setHiddenField('CurrentPageIndex', pageIndex);
                        $.Mustache.load(systemConfig.html.error + '?v=' + systemConfig.version)
                            .done(function () {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listError, res);

                                $('.panel-heading span').text(res.PagerInfo);
                                $(systemConfig.pagerInfo).html(res.PagerInfo);
                                $(systemConfig.pager).html(res.Pager);
                                                                
                                $("[data-toggle=popover]").popover().click(function (e) { e.preventDefault(); });
                                $('.tip').tooltip();
                            });
                    } else {
                        $(systemConfig.tableBody).html(system.noData(8));
                        $(systemConfig.pagerInfo).html('');
                        $(systemConfig.pager).html('');
                    }
                });
        },
        
        // Action
        manipulate: function (action, id) {            
            var params = {};
            if (id != null)
                params = { ErrorId: id, Action: action };

            switch (action) {                
                case systemConfig.action.getById:
                    $.when(
                        $.ajax({ url: systemConfig.serviceBase.errorAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {                            
                            if (res.Success) {
                                $(systemConfig.modal.content).html('');
                                $(systemConfig.modal.content).mustache(systemConfig.template.getError, res);
                            }
                        })
                    ).done(function () {                        
                        system.editor(systemConfig.modal.form + ' [name=Note]');
                        $(systemConfig.modal.id).modal('show');
                    });                    
                    break;
                    
                case systemConfig.action.save:
                    params = $.extend(params, { Note: $(systemConfig.modal.form + ' [name=Note]').val() });
                    $.ajax({ url: systemConfig.serviceBase.errorAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Lưu ghi chú thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.error.list(utils.getHiddenField('CurrentPageIndex'));
                                $(systemConfig.modal.id).modal('hide');
                            }
                        });                                                    
                break;                    

                case systemConfig.action.published:
                    params = $.extend(params, { LstId: system.error.currentSelection });
                    $.ajax({ url: systemConfig.serviceBase.errorAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Đã chỉnh sửa lỗi hoàn thành', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.error.list(utils.getHiddenField('CurrentPageIndex'));
                            }                                
                            else 
                                $.jGrowl('Bạn cần chọn lỗi.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });
                            
                            system.error.currentSelection.splice(0, system.error.currentSelection.length);
                        });
                    break;
                    
                case systemConfig.action.remove:
                    params = $.extend(params, { LstId: system.error.currentSelection });
                    $.ajax({ url: systemConfig.serviceBase.errorAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {
                                $.jGrowl('Gỡ lỗi thành công.', { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.error.list(utils.getHiddenField('CurrentPageIndex'));
                            }                                
                            else 
                                $.jGrowl('Bạn cần chọn lỗi.', { sticky: false, theme: 'growl-warning', header: 'Thông báo' });

                            system.error.currentSelection.splice(0, system.error.currentSelection.length);
                        });
                    break;
                    
                case systemConfig.action.send:                    
                    var data = new FormData();

                    data.append('FullName', $(system.error.formError + ' input[name=FullName]').val());
                    data.append('Email', $(system.error.formError + ' input[name=Email]').val());
                    data.append('Message', $(system.error.formError + ' textarea[name=Message]').val());
                    data.append('Priority', $(systemConfig.ddlPriority).val());

                    // Add the uploaded image content to the form data collection
                    var files = $("#attachFile").get(0).files;
                    if (files.length > 0)
                        data.append('AttachFile', files[0]);

                    // Make Ajax request with the contentType = false, and procesDate = false
                    var ajaxRequest = $.ajax({
                        type: 'POST',
                        url: systemConfig.serviceBase.errorSend,
                        contentType: false,
                        processData: false,
                        data: data
                    });

                    ajaxRequest.done(function (responseData, textStatus) {
                        var message = '';
                        if (textStatus == 'success') {
                            if (responseData != null) {
                                if (responseData.Key) {
                                    message = String.format('<div class="alert alert-success block-inner text-center">{0}</div><hr>', responseData.Value);
                                    $('#attachFile').val('');
                                    $(system.error.formError + ' input[name=FullName]').val('');
                                    $(system.error.formError + ' input[name=Email]').val('');
                                    $(system.error.formError + ' textarea').val('');
                                    $(systemConfig.ddlPriority).select2('val', 0);
                                }
                            }
                        } else
                            message = String.format('<div class="alert alert-error block-inner text-center">{0}</div><hr>', responseData.Value);

                        $('#regionMessage').html(message);
                    });
                    break;
            }
        }       
    },
    
    adv: {
        init: function () {
            // DropDownList            
            system.staticDropDownList(systemConfig.ddlSearchAdvType, systemConfig.data.advType, -1, { id: -1, text: '-- Loại --' }, '180px', true);
            system.staticDropDownList(systemConfig.ddlPageSize, systemConfig.data.pageSize, systemConfig.defaultPageSize, null, '65px', true);

            // List
            system.adv.list(systemConfig.defaultPageIndex);
            
            // Register Event
            $(systemConfig.ddlPageSize + ', ' + systemConfig.ddlSearchAdvType).change(function () {
                system.adv.list(systemConfig.defaultPageIndex);
            });
        },
        
        // List
        list: function(pageIndex) {
            var params = {                
                typeId: $(systemConfig.ddlSearchAdvType).val(),
                pageIndex: pageIndex,
                pageSize: $(systemConfig.ddlPageSize).val()
            };
            
            $.ajax({ url: systemConfig.serviceBase.advList, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    if (res.Success && res.Data.length > 0) {
                        utils.setHiddenField('CurrentPageIndex', pageIndex);
                        $.Mustache.load(systemConfig.html.adv + '?v=' + systemConfig.version)
                            .done(function () {
                                $(systemConfig.tableBody).html('');
                                $(systemConfig.tableBody).mustache(systemConfig.template.listAdv, res);

                                $(systemConfig.pagerInfo).html(res.PagerInfo);
                                $(systemConfig.pager).html(res.Pager);

                                $("[data-toggle=popover]").popover().click(function (e) { e.preventDefault(); });
                                $('.panel-heading span').text(res.PagerInfo);
                                $('.tip').tooltip();
                            });
                    } else {
                        $(systemConfig.tableBody).html(system.noData(6));
                        $(systemConfig.pagerInfo).html('');
                        $(systemConfig.pager).html('');
                    }
                });
        },
        
        // Action
        manipulate: function (action, id, typeId) {
            var params = {};
            if (id != null)
                params = { AdvId: id, Action: action };

            var typeName = typeId == 1 ? 'ảnh' : 'đối tác';
            
            switch (action) {
                case systemConfig.action.create:
                    $.Mustache.load(systemConfig.html.adv + '?v=' + systemConfig.version)
                        .done(function () {
                            $(systemConfig.modal.content).html('');
                            $(systemConfig.modal.content).mustache(systemConfig.template.createAdv);
                            
                            system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.advType, 4, null, null, true);
                            system.spinner(systemConfig.modal.form + ' [name*=Priority]');
                            
                            $(systemConfig.modal.id).modal('show');
                    });
                    break;

                case systemConfig.action.getById:                    
                        $.ajax({ url: systemConfig.serviceBase.advAction, data: params, type: 'POST' }, function() { })
                            .done(function (res) {
                                if (res.Success) {                                    
                                    $(systemConfig.modal.content).html('');
                                    $(systemConfig.modal.content).mustache(systemConfig.template.getAdv, res);
                                    
                                    system.staticDropDownList(systemConfig.ddlStatus, systemConfig.data.advType, res.Data.TypeId, null, null, true);
                                    system.spinner(systemConfig.modal.form + ' [name*=Priority]');
                                    
                                    $(systemConfig.modal.id).modal('show');
                                }
                            });                    
                    break;

                case systemConfig.action.save:                    
                    params = $.extend(params, $(systemConfig.modal.form).serializeObject(), { TypeId: $(systemConfig.ddlStatus).val() });
                    $.ajax({ url: systemConfig.serviceBase.advAction, data: params, type: 'POST' }, function () { })
                        .done(function (res) {
                            if (res.Success) {                                
                                $.jGrowl(String.format('Lưu thông tin {0} thành công.', typeName), { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                system.adv.list(utils.getHiddenField('CurrentPageIndex'));
                                $(systemConfig.modal.id).modal('hide');
                            }
                        });
                    break;
                    
                case systemConfig.action.del:
                    var confirm = window.confirm('Bạn có chắc muốn xóa?');
                    if (confirm) {                        
                        $.ajax({ url: systemConfig.serviceBase.advAction, data: params, type: 'POST' }, function () { })
                            .done(function (res) {                                
                                if (res.Success) {                                    
                                    $.jGrowl(String.format('Xóa {0} thành công.', typeName), { sticky: false, theme: 'growl-success', header: 'Thông báo' });
                                    system.adv.list(utils.getHiddenField('CurrentPageIndex'));
                                }
                            });
                    }
                    break;
            }
        },
        

        openFileManager: function () {            
            var finder = new CKFinder();            
            finder.selectActionFunction = system.adv.setPathToControl;
            finder.popup();
        },

        setPathToControl: function (fileUrl) {
            $('#formAdv [name=ImagePath]').val(fileUrl);
        }
    }
};

