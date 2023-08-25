function deshabilitarBoton() {
    let boton = document.getElementById("boton");
    boton.innerHTML=">>>>";
    boton.style.backgroundColor = "yellow"; // o cualquier otro color
    boton.disabled=false;    
}