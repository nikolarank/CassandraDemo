var slideIndex = 1;
var pom = document.getElementById("skriven");
showDivs(slideIndex, pom.value);

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