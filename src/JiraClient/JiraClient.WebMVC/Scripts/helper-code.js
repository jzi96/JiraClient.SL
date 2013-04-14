function RegisterForInlineEditing(ctrl) {
    RegisterForInlineEditingItem($(ctrl));
}
function RegisterForInlineEditingItem(ctrlAsElement, formatting, onEditFinish) {
    ctrlAsElement.data("onEditFinishFunction", onEditFinish);
    ctrlAsElement.click(function () {
        var userName = $(this).text();
        var input = $("<input type='text' value='" + userName + "'/>");
        if (formatting != null)
            $(input).addClass(formatting);
        $(this).data("oldValue", userName);
        $(this).empty().append($(input));
        $(input).select();
        $(input).focusout(function () {
            var newValue = $(this).val();
            //if empty add a space, otherwise the area may gone!
            if (!newValue)
                newValue = "&nbsp;";
            var parentItem = $(this).parent();
            var oldValue = parentItem.data("oldValue");
            var onEditFinish = parentItem.data("onEditFinishFunction");
            parentItem.html("").text(newValue);
            parentItem.removeData("oldValue");
            if (onEditFinish)
                onEditFinish(parentItem, newValue, oldValue);
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
