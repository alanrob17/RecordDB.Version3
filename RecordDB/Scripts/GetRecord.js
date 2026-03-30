$(document).ready(function () {
    $('#recordFormView').hide().fadeIn(2000);

    var media = $('#media').text();

    switch (media) {
        case "CD":
            $('#media').text('CD-Audio');
            break;
        case "CD/Blu-ray":
            $('#media').text('CD-Audio & Blu-ray');
            break;
        case "CD/DVD":
            $('#media').text('CD-Audio & DVD');
            break;
        case "R":
            $('#media').text('Record');
            break;
    }

    var rating = $('#rating').text();

    switch (rating) {
        case "*":
            $('#rating').text('Mediocre');
            break;
        case "**":
            $('#rating').text('Average');
            break;
        case "***":
            $('#rating').text('Slightly flawed');
            break;
        case "****":
            $('#rating').text('Indispensible');
            break;
    }

    var pressing = $('#pressing').text();

    switch (pressing) {
        case "Am":
            $('#pressing').text('USA');
            break;
        case "Aus":
            $('#pressing').text('Australia');
            break;
        case "Can":
            $('#pressing').text('Canada');
            break;
        case "Eng":
            $('#pressing').text('UK');
            break;
        case "Fra":
            $('#pressing').text('France');
            break;
        case "Ger":
            $('#pressing').text('Germany');
            break;
        case "Hk":
            $('#pressing').text('Hong Kong');
            break;
        case "Hol":
            $('#pressing').text('Holland');
            break;
        case "Ita":
            $('#pressing').text('Italy');
            break;
        case "Jap":
            $('#pressing').text('Japan');
            break;
        case "Kor":
            $('#pressing').text('Korea');
            break;
        case "Swe":
            $('#pressing').text('Swedan');
            break;
        case "Swi":
            $('#pressing').text('Switzerland');
            break;
    }

    $('#biography').hide();
    $('#biographyButton').click(function () {
        if ($('#biography').is(':visible')) {
            $('#biography').hide();
        } else {
            $('#biography').show();
        }
    });

    $('#review').hide();
    $('#showButton').click(function () {
        if ($('#review').is(':visible')) {
            $('#review').hide();
        } else {
            $('#review').show();
        }
    });

});
