let nim1TokenPosition = 9;

function Nim1Reset()
{
    nim1TokenPosition = 9;
    // enabling all buttons
    Nim1EnableMove();
    document.getElementById("FDS2025Nim1Display").innerText = "It's your turn";
    // all token position images to blank except the number 9 where the toke is displayed
    document.getElementById("FDS2025NimTokenPosition9").src = "../../images/talk/FDS2025NimToken.png";
    document.getElementById("FDS2025NimTokenPosition8").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition7").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition6").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition5").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition4").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition3").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition2").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition1").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025NimTokenPosition0").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025NimTokenImage1").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage2").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage3").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage4").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage5").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage6").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage7").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025NimTokenImage8").src = "../../images/talk/FDS2025EmptyToken.png";
}

function Sleep(ms)
{
    return new Promise(resolve => setTimeout(resolve, ms));
}

function Nim1Move1()
{
    Nim1Move(1);
}

function Nim1Move2()
{
    Nim1Move(2);
}

function Nim1Move3()
{
    Nim1Move(3);
}

async function Nim1Move(index)
{
    nim1TokenPosition = Math.max(0, nim1TokenPosition - index);
    Nim1MoveTokenToPosition();
    Nim1DisableMove();
    if (nim1TokenPosition == 0)
    {
        Nim1PlayerLost();
        return;
    }
    document.getElementById("FDS2025Nim1Display").innerText = "It's the AI's turn";
    await Sleep(1000);
    Nim1AIMove();
}

function Nim1MoveTokenToPosition()
{
    for (i = 9; i >= 0; i--)
    {
        let id = "FDS2025NimTokenPosition" + i;
        if (i == nim1TokenPosition)
        {
            document.getElementById(id).src = "../../images/talk/FDS2025NimToken.png";
        }
        else
        {
            document.getElementById(id).src = "../../images/talk/FDS2025NimTokenEmpty.png";
        }
    }
}

async function Nim1AIMove()
{
    let newPosition = nim1TokenPosition;
    if (nim1TokenPosition == 8 || nim1TokenPosition == 4)
    {
        newPosition = nim1TokenPosition - 3;
        Nim1PickTokenFromCup(3, nim1TokenPosition);
    }
    else if (nim1TokenPosition == 7 || nim1TokenPosition == 3)
    {
        newPosition = nim1TokenPosition - 2;
        Nim1PickTokenFromCup(2, nim1TokenPosition);
    }
    else if (nim1TokenPosition == 6 || nim1TokenPosition == 2)
    {
        newPosition = nim1TokenPosition - 1;
        Nim1PickTokenFromCup(1, nim1TokenPosition);
    }
    nim1TokenPosition = newPosition;
    Nim1MoveTokenToPosition();
    await Sleep(1000);
    document.getElementById("FDS2025Nim1Display").innerText = "It's your turn";
    Nim1EnableMove();
}

function Nim1PickTokenFromCup(tokenValue, cupIndex)
{
    let tokenImage = "../../images/talk/FDS2025Token" + tokenValue + ".png";
    let tokenId = "FDS2025NimTokenImage" + cupIndex;
    document.getElementById(tokenId).src = tokenImage;
}

function Nim1EnableMove()
{
    document.getElementById("FDS2025Nim1ButtonMove1").disabled = false;
    document.getElementById("FDS2025Nim1ButtonMove2").disabled = false;
    document.getElementById("FDS2025Nim1ButtonMove3").disabled = false;
}

function Nim1DisableMove()
{
    document.getElementById("FDS2025Nim1ButtonMove1").disabled = true;
    document.getElementById("FDS2025Nim1ButtonMove2").disabled = true;
    document.getElementById("FDS2025Nim1ButtonMove3").disabled = true;
}

function Nim1PlayerLost()
{
    Nim1DisableMove();
    document.getElementById("FDS2025Nim1Display").innerText = "You lost !";
}