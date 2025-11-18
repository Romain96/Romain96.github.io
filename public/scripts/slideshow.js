let slideIndex = 1;
showSlide(slideIndex);

function nextSlide()
{
    showSlide(slideIndex += 1);
}

function prevSlide()
{
    showSlide(slideIndex -= 1);
}

function currentSlide(n)
{
    showSlide(slideIndex = n);
}

function showSlide(n)
{
    let i;
    let slides = document.getElementsByClassName("slideshow-frame");
    let dots = document.getElementsByClassName("dot");
    if (n > slides.length || n < 0)
    {
        slideIndex = 1;
    }
    for (i = 0; i < slides.length; i++)
    {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++)
    {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}