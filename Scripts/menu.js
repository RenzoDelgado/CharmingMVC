
let btnMensu = document.getElementById('btnmenu');
let menu = document.getElementById('menu');

btnMensu.addEventListener('click', function () {
    menu.classList.toggle('mostrar');

    //menu.addEventListener('mouseleave', function () {
    //    menu.classList.toggle('esconder');

    //});
});