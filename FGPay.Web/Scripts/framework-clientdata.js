var clients = [];
$(function () {
    clients = $.clientsInit();
})
$.clientsInit = function () {
    var dataJson = {
        groups: [],
        menuPermissions: [],
        userInfo: Object
    };
    var init = function () {
        $.ajax({
            url: "/ClientsData/GetClientsDataJson",
            type: "get",
            dataType: "json",
            async: false,
            success: function (data) {
                dataJson.groups = data.groups;
                dataJson.menuPermissions = data.menuPermissions;
                dataJson.userInfo = data.userInfo;
            }
        });
    }
    init();
    return dataJson;
}