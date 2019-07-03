var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("tab");
    // Aca agarrar a todos los "tabs" del form.
    x[n].style.display = "block";
    // Aca muestra el tab deseado.

    //... and fix the Previous/Next buttons:
    // Habilitacion de los botones de Previous y Next
    if (n == 0) {
        // Si nos encontramos en el primer tab de nuestro form.
        document.getElementById("prevBtn").style.display = "none";
        // No mostrar el boton de Siguiente, pues no hay nada a que volver.
    } else {
        document.getElementById("prevBtn").style.display = "inline";
        // Mostrar el boton de Previous
    }
    if (n == (x.length - 1)) {
        // Si nos encontramos en el ultimo boton
        document.getElementById("nextBtn").innerHTML = "Submit";
        // Cambiar el texto del boton a Submit
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
        // Seguir mostrando el boton.
    }
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // Metodo llamado por el click de los botones.
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");
    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value == "") {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false
            valid = false;
        }
    }
    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    // Modifica el indicador del paso activo.
    var i, x = document.getElementsByClassName("step");
    // Agarra a todos los indicadores 'step'
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
        // Remover la propiedad de active
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}