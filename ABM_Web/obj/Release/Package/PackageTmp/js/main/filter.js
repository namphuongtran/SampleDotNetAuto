// Filter Config
var filterConfig = {
    version: '0.3',
    
    serviceBase: '/api/Manipulation/ListFilterByType',
    
    isOptionAll: { id: -1, value: -1, text: '-- Tất cả --' },    

    // List Control 
    dateRange: '#txtDateRange',

    advertisingType: { type: 'HTQC', name: 'AdvertisingType', minimumInputLength: 1, multiple: true },
    banner: { type: 'Banner', name: 'Banner', multiple: true },

    product: { type: 'SanPham', name: 'Product', minimumInputLength: 1, multiple: true },
    productByAdvertisingType: { type: 'SanPhamHTQC', name: 'Product', minimumInputLength: 1, multiple: true },

    contract: { type: 'HopDong', name: 'Contract', minimumInputLength: 2, multiple: true },
    website: { type: 'Website', name: 'Website', minimumInputLength: 2, multiple: true },

    customer: { type: 'KhachHang', name: 'Customer', minimumInputLength: 2, multiple: true },
    label: { type: 'NhanHang', name: 'Label', minimumInputLength: 2, multiple: true },

    departments: { type: 'PhongBan', name: 'Departments', multiple: true },
    parts: { type: 'BoPhanNghiepVu', name: 'Parts', multiple: true },
    group: { type: 'NhomLamViec', name: 'Group', multiple: true },
    departmentsPartsGroup: { type: 'P-B-N', name: 'DepartmentPartsGroup' },
    
    staff: { type: 'NhanVien', name: 'Staff', minimumInputLength: 2, multiple: true },
    unit: { type: 'DonViTinh', name: 'Unit', multiple: true },

    bookingId: { type: 'BookingId', name: 'BookingId', minimumInputLength: 1, multiple: true },
    bannerId: { type: 'BannerId', name: 'BannerId', minimumInputLength: 1, multiple: true },

    websiteProduct: { type: 'WebsiteProduct', name: 'WebsiteProduct' }
};

// Filter
var filter = {
    buildDropDownList: function (lstDropDownList) {        
        for (var i = 0; i < lstDropDownList.length; i++) {
            (function (i) {
                var options = {
                    width: "100%",                                              
                    ajax: {                        
                        url: filterConfig.serviceBase,
                        type: 'POST',
                        data: function (term) {                            
                            var params = { Type: lstDropDownList[i].type, Keyword: term };

                            // Only For BookingId & BannerId
                            if (lstDropDownList[i].type == filterConfig.bookingId.name || lstDropDownList[i].type == filterConfig.bannerId.name)
                                params = $.extend(params, { startDate: utils.getValidDate($(filterConfig.dateRange).val(), 0), endDate: utils.getValidDate($(filterConfig.dateRange).val(), 1) });                   
                            return params;
                        },
                        results: function (res) {
                            if (res.Success && res.Data.length > 0) 
                                return { results: res.Data };                            
                        }
                    },                    
                    formatNoMatches: function () { return 'Không tìm thấy'; },
                    formatSearching: function () { return 'Tìm kiếm ...'; }                    
                };                
                
                // Multiple
                options = lstDropDownList[i].multiple != undefined
                            ? $.extend(options, { multiple: lstDropDownList[i].multiple }) : options;
                
                // Minimum Input Length
                options = lstDropDownList[i].minimumInputLength != undefined && lstDropDownList[i].minimumInputLength > 0
                            ? $.extend(options, {
                                minimumInputLength: lstDropDownList[i].minimumInputLength,
                                formatInputTooShort: function () {
                                    return 'Nhập ít nhất ' + lstDropDownList[i].minimumInputLength + ' ký tự';
                                }
                            }) : options;
                
                // Placeholder
                options = lstDropDownList[i].placeholder != undefined && lstDropDownList[i].placeholder.length > 0
                            ? $.extend(options, { placeholder: lstDropDownList[i].placeholder }) : options;

                $("#ddl" + lstDropDownList[i].name).select2(options);                
            })(i);
        }
    }        
};