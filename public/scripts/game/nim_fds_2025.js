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
	Nim1UpdateStatus("ongoing");
	Nim1UpdateTurn("human");
	// all token position images to blank except the number 9 where the toke is displayed
	document.getElementById("nim_1_token_position_9").src = "../../images/talk/FDS2025/Nim/NimToken.png";
	document.getElementById("nim_1_token_position_8").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_7").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_6").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_5").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_4").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_3").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_2").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_1").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_1_token_position_0").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	// all token images to blank
	document.getElementById("nim_1_token_image_1").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_2").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_3").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_4").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_5").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_6").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_7").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_1_token_image_8").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
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
	// human turn
	nim1TokenPosition = Math.max(0, nim1TokenPosition - index);
	Nim1MoveTokenToPosition();
	Nim1DisableMove();
	if (nim1TokenPosition == 0)
	{
		Nim1PlayerLost();
		return;
	}
	// AI turn
	Nim1UpdateStatus("ongoing");
	Nim1UpdateTurn("ai");
	await Sleep(1000);	// 1s
	Nim1AIMove();
}

function Nim1MoveTokenToPosition()
{
	for (i = 9; i >= 0; i--)
	{
		let id = "nim_1_token_position_" + i;
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
	// player turn
	Nim1UpdateStatus("ongoing");
	Nim1UpdateTurn("human");
	await Sleep(1000);	// 1s
	Nim1EnableMove();
}

function Nim1PickTokenFromCup(tokenValue, cupIndex)
{
	let tokenImage = "../../images/talk/FDS2025/Nim/Token" + tokenValue + ".png";
	let tokenId = "nim_1_token_image_" + cupIndex;
	document.getElementById(tokenId).src = tokenImage;
}

function Nim1EnableMove()
{
	document.getElementById("nim_1_button_move_1").disabled = false;
	document.getElementById("nim_1_button_move_2").disabled = false;
	document.getElementById("nim_1_button_move_3").disabled = false;
}

function Nim1DisableMove()
{
	document.getElementById("nim_1_button_move_1").disabled = true;
	document.getElementById("nim_1_button_move_2").disabled = true;
	document.getElementById("nim_1_button_move_3").disabled = true;
}

function Nim1PlayerLost()
{
	Nim1DisableMove();
	Nim1UpdateStatus("ai");
}

function Nim1UpdateTurn(player)
{
	// disabling all
	document.getElementById("nim_1_display_human").hidden = true;
	document.getElementById("nim_1_display_ai").hidden = true;

	// enabling requested
	if (player == "human")
	{
		document.getElementById("nim_1_display_human").hidden = false;
	}
	else if (player == "ai")
	{
		document.getElementById("nim_1_display_ai").hidden = false;
	}
}

function Nim1UpdateStatus(status)
{
	// disabling all
	document.getElementById("nim_1_status_ongoing").hidden = true;
	document.getElementById("nim_1_status_human").hidden = true;
	document.getElementById("nim_1_status_ai").hidden = true;

	// enabling requested
	if (status == "ongoing")
	{
		document.getElementById("nim_1_status_ongoing").hidden = false;
	}
	else if (status == "human")
	{
		document.getElementById("nim_1_status_human").hidden = false;
	}
	else if (status == "ai")
	{
		document.getElementById("nim_1_status_ai").hidden = false;
	}
}

// default config
Nim1Reset();

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
	nim2PlayerWon = 0;
	nim2AIWon = 0;
	nim2CupTokens = [[1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3], [1, 2, 3]];
	nim2LastChoiceIndex = -1;
	nim2LastChoiceValue = -1;
	// enabling all buttons
	Nim2EnableMove();
	Nim2UpdateTurn("human");
	Nim2UpdateStatus("ongoing");
	Nim2UpdateStats();
	// all token position images to blank except the number 9 where the toke is displayed
	document.getElementById("nim_2_token_position_9").src = "../../images/talk/FDS2025/Nim/NimToken.png";
	document.getElementById("nim_2_token_position_8").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_7").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_6").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_5").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_4").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_3").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_2").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_1").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_0").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	// all token images to blank
	document.getElementById("nim_2_token_image_0").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_1").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_2").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_3").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_4").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_5").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_6").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_7").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_8").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_9").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	// all cup tokens to 1,2,3
	document.getElementById("nim_2_cup_8_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_8_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_8_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_7_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_7_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_7_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_6_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_6_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_6_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_5_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_5_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_5_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_4_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_4_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_4_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_3_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_3_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_3_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_2_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_2_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_2_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
	document.getElementById("nim_2_cup_1_token_1").src = "../../images/talk/FDS2025/Nim/Token1.png";
	document.getElementById("nim_2_cup_1_token_2").src = "../../images/talk/FDS2025/Nim/Token2.png";
	document.getElementById("nim_2_cup_1_token_3").src = "../../images/talk/FDS2025/Nim/Token3.png";
}

function Nim2ResetGame()
{
	nim2TokenPosition = 9;
	nim2LastChoiceIndex = -1;
	nim2LastChoiceValue = -1;
	// enabling all buttons
	Nim2EnableMove();
	// all token position images to blank except the number 9 where the toke is displayed
	document.getElementById("nim_2_token_position_9").src = "../../images/talk/FDS2025/Nim/NimToken.png";
	document.getElementById("nim_2_token_position_8").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_7").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_6").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_5").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_4").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_3").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_2").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_1").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	document.getElementById("nim_2_token_position_0").src = "../../images/talk/FDS2025/Nim/NimTokenEmpty.png";
	// all token images to blank
	document.getElementById("nim_2_token_image_0").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_1").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_2").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_3").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_4").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_5").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_6").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_7").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_8").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	document.getElementById("nim_2_token_image_9").src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
}

function Nim2EnableMove()
{
	document.getElementById("nim_2_button_move_1").disabled = false;
	document.getElementById("nim_2_button_move_2").disabled = false;
	document.getElementById("nim_2_button_move_3").disabled = false;
}

function Nim2DisableMove()
{
	document.getElementById("nim_2_button_move_1").disabled = true;
	document.getElementById("nim_2_button_move_2").disabled = true;
	document.getElementById("nim_2_button_move_3").disabled = true;
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
	// player turn
	nim2TokenPosition = Math.max(0, nim2TokenPosition - index);
	Nim2MoveTokenToPosition();
	Nim2DisableMove();
	if (nim2TokenPosition == 0)
	{
		Nim2PlayerLost();
		return;
	}
	// AI turn
	await Sleep(1000);	// 1s
	Nim2UpdateTurn("ai");
	Nim2UpdateStatus("ongoing");
	Nim2AIMove();
	if (nim2TokenPosition == 0)
	{
		Nim2AILost();
		return;
	}
	else
	{
		Nim2EnableMove();
	}
}

function Nim2MoveTokenToPosition()
{
	for (i = 9; i >= 0; i--)
	{
		let id = "nim_2_token_position_" + i;
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
	let maxChoice = nim2CupTokens[cupIndex].length;
	if (maxChoice == 0)
	{
		Nim2AILost();
	}
	else
	{
		let pick = nim2CupTokens[cupIndex][Math.floor(Math.random() * nim2CupTokens[cupIndex].length)];
		nim2LastChoiceIndex = cupIndex;
		nim2LastChoiceValue = pick;
		let newPosition = Math.max(0, nim2TokenPosition - pick);
		let imageID = "nim_2_token_image_" + nim2TokenPosition;
		document.getElementById(imageID).src = "../../images/talk/FDS2025/Nim/Token" + pick + ".png";
		nim2TokenPosition = newPosition;
		Nim2MoveTokenToPosition();
		// player turn
		await Sleep(1000);	// 1s
		Nim2UpdateTurn("human");
		Nim2UpdateStatus("ongoing");
	}
}

function Nim2PlayerLost()
{
	nim2GamePlayed += 1;
	nim2AIWon += 1;
	Nim2UpdateTurn("human");
	Nim2UpdateStatus("ai");
	Nim2UpdateStats();
	Nim2DisableMove();
}

function Nim2AILost()
{
	nim2GamePlayed += 1;
	nim2PlayerWon += 1;
	Nim2UpdateTurn("human");
	Nim2UpdateStatus("human");
	Nim2UpdateStats();
	// learn
	Nim2LearnFromMistake();
	Nim2DisableMove();
}

function Nim2LearnFromMistake()
{
	// removing the last choice
	let index = nim2CupTokens[nim2LastChoiceIndex].indexOf(nim2LastChoiceValue);
	nim2CupTokens[nim2LastChoiceIndex].splice(index, 1);
	let imageID = "nim_2_cup_" + (nim2LastChoiceIndex + 1) + "_token_" + nim2LastChoiceValue;
	document.getElementById(imageID).src = "../../images/talk/FDS2025/Nim/EmptyToken.png";
	nim2LastChoicesIndex = [];
	nim2LastChoicesValue = [];
}

function Nim2UpdateTurn(player)
{
	// disabling all
	document.getElementById("nim_2_display_human").hidden = true;
	document.getElementById("nim_2_display_ai").hidden = true;

	// enabling requested
	if (player == "human")
	{
		document.getElementById("nim_2_display_human").hidden = false;
	}
	else if (player == "ai")
	{
		document.getElementById("nim_2_display_ai").hidden = false;
	}
}

function Nim2UpdateStatus(status)
{
	// disabling all
	document.getElementById("nim_2_status_ongoing").hidden = true;
	document.getElementById("nim_2_status_human").hidden = true;
	document.getElementById("nim_2_status_ai").hidden = true;

	// enabling requested
	if (status == "ongoing")
	{
		document.getElementById("nim_2_status_ongoing").hidden = false;
	}
	else if (status == "human")
	{
		document.getElementById("nim_2_status_human").hidden = false;
	}
	else if (status == "ai")
	{
		document.getElementById("nim_2_status_ai").hidden = false;
	}
}

function Nim2UpdateStats()
{
	console.log(nim2GamePlayed + " - " + nim2PlayerWon + " - " + nim2AIWon);
	document.getElementById("nim_2_stats_played_num").innerText = nim2GamePlayed;
	document.getElementById("nim_2_stats_human_num").innerText = nim2PlayerWon;
	document.getElementById("nim_2_stats_ai_num").innerText = nim2AIWon;
}

// default config
Nim2Reset()