$(document).ready(function(){
    getRecipeOfTheDay();
});

function getRecipeOfTheDay() {
    $.ajax({
        url: "/Recipe/RecipeOfTheDay",
        success: function (view) {
            $("#RecipeOfTheDay").html(view);
        }
    });
}