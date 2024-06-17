// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 function  deleteTodo(itemID){
    $.ajax({ //ajax call with JQuery
        url: 'Home/Delete',
        type: 'POST',
        data: {
            id: itemID
        },
        success: function(){
            window.location.reload();
        }
    });
 }

 function populateForm(itemID){
    $.ajax({
        url: 'Home/PopulateForm',
        type: 'Get',
        data: {
            id: itemID
        },
        dataType: 'json',
        success: function (response){
            $("#Todo_Name").val(response.name);
            $("#Todo_Id").val(response.id);
            $("#form-button").val("Update Todo");
            $("#form-action").attr("action", "/Home/Update")
        }
    })
 }

 function displayLogin(){
    alert("button works!");
 }