
    //定义方法
    (function ($) {

        $.login = {
            //展示信息方法
            formMessage: function (msg) {
                $('.login_tips').find('.tips_msg').remove(); //删除原有的div信息
                $('.login_tips').append('<div class="tips_msg"><i class="fa fa-question-circle"></i>' + msg + '</div>'); //显示后端返回的msg
            },
            //登录点击方法
            loginClick: function () {
                var $username = $("#txt_account");
                var $password = $("#txt_password");
                var $code = $("#txt_code");
                if ($username.val() == "") {
                    $("#txt_account").focus();
                    $.login.formMessage('请输入用户名/手机号/邮箱。');
                    return false;
                } else if ($password.val() == "") {
                    $password.focus();
                    $.login.formMessage('请输入登录密码。');
                    return false;
                } else if ($code.val() == "") {
                    $code.focus();
                    $.login.formMessage('请输入验证码。');
                    return false;
                } else {
                    $("#login_button").attr('disabled', 'disabled').find('span').html("正在登录中..."); //button属性设为disabled
                    //用ajax发送登录信息到服务器
                    $.ajax({
                        url: "/Login/CheckLogin", //请求LoginController的CheckLogin方法
                        data: { username: $.trim($username.val()), password: $.md5($.trim($password.val())), code: $.trim($code.val()) },//password进行了md5加密
                        type: "post", //Post请求
                        dataType: "json", //json格式发送
                        success: function (data) { //data为服务器返回的数据
                            if (data.state == "success") {
                                $("#login_button").find('span').html("登录成功，正在跳转...");
                                window.setTimeout(function () {
                                    window.location.href = "/Home/Index";
                                }, 500);  //500ms延时之后转向HomeController:Index
                            } else {
                                $("#login_button").removeAttr('disabled').find('span').html("登录");
                                $("#switchCode").trigger("click");  //触发switchCode元素Click事件
                                $code.val('');
                                $.login.formMessage(data.message);
                            }
                        }
                    });
                }
            },
            //初始化
            init: function () {
                $('.wrapper').height($(window).height());
                $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
                $(window).resize(function (e) {
                    $('.wrapper').height($(window).height());
                    $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
                });  //调整页面大小
                //获取验证码
                $("#switchCode").click(function () {
                    $("#imgcode").attr("src", "/Login/GetAuthCode?time=" + Math.random()); //attr为元素设置属性，这里为img标签的src属性指向/Login/GetAuthCode?time=" + Math.random()来得到一个验证码图片
                });
                var login_error = top.$.cookie('ACA_login_error'); //获取ACA_login_error cookie
                if (login_error != null) {
                    switch (login_error) {
                        case "overdue":
                            $.login.formMessage("系统登录已超时,请重新登录");
                            break;
                        case "OnLine":
                            $.login.formMessage("您的帐号已在其它地方登录,请重新登录");
                            break;
                        case "-1":
                            $.login.formMessage("系统未知错误,请重新登录");
                            break;
                    }
                    top.$.cookie('ACA_login_error', '', { path: "/", expires: -1 });
                }
                //login_button.Click=>$.login.loginClick()
                $("#login_button").click(function () {
                    $.login.loginClick();
                });
                //回车登录
                document.onkeydown = function (e) {
                    if (!e) e = window.event;
                    if ((e.keyCode || e.which) == 13) {
                        document.getElementById("login_button").focus();
                        document.getElementById("login_button").click();
                    }
                }
            }
        };
    //&(function(){}当文档加载完毕执行
    $(function () {
        $.login.init();
    });
})(jQuery);