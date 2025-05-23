# LA-QUOI-LA-CLOPE

## Description

Projet pour la matière "projet d'assimiliation".

Le but est de créer un jeu pour la prévention du tabagisme.

La Quoi La Clope est un WarioWare-like où le joueur doit réaliser des mini-jeux en un temps limité.

> Alias : KOF KOF

## Histoire et promotions engagées sur KOF KOF
- P10 IEM 2024
- P9 IEM 2023

## Gameplay du jeu
- Le joueur arrive sur le menu ou il peut lancer ou quitter le jeu.
- La partie contient N (nombre défini) mini-jeux qui s'enchainent aléatoirement.
- Il n'y a pas de limite de temps pour chaque mini-jeu pour l'instant. (à voir si à prévoir)
- A la fin des N mini-jeux, le joueur a un score final.
- Le joueur peut rejouer ou quitter le jeu.

## Présentation des mini-jeux

### BabyClope
Le joueur doit tirer dans le but (les économies) en évitant le gardien (la clope) et en tirent avec une balle (une pièce).

-> Status: REPRIS

### SautDeClope
Le joueur doit sauter au dessus d'une haie de clopes dans sa course.

-> Status: REPRIS

### BrosseToiLesDents
Le joueur doit brosser les dents de son personnage avec un mouvement de va-et-vient pour enlever le jaune de la cigarette.

-> Status: NON REPRIS

### PrendsTonSpray
Aucune idée de ce que c'est mdr mais c'était un dossier dans le projet des P9.

-> Status: SUPPRIMÉ

### ArgentOuClope
Aucune idée de ce que c'est mdr mais c'était un dossier dans le projet des P9.

-> Status: SUPPRIMÉ

### PrendsPasLaTaffe
Le joueur doit appuyer sur l'écran pour empêcher le personnage de prendre une taffe.

-> Status: NON REPRIS

### TempetesDeCigarettesGéantes
Le joueur doit ramasser les mégots de cigarettes qui tombent du ciel.

-> Status: NON REPRIS

## Systèmes de l'ancienne version gardée mais non repris

### Tutos des mini-jeux
- Un logo montre comment jouer au jeu: TAP, DRAG, MULTI-TAP, etc.
- Un texte explique comment jouer au jeu: "TIRER", "SAUTER", "BROSSER", etc.

### Système de temps
- Chaque mini-jeu a un temps limité pour être réalisé.
- Un timer est affiché en haut de l'écran.
- Si le temps est écoulé, le mini-jeu est perdu.

# Ajouter des audios

## Ajouter les enums dans Constants.cs (Game Manager)

_trouver dans un premier temps l'acronyme de votre nouveau mini jeu en maximum 4 lettres (ex: PokeClope: PKCGameManager.cs)_

Ajouter le nom de l'audio sous format: $ACRONYME_$AUDIO dans l'enum `Audio`.

Ensuite, ajouter dans `AudioManager` le [SerializeField] $monAudio avec un [Header] au dessus si cela est un nouveau jeu.

Remplir l'audio dans unity avec l'audio dans le dossier Audio/$MiniJeu

Finalement, ajouter une ligne dans _audioClips en ajoutant { Audio.$ACRONYME_$AUDIO, $monAudio }

# Ajouter un Mini Jeu

Pour chaque fichier script du Mini Jeu, les nommer: $ACRONYME$MiniJeu -> ex: PCKGameManager, SCJump, BCCoinMovment

## Créer un mini jeu

**Pour chaque mini jeu, il faut un GameManager, la classe doit hériter de IGame**.

### IGame
- bool IsGameRunning -> une verification de si le mini jeu tourne actuellement
- void Win() -> Généralement, on fait les animations de win ici
- void Lost() -> Généralement aussi, on fait les animations de loose
- void Gameover() -> quand le timer du mini jeu est terminé. Généralement ici on appelle Lost() car il a forcément perdu.

Donc, on implémente les fonctions de l'interface IGame, ensuite il faut faire ces étapes:
- Dans la class GameManager du mini jeu, il faut ajouter la propriété: public bool IsGameRunning { get; set; }
- Dans le constructeur, ajouter ces lignes suivantes: `IsGameRunning = true; GameManager.Instance.CurrentGameManager = this;`, ce qui va dire que ce GameManager est celui qui va annoncer la victoire / défaite.
- Egalement ajoute cette méthode privée:
```csharp
private IEnumerator Result(bool win) {
  if (win) Win();
  else Lost();
  yield return new WaitForSeconds(1.5f); // le temps que dure les animations de Win ou Lost (0 si pas d'anim)
  GameManager.Instance.GameResult(win);
}
```
- Dans GameOver, on va mettre `IsGameRunning = false;` et appeller `StartCoroutine(Result(false));`.

Après, on va aller dans le script GameStats dans le dossier GameManager, on va ajouter le nom du mini jeu en UPPERCASE, et ensuite, ajouter la liaison entre l'enum et le nom réel de la scène du mini jeu dans la méthode GetSceneName juste en dessous de l'enum GameName.

La partie script est fini, ensuite on va aller dans la scène Management, pour aller dans le gameObject GameManager, et ajouter dans la liste des minis jeux les paramètres de temps du mini jeu, le message "tuto" au début du mini jeu, l'interaction et le nom du mini jeu.

PS évolution du système:
faudrais t il changer l'interface par une class abstract pour ainsi éviter de répéter la méthode Result ?
le systeme pour l'audio est trop complexe ? et le systeme
