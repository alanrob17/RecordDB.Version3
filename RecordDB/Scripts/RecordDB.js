$(document).ready(function() {
    function ShowTime() {
        var dt = new Date();
        var hours = dt.getHours();
        var part = "am";
        if (hours > 12) {
            hours -= 12;
            part = "pm";
        }
        var newtime = +hours + ":" + dt.getMinutes() + part;
        if (dt.getMinutes() < 10) {
            newtime = newtime.replace(":", ":0");
        }
        document.getElementById('<%= textClock.ClientID %>').value = newtime;
        window.setTimeout("ShowTime()", 100);
    }

    function runCode() {
        window.setTimeout("ShowTime()", 1000);
    }
});

 