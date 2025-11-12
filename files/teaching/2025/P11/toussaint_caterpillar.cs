// Auteur : Romain PERRIN

using System;

class Caterpillar
{
	// Fonction : AskGameSize
	// Entrée :	/
	// Sortie :	entier > 0
	public static int AskGameSize()
	{
		int size;
		string input;
		do
		{
			do
			{
				Console.Write("Enter the size of the game board (> 0) : ");
				input = Console.ReadLine();
			}
			while (input.Length < 1);
			size = int.Parse(input);
		}
		while (size < 1);
		return size;
	}
	
	// Fonction : InitGameBoard
	// Entrée :	- gameSize : entier
	// Sortie :	tableau 2D de gameSize*gameSize caractères
	public static char[,] InitGameBoard(int gameSize)
	{
		char[,] gameBoard = new char[gameSize, gameSize];
		for (int i = 0; i < gameSize; i++)
		{
			for (int j = 0; j < gameSize; j++)
			{
				gameBoard[i, j] = ' ';
			}
		}
		return gameBoard;
	}
	
	// Fonction : InitPlayerRow
	// Entrée :	- gameSize : entier
	// Sortie :	tableau 1D de 3*gameSize entiers
	public static int[] InitPlayerRow(int gameSize)
	{
		int[] playerRow = new int[3 * gameSize];
		for (int i = 0; i < 3 * gameSize; i++)
		{
			playerRow[i] = -1;
		}
		playerRow[0] = 0;
		return playerRow;
	}

	// Fonction : InitPlayerCol
	// Entrée :	- gameSize : entier
	// Sortie :	tableau 1D de 3*gameSize entiers
	public static int[] InitPlayerCol(int gameSize)
	{
		int[] playerCol = new int[3 * gameSize];
		for (int i = 0; i < 3 * gameSize; i++)
		{
			playerCol[i] = -1;
		}
		playerCol[0] = 0;
		return playerCol;
	}
	
	// Procédure : RandomPositionInGameBoard()
	// Entrée :	- gameBoard : tableau 2D de caractères
	//			- référence row : entier
	//			- référence col : entier
	//			- size: entier
	// Sortie :	void
	public static void RandomPositionInGameBoard(char[,] gameBoard, ref int row, ref int col, int size)
	{
		Random gen = new Random();
		int n; 
		do
		{
			n = gen.Next(0, size * size);
			row = n / size;
			col = n % size;
		}
		while (gameBoard[row, col] != ' ');
	}
	
	// Fonction : AskMovement
	// Entrée :	/
	// Sortie :	caractère
	public static char AskMovement()
	{
		string input;
		char action;
		do
		{
			do
			{
				Console.WriteLine("Choose the next action.");
				Console.WriteLine("'z' to move up");
				Console.WriteLine("'s' to move down");
				Console.WriteLine("'q' to move left");
				Console.WriteLine("'d' to move right");
				Console.WriteLine("'m' to stop the game");
				Console.Write("Enter the next action : ");
				input = Console.ReadLine();
			}
			while (input.Length < 1);
			action = input[0];
		}
		while (action != 'z' && action != 'q' && action != 's' && action != 'd' && action != 'm');
		return action;
	}
	
	// Procédure : DisplayBoard
	// Entrée :	- gameBoard
	// Sortie :	void
	public static void DisplayBoard(char[,] gameBoard)
	{
		for (int i = 0; i < gameBoard.GetLength(1) + 2; i++)
		{
			Console.Write("—");
		}
		Console.Write("\n");
		for (int i = 0; i < gameBoard.GetLength(0); i++)
		{
			Console.Write("|");
			for (int j = 0; j < gameBoard.GetLength(1); j++)
			{
				Console.Write($"{gameBoard[i, j]}");
			}
			Console.Write("|\n");
		}
		for (int i = 0; i < gameBoard.GetLength(1) + 2; i++)
		{
			Console.Write("—");
		}
		Console.Write("\n");
	}
	
	// Procédure : UpdateBoard
	// Entrée :	- gameBoard : tableau 2D de caractères
	//			- gameSize : entier
	//			- playerRow : tableau 1D d'entiers
	//			- playerCol : tableau 1D d'entiers
	//			- size : entier
	// Sortie :	void
	public static void UpdateBoard(char[,] gameBoard, int gameSize, int[] playerRow, int[] playerCol, int size)
	{
		// reset du gameBoard
		for (int i = 0; i < gameSize; i++)
		{
			for (int j = 0; j < gameSize; j++)
			{
				gameBoard[i, j] = ' ';
			}
		}
		// placement du joueur
		for (int i = 0; i < size; i++)
		{
			Console.WriteLine($"playerRow[{i}] = {playerRow[i]}");
		}
		gameBoard[playerRow[0], playerCol[0]] = 'C';	// tête
		for (int i = 1; i < size && playerRow[i] != -1 && playerCol[i] != -1; i++)
		{
			gameBoard[playerRow[i], playerCol[i]] = 'c';	// corps
		}
	}
	
	// Fonction : CheckSelfEat
	// Entrée :	- playerRow : tableau 1D d'entiers
	//			- playerCol : tableau 1D d'entiers
	//			- size : entier
	//			- incrR : entier
	//			- incrC : entier
	// Sortie :	booléen
	public static bool CheckSelfEat(int[] playerRow, int[] playerCol, int size, int incrR, int incrC)
	{
		int r = playerRow[0] + incrR;	// prochaine position de la tête en ligne
		int c = playerCol[0] + incrC;	// prochaine position de la tête en colonne
		for (int i = 0; i < size - 1 && playerRow[i] != -1 && playerCol[i] != -1; i++)
		{
			// on touche une ancienne position (entre 0 et size - 1)
			if (playerRow[i] == r && playerCol[i] == c)
			{
				return true;
			}
		}
		return false;
	}
	
	// Fonction : CheckOutOfBounds
	// Entrée :	- gameSize : entier
	// 			- playerRow : tableau 1D d'entiers
	//			- playerCol : tableau 1D d'entiers
	//			- incrR : entier
	//			- incrC : entier
	// Sortie :	booléen
	public static bool CheckOutOfBounds(int gameSize, int[] playerRow, int[] playerCol, int incrR, int incrC)
	{
		int r = playerRow[0] + incrR;
		int c = playerCol[0] + incrC;
		if (r < 0 || r >= gameSize || c < 0 || c >= gameSize)
		{
			return true;
		}
		return false;
	}
	
	// Fonction : CheckEatLeaf
	// Entrée :	- playerRow : tableau 1D d'entiers
	//			- playerCol : tableau 1D d'entiers
	//			- incrR : entier
	//			- incrC : entier
	//			- tokenRow : entier
	//			- tokenCol : entier
	// Sortie :	booléen
	public static bool CheckEatLeaf(int[] playerRow, int[] playerCol, int incrR, int incrC, int tokenRow, int tokenCol)
	{
		int r = playerRow[0] + incrR;
		int c = playerCol[0] + incrC;
		if (r == tokenRow && c == tokenCol)
		{
			return true;
		}
		return false;
	}
	
	// Procédure : ApplyMovement
	// Entrée :	- playerRow : tableau 1D d'entiers
	//			- playerCol : tableau 1D d'entiers
	//			- référence incrR : entier
	//			- référence incrC : entier
	//			- référence size : entier
	// Sortie :	void
	public static void ApplyMovement(int[] playerRow, int[] playerCol, ref int incrR, ref int incrC, ref int size)
	{
		// toutes les positions (playerRow, playerCol) sont à bouger d'une case vers la droite
		// la case 1 prend la valeur de la case 0 (ancienne tête), la case 2 celle de la case 1...
		// la case size-1 est perdue
		// la case 0 devient l'ancienne case 0 + (incrR, incrC) aka la nouvelle tête
		for (int i = size - 1; i >= 1; i--)
		{
			playerRow[i] = playerRow[i - 1];
			playerCol[i] = playerCol[i - 1];
		}
		if (size == 1)
		{
			playerRow[0] += incrR;
			playerCol[0] += incrC;
		}
		else
		{
			playerRow[0] = playerRow[1] + incrR;
			playerCol[0] = playerCol[1] + incrC;
		}
		incrR = 0;
		incrC = 0;
	}
	
	// Procédure : EatLeaf
	// Entrée :	- playerRow : tableau 1D d'entiers
	//			- playerCol : tableau 1D d'entiers
	//			- tokenRow : entier
	//			- tokenCol : entier
	//			- référence size : entier
	// Sortie :	void
	public static void EatLeaf(int[] playerRow, int[] playerCol, ref int incrR, ref int incrC, ref int size)
	{
		// toutes les positions (playerRow, playerCol) sont à bouger d'une case vers la droite
		// la case 1 prend la valeur de la case 0 (ancienne tête), la case 2 celle de la case 1...
		// la case size-1 déborde en size (+1 en longueur)
		// la case 0 devient l'ancienne case 0 + (incrR, incrC) aka la nouvelle tête
		for (int i = size; i >= 1; i--)
		{
			playerRow[i] = playerRow[i - 1];
			playerCol[i] = playerCol[i - 1];
		}
		playerRow[0] = playerRow[1] + incrR;
		playerCol[0] = playerCol[1] + incrC;
		size++;
		incrR = 0;
		incrC = 0;
	}
	
	public static void Main()
	{
		// initialisation du jeu
		int gameSize = AskGameSize();
		char[,] gameBoard = InitGameBoard(gameSize);
		gameBoard[0,0] = 'C';
		int[] playerRow = InitPlayerRow(gameSize);
		int[] playerCol = InitPlayerCol(gameSize);
		int tokenRow = -1;
		int tokenCol = -1;
		int incrR = 0;
		int incrC = 0;
		int size = 1;
		UpdateBoard(gameBoard, gameSize, playerRow, playerCol, size);
		RandomPositionInGameBoard(gameBoard, ref tokenRow, ref tokenCol, gameSize);
		gameBoard[tokenRow, tokenCol] = 'o';
		
		// début du jeu
		bool play = true;
		char nextAction;
		while (play)
		{
			// affichage du plateau
			DisplayBoard(gameBoard);
			// prochain mouvement
			nextAction = AskMovement();
			switch (nextAction)
			{
				case 'z':
					incrR = -1; break;
				case 's':
					incrR = 1; break;
				case 'q': 
					incrC = -1; break;
				case 'd':
					incrC = 1; break;
				default:
					// la fonction AskMovement ne peut retourner que 'z', 's', 'q', 'd' ou 'm' donc ici c'est le cas 'm'
					play = false;
					break;
			}
			// tester la validité du déplacement (toucher son corps, sortir de l'espace vital, manger un feuille)
			if (CheckSelfEat(playerRow, playerCol, size, incrR, incrC))
			{
				Console.WriteLine("You ate yourself you moron !");
				play = false;
			}
			else if (CheckOutOfBounds(gameSize, playerRow, playerCol, incrR, incrC))
			{
				Console.WriteLine("Don't leave your Lebensraum !!!");
				play = false;
			}
			else if (CheckEatLeaf(playerRow, playerCol, incrR, incrC, tokenRow, tokenCol))
			{
				EatLeaf(playerRow, playerCol, ref incrR, ref incrC, ref size);
				UpdateBoard(gameBoard, gameSize, playerRow, playerCol, size);
				RandomPositionInGameBoard(gameBoard, ref tokenRow, ref tokenCol, gameSize);
				gameBoard[tokenRow, tokenCol] = 'o';
			}
			else
			{
				ApplyMovement(playerRow, playerCol, ref incrR, ref incrC, ref size);
				UpdateBoard(gameBoard, gameSize, playerRow, playerCol, size);
				gameBoard[tokenRow, tokenCol] = 'o';
			}
			// vérification de victoire
			if (size >= 3 * gameSize)
			{
				Console.WriteLine("VICTORY !!!");
				play = false;
			}
		}
	}
}
