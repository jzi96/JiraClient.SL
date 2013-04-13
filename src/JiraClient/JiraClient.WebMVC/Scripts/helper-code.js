function RegisterForInlineEditing(ctrl) {
    $(ctrl).click(function () {
        var userName = $(this).text();
        var input = $("<input type='text' value='" + userName + "'/>");
        $(this).empty().append($(input));
        $(input).select();
        $(input).focusout(function () {
            var userName = $(this).val();
            $(this).parent().empty().text(userName);
        });
        //register ...
    });
    $(ctrl).hover(function () {
        $(this).addClass("hover");
    }, function () {
        $(this).removeClass("hover");
    });
}
