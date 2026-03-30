    var yr = new Date();
    var year = yr.getFullYear();

    function ShowTime() {
            var dt = new Date();
    var hours = dt.getHours();

    var part = "am";
            if (hours >= 12) {
                if (hours > 12) {
        hours -= 12;
                }
    part = "pm";
            }

    // Adjust for midnight
    if (hours === 0) {
        hours = 12;
            }

    var newtime = +hours + ":" + dt.getMinutes() + part;
    if (dt.getMinutes() < 10) {
        newtime = newtime.replace(":", ":0");
            }
    document.getElementById('<%= textClock.ClientID %>').value = newtime;
    window.setTimeout(ShowTime, 100);
        }

    function runCode() {
        window.setTimeout(ShowTime, 1000);
        }

    $(document).ready(function () {
        $('div.row').hide().fadeIn(1000);
    $('h2.headerLabel').css('text-align', 'center');
    $('h3.dateLabel').css('text-align', 'center');
    $('h4.clockFace').css('text-align', 'center');
    $('#<%=textClock.ClientID %>').css('text-align', 'center');
    runCode();
        });
