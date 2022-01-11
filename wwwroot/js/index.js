// Usin jQuery as it is more adaptable to the different browsers

// To execute the block of code only once the page has been completely loaded
$(document).ready(function () {
    // All code inside this function is visible to each other
    // But it is not leaked into the global scope

    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#updateContent");
    button.on("click", function () {
        console.log("Updating Info");
    });

    var musicianInfo = $(".musician-props li");
    musicianInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.fadeToggle(1000);
    })

});