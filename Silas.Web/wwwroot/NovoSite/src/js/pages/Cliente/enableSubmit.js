
var $input = document.getElementById('confirmacao');
var $codigo = document.getElementById('codigo');
var $submit = document.getElementById('btn-submit');


setInterval(()=>{
    enable();
},1000)
function enable() {
    if ($input.value == $codigo.value) {
        $submit.disabled = false;
    }
    else {
        $submit.disabled = true;
    }

}