$(document).ready(function(){
    getRecipeOfTheDay();
    $("#AddBtn").on("click", goToAdd);
});

function getRecipeOfTheDay() {
    $.ajax({
        url: "/Recipe/RecipeOfTheDay",
        success: function (view) {
            $("#RecipeOfTheDay").html(view);
            $("#EditBtn").on("click", goToEdit);
            $("#ViewBtn").on("click", goToView);
        }
    });
}

function goToEdit() {
    var url = 'Recipes/Edit/' + $('#RecipeId')[0].value;
    window.location.href = url;
}

function goToView() {
    var url = 'Recipes/Details/' + $('#RecipeId')[0].value;
    window.location.href = url;
}

function goToAdd() {
    var url = 'Recipes/Edit/';
    window.location.href = url;
}