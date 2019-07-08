$(document).ready(function () {
    $('#displayAmount').val("0");
    $('#displayMessage').val("");
    $('#idDisplay').val("");
    $('#displayChange').val("");
    loadItems();
});
function updateItems (){
    var amount = $('#displayAmount').val();
    var id = $('#idDisplay').val();
    $.ajax({
        type: 'POST',
        url: 'http://tsg-vending.herokuapp.com/money/' + amount + '/item/' + id,
        success: function(data) {
            $('#displayMessage').val('Thank You!');
            var changeQuarters = data.quarters; 
            var changeDimes = data.dimes;
            var changeNickels = data.nickels;
            var changePennies = data.pennies;

            $('#displayChange').val(changeQuarters + ' quarters, ' + changeDimes + ' dimes, ' + changeNickels + ' nickels, ' + changePennies + ' pennies');
            loadItems();
            $('#displayAmount').val("0");
        },
        error: function(result){
            $('#displayMessage').val(result.responseJSON.message);
        }
    });
};
function loadItems (){
    var contentCards = $('#cards');
    contentCards.empty();
    $.ajax({
        type: 'GET',
        url: 'http://tsg-vending.herokuapp.com/items',
        success: function(itemArray) {
            $.each(itemArray, function(index, item) {
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var card = '<div class="card float-left" onclick="itemClick(' + id + ')" id="item' + id + '">';
                    card += '<div class="card-body">';
                    card += '<p class="card-text"></p>';
                    card += '</div>';
                    card += '<div>' + id + '</div>';
                    card += '<div>' + name + '</div>';
                    card += '<div>' + price + '<div>';
                    card += '<div>' + quantity + '</div>';
                    card += '</div>';
                contentCards.append(card);
            });
        },
        error: function() {
            alert("failed");
        }
    });
};

function itemClick(id){
 $('#idDisplay').val(id);
};

function addMoney(amount){
    var money = $('#displayAmount').val();
    var newBalance = parseFloat(money);
    newBalance = amount + newBalance;
    $('#displayAmount').val(newBalance.toFixed(2));
}
function purchaseButton(){
    if($('#idDisplay').val() == ''){
        $('#displayMessage').val('Please make a selection.');
    }
    else{
        updateItems();
    }
}
function returnChange(){
    var value = $('#displayAmount').val();
    value = parseFloat(value) + .001;
    var changeQuarters = parseInt(value / .25);
    value = value - changeQuarters * .25;
    var changeDimes = parseInt(value / .10);
    value = value - changeDimes * .10;
    var changeNickels = parseInt(value / .05);
    value = value - changeNickels * .05;
    var changePennies = parseInt(value / .01);
    $('#displayAmount').val("0")
    $('#displayChange').val(changeQuarters + ' Quarters, ' + changeDimes + ' Dimes, ' + changeNickels + ' Nickels, ' + changePennies + ' Pennies');
    
}