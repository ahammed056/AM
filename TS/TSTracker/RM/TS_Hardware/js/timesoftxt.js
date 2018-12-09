$(document).ready(function () {
    $("#<%=TextBox1.ClientID %>").dynDateTime({
        showsTime: true,
        ifFormat: "%d/%m/%Y %H:%M",
        daFormat: "%l;%M %p, %e %m,  %Y",
        align: "BR",
        electric: false,
        singleClick: false,
        displayArea: ".siblings('.dtcDisplayArea')",
        button: ".next()"
    });
});