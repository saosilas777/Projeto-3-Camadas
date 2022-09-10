const domCampo1 = document.getElementById("example-text-input");
const domBtnSubmit = document.getElementById("btn-submit");

function initDOM() {
    setTimeout(function () {
        alert("Pagina JavaScript");
    }, 3000);

    domCampo1.value = "Olá";

    domBtnSubmit.addEventListener("click", alterarCampo1);
}
function alterarCampo1() {
    domCampo1.value = "Tchau!";
}

initDOM();