function play() {
    window.location = "play.html";
}

function loadExamplePage() {
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

function register() {
    window.location = "user/register.html";
}

function registerNewUser() {

    var username = document.getElementById("newUsername").value;
    var password = document.getElementById("newPassword").value;

    console.log(username);
    console.log(password);

    if (username == "" || password == "") {
        alert("Fields cannot be empty");
    } else {
        
        var data = new FormData();
        data.append("username", username);
        data.append("password", password);

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                console.log(this.responseText);
            }
        };

        xhttp.open("POST", "../api/Users/RegisterUser");
        xhttp.send(data);

    }
}

function sendUserCredentials() {
    
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    console.log(username);
    console.log(password);

    if (username == "" || password == "") {
        alert("Fields cannot be empty");
    } else {
        
        var data = new FormData();
        data.append("username", username);
        data.append("password", password);

        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                console.log(this.responseText);
            }
        };

        xhttp.open("POST", "../api/Users/Authenticate");
        xhttp.send(data);

    }
}