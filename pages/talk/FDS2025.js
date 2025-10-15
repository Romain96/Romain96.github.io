let nim1TokenPosition = 9;
let nim2TokenPosition = 9;
let nim2GamePlayed = 0;
let nim2PlayerWon = 0;
let nim2AIWon = 0;
let nim2CupTokens = [[1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3]];
let nim2LastChoiceIndex = -1;
let nim2LastChoiceValue = -1;

function Nim1Reset()
{
    nim1TokenPosition = 9;
    // enabling all buttons
    Nim1EnableMove();
    document.getElementById("FDS2025Nim1Display").innerText = "It's your turn";
    // all token position images to blank except the number 9 where the toke is displayed
    document.getElementById("FDS2025Nim1TokenPosition9").src = "../../images/talk/FDS2025NimToken.png";
    document.getElementById("FDS2025Nim1TokenPosition8").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition7").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition6").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition5").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition4").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition3").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition2").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition1").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition0").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025Nim1TokenImage1").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage2").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage3").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage4").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage5").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage6").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage7").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage8").src = "../../images/talk/FDS2025EmptyToken.png";
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
        let id = "FDS2025Nim1TokenPosition" + i;
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
    let tokenId = "FDS2025Nim1TokenImage" + cupIndex;
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


function Nim2Reset()
{
    nim2TokenPosition = 9;
    nim2GamePlayed = 0;
    nim2GamePlayed = 0;
    nim2PlayerWon = 0;
    nim2AIWon = 0;
    nim2CupTokens = [[1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3]];
    nim2LastChoiceIndex = -1;
    nim2LastChoiceValue = -1;
    // enabling all buttons
    Nim2EnableMove();
    document.getElementById("FDS2025Nim2Display").innerText = "It's your turn\nStats : played 0, Player won 0/0, AI won 0/0";
    // all token position images to blank except the number 9 where the toke is displayed
    document.getElementById("FDS2025Nim2TokenPosition9").src = "../../images/talk/FDS2025NimToken.png";
    document.getElementById("FDS2025Nim2TokenPosition8").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition7").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition6").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition5").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition4").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition3").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition2").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition1").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition0").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025Nim2TokenImage0").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage1").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage2").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage3").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage4").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage5").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage6").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage7").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage8").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage9").src = "../../images/talk/FDS2025EmptyToken.png";
    // all cup tokens to 1,2,3
    document.getElementById("FDS2025Nim2Cup8Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup8Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup8Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup7Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup7Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup7Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup6Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup6Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup6Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup5Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup5Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup5Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup4Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup4Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup4Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup3Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup3Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup3Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup2Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup2Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup2Token3").src = "../../images/talk/FDS2025Token3.png";
    document.getElementById("FDS2025Nim2Cup1Token1").src = "../../images/talk/FDS2025Token1.png";
    document.getElementById("FDS2025Nim2Cup1Token2").src = "../../images/talk/FDS2025Token2.png";
    document.getElementById("FDS2025Nim2Cup1Token3").src = "../../images/talk/FDS2025Token3.png";
}

function Nim2ResetGame()
{
    nim2TokenPosition = 9;
    nim2LastChoiceIndex = -1;
    nim2LastChoiceValue = -1;
    // enabling all buttons
    Nim2EnableMove();
    // all token position images to blank except the number 9 where the toke is displayed
    document.getElementById("FDS2025Nim2TokenPosition9").src = "../../images/talk/FDS2025NimToken.png";
    document.getElementById("FDS2025Nim2TokenPosition8").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition7").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition6").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition5").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition4").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition3").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition2").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition1").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition0").src = "../../images/talk/FDS2025NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025Nim2TokenImage0").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage1").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage2").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage3").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage4").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage5").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage6").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage7").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage8").src = "../../images/talk/FDS2025EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage9").src = "../../images/talk/FDS2025EmptyToken.png";
}

function Nim2EnableMove()
{
    document.getElementById("FDS2025Nim2ButtonMove1").disabled = false;
    document.getElementById("FDS2025Nim2ButtonMove2").disabled = false;
    document.getElementById("FDS2025Nim2ButtonMove3").disabled = false;
}

function Nim2DisableMove()
{
    document.getElementById("FDS2025Nim2ButtonMove1").disabled = true;
    document.getElementById("FDS2025Nim2ButtonMove2").disabled = true;
    document.getElementById("FDS2025Nim2ButtonMove3").disabled = true;
}

function RandomInt(min, max)
{
    return min + Math.floor(Math.random() * max);
}

function Nim2Move1()
{
    Nim2Move(1);
}

function Nim2Move2()
{
    Nim2Move(2);
}

function Nim2Move3()
{
    Nim2Move(3);
}

async function Nim2Move(index)
{
    nim2TokenPosition = Math.max(0, nim2TokenPosition - index);
    Nim2MoveTokenToPosition();
    Nim2DisableMove();
    if (nim2TokenPosition == 0)
    {
        Nim2PlayerLost();
        return;
    }
    document.getElementById("FDS2025Nim2Display").innerText = "It's the AI's turn\nStats : played " + nim2GamePlayed + ", Player won " + nim2PlayerWon + ", AI won " + nim2AIWon;;
    await Sleep(1000);
    Nim2AIMove();
    if (nim2TokenPosition == 0)
    {
        Nim2AILost();
        return;
    }
}

function Nim2MoveTokenToPosition()
{
    for (i = 9; i >= 0; i--)
    {
        let id = "FDS2025Nim2TokenPosition" + i;
        if (i == nim2TokenPosition)
        {
            document.getElementById(id).src = "../../images/talk/FDS2025NimToken.png";
        }
        else
        {
            document.getElementById(id).src = "../../images/talk/FDS2025NimTokenEmpty.png";
        }
    }
}

async function Nim2AIMove()
{
    // random pick from the current cup
    let cupIndex = nim2TokenPosition - 1;
    console.log("cup index " + cupIndex);
    let maxChoice = nim2CupTokens[cupIndex].length;
    console.log("max choices on cup " + cupIndex + " : " + maxChoice);
    if (maxChoice == 0)
    {
        console.log("no choices, AI lost");
        Nim2AILost();
    }
    else
    {
        console.log("choices remaining, picking");
        let pick = nim2CupTokens[cupIndex][Math.floor(Math.random() * nim2CupTokens[cupIndex].length)];
        nim2LastChoiceIndex = cupIndex;
        nim2LastChoiceValue = pick;
        let newPosition = Math.max(0, nim2TokenPosition - pick);
        let imageID = "FDS2025Nim2TokenImage" + nim2TokenPosition;
        document.getElementById(imageID).src = "../../images/talk/FDS2025Token" + pick + ".png";
        nim2TokenPosition = newPosition;
        Nim2MoveTokenToPosition();
        await Sleep(1000);
        document.getElementById("FDS2025Nim2Display").innerText = "It's your turn\nStats : played " + nim2GamePlayed + ", Player won " + nim2PlayerWon + ", AI won " + nim2AIWon;
        Nim2EnableMove();
    }
}

function Nim2PlayerLost()
{
    Nim2DisableMove();
    nim2GamePlayed += 1;
    nim2AIWon += 1;
    document.getElementById("FDS2025Nim2Display").innerText = "You lost !\nStats : played " + nim2GamePlayed + ", Player won " + nim2PlayerWon + ", AI won " + nim2AIWon;
    Nim2ResetGame();
}

function Nim2AILost()
{
    Nim2DisableMove();
    nim2GamePlayed += 1;
    nim2PlayerWon += 1;
    document.getElementById("FDS2025Nim2Display").innerText = "You won !\nStats : played " + nim2GamePlayed + ", Player won " + nim2PlayerWon + ", AI won " + nim2AIWon;
    // learn
    Nim2LearnFromMistake();
    Nim2ResetGame();
}

function Nim2LearnFromMistake()
{
    // removing the last choice
    console.log("index " + nim2LastChoiceIndex + " value " + nim2LastChoiceValue);
    let index = nim2CupTokens[nim2LastChoiceIndex].indexOf(nim2LastChoiceValue);
    nim2CupTokens[nim2LastChoiceIndex].splice(index, 1);
    let imageID = "FDS2025Nim2Cup" + (nim2LastChoiceIndex + 1) + "Token" + nim2LastChoiceValue;
    document.getElementById(imageID).src = "../../images/talk/FDS2025EmptyToken.png";
    nim2LastChoicesIndex = [];
    nim2LastChoicesValue = [];
}