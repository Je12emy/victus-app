function SelectThis(radio) {
    UnselectAll();
    radio.style.backgroundColor = "#ecf0f1";
    radio.style.color = "#2c3e50";
    radio.style.border = "2px solid #ecf0f1";
}
function UnselectAll() {
    var options = document.getElementsByClassName("button_radio");
    for (var i = 0; i < options.length; i++) {
        
        options[i].style.background = "none";
        options[i].style.border = "2px solid #3498db";
        options[i].style.color = "white";
    }
}