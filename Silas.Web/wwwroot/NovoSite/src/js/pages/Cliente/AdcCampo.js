var controleCampo = 1;
function adcCampo() {
    controleCampo++;
    document.getElementById('telefone').insertAdjacentHTML('afterend','<div class="form-group row" id="telefone"><label for="example-password-input" class="col-2 col-form-label">Telefone</label><div class="col-10"><output class="form-control" type="number" name="telefone"></output></div>');
}

