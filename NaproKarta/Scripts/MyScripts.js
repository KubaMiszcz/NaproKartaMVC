function InitPageSettings() {
    var ciphers = document.getElementsByName("Observation.Cipher.Value");
    var ciphersCD = document.getElementsByName("Observation.CipherCD.Value");
    for (var i = 0; i < ciphers.length; i++) {
        var cipherId = ciphers[i].id;
        if (cipherId === "6" || cipherId === "8" || cipherId === "10") {
            for (var i = 0; i < ciphersCD.length; i++) {
                ciphersCD[i].disabled = true;
            }
        }
    }
}

function SetProperty(propName, val) {
    document.getElementById(propName).value = val;
    //alert(val);
}

function ChangeSelectedChart(userId, dropdown) {
    //alert(dropdown.options[dropdown.selectedIndex].value);
    var chartID = dropdown.options[dropdown.selectedIndex].value;
    window.location.href = '/User/Chart/' + userId + '?chartId=' + chartID;
}

function NoteMarkUpdateLetter(id, markId) {
    var note = document.getElementById(id);
    var NoteMarkId = document.getElementById(markId);
    NoteMarkId.value = note.value.trim().substring(0, 1).toUpperCase();
}

function NoteMarkUpdateColor(id, markId) {
    var notecbox = document.getElementById(id);
    var NoteMarkId = document.getElementById(markId);
    if (notecbox.checked) {
        NoteMarkId.style.backgroundColor = "red";
    }
    else {
        NoteMarkId.style.backgroundColor = "white";
    }
}













function ToggleCipherCD(id) {
    var cipherVal = document.getElementById(id).id;
    var ciphersCD = document.getElementsByName("Observation.CipherCD.Value");
    if (cipherVal === "6" || cipherVal === "8" || cipherVal === "10") {
        for (var i = 0; i < ciphersCD.length; i++) {
            ciphersCD[i].disabled = true;
            //ciphersCD[i].checked = "unchosen";
            //ciphersCD[i].css.color("color", "red");
            //alert(ciphersCD[i].style.color);
        }
    } else {
        //alert("nok");
        for (var i = 0; i < ciphersCD.length; i++) {
            ciphersCD[i].disabled = false;
            //ciphersCD[i].checked = "unchosen";
            //ciphersCD[i].css.color("color", "green");
            //ciphersCD[i].style.color = "red";
            //alert(ciphersCD[i].style.color);
        }
    }
}

function ColorOnCheck(id) {
    var div = document.getElementsByTagName("div");
    // alert(div.length);
    for (var i = 0; i < div.length; i++) {
        if (div.className === "rchecked") div.className = "runchecked";
        else if (div.className === "runchecked") div.className = "rchecked";
    }
}




