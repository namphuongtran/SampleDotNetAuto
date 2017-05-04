gridConfig = {
    // Common
    defaultPageIndex: 1,
    defaultPageSize: 20,
    
    lstTypeReport: {
        reportDetail: 'reportDetail',
        reportSynthesis: 'reportSynthesis',
        reportLabel: 'reportLabel',
        reportLechTreoha: 'reportLechTreoHa',
        reportWebsiteProduct: 'reportWebsiteProduct',
        reportCustomer: 'reportCustomer',
        reportDataFromProductSystem: 'reportDataFromProductSystem'
    },

    loading: '[id*=gridLoading]',
    table: '#gridWrap table',
    tableBody: '#gridWrap tbody',
    tableBodyTr: '#gridWrap tbody tr',
    pagerInfo: '#gridPagerInfo',
    pager: '#gridPager ul',

    timeOutNotification: 30000,
    txtDateRange: '#txtDateRange',
    ddlPageSize: '#ddlPageSize',
    ddlNoiBo: '#ddlNoiBo',
    processing: '#processing',

    // Group Field Name
    groupFieldName: {
        product: 'TenSanPham',
        website: 'TenWebsite',
        contract: 'SoHopDong',
        departments: 'TenPhongBan',
        parts: 'TenBoPhan',
        group: 'TenNhomLamViec',
        staff: 'TenNhanVien'
    },

    // Service Base
    reportDetailServiceBase: '/handler/FilterForm.ashx',
    reportLableServiceBase: '/handler/FilterForm.ashx',
    reportDataFromProductSystemServiceBase: '/handler/FilterForm.ashx',

    reportSynthesisServiceBase: '/handler/SynthesisReport.ashx',

    reportWebsiteProductServiceBase: '/handler/Reports.ashx',
    reportCustomerServiceBase: '/handler/Reports.ashx',

    actionNotificationTime: 'get_max_implementation_date',

    // Static Param
    getStaticParams: function () {
        var params = {
            advertisingType: utils.getHiddenField(filterConfig.advertisingType.name),
            lstBanner: utils.getHiddenField(filterConfig.banner.name),

            lstProduct: utils.getHiddenField(filterConfig.product.name),
            lstContract: utils.getTokenInput(filterConfig.contract.name),
            lstWebsite: utils.getTokenInput(filterConfig.website.name),

            lstDepartments: utils.getHiddenField(filterConfig.departments.name),
            lstParts: utils.getHiddenField(filterConfig.parts.name),
            lstGroup: utils.getHiddenField(filterConfig.group.name),
            lstStaff: utils.getTokenInput(filterConfig.staff.name),

            lstLabel: utils.getTokenInput(filterConfig.label.name),
            lstCustomer: utils.getTokenInput(filterConfig.customer.name),
            unit: utils.getHiddenField(filterConfig.unit.name),

            lstBookingId: utils.getHiddenField(filterConfig.bookingId.name),
            lstBannerId: utils.getHiddenField(filterConfig.bannerId.name)
        };

        return params;
    },

    // Dynamic Params
    dynamicParams: {
        pageIndex: 1,
        pageSize: 20,
        action: '',
        rootGroupFieldName: '',
        groupFieldName: '',

        startDate: '',
        endDate: '',
        unit: '',

        level1: '',
        level2: '',
        levelValue1: '',
        levelValue2: '',

        reportGroupType: '',

        isShowNoiBo: -1,
        type: ''
    },

    // Report Detail        
    reportDetail: {
        urlTemplate: '/Templates/tpl_report_detail.htm',
        noData: '<tr><td colspan="14">Không có dữ liệu! Vui lòng chọn điều kiện tìm kiếm khác.</td></tr>',

        levelContract: 'report-detail-contact',
        levelContractDetail: 'report-detail-contact-detail',

        actionLevel1: 'report_sum_by_filter_condition',
        actionLevel2: 'report_list_contract_paging',
        actionLevel3: 'report_list_contract_detail_paging',
        actionSum: 'total_sum_by_filter_condition',

        tplLevel1: 'tpl-report-detail-level1',
        tplLevel2: 'tpl-report-detail-level2',
        tplLevel3: 'tpl-report-detail-level3',
        tplContract: 'tpl-report-detail-contract',
        tplSum: 'tpl-report-detail-sum'
    },

    // Report Synthesis
    reportSynthesis: {
        reportGroupType1: "group1",
        reportGroupType2: "group2",

        reportLevel1: 'level1',
        reportLevel2: 'level2',
        reportLevel3: 'level3',

        hfGroupFieldName: 'GroupFieldName',
        hfReportGroupType: 'ReportGroupType',

        urlTemplate: '/Templates/tpl_report_synthesis.htm',
        noData: '<tr><td colspan="7">Không có dữ liệu!</td></tr>',

        actionList: 'get_synthetic_filter_condition',
        actionSum: 'get_synthetic_totalvalue_filter_condition'
    },

    // Report Label
    reportLabel: {
        urlTemplate: '/Templates/tpl_report_label.htm',
        noData: '<tr><td colspan="7">Không có dữ liệu!</td></tr>',

        levelLabel: 'report-list-label',
        levelLabelContract: 'report-list-label-contract',

        actionLevel1: 'report_list_label',
        actionLevel2: 'report_list_contract_label',
        actionSum: 'report_list_label_total_value',

        tplLevel1: 'tpl-report-list-label',
        tplLevel2: 'tpl-report-list-label-contract',
        tplSum: 'tpl-report-list-label-total-value'
    },

    // Report Website Product
    reportWebsiteProduct: {
        urlTemplate: '/Templates/tpl_reports.htm',
        tplList: 'tpl-list-website-product',
        noData: '<tr><td colspan="21">Không có dữ liệu!</td></tr>',

        actionList: 'getListWebsiteProduct',
        actionExportExcel: 'getDownloadExcelWebsiteProduct',
    },

    // Report Lech Treo Ha
    reportLechTreoHa: {
        urlTemplate: '/Templates/tpl_lech_treo_ha.htm',
        noData: '<tr><td colspan="11">Không có dữ liệu! Vui lòng chọn điều kiện tìm kiếm khác.</td></tr>',

        actionLechTreoHaLevel1: 'report_lech_treo_ha_by_sanpham',
        actionLechTreoHaTotalValue: 'report_lech_treo_ha_total_value',

        actionLevel2: 'report_lech_treo_ha_list_contract_paging',

        tplLevel1: 'tpl-report-lechtreoha-level1',
        tplLevel2: 'tpl-report-lechtreoha-level2',
        tplSum: 'tpl-report-lth-sum'
    },

    // Report Customer
    reportCustomer: {
        urlTemplate: '/Templates/tpl_reports.htm',

        levelCustomer: 'report-list-customer',
        levelCustomerContract: 'report-list-customer-contract',

        reportTypeCustomer: 'customer',
        reportTypeCustomerContract: 'customer-contract',

        actionListByType: 'getListCustomerContractByType',
        actionSum: 'getSumCustomerContract',

        tplLevel1: 'tpl-list-report-by-customer',
        tplLevel2: 'tpl-list-report-by-customer-contract',
        tplSum: 'tpl-sum-report-by-customer',

        noData: '<tr><td colspan="6">Không có dữ liệu!</td></tr>'
    },

    // Dữ liệu thực chạy từ hệ thống sản phẩm
    reportDataFromProductSystem: {
        urlTemplate: '/Templates/tpl_report_detail.htm',

        levelProduct: 'report-list-product',
        levelProductContract: 'report-list-product-contract',

        actionList: 'report_list_data_summary_from_thuc_chay',
        actionDetail: 'report_list_bao_cao_thuc_chay_chi_tiet',

        tplLevel1: 'tpl-report-data-from-product',
        tplLevel2: 'tpl-report-data-from-product-contract',

        noData: '<tr><td colspan="9">Không có dữ liệu!</td></tr>'
    },

    // Print
    print: {
        reportTypeDetail: 'detail',
        reportTypeSynthesis: 'synthesis',
        detail: 1,
        synthesis: 2,
        btnSearch: '#btnSearch',
        btnPrintSynthesis: '#btnPrintSynthesis',
        btnPrintDetail: '#btnPrintDetail'
    },
};

grid = {
    /*****************************************************************************************************************
    = Common Function
    ----------------------------------------------------------------------------------------------------------------*/
    isUnauthorized: function (res) {
        if (res != null && res.toLowerCase() == 'unauthorized') {
            smoke.signal('Phiên làm việc của bạn đã hết.');
            setTimeout("window.location.href = 'Login.aspx';", 4000);
        }
    },

    notificationTime: function () {
        var url = String.format('{0}?action={1}', gridConfig.reportDetailServiceBase, gridConfig.actionNotificationTime);

        $.getJSON(url, function (res) {
            if (res.Success && res.Data != null)
                $('#msgNotification').append(res.Data[0].MessageNotification);
        });
    },

    clickRowReportCommon: function (groupFieldName) {
        $(gridConfig.table).delegate("tbody tr td[is_expand=no]", "click", function () {
            var row = $(this).parent();
            var cell = row.find('td');

            if ($(row).attr('abm_action') != 'no') {
                var rowSelected = $(row).find('td:first');
                var level = row.attr('abm_level');
                var isContract = row.attr('is_contract') == undefined ? false : true;

                if (level == gridConfig.reportDetail.levelContractDetail)
                    rowSelected = $(row).find('td:eq(1)');

                if (isContract)
                    rowSelected = $(row).find('td:first');

                var isExpandOrCollapse = rowSelected.text().localeCompare('[+]');
                if (isExpandOrCollapse == 0) {
                    rowSelected.html('[-]');
                    cell.addClass(level + '-active');
                    //debugger;
                    switch (level) {
                        // Report Detail
                        case gridConfig.reportDetail.levelContract:
                            var elFather1 = row.attr('id');
                            var elFatherVal1 = $('#' + elFather1).attr('abm_id');

                            grid.reportDetailLevel2(elFather1, elFatherVal1, groupFieldName, gridConfig.defaultPageIndex);
                            break;

                        case gridConfig.reportDetail.levelContractDetail:
                            var elGrandFather2 = row.attr('class');
                            var elFather2 = row.attr('id');
                            var elGrandFatherVal2 = $(this).parent('tr').attr('parent_abm_id');
                            var elFatherVal2 = row.attr('abm_id');

                            grid.reportDetailLevel3(elGrandFather2, elFather2, elGrandFatherVal2, elFatherVal2, gridConfig.groupFieldName.contract, gridConfig.defaultPageIndex);
                            break;

                            // Report Label
                        case gridConfig.reportLabel.levelLabel:
                            var elFather3 = row.attr('id');
                            grid.reportLabelLevel2(elFather3, gridConfig.defaultPageIndex);
                            break;

                            // Report Customer
                        case gridConfig.reportCustomer.levelCustomer:
                            var elFather4 = row.attr('id');
                            grid.reportCustomerLevel2(elFather4, gridConfig.defaultPageIndex);
                            break;

                            // Dữ liệu thực chạy từ hệ thống sản phẩm
                        case gridConfig.reportDataFromProductSystem.levelProduct:
                            var elFather5 = row.attr('id');
                            grid.reportDataFromProductSystemLevel2(elFather5, gridConfig.defaultPageIndex);
                            break;
                    }
                } else {
                    rowSelected.html('[+]');
                    cell.removeClass(level + '-active');

                    $('.' + row.attr('id')).remove();
                }
            }
        });
    },

    /*****************************************************************************************************************
    = Report Detail
    ----------------------------------------------------------------------------------------------------------------*/
    reportDetailLevel1: function (groupFieldName, pageIndex) { // Danh sách theo 7 chiều tương ứng với GroupFieldName
        $("html").addClass("js");

        // Set Parameter For Report Detail Level 1
        gridConfig.dynamicParams.groupFieldName = groupFieldName;
        gridConfig.dynamicParams.action = gridConfig.reportDetail.actionLevel1;
        gridConfig.dynamicParams.startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        gridConfig.dynamicParams.endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.pageIndex = pageIndex;
        gridConfig.dynamicParams.pageSize = $(gridConfig.ddlPageSize).val();

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());
        $.when(
            $.ajax({ url: gridConfig.reportDetailServiceBase, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);
                    if (res.Success && res.Data.length > 0) {

                        $.Mustache.load(gridConfig.reportDetail.urlTemplate)
                            .done(function () {
                                $(gridConfig.tableBody).html('');

                                var template = groupFieldName == gridConfig.groupFieldName.contract
                                    ? gridConfig.reportDetail.tplContract
                                    : gridConfig.reportDetail.tplLevel1;

                                $(gridConfig.tableBody).mustache(template, res);

                                $(gridConfig.pagerInfo).html(res.PagerInfo);
                                $(gridConfig.pager).html(res.Pager);
                            });
                    } else {
                        $(gridConfig.tableBody).html(gridConfig.reportDetail.noData);
                        $(gridConfig.pagerInfo).html('');
                        $(gridConfig.pager).html('');
                    }
                })
        ).then(function () {
            $(gridConfig.processing).css('visibility', 'hidden');
            grid.reportDetailSum(params);
        });
    },

    reportDetailLevel2: function (elFather, elFatherVal, groupFieldName, pageIndex) { // Danh sách Hợp đồng
        $('html').addClass('js');
        var father = $('#' + elFather);
        var fatherObj = { id: father.attr('id'), unit: father.attr('abm_unit'), level: father.attr('abm_level') };

        // Set Parameter For Report Detail Level 2        
        gridConfig.dynamicParams.groupFieldName = groupFieldName;
        gridConfig.dynamicParams.action = gridConfig.reportDetail.actionLevel2;
        gridConfig.dynamicParams.level1 = fatherObj.id;
        gridConfig.dynamicParams.levelValue1 = elFatherVal;
        gridConfig.dynamicParams.unit = fatherObj.unit;
        gridConfig.dynamicParams.pageIndex = pageIndex;

        var params = $.extend(true, gridConfig.dynamicParams, { advertisingType: utils.getHiddenField(filterConfig.advertisingType.name) });

        $.when(
            $.ajax({ url: gridConfig.reportDetailServiceBase, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);
                    if (res.Success && res.Data != null) {
                        // Xóa các dòng của Level 1
                        $('.' + fatherObj.id).remove();

                        //alert('Parent Html: ' + father.html());
                        var table = $('<table/>').append($("<tr/>")
                            .attr('id', fatherObj.id)
                            .attr('abm_id', elFatherVal)
                            .attr('abm_unit', fatherObj.unit)
                            .attr('abm_level', fatherObj.level)
                            .append(father.html()));

                        table.find('tbody').append($.Mustache.render(gridConfig.reportDetail.tplLevel2, res));
                        //alert('Table Html: ' + table.html());

                        table.find('.level').attr('class', fatherObj.id);
                        //alert('Table Html: ' + table.html());
                        $(father).replaceWith(table.find('tbody').html());
                        gebo_tips.init();
                    }
                })
        ).then(function () {
            grid.calcShowColumnPagination();
            $('html').removeClass('js');
        });
    },

    reportDetailLevel3: function (elGrandFather, elFather, elGrandFatherVal, elFatherVal, groupFieldName, pageIndex) { // Danh sách chi tiết Hợp đồng        
        $('html').addClass('js');

        // GF: report-detail-contact-2
        // F: report-detail-contact-detail-1

        // Set Parameter For Report Detail Level 3        
        var father = $('#' + elFather);
        var isContract = father.attr('is_contract') == undefined ? false : father.attr('is_contract');
        var unit = father.attr('abm_unit');

        gridConfig.dynamicParams.groupFieldName = groupFieldName;
        gridConfig.dynamicParams.action = gridConfig.reportDetail.actionLevel3;
        gridConfig.dynamicParams.level1 = elGrandFather;
        gridConfig.dynamicParams.level2 = elFather;
        gridConfig.dynamicParams.levelValue1 = elGrandFatherVal;
        gridConfig.dynamicParams.levelValue2 = elFatherVal;
        gridConfig.dynamicParams.unit = unit;
        gridConfig.dynamicParams.isContract = isContract;
        gridConfig.dynamicParams.pageIndex = pageIndex;

        gridConfig.dynamicParams.rootGroupFieldName = utils.getHiddenField('RootGroupFieldName'); // Important (Root GroupFieldName)

        if (elFatherVal.length > 0 && elFatherVal != '-') { // ContractNo Length > 0     
            $.when(
                $.ajax({ url: gridConfig.reportDetailServiceBase, data: gridConfig.dynamicParams, type: 'POST' }, function () { })
                    .done(function (res) {
                        grid.isUnauthorized(res);

                        res = $.parseJSON(res);

                        if (res.Success && res.Data != null) {

                            // Xóa các dòng của Level 2
                            $('.' + elFather).remove();

                            // Lấy dữ liệu chèn vào dòng hiện tại 
                            var parent = $('#' + elFather);
                            var table = $('<table/>').append($("<tr/>")
                                .attr('id', '' + elFather)
                                .attr('class', elGrandFather)
                                .attr('parent_abm_id', $('#' + elGrandFather).attr('abm_id'))
                                .attr('abm_id', elFatherVal)
                                .attr('abm_unit', unit)
                                .attr('abm_level', $('#' + elFather).attr('abm_level'))
                                .append(parent.html()));
                            //alert('Table 1: ' + table.html());		                 

                            if (isContract) // Important
                                table.find('tr').attr('is_contract', isContract);

                            table.find('tbody').append($.Mustache.render(gridConfig.reportDetail.tplLevel3, res));
                            table.find('.level').attr('class', String.format('{0} {1}', elGrandFather, elFather));
                            //alert('Table 2: ' + table.html());

                            $('#' + elFather).replaceWith(table.find('tbody').html());
                            gebo_tips.init();
                        }
                    })
            ).then(function () {
                grid.calcShowColumnPagination();
                $('html').removeClass('js');
            });
        } else {
            $.sticky("Không có hợp đồng.", { autoclose: 5000, position: "top-right", type: "st-info" });
            $('html').removeClass('js');
        }
    },

    reportDetailSum: function (params) {
        params.action = gridConfig.reportDetail.actionSum;

        $.ajax({ url: gridConfig.reportDetailServiceBase, data: params, type: 'POST' }, function () { })
            .done(function (res) {
                grid.isUnauthorized(res);

                res = $.parseJSON(res);
                if (res.Success && res.Data != null) {
                    if ($(gridConfig.tableBodyTr).hasClass('total') == false) {
                        $(gridConfig.tableBody).append($.Mustache.render(gridConfig.reportDetail.tplSum, res));
                    }
                }
            })
            .complete(function () {
                grid.calcShowColumnPagination();
                $('html').removeClass('js');
            });
    },

    reportDetailPrint: function (groupFieldName, printType) {
        var url = String.format('/Controls/PrintReports/PrintReportThucChay.aspx?&GroupFieldName={0}&StartDate={1}&EndDate={2}&LstSanPham={3}&LstWebsite={4}&LstHopDong={5}&LstPhongBan={6}&LstBoPhan={7}&LstNhom={8}&LstNhanVien={9}&PrintType={10}&LstHinhThucQuangCao={11}&LstBanner={12}&LstUnit={13}',
            groupFieldName, utils.getValidDate($(gridConfig.txtDateRange).val(), 0), utils.getValidDate($(gridConfig.txtDateRange).val(), 1),
            utils.getHiddenField(filterConfig.product.name), utils.getTokenInput(filterConfig.website.name), utils.getTokenInput(filterConfig.contract.name),
            utils.getHiddenField(filterConfig.departments.name), utils.getHiddenField(filterConfig.parts.name), utils.getHiddenField(filterConfig.group.name), utils.getTokenInput(filterConfig.staff.name),
            printType, utils.getHiddenField(filterConfig.advertisingType.name), utils.getHiddenField(filterConfig.banner.name), utils.getHiddenField(filterConfig.unit.name));

        window.open(url);
    },

    /*****************************************************************************************************************
    = Report Synthesis 
    ----------------------------------------------------------------------------------------------------------------*/
    clickRowReportSynthesis: function (groupFieldName, reportGroupType) {
        $(gridConfig.table).delegate("tbody tr td[is_expand=no]", "click", function () {
            var row = $(this).parent();
            var rowAttr = new Object();
            var cell = row.find('td');

            rowAttr.classId = row.attr('id');
            rowAttr.values = row.attr('abm_id');
            rowAttr.group = row.attr('abm_group');
            rowAttr.select = row.attr('abm_select');
            rowAttr.cssClass = row.attr('class');

            if ($(row).attr('abm_action') != 'no') {
                var level = row.attr('abm_level');
                var rowSelected = $(row).find('td:first');

                // Row Selected [+] [-]
                if ((reportGroupType == abm.ReportGroupType1 || reportGroupType == abm.ReportGroupType2) && level != 'level1')
                    rowSelected = $(row).find('td:eq(1)');

                // Collapse
                if (cell.hasClass(level + '-active')) {
                    //alert('-');                
                    cell.removeClass(level + '-active');
                    rowSelected.html('[+]');
                    $('.' + rowAttr.classId).remove();
                    return;
                }

                // Expansion
                if (rowSelected.html('[+]')) {
                    //alert('+');
                    cell.addClass(level + '-active');
                    rowSelected.html('[-]');

                    if (level == 'level1')
                        grid.reportSynthesisNestedList(rowAttr.classId, rowAttr.values, '', abm.PageIndex);
                    else if (level == 'level2')
                        grid.reportSynthesisNestedList(rowAttr.classId, $('#' + rowAttr.cssClass).attr('abm_id'), rowAttr.values, abm.PageIndex);
                }
            }
        });
    },

    reportSynthesisList: function (groupFieldName, reportGroupType, pageIndex) {
        $('html').addClass('js');

        // Set Parameter For Report Synthesis
        gridConfig.dynamicParams.groupFieldName = groupFieldName;
        gridConfig.dynamicParams.action = gridConfig.reportSynthesis.actionList;
        gridConfig.dynamicParams.reportGroupType = reportGroupType;
        gridConfig.dynamicParams.startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        gridConfig.dynamicParams.endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.pageIndex = pageIndex;

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());
        $.when(
            $.ajax({ url: gridConfig.reportSynthesisServiceBase, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);

                    if (res.Success && res.Data.length > 0) {
                        $.Mustache.load(gridConfig.reportSynthesis.urlTemplate)
                            .done(function () {
                                $(gridConfig.tableBody).html('');
                                $(gridConfig.tableBody).mustache(String.format('tpl-list-by-{0}-{1}', reportGroupType, groupFieldName), res);

                                $(gridConfig.pagerInfo).html(res.PagerInfo);
                                $(gridConfig.pager).html(res.Pager);
                            });
                    } else {
                        $(gridConfig.tableBody).html(gridConfig.reportSynthesis.noData);
                        $(gridConfig.pagerInfo).html('');
                        $(gridConfig.pager).html('');
                    }
                })
        )
        .then(function () {
            $(gridConfig.processing).css('visibility', 'hidden');
            grid.reportSynthesisSum(params);
        });
    },

    reportSynthesisNestedList: function (classId, vLevel1, vLevel2, pageIndex) {
        if (vLevel1 != '-1' && vLevel1 != '-') {
            $('html').addClass('js');

            var groupFieldName = utils.getHiddenField(gridConfig.reportSynthesis.hfGroupFieldName);
            var reportGroupType = utils.getHiddenField(gridConfig.reportSynthesis.hfReportGroupType);
            var level = vLevel2 == '' ? 'level1' : 'level2';

            //alert('vLevel1: ' + vLevel1 + ' _ vLevel2: ' + vLevel2);        
            var url = grid.reportSynthesisGenerateLink(groupFieldName, classId, vLevel1, vLevel2, pageIndex);

            if (url.length > 0)
                $.ajax({ url: url, type: 'GET', dataType: 'json' }, function () { })
                    .done(function (res) {
                        debugger;
                        if (res.Success && res.Data.length > 0) {

                            var template = '';
                            var parent = $('#' + classId);
                            // Xóa toàn bộ các dòng con
                            $('.' + parent.attr('id')).remove();

                            var table, cssClass = '';
                            if (level == 'level1') {
                                cssClass = parent.attr('id');

                                table = $('<table/>').append($("<tr/>")
                                    .attr('id', parent.attr('id'))
                                    .attr('abm_id', vLevel1)
                                    .attr('abm_group', reportGroupType)
                                    .attr('abm_select', groupFieldName)
                                    .attr('abm_level', level)
                                    .append(parent.html()));

                                template = reportGroupType == abm.ReportGroupType1
                                    ? String.format('tpl-list-by-nested-{0}-{1}', reportGroupType, abm.Staff)
                                    : String.format('tpl-list-by-nested-{0}-{1}', reportGroupType, abm.Product);
                            } else if (level == 'level2') {
                                cssClass = String.format('{0} {1}', $('#' + parent.attr('id')).attr('class'), parent.attr('id'));

                                table = $('<table/>').append($("<tr/>")
                                    .attr('id', parent.attr('id'))
                                    .attr('class', $('#' + parent.attr('id')).attr('class'))
                                    .attr('abm_id', vLevel2)
                                    .attr('abm_group', reportGroupType)
                                    .attr('abm_select', groupFieldName)
                                    .attr('abm_level', level)
                                    .append(parent.html()));

                                template = reportGroupType == abm.ReportGroupType1
                                    ? String.format('tpl-list-by-nested-{0}-{1}', reportGroupType, abm.Contract)
                                    : String.format('tpl-list-by-nested-{0}-{1}', reportGroupType, abm.Website);
                            }

                            table.find('tbody').append($.Mustache.render(template, res));
                            //alert('Table Html: ' + table.html());

                            table.find('.level').attr('class', cssClass);
                            //alert('Table Html: ' + table.html());

                            $(parent).replaceWith(table.find('tbody').html());
                        }
                    })
                    .fail(function (resFailed) {
                        abm.checkSessionState(resFailed);
                    })
                    .complete(function () {
                        $('html').removeClass('js');
                    });
        }
    },

    reportSynthesisSum: function (params) {
        params.action = gridConfig.reportSynthesis.actionSum;

        $.ajax({ url: gridConfig.reportSynthesisServiceBase, data: params, type: 'POST' }, function () { })
            .done(function (res) {
                grid.isUnauthorized(res);

                res = $.parseJSON(res);

                if (res.Success && res.Data != null) {
                    if ($(gridConfig.tableBodyTr).hasClass('total') == false) {
                        $(gridConfig.tableBody).append($.Mustache.render('tpl-get-sum-total-value', res));
                    }
                }
            })
            .complete(function () {
                $('html').removeClass('js');
            });
    },

    reportSynthesisPrint: function (groupFieldName, printType) {
        var url = String.format('/Controls/PrintReports/PrintReportSyntheticThucChay.aspx?&GroupFieldName={0}&StartDate={1}&EndDate={2}&LstSanPham={3}&LstWebsite={4}&LstHopDong={5}&LstPhongBan={6}&LstBoPhan={7}&LstNhom={8}&LstNhanVien={9}&PrintType={10}&LstHinhThucQuangCao={11}&LstBanner={12}&LstUnit={13}',
            groupFieldName, utils.getValidDate($(gridConfig.txtDateRange).val(), 0), utils.getValidDate($(gridConfig.txtDateRange).val(), 1),
            utils.getHiddenField(filterConfig.product.name), utils.getTokenInput(filterConfig.website.name), utils.getTokenInput(filterConfig.contract.name),
            utils.getHiddenField(filterConfig.departments.name), utils.getHiddenField(filterConfig.parts.name), utils.getHiddenField(filterConfig.group.name), utils.getTokenInput(filterConfig.staff.name),
            printType, utils.getHiddenField(filterConfig.advertisingType.name), utils.getHiddenField(filterConfig.banner.name), utils.getHiddenField(filterConfig.unit.name));

        window.open(url);
    },

    reportSynthesisGenerateLink: function (groupFieldName, classId, vLevel1, vLevel2, pageIndex) {
        var urlProduct = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstProduct={5}&LstStaff={6}&LstContract={7}&ClassId={8}&vLevel1={5}&vLevel2={6}';
        var urlWebsite = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstWebsite={5}&LstStaff={6}&LstContract={7}&LstDepartments={8}&ClassId={9}&vLevel1={5}&vLevel2={6}';
        var urlDepartments = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstDepartments={5}&LstStaff={6}&LstContract={7}&ClassId={8}&vLevel1={5}&vLevel2={6}';
        var urlParts = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstParts={5}&LstStaff={6}&LstContract={7}&LstDepartments={8}&ClassId={9}&vLevel1={5}&vLevel2={6}';
        var urlGroup = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstGroup={5}&LstStaff={6}&LstContract={7}&LstDepartments={8}&ClassId={9}&vLevel1={5}&vLevel2={6}';

        var urlContract = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstContract={5}&LstProduct={6}&LstWebsite={7}&ClassId={8}&vLevel1={5}&vLevel2={6}';
        var urlStaff = gridConfig.reportSynthesisServiceBase + '?action=get_synthetic_filter_condition&PageIndex={0}&PageSize={1}&GroupFieldName={2}&StartDate={3}&EndDate={4}&LstStaff={5}&LstProduct={6}&LstWebsite={7}&ClassId={8}&vLevel1={5}&vLevel2={6}';

        var startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        var endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        var pageSize = $(gridConfig.ddlPageSize).val();

        debugger;

        var url = '';
        switch (groupFieldName) {
            // 1. Sản phẩm | Website | Phòng ban/Bộ phận/Nhóm --> Người bán --> Hợp đồng                           
            case abm.Product:
                if (vLevel2 == '')
                    url = String.format(urlProduct, pageIndex, pageSize, abm.Staff, startDate, endDate, vLevel1, utils.getTokenInput(filterConfig.staff.name), utils.getTokenInput(filterConfig.contract.name), classId);
                else
                    url = String.format(urlProduct, pageIndex, pageSize, abm.Contract, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.contract.name), classId);
                break;
            case abm.Website:
                if (vLevel2 == '')
                    url = String.format(urlWebsite, pageIndex, pageSize, abm.Staff, startDate, endDate, vLevel1, utils.getTokenInput(filterConfig.staff.name), utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.departments.name), classId);
                else
                    url = String.format(urlWebsite, pageIndex, pageSize, abm.Contract, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.departments.name), classId);
                break;
            case abm.Departments:
                if (vLevel2 == '')
                    url = String.format(urlDepartments, pageIndex, pageSize, abm.Staff, startDate, endDate, vLevel1, utils.getTokenInput(filterConfig.staff.name), utils.getTokenInput(filterConfig.contract.name), classId);
                else
                    url = String.format(urlDepartments, pageIndex, pageSize, abm.Contract, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.contract.name), classId);
                break;
            case abm.Parts:
                if (vLevel2 == '')
                    url = String.format(urlParts, pageIndex, pageSize, abm.Staff, startDate, endDate, vLevel1, utils.getTokenInput(filterConfig.staff.name), utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.departments.name), classId);
                else
                    url = String.format(urlParts, pageIndex, pageSize, abm.Contract, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.departments.name), classId);
                break;
            case abm.Group:
                if (vLevel2 == '')
                    url = String.format(urlGroup, pageIndex, pageSize, abm.Staff, startDate, endDate, vLevel1, utils.getTokenInput(filterConfig.staff.name), utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.departments.name), classId);
                else
                    url = String.format(urlGroup, pageIndex, pageSize, abm.Contract, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.departments.name), classId);
                break;
                // 2. Hợp đồng | Nhân viên --> Sản phẩm --> Website                    
            case abm.Contract:
                if (vLevel2 == '')
                    url = String.format(urlContract, pageIndex, pageSize, abm.Product, startDate, endDate, vLevel1, utils.getHiddenField(filterConfig.product.name), utils.getTokenInput(filterConfig.website.name), classId);
                else
                    url = String.format(urlContract, pageIndex, pageSize, abm.Website, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.website.name), classId);
                break;
            case abm.Staff:
                if (vLevel2 == '')
                    url = String.format(urlStaff, pageIndex, pageSize, abm.Product, startDate, endDate, vLevel1, utils.getHiddenField(filterConfig.product.name), utils.getTokenInput(filterConfig.website.name), classId);
                else
                    url = String.format(urlStaff, pageIndex, pageSize, abm.Website, startDate, endDate, vLevel1, vLevel2, utils.getTokenInput(filterConfig.website.name), classId);
                break;
        }
        return url;
    },

    /*****************************************************************************************************************
    = Report Label
    ----------------------------------------------------------------------------------------------------------------*/
    reportLabelLevel1: function (pageIndex) {
        $("html").addClass("js");

        // Set Parameter For Report Label Level 1        
        gridConfig.dynamicParams.action = gridConfig.reportLabel.actionLevel1;
        gridConfig.dynamicParams.startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        gridConfig.dynamicParams.endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.pageIndex = pageIndex;
        gridConfig.dynamicParams.pageSize = $(gridConfig.ddlPageSize).val();

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());
        $.when(
            $.ajax({ url: gridConfig.reportLableServiceBase, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);
                    if (res.Success && res.Data.length > 0) {
                        $.Mustache.load(gridConfig.reportLabel.urlTemplate)
                            .done(function () {
                                $(gridConfig.tableBody).html('');

                                $(gridConfig.tableBody).mustache(gridConfig.reportLabel.tplLevel1, res);

                                $(gridConfig.pagerInfo).html(res.PagerInfo);
                                $(gridConfig.pager).html(res.Pager);
                            });
                    } else {
                        $(gridConfig.tableBody).html(gridConfig.reportLabel.noData);
                        $(gridConfig.pagerInfo).html('');
                        $(gridConfig.pager).html('');
                    }
                })
        ).then(function () {
            $(gridConfig.processing).css('visibility', 'hidden');
            grid.reportLabelSum(params);
        });
    },

    reportLabelLevel2: function (elFather, pageIndex) {
        $("html").addClass("js");

        var father = $('#' + elFather);
        var fatherObj = { id: father.attr('id'), value: father.attr('abm_id'), unit: father.attr('abm_unit'), level: father.attr('abm_level') };

        // Set Dynamic Parameter For Report Label Level 2        
        gridConfig.dynamicParams.groupFieldName = gridConfig.groupFieldName.contract;
        gridConfig.dynamicParams.action = gridConfig.reportLabel.actionLevel2;
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.level1 = elFather;
        gridConfig.dynamicParams.levelValue1 = fatherObj.value;
        gridConfig.dynamicParams.pageIndex = pageIndex;

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());

        $.when(
            $.ajax({ url: gridConfig.reportLableServiceBase, data: params, type: 'POST' }, function () {
            })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);

                    if (res.Success && res.Data != null) {
                        // Xóa toàn bộ các dòng con mức 1
                        $('.' + fatherObj.id).remove();

                        //alert('Parent Html: ' + parent.html());
                        var table = $('<table/>').append($("<tr/>")
                            .attr('id', fatherObj.id)
                            .attr('abm_id', fatherObj.value)
                            .attr('abm_unit', fatherObj.unit)
                            .attr('abm_level', fatherObj.level)
                            .append(father.html()));

                        table.find('tbody').append($.Mustache.render(gridConfig.reportLabel.tplLevel2, res));
                        //alert('Table Html: ' + table.html());

                        table.find('.level').attr('class', fatherObj.id);
                        //alert('Table Html: ' + table.html());
                        $(father).replaceWith(table.find('tbody').html());

                        gebo_tips.init();
                    }
                })
        ).then(function () {
            // Hiển thị ẩn hiện các cột tương tứng khi phân trang
            grid.calcShowColumnPagination();

            $("html").removeClass("js");
        });
    },

    reportLabelSum: function (params) {
        params.action = gridConfig.reportLabel.actionSum;

        $.ajax({ url: gridConfig.reportLableServiceBase, data: params, type: 'POST' }, function () { })
            .done(function (res) {
                res = $.parseJSON(res);

                if (res.Success && res.Data != null) {
                    if ($(gridConfig.tableBodyTr).hasClass('total') == false) {
                        $(gridConfig.tableBody).append($.Mustache.render(gridConfig.reportLabel.tplSum, res));
                    }
                }
            })
            .fail(function (resFailed) {
                abm.checkSessionState(resFailed);
            })
            .complete(function () {
                $('html').removeClass('js');
            });
    },

    reportLabelPrint: function (printType) {
        var url = String.format('/Controls/PrintReports/PrintReportBaoCaoNhanHang.aspx?&startDate={0}&endDate={1}&lstProduct={2}&lstWebsite={3}&lstContract={4}&advertisingType={5}&lstBanner={6}&lstLabel={7}&lstCustomer={8}&lstUnit={9}&printType={10}',
            utils.getValidDate($(gridConfig.txtDateRange).val(), 0), utils.getValidDate($(gridConfig.txtDateRange).val(), 1),
            utils.getHiddenField(filterConfig.product.name), utils.getTokenInput(filterConfig.website.name), utils.getTokenInput(filterConfig.contract.name),
            utils.getHiddenField(filterConfig.advertisingType.name), utils.getHiddenField(filterConfig.banner.name),
            utils.getTokenInput(filterConfig.label.name), utils.getTokenInput(filterConfig.customer.name), utils.getHiddenField(filterConfig.unit.name), printType);

        window.open(url);
    },

    /*****************************************************************************************************************
    = Report Product Website
    ----------------------------------------------------------------------------------------------------------------*/
    reportWebsiteProduct: function () {
        $('html').addClass('js');

        var params = {
            action: gridConfig.reportWebsiteProduct.actionList,
            startDate: utils.getValidDate($(gridConfig.txtDateRange).val(), 0),
            endDate: utils.getValidDate($(gridConfig.txtDateRange).val(), 1),
            lstWebsite: utils.getHiddenField(filterConfig.websiteProduct.name)
        };

        $.when(
            $.ajax({ url: gridConfig.reportWebsiteProductServiceBase, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);
                    if (res.Success && res.Data != null) {
                        $.Mustache.load(gridConfig.reportWebsiteProduct.urlTemplate)
                            .done(function () {
                                $(gridConfig.tableBody).html('');

                                $(gridConfig.tableBody).mustache(gridConfig.reportWebsiteProduct.tplList, res);
                            });
                    } else
                        $(gridConfig.tableBody).html(gridConfig.reportWebsiteProduct.noData);
                })
        ).then(function () {
            $(gridConfig.processing).css('visibility', 'hidden');
            grid.calcShowColumnPagination();
            $('html').removeClass('js');
        });
    },

    reportWebsiteProductExportExcel: function () {
        var url = String.format('{0}?action={1}&startDate={2}&endDate={3}&lstWebsite={4}',
            gridConfig.reportWebsiteProductServiceBase, gridConfig.reportWebsiteProduct.actionExportExcel,
            utils.getValidDate($(gridConfig.txtDateRange).val(), 0), utils.getValidDate($(gridConfig.txtDateRange).val(), 1),
            utils.getHiddenField(filterConfig.websiteProduct.name));
        window.open(url, '_self');
    },

    /*****************************************************************************************************************
    = Report lệch treo hạ
    ----------------------------------------------------------------------------------------------------------------*/
    reportLechTreoHaLevel1: function (pageIndex) {
        $("html").addClass("js");

        // Set Parameter For Report Detail Level 1
        gridConfig.dynamicParams.action = gridConfig.reportLechTreoHa.actionLechTreoHaLevel1;
        gridConfig.dynamicParams.startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        gridConfig.dynamicParams.endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.pageIndex = pageIndex;
        gridConfig.dynamicParams.pageSize = $(gridConfig.ddlPageSize).val();
        gridConfig.dynamicParams.isShowNoiBo = $(gridConfig.ddlNoiBo).val();

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());

        $.when(
            $.ajax({ url: gridConfig.reportDetailServiceBase, data: params, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);

                    if (res.Success && res.Data.length > 0) {
                        $.Mustache.load(gridConfig.reportLechTreoHa.urlTemplate)
                            .done(function () {
                                $(gridConfig.tableBody).html('');

                                var template = gridConfig.reportLechTreoHa.tplLevel1;

                                $(gridConfig.tableBody).mustache(template, res);

                                //$(gridConfig.pagerInfo).html(res.PagerInfo);
                                //$(gridConfig.pager).html(res.Pager);
                            });
                    } else {
                        $(gridConfig.tableBody).html(gridConfig.reportDetail.noData);
                        $(gridConfig.pagerInfo).html('');
                        $(gridConfig.pager).html('');
                    }
                })
        ).then(function () {
            $(gridConfig.processing).css('visibility', 'hidden');
            grid.reportLechTreoHaSum(params);
        });
    },

    reportLechTreoHaLevel2: function (elFather, elFatherVal, pageIndex) { // Danh sách Hợp đồng        
        $('html').addClass('js');
        var father = $('#' + elFather);
        var fatherObj = { id: father.attr('id'), unit: father.attr('abm_unit'), level: father.attr('abm_level') };

        // Set Parameter For Report Detail Level 2        
        gridConfig.dynamicParams.action = gridConfig.reportLechTreoHa.actionLevel2;
        gridConfig.dynamicParams.level1 = fatherObj.id;
        gridConfig.dynamicParams.levelValue1 = elFatherVal;
        gridConfig.dynamicParams.lstProduct = elFatherVal;
        gridConfig.dynamicParams.unit = fatherObj.unit;
        gridConfig.dynamicParams.level1 = fatherObj.id;
        gridConfig.dynamicParams.levelValue1 = elFatherVal;
        gridConfig.dynamicParams.pageIndex = pageIndex;

        $.when(
            $.ajax({ url: gridConfig.reportDetailServiceBase, data: gridConfig.dynamicParams, type: 'POST' }, function () { })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);
                    if (res.Success && res.Data != null) {
                        // Xóa các dòng của Level 1
                        $('.' + fatherObj.id).remove();

                        //alert('Parent Html: ' + father.html());
                        var table = $('<table/>').append($("<tr/>")
                            .attr('id', fatherObj.id)
                            .attr('abm_id', elFatherVal)
                            .attr('abm_unit', fatherObj.unit)
                            .attr('abm_level', fatherObj.level)
                            .append(father.html()));

                        table.find('tbody').append($.Mustache.render(gridConfig.reportLechTreoHa.tplLevel2, res));
                        //alert('Table Html: ' + table.html());

                        table.find('.level').attr('class', fatherObj.id);
                        //alert('Table Html: ' + table.html());
                        $(father).replaceWith(table.find('tbody').html());
                        gebo_tips.init();
                    }
                })
        ).then(function () {
            grid.calcShowColumnPagination();
            $('html').removeClass('js');
        });
    },

    clickRowReportLechTreoHa: function () {
        $(gridConfig.table).delegate("tbody tr td[is_expand=no]", "click", function () {
            var row = $(this).parent();
            var cell = row.find('td');

            if ($(row).attr('abm_action') != 'no') {
                var rowSelected = $(row).find('td:first');
                var level = row.attr('abm_level');
                var isContract = row.attr('is_contract') == undefined ? false : true;

                if (level == gridConfig.reportDetail.levelContractDetail)
                    rowSelected = $(row).find('td:eq(1)');

                if (isContract)
                    rowSelected = $(row).find('td:first');

                var isExpandOrCollapse = rowSelected.text().localeCompare('[+]');
                if (isExpandOrCollapse == 0) {
                    rowSelected.html('[-]');
                    cell.addClass(level + '-active');

                    var elFather1 = row.attr('id');
                    var elFatherVal1 = $('#' + elFather1).attr('abm_id');

                    grid.reportLechTreoHaLevel2(elFather1, elFatherVal1, gridConfig.defaultPageIndex);

                } else {
                    rowSelected.html('[+]');
                    cell.removeClass(level + '-active');

                    $('.' + row.attr('id')).remove();
                }
            }
        });
    },

    reportLechTreoHaSum: function (params) {
        params.action = gridConfig.reportLechTreoHa.actionLechTreoHaTotalValue;

        $.when(
            $.ajax({ url: gridConfig.reportDetailServiceBase, data: params, type: 'POST' }, function () {
            })
                .done(function (res) {
                    res = $.parseJSON(res);
                    if (res.Success && res.Data != null) {
                        if ($(gridConfig.tableBodyTr).hasClass('total') == false) {
                            $(gridConfig.tableBody).append($.Mustache.render(gridConfig.reportLechTreoHa.tplSum, res));
                        }
                    }
                })
                .fail(function (resFailed) {
                    abm.checkSessionState(resFailed);
                })
        ).then(function () {
            grid.calcShowColumnPagination();
            $('html').removeClass('js');
        });
    },

    /*****************************************************************************************************************
    = Report Customer
    ----------------------------------------------------------------------------------------------------------------*/
    reportCustomerLevel1: function (pageIndex) {
        $("html").addClass("js");

        // Set Parameter For Report Customer Level 1        
        gridConfig.dynamicParams.action = gridConfig.reportCustomer.actionListByType;
        gridConfig.dynamicParams.startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        gridConfig.dynamicParams.endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.pageIndex = pageIndex;
        gridConfig.dynamicParams.type = gridConfig.reportCustomer.reportTypeCustomer;
        gridConfig.dynamicParams.level1 = '';
        gridConfig.dynamicParams.levelValue1 = '';

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());
        $.when(
            $.ajax({ url: gridConfig.reportCustomerServiceBase, data: params, type: 'POST' }, function () {
            })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);

                    if (res.Success && res.Data != null) {
                        $.Mustache.load(gridConfig.reportCustomer.urlTemplate)
                            .done(function () {
                                $(gridConfig.tableBody).html('');

                                $(gridConfig.tableBody).mustache(gridConfig.reportCustomer.tplLevel1, res);

                                $(gridConfig.pagerInfo).html(res.PagerInfo);
                                $(gridConfig.pager).html(res.Pager);
                            });
                    } else {
                        $(gridConfig.tableBody).html(gridConfig.reportCustomer.noData);
                        $(gridConfig.pagerInfo, gridConfig.pager).html('');
                    }
                })
        ).then(function () {
            $(gridConfig.processing).css('visibility', 'hidden');
            grid.reportCustomerSum(params);
        });
    },

    reportCustomerLevel2: function (elFather, pageIndex) {
        $("html").addClass("js");
        var father = $('#' + elFather);
        var fatherObj = { id: father.attr('id'), value: father.attr('abm_id'), unit: father.attr('abm_unit'), level: father.attr('abm_level'), type: father.attr('abm_type') };

        // Set Parameter For Report Customer Level 2                        
        gridConfig.dynamicParams.action = gridConfig.reportCustomer.actionListByType;
        gridConfig.dynamicParams.type = gridConfig.reportCustomer.reportTypeCustomerContract;
        gridConfig.dynamicParams.level1 = elFather;
        gridConfig.dynamicParams.levelValue1 = fatherObj.value;
        gridConfig.dynamicParams.unit = utils.getHiddenField(filterConfig.unit.name);
        gridConfig.dynamicParams.pageIndex = pageIndex;

        $.when(
            $.ajax({ url: gridConfig.reportCustomerServiceBase, data: gridConfig.dynamicParams, type: 'POST' }, function () {
            })
                .done(function (res) {
                    grid.isUnauthorized(res);

                    res = $.parseJSON(res);

                    if (res.Success && res.Data != null) {

                        // Xóa các dòng ở mức con                    
                        $('.' + fatherObj.id).remove();

                        //alert('Parent Html: ' + parent.html());
                        var table = $('<table/>').append($("<tr/>")
                            .attr('id', fatherObj.id)
                            .attr('abm_id', fatherObj.value)
                            .attr('abm_level', fatherObj.level)
                            .attr('abm_type', fatherObj.type)
                            .append(father.html()));

                        table.find('tbody').append($.Mustache.render(gridConfig.reportCustomer.tplLevel2, res));
                        //alert('Table Html1: ' + table.html());

                        table.find('.level').attr('class', fatherObj.id);
                        //alert('Table Html2: ' + table.html());

                        $(father).replaceWith(table.find('tbody').html());
                    }
                })
        ).then(function () {
            // Hiển thị ẩn hiện các cột tương tứng khi phân trang
            grid.calcShowColumnPagination();
            gebo_tips.init();

            $("html").removeClass("js");
        });
    },

    reportCustomerSum: function (params) {
        params.action = gridConfig.reportCustomer.actionSum;
        //var params = reports.getCustomerParams(null, null, null, null, reportsConfig.actionSumCustomerContract, null);

        $.ajax({ url: gridConfig.reportCustomerServiceBase, data: params, type: 'POST' }, function () {
        })
            .done(function (res) {
                res = $.parseJSON(res);

                if (res.Success && res.Data != null) {
                    if ($(gridConfig.tableBodyTr).hasClass('total') == false) {
                        $(gridConfig.tableBody).append($.Mustache.render(gridConfig.reportCustomer.tplSum, res));
                    }
                }
            })
            .fail(function (resFailed) {
                abm.checkSessionState(resFailed);
            })
            .complete(function () {
                grid.calcShowColumnPagination();
                $('html').removeClass('js');
            });
    },

    reportCustomerPrint: function (printType) {
        var url = String.format('/Controls/PrintReports/PrintReportBaoCaoKhachHang.aspx?&startDate={0}&endDate={1}&lstProduct={2}&lstWebsite={3}&lstContract={4}&advertisingType={5}&lstBanner={6}&lstLabel={7}&lstCustomer={8}&lstUnit={9}&printType={10}',
                    utils.getValidDate($(gridConfig.txtDateRange).val(), 0), utils.getValidDate($(gridConfig.txtDateRange).val(), 1),
                    utils.getHiddenField(filterConfig.product.name), utils.getTokenInput(filterConfig.website.name), utils.getTokenInput(filterConfig.contract.name), utils.getHiddenField(filterConfig.advertisingType.name),
                    utils.getHiddenField(filterConfig.banner.name), utils.getTokenInput(filterConfig.label.name), utils.getTokenInput(filterConfig.customer.name), utils.getHiddenField(filterConfig.unit.name), printType);

        window.open(url);
    },

    /*****************************************************************************************************************
    = Báo cáo dữ liệu từ hệ thống sản phẩm
    ----------------------------------------------------------------------------------------------------------------*/
    reportDataFromProductSystemLevel1: function (pageIndex) {
        $("html").addClass("js");

        // Set Parameter For Report Data Frrom Product System Level 1        
        gridConfig.dynamicParams.action = gridConfig.reportDataFromProductSystem.actionList;
        gridConfig.dynamicParams.startDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 0);
        gridConfig.dynamicParams.endDate = utils.getValidDate($(gridConfig.txtDateRange).val(), 1);
        gridConfig.dynamicParams.pageIndex = pageIndex;
        gridConfig.dynamicParams.pageSize = $(gridConfig.ddlPageSize).val();

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());

        $.ajax({ url: gridConfig.reportDataFromProductSystemServiceBase, data: params, type: 'POST' }, function () { })
            .done(function (res) {
                grid.isUnauthorized(res);

                res = $.parseJSON(res);
                if (res.Success && res.Data.length > 0) {
                    $.Mustache.load(gridConfig.reportDataFromProductSystem.urlTemplate)
                        .done(function () {
                            $(gridConfig.tableBody).html('');

                            $(gridConfig.tableBody).mustache(gridConfig.reportDataFromProductSystem.tplLevel1, res);

                            $(gridConfig.pagerInfo).html(res.PagerInfo);
                            $(gridConfig.pager).html(res.Pager);
                        });
                } else {
                    $(gridConfig.tableBody).html(gridConfig.reportDataFromProductSystem.noData);
                    $(gridConfig.pagerInfo).html('');
                    $(gridConfig.pager).html('');
                }
            })
            .complete(function () {
                $(gridConfig.processing).css('visibility', 'hidden');
                $("html").removeClass("js");
            });
    },

    reportDataFromProductSystemLevel2: function (elFather, pageIndex) {
        $("html").addClass("js");

        var father = $('#' + elFather);
        var fatherObj = { id: father.attr('id'), value: father.attr('abm_id'), level: father.attr('abm_level') };

        // Set Parameter For Report Data Frrom Product System Level 2
        gridConfig.dynamicParams.action = gridConfig.reportDataFromProductSystem.actionDetail;
        gridConfig.dynamicParams.level1 = elFather;
        gridConfig.dynamicParams.levelValue1 = fatherObj.value;
        gridConfig.dynamicParams.action = gridConfig.reportDataFromProductSystem.actionDetail;
        gridConfig.dynamicParams.pageIndex = pageIndex;

        var params = $.extend(gridConfig.dynamicParams, gridConfig.getStaticParams());

        $.ajax({ url: gridConfig.reportDataFromProductSystemServiceBase, data: params, type: 'POST' }, function () { })
		 .done(function (res) {
		     grid.isUnauthorized(res);

		     res = $.parseJSON(res);
		     if (res.Success && res.Data != null) {

		         // Xóa các dòng con mức 1
		         $('.' + elFather).remove();

		         // Lấy dữ liệu chèn vào dòng hiện tại                 
		         var table = $('<table/>').append($("<tr/>")
                                             .attr('id', elFather)
                                             .attr('abm_id', fatherObj.value)
                                             .attr('abm_level', fatherObj.level)
                                             .append(father.html()));
		         //alert('Table 1: ' + table.html());

		         table.find('tbody').append($.Mustache.render(gridConfig.reportDataFromProductSystem.tplLevel2, res));
		         table.find('.level').attr('class', elFather);
		         //alert('Table 2: ' + table.html());

		         father.replaceWith(table.find('tbody').html());
		     }
		     else
		         $(gridConfig.tableBody).html(gridConfig.reportDataFromProductSystem.noData);
		 })
         .complete(function () {
             $("html").removeClass("js");
         });
    },

    /*****************************************************************************************************************
    = Print & Page Size
    ----------------------------------------------------------------------------------------------------------------*/
    manipulatePrintAndPageSize: function (typeReport, groupFieldName, reportGroupType) {
        switch (typeReport) {
            case gridConfig.lstTypeReport.reportDetail: // Report Detail
                $(gridConfig.print.btnSearch).click(function () {
                    grid.reportDetailLevel1(groupFieldName, gridConfig.defaultPageIndex);
                    return false;
                });

                $(gridConfig.print.btnPrintSynthesis).click(function () {
                    grid.reportDetailPrint(groupFieldName, gridConfig.print.synthesis);
                    return false;
                });

                $(gridConfig.print.btnPrintDetail).click(function () {
                    grid.reportDetailPrint(groupFieldName, gridConfig.print.detail);
                    return false;
                });

                $(ddlPageSize).change(function () {
                    grid.reportDetailLevel1(groupFieldName, gridConfig.defaultPageIndex);
                });
                break;
            case gridConfig.lstTypeReport.reportSynthesis: // Report Synthesis
                $(gridConfig.print.btnSearch).click(function () {
                    grid.reportSynthesisList(groupFieldName, reportGroupType, gridConfig.defaultPageIndex);
                    return false;
                });

                $(gridConfig.print.btnPrintSynthesis).click(function () {
                    grid.reportSynthesisPrint(groupFieldName, gridConfig.print.synthesis);
                    return false;
                });

                $(gridConfig.print.btnPrintDetail).click(function () {
                    grid.reportSynthesisPrint(groupFieldName, gridConfig.print.detail);
                    return false;
                });

                $(ddlPageSize).change(function () {
                    grid.reportSynthesisList(groupFieldName, reportGroupType, gridConfig.defaultPageIndex);
                });
                break;
            case gridConfig.lstTypeReport.reportLabel: // Report Label                 
                $(gridConfig.print.btnSearch).click(function () {
                    grid.reportLabelLevel1(gridConfig.defaultPageIndex);
                    return false;
                });

                $(gridConfig.print.btnPrintSynthesis).click(function () {
                    grid.reportLabelPrint(gridConfig.print.synthesis);
                    return false;
                });

                $(gridConfig.print.btnPrintDetail).click(function () {
                    grid.reportLabelPrint(gridConfig.print.detail);
                    return false;
                });

                $(ddlPageSize).change(function () {
                    grid.reportLabelLevel1(gridConfig.defaultPageIndex);
                });
                break;

            case gridConfig.lstTypeReport.reportLechTreoha: // Lech Treo Ha
                $(gridConfig.print.btnSearch).click(function () {
                    grid.reportLechTreoHaLevel1(gridConfig.defaultPageIndex);
                    return false;
                });

                $(ddlPageSize).change(function () {
                    grid.reportLechTreoHaLevel1(gridConfig.defaultPageIndex);
                });
                break;

            case gridConfig.lstTypeReport.reportCustomer: // Report Customer
                $(gridConfig.print.btnSearch).click(function () {
                    grid.reportCustomerLevel1(gridConfig.defaultPageIndex);
                    return false;
                });

                $(gridConfig.print.btnPrintSynthesis).click(function () {
                    grid.reportCustomerPrint(gridConfig.print.synthesis);
                    return false;
                });

                $(gridConfig.print.btnPrintDetail).click(function () {
                    grid.reportCustomerPrint(gridConfig.print.detail);
                    return false;
                });

                $(ddlPageSize).change(function () {
                    grid.reportCustomerLevel1(gridConfig.defaultPageIndex);
                });
                break;

            case gridConfig.lstTypeReport.reportDataFromProductSystem: // Dữ liệu thực chạy từ hệ thống sản phẩm
                $(gridConfig.print.btnSearch).click(function () {
                    grid.reportDataFromProductSystemLevel1(gridConfig.defaultPageIndex);
                    return false;
                });

                $(ddlPageSize).change(function () {
                    grid.reportDataFromProductSystemLevel1(gridConfig.defaultPageIndex);
                });
                break;
        }
    },

    manipulateScroll: function () {
        // Di chuột vào sang trái & phải
        var speed = 180;
        var $content = $('.dataTables_wrapper');

        function loopLeft() { $content.stop().animate({ scrollLeft: '-=' + speed }, 1000, 'linear', loopLeft); }

        function loopRight() { $content.stop().animate({ scrollLeft: '+=' + speed }, 1000, 'linear', loopRight); }

        function stop() { $content.stop(); }

        $("#prev").hover(loopLeft, stop);
        $("#next").hover(loopRight, stop);

        $content.mousewheel(function (event, delta) {
            this.scrollLeft -= (delta * 30);
            event.preventDefault();
        });
    },

    /*****************************************************************************************************************
    = Show, Hide Column On Grid
    ----------------------------------------------------------------------------------------------------------------*/
    calcShowColumn: function (obj, index, operator) {
        var quantity;
        var className = index <= 3 ? 'sl' : 'tt';
        var upDown = $('.' + className).attr('colspan');

        if (operator == '-') {
            $('#hfLstColumn').val(String.format('{0} {1},', $('#hfLstColumn').val(), index));

            quantity = parseInt(upDown) - 1;
            $('.mtc' + index).hide();
            $(obj).attr('abm', 'show').find('a').css('color', '#ccc');
        } else {
            $('#hfLstColumn').val($('#hfLstColumn').val().replace(String.format('{0},', index), ""));

            quantity = parseInt(upDown) + 1;
            $('.mtc' + index).show();
            $(obj).attr('abm', 'hide').find('a').css('color', '#333');
        }

        if (quantity == 0)
            $('.' + className).hide();
        else
            $('.' + className).show();

        $('.' + className).attr('colspan', quantity);
    },

    // Calc Show Column When Pagination
    calcShowColumnPagination: function () {
        var lstColumn = $('#hfLstColumn').val().split(',');
        for (var i = 0; i < lstColumn.length; i++) {
            var index = parseInt(lstColumn[i]);
            if (index > 0) {
                $('.mtc' + index).hide();
            }
        }
    },

    // Show Hide Column
    showColumn: function (obj, index) {
        var status = $(obj).attr('abm');

        // Show, hide one column
        if (status == 'hide' && index > 0)
            grid.calcShowColumn(obj, index, '-');
        else if (index > 0)
            grid.calcShowColumn(obj, index, '+');

        // Show all columns
        if (index == 0) {
            for (var i = 1; i < 7; i++) {
                $('.mtc' + i).show();
            }
            $('.dropdown-menu li').attr('abm', 'hide').find('a').css('color', '#333');

            $('.sl').attr('colspan', 3).show();
            $('.tt').attr('colspan', 3).show();

            $('#hfLstColumn').val(''); // Reset
        }
    },

    /*****************************************************************************************************************
    = Init Report
    ----------------------------------------------------------------------------------------------------------------*/
    initReportDetail: function (groupFieldName) {
        //grid.reportDetailLevel1(groupFieldName, gridConfig.defaultPageIndex);
        grid.clickRowReportCommon(groupFieldName);
        grid.manipulatePrintAndPageSize(gridConfig.lstTypeReport.reportDetail, groupFieldName, null);
    },

    initReportSynthesis: function (groupFieldName, reportGroupType) {
        //grid.reportSynthesisList(groupFieldName, reportGroupType, gridConfig.defaultPageIndex);
        grid.clickRowReportSynthesis(groupFieldName, reportGroupType);
        grid.manipulatePrintAndPageSize(gridConfig.lstTypeReport.reportSynthesis, groupFieldName, reportGroupType);

        $(gridConfig.tableBodyTr + ' td:eq(0), ' + gridConfig.tableBodyTr + ' td:eq(1), ' + gridConfig.tableBodyTr + ' td:eq(2)').mouseover(function () {
            $(this).css('cursor', 'pointer');
        });
    },

    intReportLechTreoHaBySanPham: function () {
        //grid.reportLechTreoHaLevel1(gridConfig.defaultPageIndex);
        grid.clickRowReportLechTreoHa();
        grid.manipulatePrintAndPageSize(gridConfig.lstTypeReport.reportLechTreoha, null, null);
    },

    initReportLabel: function () {
        //grid.reportLabelLevel1(gridConfig.defaultPageIndex);
        grid.manipulatePrintAndPageSize(gridConfig.lstTypeReport.reportLabel, null, null);
        grid.clickRowReportCommon(null);
    },

    initReportCustomer: function () {
        //grid.reportCustomerLevel1(gridConfig.defaultPageIndex);
        grid.manipulatePrintAndPageSize(gridConfig.lstTypeReport.reportCustomer, null, null);
        grid.clickRowReportCommon(null);
    },

    initReportDataFromProductSystem: function () {
        //grid.reportDataFromProductSystemLevel1(gridConfig.defaultPageIndex);
        grid.manipulatePrintAndPageSize(gridConfig.lstTypeReport.reportDataFromProductSystem, null, null);
        grid.clickRowReportCommon(null);
    }
};
