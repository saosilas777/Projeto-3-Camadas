var campoTel = 1;
function AdcTelefone() {
    
    if (campoTel < 3) {
        document.getElementById('telefone').insertAdjacentHTML('afterbegin','<div id="telefone" class="form-group"><div class="inputBtn"><label>Telefone</label><input class="ylw form-control inputs" type="tel" placeholder="(XX)XXXXX-XXXX" name="Telefone" maxlength="11"/></div></div> ')
    }
    campoTel++;
    
}
campoMail = 1;
function AdcEmail() {
    
    if (campoMail < 3) {
        document.getElementById('email').insertAdjacentHTML('afterbegin', '<div id="email" class="efect form-group"><div class="inputBtn"><label>Email</label><input class="ylw form-control inputs" type="email" placeholder="autopecas@email.com" id="email" name="Email" required /></div></div>')
    }
    campoMail++;
}



   
    
var $input = document.querySelectorAll('.inputs');

$($input).keyup(function (e) {
    if (e.which === 13) {
        
        var index = $($input).index(this) + 1;
        
        $($input).eq(index).focus();
    }
});



function submite() {
    var $btnSubmite = document.getElementById('submit-form'); 
    $btnSubmite.disabled = false;
    $btnSubmite.click();
}