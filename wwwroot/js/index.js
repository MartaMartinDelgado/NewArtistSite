console.log("hello");

// in js
//var theForm = document.getElementById("theForm");
//theForm.hidden = true;

// with jQuery
var theForm = $("#theForm");
theForm.hide();
// jQuery is more adaptable to the different browsers

var button = $("#updateContent");
button.on("click", function () {
    console.log("Updating Info");
});

var musicianInfo = $(".musician-props li");
musicianInfo.on("click", function () {
    console.log("You clicked on " + $(this).text());
});
