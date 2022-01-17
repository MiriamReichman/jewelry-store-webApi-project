function login() {
    //fetch("api/Server/?email=" + document.getElementById("email").value + "&password=" + document.getElementById("password").value)
    fetch("api/Server/" + document.getElementById("email").value + "/" + document.getElementById("password").value)
        .then((response) => {

            if (response.ok && response.status == 200)
                return response.json()

            else {
                alert("there is no exsisting user with this password! ");
                document.getElementById("add").style.display = "block";
                return "erro";
            }
        })
        .then(data => {
            
            console.log(data);
            //alert("oooooo")
            if (data != "erro") {
                alert("welcome back " + data.firstName);
                sessionStorage.setItem('user', JSON.stringify(data));
                window.location.href = "welcomeBack.html";


            }

        }).catch((error) => { debugger;console.log(error); alert(error) });
}
function load() {
    var old = JSON.parse(sessionStorage.getItem('user'))

    document.getElementById("email1").value = old.email;
    document.getElementById("password1").value = old.password;
    document.getElementById("firstName1").value = old.firstName;
    document.getElementById("lastName1").value =old.lastName;

}

function sign() {
    fetch("api/Server", {
    method: 'POST',
        headers: {
        'Content-Type':'application/json'
    },
    body: JSON.stringify({
        Email: document.getElementById("email2").value,
        Password: document.getElementById("password2").value,
        FirstName: document.getElementById("firstName2").value,
        LastName: document.getElementById("lastName2").value,
 
    })
    
    }).then(response => {return response.json() })
    .then(data => {
        alert('Success:', data);
        
    })

}
function update() {
    var user= JSON.parse(sessionStorage.getItem('user'))
 
    fetch("api/Server/" + user.id , {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            Email: document.getElementById("email1").value,
            Password: document.getElementById("password1").value,
            FirstName: document.getElementById("firstName1").value,
            LastName: document.getElementById("lastName1").value,
            Id: user.id
        })
    }).then(response => { return response.json() })
        .then(data => {
            alert('updated Successfuly:'+ data.firstName);

        })

}
function enter() {
    window.location.href = "Products.html";
}
function ToUpdate() {
    window.location.href = "ExsistingUser.html";
}