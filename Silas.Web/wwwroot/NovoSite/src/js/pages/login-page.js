//#region DOM ELEMENTS
const domUserName = document.getElementById("username");
const domPwd = document.getElementById("password");
const domForgotPass = document.getElementById("kt_login_forgot");
const domBtnEnter = document.getElementById("kt_login_signin_submit");
const domSign = document.getElementById("kt_login_signup");
const domFullName = document.getElementById("fullName");
const domSEmail = document.getElementById("sEmail");
const domSPass = document.getElementById("sPassword");
const domCPass = document.getElementById("cPassword");

//#endregion

function initDOM() {
    if (!(domBtnEnter === null)){
        domBtnEnter.addEventListener('click', login);
    }
    
}

function login() {
   
    const btn = document.getElementById("kt_login_signin_submit");
    if (domUserName.value == "" || domPwd.value == "")
        return;
    
    var model = { username: domUserName.value, password: domPwd.value };
    $.post("/Authentication", model, function (data) {       
        jsonResponse = data;  
        console.log("passou");
    }).done(function () {
    }).fail(function (e) {
        
        var json = JSON.parse(e.responseText);
        var msg = "Code: " + json.code + "\nError Msg: " + json.errorMessage + "\nMsg: " + json.message;
        alert(msg);
        console.log(e.responseText);
    });
}

var $btnForget = document.getElementById('kt_login_forgot_form_btn');
var $btnSignUp = document.getElementById('kt_login_signup_btn');
$btnForget.addEventListener('click', loginForgot);
$btnSignUp.addEventListener('click', signUp);

function loginForgot() {

    document.getElementById('kt_login_signin').style.display = 'none';
    document.getElementById('kt_login_forgot').style.display = 'block';

}
function signUp() {
    document.getElementById('kt_login_signin').style.display = 'none';
    document.getElementById('kt_login_signup').style.display = 'block';
}
initDOM();