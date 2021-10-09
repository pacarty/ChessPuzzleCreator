function loadPage() {
    document.getElementById("displayArea").innerHTML = "placeholder";

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("displayArea").innerHTML = this.responseText;
        }
    };

    xhttp.open("GET", "api/Example/GetModels");
    xhttp.send();
}

function postModel() {
    var userInput = document.getElementById("textField").value;

    var data = new FormData();
    data.append("name", userInput);

    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
        }
    };

    xhttp.open("POST", "api/Example/PostModel");
    xhttp.send(data);
}