var slideIndex = 1;
//var pom = document.getElementById("skriven");
//showDivs(slideIndex, pom.value);

var pom = document.getElementsByClassName("cont");
var i;
for (i = 0; i < pom.length; i++) {
    var childs = pom[i].children;
    var slike = childs[8].getElementsByTagName("img");
    var j;
    for (j = 1; j < slike.length; j++) {
        slike[j].style.display = "none";
    }
}

function plusDivs(n, id)
{   
    showDivs(slideIndex += n, id);
}

function showDivs(n, id)
{
    var i;
    var x = document.getElementsByClassName(id);
    if (n > x.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = x.length }
    for (i = 0; i < x.length; i++)
    {
        x[i].style.display = "none";
    }
    x[slideIndex - 1].style.display = "block";
}
