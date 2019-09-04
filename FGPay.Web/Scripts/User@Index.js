$(function () {
    //gridList();
})
function gridList() {
    var $gridList = $("#gridList");
    $gridList.dataGrid({
        url: "GetGridJson",
        height: $(window).height() - 128,
        colModel: [
            { label: 'ID', name: 'ID', hidden: true },
            { label: "账号", name: 'AccountName', width: 80, align: 'left' },
            { label: "姓名", name: 'RealName', width: 80, align: 'left' },
            { label: "电话", name: 'MobilePhone', width: 80, align: 'left' },
            { label: 'Email', name: 'Email', width: 140, align: 'left' },
            {
                label: PageResx.col_role, name: 'RoleId', width: 80, align: 'left',
                formatter: function (cellvalue, options, rowObject) {
                    return top.clients.groups[cellvalue] == null ? "" : top.clients.groups[cellvalue];
                }
            },
            {
                label: PageResx.col_entrydate, name: 'Entrydate', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: PageResx.col_isAble, name: "IsAble", width: 80, align: "left",
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == true) {
                        return '<span class=\"label label-success\">启用</span>';
                    } else if (cellvalue == false) {
                        return '<span class=\"label label-default\">禁用</span>';
                    }
                }
            }
        ],
        pager: "#gridPager",
        sortname: 'ID',
        //sortorder: "desc", // 倒叙
        rowNum: 20,
        rowList: [10, 20, 30, 40, 50],
        viewrecords: true
    });
    $("#btn_search").click(function () {
        $gridList.jqGrid('setGridParam', {
            postData: { keyword: $("#txt_keyword").val() },
        }).trigger('reloadGrid');
    });
}
function btn_add() {
    $.modalOpen({
        id: "UserEdit",
        title: "新增",
        url: "/User/UserEdit",
        width: "700px",
        height: "510px",
        callBack: function (iframeId) {
            top.frames[iframeId].submitForm();
        }
    });
}
function btn_edit() {
    var keyValue = $("#gridList").jqGridRowValue().ID;
    $.modalOpen({
        id: "UserEdit",
        title: GlobalResx.edit,
        url: "/User/UserEdit?ID=" + keyValue,
        width: "700px",
        height: "510px",
        callBack: function (iframeId) {
            top.frames[iframeId].submitForm();
        }
    });
}
function btn_delete() {
    $.deleteForm({
        url: "Delete",
        param: { ID: $("#gridList").jqGridRowValue().ID },
        success: function () {
            $.currentWindow().$("#gridList").trigger("reloadGrid");
        }
    })
}
function btn_disabled() {
    var keyValue = $("#gridList").jqGridRowValue().ID;
    $.modalConfirm(PageResx.confirm4disable, function (r) {
        if (r) {
            $.submitForm({
                url: "UpdateIsAble",
                param: { ID: keyValue, IsAble: false },
                success: function () {
                    $.currentWindow().$("#gridList").trigger("reloadGrid");
                }
            })
        }
    });
}
function btn_enabled() {
    var keyValue = $("#gridList").jqGridRowValue().ID;
    $.modalConfirm(PageResx.confirm4enable, function (r) {
        if (r) {
            $.submitForm({
                url: "/User/UpdateIsAble",
                param: { ID: keyValue, IsAble: true },
                success: function () {
                    $.currentWindow().$("#gridList").trigger("reloadGrid");
                }
            })
        }
    });
}