var ID = $.request("ID");
$(function () {
    initControl();
    if (!!ID) {
        $("#txtPassword").val("******").attr('disabled', 'disabled');
        $("#txtAccountName").attr('disabled', 'disabled');
        $("#sltDepartmentId").val($("#sltDepartmentId").attr("value"));
        $("#sltRoleId").val($("#sltRoleId").attr("value"));
        $("#sltIsAble").val($("#sltIsAble").attr("value") == undefined ? "false" : "true");
        if ($("#txtEntrydate").data("value") != "") {
            $("#txtEntrydate").val(new Date($("#txtEntrydate").data("value")).Format("yyyy-MM-dd"));
        }
        if ($("#txtBirthday").data("value") != "") {
            $("#txtBirthday").val(new Date($("#txtBirthday").data("value")).Format("yyyy-MM-dd"));
        }
        $("#txtRealName").val($.trim($("#txtRealName").val()));
    }
});
function initControl() {
    var topData = top.clients;
    $("#sltRoleId").bindSlt(topData.groups);
    $("#sltDepartmentId").bindSltSpe({
        id: "id", name: "name", data: topData.departments
    });
}
function submitForm() {
    if (!$('#UserEidt').formValid()) {
        return false;
    }
    var userEntity = $("#UserEidt").dataSerialize();
    if (userEntity.Password != "******") {
        userEntity.Password = $.md5($.trim(userEntity.Password));
    }
    $.submitForm({
        url: "/User/" + (!!ID == true ? "Update":"Add"),
        param: userEntity,
        success: function () {
            $.currentWindow().$("#gridList").trigger("reloadGrid");
        }
    })
}