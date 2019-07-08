$(document).ready(function() {
    loadDvds();

    $('#add-Dvd').click(function (event) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:55825/dvd',
            data: JSON.stringify({
                title: $('#add-Dvd-Title').val(),
                releasedYear: $('#add-Dvd-Year').val(),
                director: $('#add-Dvd-Director').val(),
                rating: $('#add-Dvd-Rating').val(),
                notes: $('#add-Dvd-Notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function(data, status) {
                $('#errorMessages').empty();
                $('#add-Dvd-Title').val('');
                $('#add-Dvd-Year').val('');
                $('#add-Dvd-Director').val('');
                $('#add-Dvd-Rating').val('');
                $('#add-Dvd-Notes').val('');
                alert('success');
                loadDvds();
                $('#add-Dvd-Form').hide();
                $('#dvdTable').show();
           } ,
            error: function(xhr, errorType, exception){
                var responseText;
                $("#dialog").html("");
                
                    alert(xhr.responseText);
                    $("#dialog").append("<div><b>" + errorType + " " + exception + "</b></div>");
                    $("#dialog").append("<div><u>Exception</u>:<br /><br />" + responseText.ExceptionType + "</div>");
                    $("#dialog").append("<div><u>StackTrace</u>:<br /><br />" + responseText.StackTrace + "</div>");
                    $("#dialog").append("<div><u>Message</u>:<br /><br />" + responseText.Message + "</div>");
                
            }
        })
    });
    $('#save-changes').click(function (dvdId) {
        $.ajax({
            type: 'PUT',
            url:'http://localhost:55825/dvd/' + $('#edit-Dvd-Id').val(),
            data: JSON.stringify({
                dvdId: $('#edit-Dvd-Id').val(),
                title: $('#edit-Dvd-Title').val(),
                releasedYear: $('#edit-Dvd-Year').val(),
                director: $('#edit-Dvd-Director').val(),
                rating: $('#edit-Dvd-Rating').val(),
                notes: $('#edit-Dvd-Notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function(data, status) {
                $('#errorMessages').empty();
                $('#edit-Dvd-Title').val('');
                $('#edit-Dvd-Year').val('');
                $('#edit-Dvd-Director').val('');
                $('#edit-Dvd-Rating').val('');
                $('#edit-Dvd-Notes').val('');
                alert('success');
                loadDvds();
                $('#edit-Dvd-Form').hide();
                $('#dvdTable').show();
            },
            error: function() {
                alert("failed");
            }
        })
    });
});

function loadDvds() {
    $('#contentRows').empty();
    var contentRows = $('#contentRows');
    $.ajax({
        type: 'GET',
        url: 'http://localhost:55825/dvds',
        success: function(dvdarray) {
            $.each(dvdarray, function(index, dvd) {
                var title = dvd.title;
                var releasedYear = dvd.releasedYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.dvdId;

                var row = '<tr>';
                    row +='<td>' + title + '</td>';
                    row += '<td>' + releasedYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button onclick="showEditDvd(' + id + ')">Edit</button></td>';
                    row += '<td><button onclick="deleteDvd(' + id + ')">Delete</button></td>';
                    row +='</td>'

                contentRows.append(row);
            });
            
        },
        error: function() {
          $('#errorMessages') 
            .append($('<li>')
            .atte({class: 'list-group-item'})
            .text('Error calling web ServiceUIFrameContext. please try again localStorage.'));
        }
    });
}
function search(){
    $('#contentRows').empty();
    var searchType = $('#searchCatagory').val();
    var contentRows = $('#contentRows');
    if(searchType == "title"){
        $.ajax({
            type: 'GET',
            url: 'http://localhost:55825/dvds/title/' + $('#term').val(),
            success: function(data, status){
                
                $.each(data, function(index, dvd) {
                    var title = dvd.title;
                    var releasedYear = dvd.releasedYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var id = dvd.dvdId;

                    var row = '<tr>';
                    row +='<td>' + title + '</td>';
                    row += '<td>' + releasedYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button onclick="showEditDvd(' + id + ')">Edit</button></td>';
                    row += '<td><button onclick="deleteDvd(' + id + ')">Delete</button></td>';
                    row +='</td>';


                contentRows.append(row);
                });
            },
            error: function() {

            }
        });
    }
    if(searchType == "realeaseYear"){
        $.ajax({
            type: 'GET',
            url: 'http://localhost:55825/dvds/year/' + $('#term').val(),
            success: function(data, status){
                $.each(data, function(index, dvd) {
                    var title = dvd.title;
                    var releasedYear = dvd.releasedYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var id = dvd.dvdId;

                    var row = '<tr>';
                    row +='<td>' + title + '</td>';
                    row += '<td>' + releasedYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button onclick="showEditDvd(' + id + ')">Edit</button></td>';
                    row += '<td><button onclick="deleteDvd(' + id + ')">Delete</button></td>';
                    row +='</td>';


                contentRows.append(row);
                });
            },
            error: function() {

            }
        });
    }
    if(searchType == "director"){
        $.ajax({
            type: 'GET',
            url: 'http://localhost:55825/dvds/director/' + $('#term').val(),
            success: function(data, status){
                $.each(data, function(index, dvd) {
                    var title = dvd.title;
                    var releasedYear = dvd.releasedYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var id = dvd.dvdId;

                    var row = '<tr>';
                    row +='<td>' + title + '</td>';
                    row += '<td>' + releasedYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button onclick="showEditDvd(' + id + ')">Edit</button></td>';
                    row += '<td><button onclick="deleteDvd(' + id + ')">Delete</button></td>';
                    row +='</td>';


                contentRows.append(row);
                });
            },
            error: function() {

            }
        });
    }
    if(searchType == "rating"){
        $.ajax({
            type: 'GET',
            url: 'http://localhost:55825/dvds/rating/' + $('#term').val(),
            success: function(data, status){
                $.each(data, function(index, dvd) {
                    var title = dvd.title;
                    var releasedYear = dvd.releasedYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var id = dvd.dvdId;

                    var row = '<tr>';
                    row +='<td>' + title + '</td>';
                    row += '<td>' + releasedYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><button onclick="showEditDvd(' + id + ')">Edit</button></td>';
                    row += '<td><button onclick="deleteDvd(' + id + ')">Delete</button></td>';
                    row +='</td>';

                contentRows.append(row);
                });
            },
            error: function() {

            }
        });
    }
}
function displayCreateTable() {
    $('#dvdTable').hide();
    $('#add-Dvd-Form').show();
}
function showEditDvd(dvdId) {
    $.ajax({
        type: 'GET',
        url:'http://localhost:55825/dvd/' + dvdId,
        success: function(data, status){
            $('#edit-Dvd-Title').val(data.title);
            $('#edit-Dvd-Year').val(data.releasedYear);
            $('#edit-Dvd-Director').val(data.director);
            $('#edit-Dvd-Rating').val(data.rating);
            $('#edit-Dvd-Notes').val(data.notes);
            $('#edit-Dvd-Id').val(data.dvdId);
        },
        error: function() {

        }
    });
    $('#dvdTable').hide();
    $('#edit-Dvd-Form').show();
}
function cancelButton(){
    $('#errorMessages').empty();
    $('#edit-Dvd-Title').val('');
    $('#edit-Dvd-Year').val('');
    $('#edit-Dvd-Director').val('');
    $('#edit-Dvd-Rating').val('');
    $('#edit-Dvd-Notes').val('');
    $('#edit-Dvd-Form').hide();
    $('#add-Dvd-Form').hide();
    $('#dvdTable').show();
}
function deleteDvd(dvdId) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:55825/dvd/' + dvdId,
        success: function (status) {
            alert('you did it');
            loadDvds();
        }
    });
    
}
