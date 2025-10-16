// Author : Romain PERRIN

//-----------------------------------------------------------------------------
// NIM v1
//-----------------------------------------------------------------------------

let nim1TokenPosition = 9;

function Nim1Reset()
{
    nim1TokenPosition = 9;
    // enabling all buttons
    Nim1EnableMove();
    document.getElementById("FDS2025Nim1Display").innerText = "It's your turn";
    // all token position images to blank except the number 9 where the toke is displayed
    document.getElementById("FDS2025Nim1TokenPosition9").src = "../../images/talk/FDS2025/Nim/NimToken.png";
    document.getElementById("FDS2025Nim1TokenPosition8").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition7").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition6").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition5").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition4").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition3").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition2").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition1").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim1TokenPosition0").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025Nim1TokenImage1").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage2").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage3").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage4").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage5").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage6").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage7").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim1TokenImage8").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
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
            document.getElementById(id).src = "../../images/talk/FDS2025/Nim/NimToken.png";
        }
        else
        {
            document.getElementById(id).src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
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
    let tokenImage = "../../images/talk/FDS2025/Nim/Token" + tokenValue + ".png";
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

//-----------------------------------------------------------------------------
// NIM v2
//-----------------------------------------------------------------------------

let nim2TokenPosition = 9;
let nim2GamePlayed = 0;
let nim2PlayerWon = 0;
let nim2AIWon = 0;
let nim2CupTokens = [[1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3]];
let nim2LastChoiceIndex = -1;
let nim2LastChoiceValue = -1;

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
    document.getElementById("FDS2025Nim2TokenPosition9").src = "../../images/talk/FDS2025/Nim/NimToken.png";
    document.getElementById("FDS2025Nim2TokenPosition8").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition7").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition6").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition5").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition4").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition3").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition2").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition1").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition0").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025Nim2TokenImage0").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage1").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage2").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage3").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage4").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage5").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage6").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage7").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage8").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage9").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    // all cup tokens to 1,2,3
    document.getElementById("FDS2025Nim2Cup8Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup8Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup8Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup7Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup7Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup7Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup6Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup6Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup6Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup5Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup5Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup5Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup4Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup4Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup4Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup3Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup3Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup3Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup2Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup2Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup2Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
    document.getElementById("FDS2025Nim2Cup1Token1").src = "../../images/talk/FDS2025/Nim/Token1.png";
    document.getElementById("FDS2025Nim2Cup1Token2").src = "../../images/talk/FDS2025/Nim/Token2.png";
    document.getElementById("FDS2025Nim2Cup1Token3").src = "../../images/talk/FDS2025/Nim/Token3.png";
}

function Nim2ResetGame()
{
    nim2TokenPosition = 9;
    nim2LastChoiceIndex = -1;
    nim2LastChoiceValue = -1;
    // enabling all buttons
    Nim2EnableMove();
    // all token position images to blank except the number 9 where the toke is displayed
    document.getElementById("FDS2025Nim2TokenPosition9").src = "../../images/talk/FDS2025/Nim/NimToken.png";
    document.getElementById("FDS2025Nim2TokenPosition8").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition7").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition6").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition5").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition4").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition3").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition2").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition1").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    document.getElementById("FDS2025Nim2TokenPosition0").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
    // all token images to blank
    document.getElementById("FDS2025Nim2TokenImage0").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage1").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage2").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage3").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage4").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage5").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage6").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage7").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage8").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    document.getElementById("FDS2025Nim2TokenImage9").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
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
            document.getElementById(id).src = "../../images/talk/FDS2025/Nim/NimToken.png";
        }
        else
        {
            document.getElementById(id).src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
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
        document.getElementById(imageID).src = "../../images/talk/FDS2025/Nim/Token" + pick + ".png";
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
    document.getElementById(imageID).src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
    nim2LastChoicesIndex = [];
    nim2LastChoicesValue = [];
}

//-----------------------------------------------------------------------------
// TIC TAC TOE v1
//-----------------------------------------------------------------------------

class TicTacToeNode
{
    constructor(level, line, column, action, leaves)
    {
        this._level = level;
        this._line = line;
        this._column = column;
        this._action = action;
        this._leaves = leaves;
    }

    get level()
    {
        return this._level;
    }

    set level(level)
    {
        this._level = level;
    }

    get line()
    {
        return this._line;
    }

    set line(line)
    {
        this._line = line;
    }

    get column()
    {
        return this._column;
    }

    set column(column)
    {
        this._column = column;
    }

    get action()
    {
        return this._action;
    }

    set action(action)
    {
        this._action = action;
    }

    get leaves()
    {
        return this._leaves;
    }

    set leaves(leaves)
    {
        this._leaves = leaves;
    }
}

let branch23 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch25 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch26 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch273 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch276 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch278 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch279 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch27 = new TicTacToeNode(2, 1, 1, "", [[null, null, branch273], [null, null, branch276], [null, branch278, branch279]]);
let branch28 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch29 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch2 = new TicTacToeNode(1, 1, 0, "", [[null, null, branch23], [null, branch25, branch26], [branch27, branch28, branch29]]);

let branch32 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch35 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch36 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch372 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch376 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch378 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch379 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch37 = new TicTacToeNode(2, 1, 1, "", [[null, branch372, null], [null, null, branch376], [null, branch378, branch379]]);
let branch38 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch39 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch3 = new TicTacToeNode(1, 1, 0, "", [[null, branch32, null], [null, branch35, branch36], [branch37, branch38, branch39]]);

let branch436 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch437 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch438 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch439 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch43 = new TicTacToeNode(2, 1, 1, "", [[null, null, null], [null, null, branch436], [branch437, branch438, branch439]]);
let branch45 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch46 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch47 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch48 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch49 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch4 = new TicTacToeNode(1, 0, 1, "", [[null, null, branch43], [null, branch45, branch46], [branch47, branch48, branch49]]);

let branch5348 = new TicTacToeNode(4, 2, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let branch5349 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let branch534 = new TicTacToeNode(3, 1, 2, "", [[null, null, null], [null, null, null], [null, branch5348, branch5349]]);
let branch536 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch538 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch539 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch53 = new TicTacToeNode(2, 2, 0, "", [[null, null, null], [branch534, null, branch536], [null, branch538, branch539]]);
let branch54 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch56 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch57 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch58 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch59 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch5 = new TicTacToeNode(1, 0, 1, "", [[null, null, branch53], [branch54, null, branch56], [branch57, branch58, branch59]]);

let branch62 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch63 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch64 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch67 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch68 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch692 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch694 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch697 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch698 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch69 = new TicTacToeNode(2, 0, 2, "", [[null, branch692, null], [branch694, null, null], [branch697, branch698, null]]);
let branch6 = new TicTacToeNode(1, 1, 1, "", [[null, branch62, branch63], [branch64, null, null], [branch67, branch68, branch69]]);

let branch734 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch736 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch738 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch739 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch73 = new TicTacToeNode(2, 1, 1, "", [[null, null, null], [branch734, null, branch736], [null, branch738, branch739]]);
let branch74 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch75 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch76 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch78 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch79 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch7 = new TicTacToeNode(1, 0, 1, "", [[null, null, branch73], [branch74, branch75, branch76], [null, branch78, branch79]]);

let branch824 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch826 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch827 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch829 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch82 = new TicTacToeNode(2, 1, 1, "", [[null, null, null], [branch824, null, branch826], [branch827, null, branch829]]);
let branch84 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch85 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch86 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch87 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch89 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch8 = new TicTacToeNode(1, 0, 2, "", [[null, branch82, null], [branch84, branch85, branch86], [branch87, null, branch89]]);

let branch924 = new TicTacToeNode(3, 1, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch925 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch926 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch928 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch92 = new TicTacToeNode(2, 2, 0, "", [[null, null, null], [branch924, branch925, branch926], [null, branch928, null]]);
let branch94 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch95 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch96 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch97 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch98 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let branch9 = new TicTacToeNode(1, 0, 2, "", [[null, branch92, null], [branch94, branch95, branch96], [branch97, branch98, null]]);

let root = new TicTacToeNode(0, 0, 0, "", [[null, branch2, branch3], [branch4, branch5, branch6], [branch7, branch8, branch9]]);
let ticTacToe1Node = root;

let ticTacToe1Choices = [[false, true, true], [true, true, true], [true, true, true]];

function TicTacToe1Reset()
{
    ticTacToe1Choices = [[false, true, true], [true, true, true], [true, true, true]];
    ticTacToe1Node = root;

    document.getElementById("FDS2025TicTacToe1Button00").disabled = true;
    document.getElementById("FDS2025TicTacToe1Button01").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button02").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button10").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button11").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button12").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button20").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button21").disabled = false;
    document.getElementById("FDS2025TicTacToe1Button22").disabled = false;

    document.getElementById("FDS2025TicTacToe1Image00").src = "../../images/talk/FDS2025/TicTacToe/X.png";
    document.getElementById("FDS2025TicTacToe1Image01").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image02").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image10").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image11").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image12").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image20").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image21").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe1Image22").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
}

function TicTacToe1PlaceX(i, j)
{
    ticTacToe1Choices[i][j] = false;
    document.getElementById(("FDS2025TicTacToe1Button" + i) + j).disabled = true;
    document.getElementById(("FDS2025TicTacToe1Image" + i) + j).src = "../../images/talk/FDS2025/TicTacToe/X.png";
}

async function TicTacToe1PlaceO(i, j)
{
    ticTacToe1Choices[i][j] = false;
    document.getElementById(("FDS2025TicTacToe1Button" + i) + j).disabled = true;
    document.getElementById(("FDS2025TicTacToe1Image" + i) + j).src = "../../images/talk/FDS2025/TicTacToe/O.png";
    document.getElementById("FDS2025TicTacToe1Display").innerText = "AI turn";
    await Sleep(1000);
    TicTacToe1AITurn(i, j);
}

async function TicTacToe1AITurn(i, j)
{
    // case 1 : currentNode at grid [i,j] is null -> player either won or matched -- cannot happen here !
    if (ticTacToe1Node.leaves[i][j] == null)
    {
        TicTacToe1Reset();
    }
    // case 2 : currentNode at grid [i,j] is not null -> new node is this one, place X on line, column and check action for win ('w') or matched ('n')
    else
    {
        ticTacToe1Node = ticTacToe1Node.leaves[i][j];
        let line = ticTacToe1Node.line;
        let column = ticTacToe1Node.column;
        TicTacToe1PlaceX(line, column);
        // check victory of matched
        let action = ticTacToe1Node.action;
        if (action == "w")
        {
            document.getElementById("FDS2025TicTacToe1Display").innerText = "AI victory !";
            await Sleep(1000);
            TicTacToe1AIWon();
        }
        else if (action == "n")
        {
            document.getElementById("FDS2025TicTacToe1Display").innerText = "Matched !";
            await Sleep(1000);
            TicTacToe1Matched();
        }
        document.getElementById("FDS2025TicTacToe1Display").innerText = "Player turn";
    }
}

function TicTacToe1AIWon()
{
    TicTacToe1Reset();
}

function TicTacToe1Matched()
{
    TicTacToe1Reset();
}

function TicTacToe1PlayerWon()
{
    TicTacToe1Reset();
}