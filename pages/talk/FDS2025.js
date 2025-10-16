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

let ttt1Branch23 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch25 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch26 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch273 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch276 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch278 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch279 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch27 = new TicTacToeNode(2, 1, 1, "", [[null, null, ttt1Branch273], [null, null, ttt1Branch276], [null, ttt1Branch278, ttt1Branch279]]);
let ttt1Branch28 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch29 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch2 = new TicTacToeNode(1, 1, 0, "", [[null, null, ttt1Branch23], [null, ttt1Branch25, ttt1Branch26], [ttt1Branch27, ttt1Branch28, ttt1Branch29]]);

let ttt1Branch32 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch35 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch36 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch372 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch376 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch378 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch379 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch37 = new TicTacToeNode(2, 1, 1, "", [[null, ttt1Branch372, null], [null, null, ttt1Branch376], [null, ttt1Branch378, ttt1Branch379]]);
let ttt1Branch38 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch39 = new TicTacToeNode(2, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch3 = new TicTacToeNode(1, 1, 0, "", [[null, ttt1Branch32, null], [null, ttt1Branch35, ttt1Branch36], [ttt1Branch37, ttt1Branch38, ttt1Branch39]]);

let ttt1Branch436 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch437 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch438 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch439 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch43 = new TicTacToeNode(2, 1, 1, "", [[null, null, null], [null, null, ttt1Branch436], [ttt1Branch437, ttt1Branch438, ttt1Branch439]]);
let ttt1Branch45 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch46 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch47 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch48 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch49 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch4 = new TicTacToeNode(1, 0, 1, "", [[null, null, ttt1Branch43], [null, ttt1Branch45, ttt1Branch46], [ttt1Branch47, ttt1Branch48, ttt1Branch49]]);

let ttt1Branch5348 = new TicTacToeNode(4, 2, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch5349 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch534 = new TicTacToeNode(3, 1, 2, "", [[null, null, null], [null, null, null], [null, ttt1Branch5348, ttt1Branch5349]]);
let ttt1Branch536 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch538 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch539 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch53 = new TicTacToeNode(2, 2, 0, "", [[null, null, null], [ttt1Branch534, null, ttt1Branch536], [null, ttt1Branch538, ttt1Branch539]]);
let ttt1Branch54 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch56 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch57 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch58 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch59 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch5 = new TicTacToeNode(1, 0, 1, "", [[null, null, ttt1Branch53], [ttt1Branch54, null, ttt1Branch56], [ttt1Branch57, ttt1Branch58, ttt1Branch59]]);

let ttt1Branch62 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch63 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch64 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch67 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch68 = new TicTacToeNode(2, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch692 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch694 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch697 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch698 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch69 = new TicTacToeNode(2, 0, 2, "", [[null, ttt1Branch692, null], [ttt1Branch694, null, null], [ttt1Branch697, ttt1Branch698, null]]);
let ttt1Branch6 = new TicTacToeNode(1, 1, 1, "", [[null, ttt1Branch62, ttt1Branch63], [ttt1Branch64, null, null], [ttt1Branch67, ttt1Branch68, ttt1Branch69]]);

let ttt1Branch734 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch736 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch738 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch739 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch73 = new TicTacToeNode(2, 1, 1, "", [[null, null, null], [ttt1Branch734, null, ttt1Branch736], [null, ttt1Branch738, ttt1Branch739]]);
let ttt1Branch74 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch75 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch76 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch78 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch79 = new TicTacToeNode(2, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch7 = new TicTacToeNode(1, 0, 1, "", [[null, null, ttt1Branch73], [ttt1Branch74, ttt1Branch75, ttt1Branch76], [null, ttt1Branch78, ttt1Branch79]]);

let ttt1Branch824 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch826 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch827 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch829 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch82 = new TicTacToeNode(2, 1, 1, "", [[null, null, null], [ttt1Branch824, null, ttt1Branch826], [ttt1Branch827, null, ttt1Branch829]]);
let ttt1Branch84 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch85 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch86 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch87 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch89 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch8 = new TicTacToeNode(1, 0, 2, "", [[null, ttt1Branch82, null], [ttt1Branch84, ttt1Branch85, ttt1Branch86], [ttt1Branch87, null, ttt1Branch89]]);

let ttt1Branch924 = new TicTacToeNode(3, 1, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch925 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch926 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch928 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch92 = new TicTacToeNode(2, 2, 0, "", [[null, null, null], [ttt1Branch924, ttt1Branch925, ttt1Branch926], [null, ttt1Branch928, null]]);
let ttt1Branch94 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch95 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch96 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch97 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch98 = new TicTacToeNode(2, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt1Branch9 = new TicTacToeNode(1, 0, 2, "", [[null, ttt1Branch92, null], [ttt1Branch94, ttt1Branch95, ttt1Branch96], [ttt1Branch97, ttt1Branch98, null]]);

let root1 = new TicTacToeNode(0, 0, 0, "", [[null, ttt1Branch2, ttt1Branch3], [ttt1Branch4, ttt1Branch5, ttt1Branch6], [ttt1Branch7, ttt1Branch8, ttt1Branch9]]);
let ticTacToe1Node = root1;

let ticTacToe1Choices = [[false, true, true], [true, true, true], [true, true, true]];

function TicTacToe1Reset()
{
    ticTacToe1Choices = [[false, true, true], [true, true, true], [true, true, true]];
    ticTacToe1Node = root1;

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

//-----------------------------------------------------------------------------
// TIC TAC TOE v2
//-----------------------------------------------------------------------------

let ttt2Branch124 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch126 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1276 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1278 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1279 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch127 = new TicTacToeNode(3, 1, 0, "", [[null, null, null], [null, null, ttt2Branch1276], [null, ttt2Branch1278, ttt2Branch1279]]);
let ttt2Branch128 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch129 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch12 = new TicTacToeNode(2, 0, 2, "", [[null, null, null], [ttt2Branch124, null, ttt2Branch126], [ttt2Branch127, ttt2Branch128, ttt2Branch129]]);
let ttt2Branch134 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch136 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch137 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1386 = new TicTacToeNode(4, 2, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1387 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1389 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch138 = new TicTacToeNode(3, 1, 0, "", [[null, null, null], [null, null, ttt2Branch1386], [ttt2Branch1387, null, ttt2Branch1389]]);
let ttt2Branch139 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch13 = new TicTacToeNode(2, 0, 1, "", [[null, null, null], [ttt2Branch134, null, ttt2Branch136], [ttt2Branch137, ttt2Branch138, ttt2Branch139]]);
let ttt2Branch142 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1436 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1438 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1439 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch143 = new TicTacToeNode(3, 0, 1, "", [[null, null, null], [null, null, ttt2Branch1436], [null, ttt2Branch1438, ttt2Branch1439]]);
let ttt2Branch146 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch148 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch149 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch14 = new TicTacToeNode(2, 2, 0, "", [[null, ttt2Branch142, ttt2Branch143], [null, null, ttt2Branch146], [null, ttt2Branch148, ttt2Branch149]]);
let ttt2Branch1624 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1627 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1629 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch162 = new TicTacToeNode(3, 0, 2, "", [[null, null, null], [ttt2Branch1624, null, null], [ttt2Branch1627, null, ttt2Branch1629]]);
let ttt2Branch163 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch164 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch167 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch169 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch16 = new TicTacToeNode(2, 1, 1, "", [[null, ttt2Branch162, ttt2Branch163], [ttt2Branch164, null, null], [ttt2Branch167, null, ttt2Branch169]]);
let ttt2Branch172 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch173 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1763 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1768 = new TicTacToeNode(4, 2, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1769 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch176 = new TicTacToeNode(3, 0, 1, "", [[null, null, ttt2Branch1763], [null, null, null], [null, ttt2Branch1768, ttt2Branch1769]]);
let ttt2Branch178 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch179 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch17 = new TicTacToeNode(2, 1, 0, "", [[null, ttt2Branch172, ttt2Branch173], [null, null, ttt2Branch176], [null, ttt2Branch178, ttt2Branch179]]);
let ttt2Branch182 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch183 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1842 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1843 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1849 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch184 = new TicTacToeNode(3, 2, 0, "", [[null, ttt2Branch1842, ttt2Branch1843], [null, null, null], [null, null, ttt2Branch1849]]);
let ttt2Branch187 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch189 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch18 = new TicTacToeNode(2, 1, 2, "", [[null, ttt2Branch182, ttt2Branch183], [ttt2Branch184, null, null], [ttt2Branch187, null, ttt2Branch189]]);
let ttt2Branch193 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch194 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch196 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch197 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1983 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1984 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch1986 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch198 = new TicTacToeNode(3, 2, 0, "", [[null, null, ttt2Branch1983], [ttt2Branch1984, null, ttt2Branch1986], [null, null, null]]);
let ttt2Branch19 = new TicTacToeNode(2, 1, 1, "", [[null, null, ttt2Branch193], [ttt2Branch194, null, ttt2Branch196], [ttt2Branch197, ttt2Branch198, null]]);
let ttt2Branch1 = new TicTacToeNode(1, 1, 1, "", [[null, ttt2Branch12, ttt2Branch13], [ttt2Branch14, null, ttt2Branch16], [ttt2Branch17, ttt2Branch18, ttt2Branch19]]);

let ttt2Branch214 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch216 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2176 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2178 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2179 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch217 = new TicTacToeNode(3, 2, 1, "", [[null, null, null], [null, null, ttt2Branch2176], [null, ttt2Branch2178, ttt2Branch2179]]);
let ttt2Branch218 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch219 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch21 = new TicTacToeNode(2, 0, 2, "", [[null, null, null], [ttt2Branch214, null, ttt2Branch216], [ttt2Branch217, ttt2Branch218, ttt2Branch219]]);
let ttt2Branch234 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch236 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch237 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch238 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2394 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2397 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2398 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch239 = new TicTacToeNode(3, 1, 2, "", [[null, null, null], [ttt2Branch2394, null, null], [ttt2Branch2397, ttt2Branch2398, null]]);
let ttt2Branch23 = new TicTacToeNode(2, 0, 0, "", [[null, null, null], [ttt2Branch234, null, ttt2Branch236], [ttt2Branch237, ttt2Branch238, ttt2Branch239]]);
let ttt2Branch241 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch246 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2476 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2478 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2479 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch247 = new TicTacToeNode(3, 0, 0, "", [[null, null, null], [null, null, ttt2Branch2476], [null, ttt2Branch2478, ttt2Branch2479]]);
let ttt2Branch248 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch249 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch24 = new TicTacToeNode(2, 0, 2, "", [[ttt2Branch241, null, null], [null, null, ttt2Branch246], [ttt2Branch247, ttt2Branch248, ttt2Branch249]]);
let ttt2Branch263 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch264 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch267 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch268 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2694 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2697 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2698 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch269 = new TicTacToeNode(3, 0, 2, "", [[null, null, null], [ttt2Branch2694, null, null], [ttt2Branch2697, ttt2Branch2698, null]]);
let ttt2Branch26 = new TicTacToeNode(2, 0, 0, "", [[null, null, ttt2Branch263], [ttt2Branch264, null, null], [ttt2Branch267, ttt2Branch268, ttt2Branch269]]);
let ttt2Branch271 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch273 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2743 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2748 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2749 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch274 = new TicTacToeNode(3, 0, 0, "", [[null, null, ttt2Branch2743], [null, null, null], [null, ttt2Branch2748, ttt2Branch2749]]);
let ttt2Branch278 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch279 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch27 = new TicTacToeNode(2, 1, 2, "", [[ttt2Branch271, null, ttt2Branch273], [ttt2Branch274, null, null], [null, ttt2Branch278, ttt2Branch279]]);
let ttt2Branch283 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch284 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch286 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch287 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2893 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2894 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2896 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch289 = new TicTacToeNode(3, 2, 0, "", [[null, null, ttt2Branch2893], [ttt2Branch2894, null, ttt2Branch2896], [null, null, null]]);
let ttt2Branch28 = new TicTacToeNode(2, 0, 0, "", [[null, null, ttt2Branch283], [ttt2Branch284, null, ttt2Branch286], [ttt2Branch287, null, ttt2Branch289]]);
let ttt2Branch291 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch293 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2961 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2967 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch2968 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch296 = new TicTacToeNode(3, 0, 2, "", [[ttt2Branch2961, null, null], [null, null, null], [ttt2Branch2967, ttt2Branch2968, null]]);
let ttt2Branch297 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch298 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch29 = new TicTacToeNode(2, 1, 0, "", [[ttt2Branch291, null, ttt2Branch293], [null, null, ttt2Branch296], [ttt2Branch297, ttt2Branch298, null]]);
let ttt2Branch2 = new TicTacToeNode(1, 1, 1, "", [[ttt2Branch21, null, ttt2Branch23], [ttt2Branch24, null, ttt2Branch26], [ttt2Branch27, ttt2Branch28, ttt2Branch29]]);

let ttt2Branch314 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch316 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch317 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3186 = new TicTacToeNode(4, 2, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3187 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3189 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch318 = new TicTacToeNode(3, 1, 0, "", [[null, null, null], [null, null, ttt2Branch3186], [ttt2Branch3187, null, ttt2Branch3189]]);
let ttt2Branch319 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch31 = new TicTacToeNode(2, 0, 1, "", [[null, null, null], [ttt2Branch314, null, ttt2Branch316], [ttt2Branch317, ttt2Branch318, ttt2Branch319]]);
let ttt2Branch324 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch326 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch327 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch328 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3294 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3297 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3298 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch329 = new TicTacToeNode(3, 1, 2, "", [[null, null, null], [ttt2Branch3294, null, null], [ttt2Branch3297, ttt2Branch3298, null]]);
let ttt2Branch32 = new TicTacToeNode(2, 0, 0, "", [[null, null, null], [ttt2Branch324, null, ttt2Branch326], [ttt2Branch327, ttt2Branch328, ttt2Branch329]]);
let ttt2Branch341 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3426 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3427 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3429 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch342 = new TicTacToeNode(3, 0, 0, "", [[null, null, null], [null, null, ttt2Branch3426], [ttt2Branch3427, null, ttt2Branch3429]]);
let ttt2Branch346 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch347 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch349 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch34 = new TicTacToeNode(2, 2, 1, "", [[ttt2Branch341, ttt2Branch342, null], [null, null, ttt2Branch346], [ttt2Branch347, null, ttt2Branch349]]);
let ttt2Branch3614 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3617 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3618 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch361 = new TicTacToeNode(3, 0, 1, "", [[null, null, null], [ttt2Branch3614, null, null], [ttt2Branch3617, ttt2Branch3618, null]]);
let ttt2Branch362 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch364 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch367 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch368 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch36 = new TicTacToeNode(2, 2, 2, "", [[ttt2Branch361, ttt2Branch362, null], [ttt2Branch364, null, null], [ttt2Branch367, ttt2Branch368, null]]);
let ttt2Branch371 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch374 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch376 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3781 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3784 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3786 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch378 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch3781, null, null], [ttt2Branch3784, null, ttt2Branch3786], [null, null, null]]);
let ttt2Branch379 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch37 = new TicTacToeNode(2, 0, 1, "", [[ttt2Branch371, null, null], [ttt2Branch374, null, ttt2Branch376], [null, ttt2Branch378, ttt2Branch379]]);
let ttt2Branch381 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch382 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3861 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3862 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3867 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch386 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch3861, ttt2Branch3862, null], [null, null, null], [ttt2Branch3867, null, null]]);
let ttt2Branch387 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch389 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch38 = new TicTacToeNode(2, 1, 0, "", [[ttt2Branch381, ttt2Branch382, null], [null, null, ttt2Branch386], [ttt2Branch387, null, ttt2Branch389]]);
let ttt2Branch391 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch392 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3941 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3947 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch3948 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch394 = new TicTacToeNode(3, 0, 1, "", [[ttt2Branch3941, null, null], [null, null, null], [ttt2Branch3947, ttt2Branch3948, null]]);
let ttt2Branch397 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch398 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch39 = new TicTacToeNode(2, 1, 2, "", [[ttt2Branch391, ttt2Branch392, null], [ttt2Branch394, null, null], [ttt2Branch397, ttt2Branch398, null]]);
let ttt2Branch3 = new TicTacToeNode(1, 1, 1, "", [[ttt2Branch31, ttt2Branch32, null], [ttt2Branch34, null, ttt2Branch36], [ttt2Branch37, ttt2Branch38, ttt2Branch39]]);

let ttt2Branch412 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4136 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4138 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4139 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch413 = new TicTacToeNode(3, 0, 1, "", [[null, null, null], [null, null, ttt2Branch4136], [null, ttt2Branch4138, ttt2Branch4139]]);
let ttt2Branch416 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch418 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch419 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch41 = new TicTacToeNode(2, 2, 0, "", [[null, ttt2Branch412, ttt2Branch413], [null, null, ttt2Branch416], [null, ttt2Branch418, ttt2Branch419]]);
let ttt2Branch421 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch426 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4276 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4278 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4279 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch427 = new TicTacToeNode(3, 0, 0, "", [[null, null, null], [null, null, ttt2Branch4276], [null, ttt2Branch4278, ttt2Branch4279]]);
let ttt2Branch428 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch429 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch42 = new TicTacToeNode(2, 0, 2, "", [[ttt2Branch421, null, null], [null, null, ttt2Branch426], [ttt2Branch427, ttt2Branch428, ttt2Branch429]]);
let ttt2Branch431 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4326 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4327 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4329 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch432 = new TicTacToeNode(3, 0, 0, "", [[null, null, null], [null, null, ttt2Branch4326], [ttt2Branch4327, null, ttt2Branch4329]]);
let ttt2Branch436 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch437 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch439 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch43 = new TicTacToeNode(2, 2, 1, "", [[ttt2Branch431, ttt2Branch432, null], [null, null, ttt2Branch436], [ttt2Branch437, null, ttt2Branch439]]);
let ttt2Branch462 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch463 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch467 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch468 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4692 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4697 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4698 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch469 = new TicTacToeNode(3, 2, 1, "", [[null, ttt2Branch4692, null], [null, null, null], [ttt2Branch4697, ttt2Branch4698, null]]);
let ttt2Branch46 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch462, ttt2Branch463], [null, null, null], [ttt2Branch467, ttt2Branch468, ttt2Branch469]]);
let ttt2Branch472 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch473 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch476 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch478 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4792 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4793 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4796 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch479 = new TicTacToeNode(3, 2, 1, "", [[null, ttt2Branch4792, ttt2Branch4793], [null, null, ttt2Branch4796], [null, null, null]]);
let ttt2Branch47 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch472, ttt2Branch473], [null, null, ttt2Branch476], [null, ttt2Branch478, ttt2Branch479]]);
let ttt2Branch482 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch483 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch486 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch487 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4892 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4893 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4896 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch489 = new TicTacToeNode(3, 2, 0, "", [[null, ttt2Branch4892, ttt2Branch4893], [null, null, ttt2Branch4896], [null, null, null]]);
let ttt2Branch48 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch482, ttt2Branch483], [null, null, ttt2Branch486], [ttt2Branch487, null, ttt2Branch489]]);
let ttt2Branch491 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch493 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch496 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch497 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4981 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4983 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch4986 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch498 = new TicTacToeNode(3, 2, 0, "", [[ttt2Branch4981, null, ttt2Branch4983], [null, null, ttt2Branch4986], [null, null, null]]);
let ttt2Branch49 = new TicTacToeNode(2, 0, 1, "", [[ttt2Branch491, null, ttt2Branch493], [null, null, ttt2Branch496], [ttt2Branch497, ttt2Branch498, null]]);
let ttt2Branch4 = new TicTacToeNode(1, 1, 1, "", [[ttt2Branch41, ttt2Branch42, ttt2Branch43], [null, null, ttt2Branch46], [ttt2Branch47, ttt2Branch48, ttt2Branch49]]);

let ttt2Branch5234 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5236 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5239 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch523 = new TicTacToeNode(3, 2, 0, "", [[null, null, null], [ttt2Branch5234, null, ttt2Branch5236], [null, null, ttt2Branch5239]]);
let ttt2Branch5243 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5247 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5249 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch524 = new TicTacToeNode(3, 1, 2, "", [[null, null, ttt2Branch5243], [null, null, null], [ttt2Branch5247, null, ttt2Branch5249]]);
let ttt2Branch5263 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5267 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5269 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch526 = new TicTacToeNode(3, 1, 0, "", [[null, null, ttt2Branch5263], [null, null, null], [ttt2Branch5267, null, ttt2Branch5269]]);
let ttt2Branch5274 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5276 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5279 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch527 = new TicTacToeNode(3, 0, 2, "", [[null, null, null], [ttt2Branch5274, null, ttt2Branch5276], [null, null, ttt2Branch5279]]);
let ttt2Branch5293 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5296 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5297 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch529 = new TicTacToeNode(3, 1, 0, "", [[null, null, ttt2Branch5293], [null, null, ttt2Branch5296], [ttt2Branch5297, null, null]]);
let ttt2Branch52 = new TicTacToeNode(2, 2, 1, "", [[null, null, ttt2Branch523], [ttt2Branch524, null, ttt2Branch526], [ttt2Branch527, null, ttt2Branch529]]);
let ttt2Branch532 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5342 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5348 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5349 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch534 = new TicTacToeNode(3, 1, 2, "", [[null, ttt2Branch5342, null], [null, null, null], [null, ttt2Branch5348, ttt2Branch5349]]);
let ttt2Branch536 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch538 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch539 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch53 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch532, null], [ttt2Branch534, null, ttt2Branch536], [null, ttt2Branch538, ttt2Branch539]]);
let ttt2Branch5423 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5427 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5429 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch542 = new TicTacToeNode(3, 2, 1, "", [[null, null, ttt2Branch5423], [null, null, null], [ttt2Branch5427, null, ttt2Branch5429]]);
let ttt2Branch5432 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5438 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5439 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch543 = new TicTacToeNode(3, 2, 0, "", [[null, ttt2Branch5432, null], [null, null, null], [null, ttt2Branch5438, ttt2Branch5439]]);
let ttt2Branch5472 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5478 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5479 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch547 = new TicTacToeNode(3, 0, 2, "", [[null, ttt2Branch5472, null], [null, null, null], [null, ttt2Branch5478, ttt2Branch5479]]);
let ttt2Branch5483 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5487 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5489 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch548 = new TicTacToeNode(3, 0, 1, "", [[null, null, ttt2Branch5483], [null, null, null], [ttt2Branch5487, null, ttt2Branch5489]]);
let ttt2Branch5493 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5497 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5498 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch549 = new TicTacToeNode(3, 0, 1, "", [[null, null, ttt2Branch5493], [null, null, null], [ttt2Branch5497, null, ttt2Branch5498]]);
let ttt2Branch54 = new TicTacToeNode(2, 1, 2, "", [[null, ttt2Branch542, ttt2Branch543], [null, null, null], [ttt2Branch547, ttt2Branch548, ttt2Branch549]]);
let ttt2Branch562 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch563 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5672 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5678 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5679 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch567 = new TicTacToeNode(3, 0, 2, "", [[null, ttt2Branch5672, null], [null, null, null], [null, ttt2Branch5678, ttt2Branch5679]]);
let ttt2Branch568 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch569 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch56 = new TicTacToeNode(2, 1, 0, "", [[null, ttt2Branch562, ttt2Branch563], [null, null, null], [ttt2Branch567, ttt2Branch568, ttt2Branch569]]);
let ttt2Branch5724 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5726 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5729 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch572 = new TicTacToeNode(3, 2, 1, "", [[null, null, null], [ttt2Branch5724, null, ttt2Branch5726], [null, null, ttt2Branch5729]]);
let ttt2Branch574 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch576 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch578 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch579 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch57 = new TicTacToeNode(2, 0, 2, "", [[null, ttt2Branch572, null], [ttt2Branch574, null, ttt2Branch576], [null, ttt2Branch578, ttt2Branch579]]);
let ttt2Branch5834 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5836 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5839 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch583 = new TicTacToeNode(3, 2, 0, "", [[null, null, null], [ttt2Branch5834, null, ttt2Branch5836], [null, null, ttt2Branch5839]]);
let ttt2Branch584 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch586 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch587 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch589 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch58 = new TicTacToeNode(2, 0, 1, "", [[null, null, ttt2Branch583], [ttt2Branch584, null, ttt2Branch586], [ttt2Branch587, null, ttt2Branch589]]);
let ttt2Branch5924 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5926 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch5927 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch592 = new TicTacToeNode(3, 2, 1, "", [[null, null, null], [ttt2Branch5924, null, ttt2Branch5926], [ttt2Branch5927, null, null]]);
let ttt2Branch594 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch596 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch597 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch598 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch59 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch592, null], [ttt2Branch594, null, ttt2Branch596], [ttt2Branch597, ttt2Branch598, null]]);
let ttt2Branch5 = new TicTacToeNode(1, 0, 0, "", [[null, ttt2Branch52, ttt2Branch53], [ttt2Branch54, null, ttt2Branch56], [ttt2Branch57, ttt2Branch58, ttt2Branch59]]);

let ttt2Branch6124 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6127 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6129 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch612 = new TicTacToeNode(3, 0, 2, "", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch613 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch614 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch617 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch619 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch61 = new TicTacToeNode(2, 2, 1, "", [[null, ttt2Branch612, ttt2Branch613], [ttt2Branch614, null, null], [ttt2Branch617, null, ttt2Branch619]]);
let ttt2Branch623 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch624 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch627 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch628 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6294 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6297 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6298 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch629 = new TicTacToeNode(3, 0, 2, "", [[null, null, null], [ttt2Branch6294, null, null], [ttt2Branch6297, ttt2Branch6298, null]]);
let ttt2Branch62 = new TicTacToeNode(2, 0, 0, "", [[null, null, ttt2Branch623], [ttt2Branch624, null, null], [ttt2Branch627, ttt2Branch628, ttt2Branch629]]);
let ttt2Branch6314 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6317 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6318 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch631 = new TicTacToeNode(3, 0, 1, "", [[null, null, null], [ttt2Branch6314, null, null], [ttt2Branch6317, ttt2Branch6318, null]]);
let ttt2Branch632 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch634 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch637 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch638 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch63 = new TicTacToeNode(2, 2, 2, "", [[ttt2Branch631, ttt2Branch632, null], [ttt2Branch634, null, null], [ttt2Branch637, ttt2Branch638, null]]);
let ttt2Branch642 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch643 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch647 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch648 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6492 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6497 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6498 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch649 = new TicTacToeNode(3, 0, 2, "", [[null, ttt2Branch6492, null], [null, null, null], [ttt2Branch6497, ttt2Branch6498, null]]);
let ttt2Branch64 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch642, ttt2Branch643], [null, null, null], [ttt2Branch647, ttt2Branch648, ttt2Branch649]]);
let ttt2Branch671 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch673 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch674 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6781 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6783 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6784 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch678 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch6781, null, ttt2Branch6783], [ttt2Branch6784, null, null], [null, null, null]]);
let ttt2Branch679 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch67 = new TicTacToeNode(2, 0, 1, "", [[ttt2Branch671, null, ttt2Branch673], [ttt2Branch674, null, null], [null, ttt2Branch678, ttt2Branch679]]);
let ttt2Branch681 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch682 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch684 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6871 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6872 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6874 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch687 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch6871, ttt2Branch6872, null], [ttt2Branch6874, null, null], [null, null, null]]);
let ttt2Branch689 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch68 = new TicTacToeNode(2, 0, 2, "", [[ttt2Branch681, ttt2Branch682, null], [ttt2Branch684, null, null], [ttt2Branch687, null, ttt2Branch689]]);
let ttt2Branch691 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch692 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch694 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6971 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6972 = new TicTacToeNode(4, 0, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch6974 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch697 = new TicTacToeNode(3, 2, 1, "", [[ttt2Branch6971, ttt2Branch6972, null], [ttt2Branch6974, null, null], [null, null, null]]);
let ttt2Branch698 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch69 = new TicTacToeNode(2, 0, 2, "", [[ttt2Branch691, ttt2Branch692, null], [ttt2Branch694, null, null], [ttt2Branch697, ttt2Branch698, null]]);
let ttt2Branch6 = new TicTacToeNode(1, 0, 2, "", [[ttt2Branch61, ttt2Branch62, ttt2Branch63], [ttt2Branch64, null, null], [ttt2Branch67, ttt2Branch68, ttt2Branch69]]);

let ttt2Branch712 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch713 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7163 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7168 = new TicTacToeNode(4, 2, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7169 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch716 = new TicTacToeNode(3, 0, 1, "", [[null, null, ttt2Branch7163], [null, null, null], [null, ttt2Branch7168, ttt2Branch7169]]);
let ttt2Branch718 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch719 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch71 = new TicTacToeNode(2, 1, 0, "", [[null, ttt2Branch712, ttt2Branch713], [null, null, ttt2Branch716], [null, ttt2Branch718, ttt2Branch719]]);
let ttt2Branch721 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch723 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7243 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7248 = new TicTacToeNode(4, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7249 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch724 = new TicTacToeNode(3, 0, 0, "", [[null, null, ttt2Branch7243], [null, null, null], [null, ttt2Branch7248, ttt2Branch7249]]);
let ttt2Branch728 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch729 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch72 = new TicTacToeNode(2, 1, 2, "", [[ttt2Branch721, null, ttt2Branch723], [ttt2Branch724, null, null], [null, ttt2Branch728, ttt2Branch729]]);
let ttt2Branch731 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch734 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch736 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7381 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7384 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7386 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch738 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch7381, null, null], [ttt2Branch7384, null, ttt2Branch7386], [null, null, null]]);
let ttt2Branch739 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch73 = new TicTacToeNode(2, 0, 1, "", [[ttt2Branch731, null, null], [ttt2Branch734, null, ttt2Branch736], [null, ttt2Branch738, ttt2Branch739]]);
let ttt2Branch742 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch743 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch746 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch748 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7492 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7493 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7496 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch749 = new TicTacToeNode(3, 2, 1, "", [[null, ttt2Branch7492, ttt2Branch7493], [null, null, ttt2Branch7496], [null, null, null]]);
let ttt2Branch74 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch742, ttt2Branch743], [null, null, ttt2Branch746], [null, ttt2Branch748, ttt2Branch749]]);
let ttt2Branch761 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch763 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch764 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7681 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7683 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7684 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch768 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch7681, null, ttt2Branch7683], [ttt2Branch7684, null, null], [null, null, null]]);
let ttt2Branch769 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch76 = new TicTacToeNode(2, 0, 1, "", [[ttt2Branch761, null, ttt2Branch763], [ttt2Branch764, null, null], [null, ttt2Branch768, ttt2Branch769]]);
let ttt2Branch7812 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7813 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7816 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch781 = new TicTacToeNode(3, 1, 0, "", [[null, ttt2Branch7812, ttt2Branch7813], [null, null, ttt2Branch7816], [null, null, null]]);
let ttt2Branch782 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch783 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch784 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch786 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch78 = new TicTacToeNode(2, 2, 2, "", [[ttt2Branch781, ttt2Branch782, ttt2Branch783], [ttt2Branch784, null, ttt2Branch786], [null, null, null]]);
let ttt2Branch791 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7921 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7923 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch7926 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch792 = new TicTacToeNode(3, 1, 0, "", [[ttt2Branch7921, null, ttt2Branch7923], [null, null, ttt2Branch7926], [null, null, null]]);
let ttt2Branch793 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch794 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch796 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch79 = new TicTacToeNode(2, 2, 1, "", [[ttt2Branch791, ttt2Branch792, ttt2Branch793], [ttt2Branch794, null, ttt2Branch796], [null, null, null]]);
let ttt2Branch7 = new TicTacToeNode(1, 1, 1, "", [[ttt2Branch71, ttt2Branch72, ttt2Branch73], [ttt2Branch74, null, ttt2Branch76], [null, ttt2Branch78, ttt2Branch79]]);

let ttt2Branch812 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch813 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8142 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8143 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8149 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch814 = new TicTacToeNode(3, 2, 0, "", [[null, ttt2Branch8142, ttt2Branch8143], [null, null, null], [null, null, ttt2Branch8149]]);
let ttt2Branch817 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch819 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch81 = new TicTacToeNode(2, 1, 2, "", [[null, ttt2Branch812, ttt2Branch813], [ttt2Branch814, null, null], [ttt2Branch817, null, ttt2Branch819]]);
let ttt2Branch823 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch824 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch826 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch827 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8293 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8294 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8296 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch829 = new TicTacToeNode(3, 2, 0, "", [[null, null, ttt2Branch8293], [ttt2Branch8294, null, ttt2Branch8296], [null, null, null]]);
let ttt2Branch82 = new TicTacToeNode(2, 0, 0, "", [[null, null, ttt2Branch823], [ttt2Branch824, null, ttt2Branch826], [ttt2Branch827, null, ttt2Branch829]]);
let ttt2Branch831 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch832 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8361 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8362 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8367 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch836 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch8361, ttt2Branch8362, null], [null, null, null], [ttt2Branch8367, null, null]]);
let ttt2Branch837 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch839 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch83 = new TicTacToeNode(2, 1, 0, "", [[ttt2Branch831, ttt2Branch832, null], [null, null, ttt2Branch836], [ttt2Branch837, null, ttt2Branch839]]);
let ttt2Branch842 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch843 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch846 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch847 = new TicTacToeNode(3, 2, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8492 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8493 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8496 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch849 = new TicTacToeNode(3, 2, 0, "", [[null, ttt2Branch8492, ttt2Branch8493], [null, null, ttt2Branch8496], [null, null, null]]);
let ttt2Branch84 = new TicTacToeNode(2, 0, 0, "", [[null, ttt2Branch842, ttt2Branch843], [null, null, ttt2Branch846], [ttt2Branch847, null, ttt2Branch849]]);
let ttt2Branch861 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch862 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch864 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8671 = new TicTacToeNode(4, 1, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8672 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8674 = new TicTacToeNode(4, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch867 = new TicTacToeNode(3, 2, 2, "", [[ttt2Branch8671, ttt2Branch8672, null], [ttt2Branch8674, null, null], [null, null, null]]);
let ttt2Branch869 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch86 = new TicTacToeNode(2, 0, 2, "", [[ttt2Branch861, ttt2Branch862, null], [ttt2Branch864, null, null], [ttt2Branch867, null, ttt2Branch869]]);
let ttt2Branch8712 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8713 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8716 = new TicTacToeNode(4, 0, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch871 = new TicTacToeNode(3, 1, 0, "", [[null, ttt2Branch8712, ttt2Branch8713], [null, null, ttt2Branch8716], [null, null, null]]);
let ttt2Branch872 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch873 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch874 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch876 = new TicTacToeNode(3, 0, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch87 = new TicTacToeNode(2, 2, 2, "", [[ttt2Branch871, ttt2Branch872, ttt2Branch873], [ttt2Branch874, null, ttt2Branch876], [null, null, null]]);
let ttt2Branch891 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch892 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8931 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8932 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch8934 = new TicTacToeNode(4, 0, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch893 = new TicTacToeNode(3, 1, 2, "", [[ttt2Branch8931, ttt2Branch8932, null], [ttt2Branch8934, null, null], [null, null, null]]);
let ttt2Branch894 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch896 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch89 = new TicTacToeNode(2, 2, 0, "", [[ttt2Branch891, ttt2Branch892, ttt2Branch893], [ttt2Branch894, null, ttt2Branch896], [null, null, null]]);
let ttt2Branch8 = new TicTacToeNode(1, 1, 1, "", [[ttt2Branch81, ttt2Branch82, ttt2Branch83], [ttt2Branch84, null, ttt2Branch86], [ttt2Branch87, null, ttt2Branch89]]);

let ttt2Branch913 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch914 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch916 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch917 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9183 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9184 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9186 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch918 = new TicTacToeNode(3, 2, 0, "", [[null, null, ttt2Branch9183], [ttt2Branch9184, null, ttt2Branch9186], [null, null, null]]);
let ttt2Branch91 = new TicTacToeNode(2, 0, 1, "", [[null, null, ttt2Branch913], [ttt2Branch914, null, ttt2Branch916], [ttt2Branch917, ttt2Branch918, null]]);
let ttt2Branch921 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch923 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9261 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9267 = new TicTacToeNode(4, 2, 1, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9268 = new TicTacToeNode(4, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch926 = new TicTacToeNode(3, 0, 2, "", [[ttt2Branch9261, null, null], [null, null, null], [ttt2Branch9267, ttt2Branch9268, null]]);
let ttt2Branch927 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch928 = new TicTacToeNode(3, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch92 = new TicTacToeNode(2, 1, 0, "", [[ttt2Branch921, null, ttt2Branch923], [null, null, ttt2Branch926], [ttt2Branch927, ttt2Branch928, null]]);
let ttt2Branch931 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch932 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9341 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9347 = new TicTacToeNode(4, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9348 = new TicTacToeNode(4, 2, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch934 = new TicTacToeNode(3, 0, 1, "", [[ttt2Branch9341, null, null], [null, null, null], [ttt2Branch9347, ttt2Branch9348, null]]);
let ttt2Branch937 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch938 = new TicTacToeNode(3, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch93 = new TicTacToeNode(2, 1, 2, "", [[ttt2Branch931, ttt2Branch932, null], [ttt2Branch934, null, null], [ttt2Branch937, ttt2Branch938, null]]);
let ttt2Branch941 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch943 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch946 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch947 = new TicTacToeNode(3, 2, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9481 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9483 = new TicTacToeNode(4, 1, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9486 = new TicTacToeNode(4, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch948 = new TicTacToeNode(3, 2, 0, "", [[ttt2Branch9481, null, ttt2Branch9483], [null, null, ttt2Branch9486], [null, null, null]]);
let ttt2Branch94 = new TicTacToeNode(2, 0, 1, "", [[ttt2Branch941, null, ttt2Branch943], [null, null, ttt2Branch946], [ttt2Branch947, ttt2Branch948, null]]);
let ttt2Branch961 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch962 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch964 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9671 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9672 = new TicTacToeNode(4, 0, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9674 = new TicTacToeNode(4, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch967 = new TicTacToeNode(3, 2, 1, "", [[ttt2Branch9671, ttt2Branch9672, null], [ttt2Branch9674, null, null], [null, null, null]]);
let ttt2Branch968 = new TicTacToeNode(3, 2, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch96 = new TicTacToeNode(2, 0, 2, "", [[ttt2Branch961, ttt2Branch962, null], [ttt2Branch964, null, null], [ttt2Branch967, ttt2Branch968, null]]);
let ttt2Branch971 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9721 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9723 = new TicTacToeNode(4, 1, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9726 = new TicTacToeNode(4, 0, 2, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch972 = new TicTacToeNode(3, 1, 0, "", [[ttt2Branch9721, null, ttt2Branch9723], [null, null, ttt2Branch9726], [null, null, null]]);
let ttt2Branch973 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch974 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch976 = new TicTacToeNode(3, 0, 1, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch97 = new TicTacToeNode(2, 2, 1, "", [[ttt2Branch971, ttt2Branch972, ttt2Branch973], [ttt2Branch974, null, ttt2Branch976], [null, null, null]]);
let ttt2Branch981 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch982 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9831 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9832 = new TicTacToeNode(4, 1, 0, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch9834 = new TicTacToeNode(4, 0, 0, "n", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch983 = new TicTacToeNode(3, 1, 2, "", [[ttt2Branch9831, ttt2Branch9832, null], [ttt2Branch9834, null, null], [null, null, null]]);
let ttt2Branch984 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch986 = new TicTacToeNode(3, 0, 2, "w", [[null, null, null], [null, null, null], [null, null, null]]);
let ttt2Branch98 = new TicTacToeNode(2, 2, 0, "", [[ttt2Branch981, ttt2Branch982, ttt2Branch983], [ttt2Branch984, null, ttt2Branch986], [null, null, null]]);
let ttt2Branch9 = new TicTacToeNode(1, 1, 1, "", [[ttt2Branch91, ttt2Branch92, ttt2Branch93], [ttt2Branch94, null, ttt2Branch96], [ttt2Branch97, ttt2Branch98, null]]);

let root2 = new TicTacToeNode(0, 0, 0, "", [[ttt2Branch1, ttt2Branch2, ttt2Branch3], [ttt2Branch4, ttt2Branch5, ttt2Branch6], [ttt2Branch7, ttt2Branch8, ttt2Branch9]]);
let ticTacToe2Node = root2;
let ticTacToe2Choices = [[true, true, true], [true, true, true], [true, true, true]];

function TicTacToe2Reset()
{
    ticTacToe2Choices = [[true, true, true], [true, true, true], [true, true, true]];
    ticTacToe2Node = root2;

    document.getElementById("FDS2025TicTacToe2Button00").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button01").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button02").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button10").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button11").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button12").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button20").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button21").disabled = false;
    document.getElementById("FDS2025TicTacToe2Button22").disabled = false;

    document.getElementById("FDS2025TicTacToe2Image00").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image01").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image02").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image10").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image11").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image12").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image20").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image21").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
    document.getElementById("FDS2025TicTacToe2Image22").src = "../../images/talk/FDS2025/TicTacToe/empty.png";
}

async function TicTacToe2PlaceX(i, j)
{
    ticTacToe2Choices[i][j] = false;
    document.getElementById(("FDS2025TicTacToe2Button" + i) + j).disabled = true;
    document.getElementById(("FDS2025TicTacToe2Image" + i) + j).src = "../../images/talk/FDS2025/TicTacToe/X.png";
    document.getElementById("FDS2025TicTacToe2Display").innerText = "AI turn";
    await Sleep(1000);
    TicTacToe2AITurn(i, j);
}

function TicTacToe2PlaceO(i, j)
{
    ticTacToe2Choices[i][j] = false;
    document.getElementById(("FDS2025TicTacToe2Button" + i) + j).disabled = true;
    document.getElementById(("FDS2025TicTacToe2Image" + i) + j).src = "../../images/talk/FDS2025/TicTacToe/O.png";
}

async function TicTacToe2AITurn(i, j)
{
    // case 1 : currentNode at grid [i,j] is null -> player either won or matched -- cannot happen here !
    if (ticTacToe2Node.leaves[i][j] == null)
    {
        await Sleep(1000);
        TicTacToe2Reset();
    }
    // case 2 : currentNode at grid [i,j] is not null -> new node is this one, place O on line, column and check action for win ('w') or matched ('n')
    else
    {
        ticTacToe2Node = ticTacToe2Node.leaves[i][j];
        let line = ticTacToe2Node.line;
        let column = ticTacToe2Node.column;
        TicTacToe2PlaceO(line, column);
        // check victory of matched
        let action = ticTacToe2Node.action;
        if (action == "w")
        {
            document.getElementById("FDS2025TicTacToe2Display").innerText = "AI victory !";
            await Sleep(1000);
            TicTacToe2AIWon();
        }
        else if (action == "n")
        {
            document.getElementById("FDS2025TicTacToe2Display").innerText = "Matched !";
            await Sleep(1000);
            TicTacToe2Matched();
        }
        document.getElementById("FDS2025TicTacToe2Display").innerText = "Player turn";
    }
}

function TicTacToe2AIWon()
{
    TicTacToe2Reset();
}

function TicTacToe2Matched()
{
    TicTacToe2Reset();
}

function TicTacToe2PlayerWon()
{
    TicTacToe2Reset();
}
