var campoTel = 1;
function AdcTelefone() {
    
    if (campoTel < 3) {
        document.getElementById('telefone').insertAdjacentHTML('afterend', '<div id="telefone" class="form-group row"><label for="example-password-input" class="col-2 col-form-label">Telefone</label> <div class="col-9"><input class="ylw form-control" type="tel" placeholder="(XX)XXXXX-XXXX" id="example-password-input" name="Telefone" maxlength="11"/></div></div>')
    }
    campoTel++;
    
}
campoMail = 1;
function AdcEmail() {
    
    if (campoMail < 3) {
        document.getElementById('email').insertAdjacentHTML('afterend', '<div id="email" class="form-group row"> <label for="example-number-input" class="col-2 col-form-label">Email</label><div class="col-9"><input class="ylw form-control" type="email" placeholder="autopecas@email.com" id="example-number-input" name="Email" /></div></div>')
    }
    campoMail++;
}



   
    
        
