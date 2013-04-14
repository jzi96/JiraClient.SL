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
                newValue = " ";
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
    //workround

    var value = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
    //alert(value.toISOString("HH:mm DD.MM.YYYY"));
    return PadLeftDT(value.getHours()) + ":" + PadLeftDT(value.getMinutes()) + " " + PadLeftDT(value.getDay()) + "." + PadLeftDT((value.getMonth())) + "." + value.getFullYear();
}
function PadLeftDT(value) {
    return PadLeft(value, 2, '0');
}
function PadLeft(value, num, padChar) {
    var lng = value.toString().length;
    if (lng > num)
        return value;
    lng = num - lng;
    for (i = 0; i < lng; i++) {
        value = padChar + value;
    }
    return value;
}
var ConvertToMinuteFactor = 60;
var ConvertToHourFactor = 60 * ConvertToMinuteFactor;
var ConvertToDayFactor = 8 * ConvertToHourFactor;
var ConvertToWeekFactor = 5 * ConvertToDayFactor;
var FactorsHirachy = [ConvertToWeekFactor, ConvertToDayFactor, ConvertToHourFactor, ConvertToMinuteFactor, 1];
var MarkersHirachy = ["w", "d", "h", "m", "s"];
function TimespentFriendlyConverter(timeSpentInSec, pos) {

    if (!pos)
        pos = 0;
    if (!timeSpentInSec)
        return "";

    var build = "";
    var factor = FactorsHirachy[pos];
    if (timeSpentInSec > factor) {
        build = Math.floor(timeSpentInSec / factor) + MarkersHirachy[pos];
        timeSpentInSec = timeSpentInSec % factor;
    }
    build = build + TimespentFriendlyConverter(timeSpentInSec, pos+1);
    return build;
}
function HighlightChange(item, depth, onComplete) {
    if (!depth) {
        onComplete($(item));
        return;
    }
    $(item).fadeToggle(300, "swing", function () { HighlightChange($(this), depth - 1, onComplete); });
    return $(item);
}
