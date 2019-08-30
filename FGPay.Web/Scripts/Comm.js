//绑定下拉框，data数据集[只支持字典模式],vle选中值
$.fn.bindSlt = function (data) {
    var $element = $(this);
    $.each(data, function (i) {
        $element.append($("<option></option>").val(i).html(data[i]));
    });
}

 // 绑定下拉框，指定id,name
$.fn.bindSltSpe = function (obj) {
    var $element = $(this);
    $.each(obj.data, function (i, n) {
        $element.append($("<option></option>").val(n[obj.id]).html(n[obj.name]));
    });
}

// 生成下拉选项
$.generateSlt = function (obj) {
    var strSlt = "";
    $.each(obj.data, function (i, val) {
        strSlt += '<option value="' + val[obj.val] + '" >' + val[obj.name] + '</option>';
    });
    return strSlt;
}

// 依赖bootstrap-select重新渲染
$.renderSlt = function (obj) {
    $(obj.ele).children().remove();
    if (obj.data != null && obj.data.length > 0) {
        $(obj.ele).bindSltSpe({
            id: obj.val, name: obj.name, data: obj.data
        });
    }
    // 刷新
    $(obj.ele).selectpicker('refresh');
}

//表单验证
$.fn.formValid = function () {
    return $(this).valid({
        errorPlacement: function (error, element) {
            element.parents('.formValue').addClass('has-error');
            element.parents('.has-error').find('i.error').remove();
            element.parents('.has-error').append('<i class="form-control-feedback fa fa-exclamation-circle error" data-placement="left" data-toggle="tooltip" title="' + error + '"></i>');
            $("[data-toggle='tooltip']").tooltip();
            if (element.parents('.input-group').hasClass('input-group')) {
                element.parents('.has-error').find('i.error').css('right', '33px')
            }
        },
        success: function (element) {
            element.parents('.has-error').find('i.error').remove();
            element.parent().removeClass('has-error');
        }
    });
}

//收集表单数据生成对象
$.fn.dataSerialize = function () {
    var element = $(this);
    var postdata = {};
    element.find('input,select,textarea').each(function (r) {
        var $this = $(this);
        var id = $this.attr('id');
        var dataID = id.substr(3);
        var type = $this.attr('type');
        switch (type) {
            case "checkbox":
                postdata[dataID] = $this.is(":checked");
                break;
            default:
                var value = $this.val() == "" ? "&nbsp;" : $.trim($this.val());
                if (!$.request("keyValue")) {
                    value = value.replace(/&nbsp;/g, '');
                }
                postdata[dataID] = value;
                break;
        }
    });
    return postdata;
};
// 时间格式转换
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "H+": this.getHours(), //小时
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}