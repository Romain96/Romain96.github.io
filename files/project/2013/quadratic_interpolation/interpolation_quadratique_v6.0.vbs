Init gfx, 5 ' Nombre entier de millisecondes entre chaque tracé

' parties théorique et pratique réalisées par RAJENDIRAN Vinojan et PERRIN Romain
' Script interpolation quadratique, version 6.0 : version finale !
'
' Paramètres à utiliser pour le repère (les mêmes que pour le TD "courbes et fonctions")
'
couleur_axes = 195
couleur_grille = &h1003399
unite = 40
'
' Paramètres à utiliser pour la courbe et les croix 
'
couleur_croix = &h1ffffff
rayon_croix = 10
'
' Repère orthonormé (tiré du TD courbes et fonctions réalisé en cours)
'
For px = unite To 320 Step unite
    Line px, -239, px, 240, couleur_grille
    Line -px, -239, -px, 239, couleur_grille
Next

For py = unite To 240 Step unite
    Line -319, py, 320, py, couleur_grille
    Line -319, -py, 320, -py, couleur_grille
Next

Line -319, 0, 320, 0, couleur_axes
Line 305, 5, 320, 0, couleur_axes
Line 305, -5, 320, 0, couleur_axes

Line 0, -239, 0, 240, couleur_axes    
Line -5, 225, 0, 240, couleur_axes
Line 5, 225, 0, 240, couleur_axes

Line unite, -5, unite, 5, couleur_axes
Line 5, unite, -5, unite, couleur_axes

' On trace la courbe de f avec la technique de la "courbe reliée" (on aurait aussi pû utiliser la technique "Monte Carlo")
' On répète les opérations (demander x0, tracer la courbe, marquer les racines et f(1)=0) indéfinément

Do
    '
    ' On demande X0 à l'utilisateur et on lui autorise la saisie des nombres décimaux
    '
    x0 = Eval(InputBox("Bonjour cher utilisateur, nous sommes heureux que vous utilisiez notre script" & VbCrLf & VbCrLf & "Script réalisé par :" &VbCrLf & "RAJENDIRAN Vinojan" & VbCrLf & "PERRIN Romain" & VbCrLf & VbCrLf & "Veuillez entrer la valeur de x0: ","Projet Interpolation Quadratique v6.0"))
    '
    ' Si on ne rempli pas la case ou que l'on clique sur "annuler" , on quitte la boucle
    '
    If x0 = 0 Then Exit Do
    '
    ' On calcule a, b et c
    '
    a = 1/x0
    b = -1 - a
    c = 1
    '
    'On calcule px0 et on l'arrondi
    '
    px0 = Round (x0*unite)
    '
    For px = -320 To 320
		x = px/unite
		y = a*x^2 + b*x + c
		py = y*unite
		Line px - 1, py_precedent, px, py, a*180
		py_precedent = py
		'
		'On trace les croix blanches aux racines et en f(0)=1
		'
		If px = unite Or px = px0 Then
			py = 0
			Line px - rayon_croix, py, px + rayon_croix, py, couleur_croix
			Line px, py - rayon_croix, px, py + rayon_croix, couleur_croix
		End If
		If px = 0 Then
			py = unite
			Line px - rayon_croix, py, px + rayon_croix, py, couleur_croix
			Line px, py - rayon_croix, px, py + rayon_croix, couleur_croix
		End If
    Next
Loop 

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Passerelle graphique VBS_gfx 1.2.0.4 - Ne rien écrire à partir de cette ligne

gfx.Write "."
gfx.Close

Sub Init (gfx, v)
    Set fs = CreateObject ("Scripting.FileSystemObject")
    Set gfx = fs.CreateTextFile (fs.GetSpecialFolder(2) & "\VBS_gfx.txt", True)
    gfx.WriteLine CLng(v)
    CreateObject ("WScript.Shell").Run "VBS_gfx.exe"
End Sub

Sub Plot (x, y, c)
    gfx.WriteLine CLng(c*17) & "," & CLng(x) & "," & CLng(y)
End Sub

Sub Line (x1, y1, x2, y2, c)
    gfx.WriteLine CLng(c*17) & "," & CLng(x2) & "," & CLng(y2) & "," & CLng(x1) & "," & CLng(y1)
End Sub

Sub Buffer
    gfx.WriteLine 0
End Sub

Sub Flush
    gfx.WriteLine 1
End Sub