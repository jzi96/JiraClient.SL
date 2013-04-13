function RegisterForInlineEditing(ctrl) {
    RegisterForInlineEditingItem($(ctrl));
}
function RegisterForInlineEditingItem(ctrlAsElement, formatting) {
    ctrlAsElement.click(function () {
        var userName = $(this).text();
        var input = $("<input type='text' value='" + userName + "'/>");
        if(formatting != null)
            $(input).addClass(formatting);
        $(this).empty().append($(input));
        $(input).select();
        $(input).focusout(function () {
            var userName = $(this).val();
            $(this).parent().empty().text(userName);
        });
        //register ...
    }).hover(function () {
        $(this).addClass("hover");
    }, function () {
        $(this).removeClass("hover");
    });

}


function FormatDate(jsonDate) {
    var value = new Date(jsonDate);
    //alert(value.toISOString("HH:mm DD.MM.YYYY"));
    return value.toLocaleString();  //value.getHours() + ":" + value.getMinutes() + " " + value.getDay() + "." + (value.getMonth()+1) + "." + value.getYear();
}
