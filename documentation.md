
# Project Documentation

Whisker Jump team: Lorenzo, Keanu, Dorian, Cyril

| Date | Version | Summary                                                  |
| ---- | ------- | -------------------------------------------------------- |
|  23.08.24    | 0.0.1   | We created a .NET MAUI project and started to change the MainWindow.xaml file. |
|  30.08.24    | 0.0.2   | We made a Figma about our project and started to recreate the design of it in MAUI. The game logic hasn't been touched yet.   |
|  06.09.24    | 0.0.3   | Today, we changed the Figma to better suit our program. We made a Use-Case of our program. We started to work on the logic behind the platforms and the buttons.   |
|  13.09.24    | 0.1.0   | Today we started to implement the logic for the platforms by adding sprites and movement.                                                         |
|  20.09.24    | 0.1.1   | Today, we are still implementing the logic for the platforms and the charachter movement, as this is the biggest part of the project.                                                         |
|      | ...     |                                                          |
|      | ...     |                                                          |

## 1. Information

### 1.1 Your Project

Whisker Jump is a game heavily inspired by the gamme Doodle Jump and is made in .NET MAUI. The main character is cat, who will jump on top of platform to reach a high highscore. Once the cat falls down, the game is over and the player loses. There might be the possibility oof a shop, in which the player can buy skins and items. The player will have to catch fish, since they will be used to purchase items from the shop.

### 1.2 User Stories

| US-№ | Priority     | Type | Description                             |
| ---- | ------------ | ---- | --------------------------------------- |
|1|	Must|	Functional|	As a player, I want to control a character by pressing two buttons at the bottom of the screen, so that I can navigate the platforms and progress in the game.|
|2|	Must|	Functional|	As a player, I want the platforms to appear randomly, so that each game session feels unique.|
|3|	Must|	Functional|	As a player, I want to collect fish during gameplay to earn points or in-game currency.|
|4|	Can|	Functional|	As a player, I want to access a shop where I can spend collected fish to buy power-ups, skins, or other items.|
|5|	Must|	Functional|	As a player, I want to see my high scores after each game, so that I can track my progress.|
|6|	Can|	Functional|	As a player, I want the game to include different types of platforms, such as moving or breaking platforms, to add variety to the gameplay.|
|7|	Must|	Quality|	As a player, I want the game to have a smooth frame rate and responsive controls, so that the gameplay experience is enjoyable and free of lag.|
|8|	Must|	Functional|	As a player, I want my progress and high scores to be saved automatically, so I don’t lose my achievements when I exit the game.|
|9|	Can|	Functional|	As a player, I want to have an option to customize my character with different skins or outfits, after buying them from the shop.|
|10|	Can|	Non-functional|	As a player, I want the game to be available on Android devices.|

### 1.3 Test Cases

| TC-№ | Initial State | Input  | Expected Output |
| ---- | ------------- | ------ | --------------- |
|1|	Game is running, player is on a platform at the start of the game.|	Press the left or right button at the bottom of the screen.|	The character moves left or right according to the button pressed.|
|2|	Game is at the start of a new session.|	Start a new game session.|	Platforms appear randomly and in different positions each session.|
|3|	Game is in progress, player is jumping on platforms.|	Move the character to collect fish that appear during gameplay.|	Fish are collected, and points or in-game currency are increased.|
|4|	Player has collected fish and the game session has ended.|	Access the in-game shop from the main menu.|	The shop opens, allowing the player to spend fish on power-ups, skins, or items.|
|5|	Game session has ended.|	View the post-game screen.|	The player's high score is displayed on the screen.|
|6|	Game is in progress.|	Continue playing the game.|	Different types of platforms (moving, breaking) appear during gameplay.|
|7|	Game is running.|	Observe game performance.|	The game runs at a smooth frame rate, and controls are responsive without lag.|
|8|	Game session has ended, player has achieved a new high score.|	Exit the game.|	High score and progress are saved automatically.|
|9|	Player has purchased a skin from the shop.|	Access the character customization menu.|	The purchased skin is available for selection, and the player can apply it to their character.|
|10|	Game is installed on an Android device.|	Launch the game on an Android device.|	The game launches successfully, and all functionalities work as intended on Android.|

### 1.4 Diagrams


![image](https://github.com/user-attachments/assets/c14c57d8-a789-4147-bf13-b2760fda5739)


![Whisker-Jump_Use-Case](https://github.com/user-attachments/assets/08fde408-263b-4ce6-995a-e661468a1150)



## 2. Planning

| AP-№ | Deadline | Responsible | Description | Planned Time |
| ---- | -------- | ----------- | ----------- | ------------ |
| 1.A  | 6.09.24         |      -       |      Two buttons at the bottom of the screen are present.       |       45'       |
| 1.B  | 6.09.24         |      -       |      Logic for the buttons is implemented and the buttons make the character move.       |     180'         |
| 2.A  | 6.09.24         |      -       |      Platforms (of various types) appear on the screen after hitting "Play".       |       60'       |
| 2.B  | 6.09.24         |      -       |      Logic for the platforms is implemented. the player can phisically interact with them.       |       200'      |
| 3.A  |    6.09.24      |      -       |      Fishes spawn of top of platforms.       |      30'        |
| 3.B  |    13.09.24     |      -       |      Fish logic is implemented and the player can collect the fishes by touching them while playing.       |       60'       |
| 4.A  |    13.09.24      |     -       |      The amount of fish collected will be shown on the screen.       |       15'       |
| 4.B  |    13.09.24      |     -       |      The player can enter the shop by clicking the "shop" button at the start of the game.       |       45'       |
| 4.C  |    13.09.24      |     -       |      The palyer is able to purchase various items and skins thanks to the collected fishes.       |      120'        |
| 4.D  |    13.09.24      |     -       |     Fish and shop logic are implemented in the game. The player can equip skins / items from the shop.        |       180'        |
| 5.A  |    20.09.24      |     -       |     An highscore displays the highest amount of points that the player has ever gotten.        |         30'     |
| 6.A  |    20.09.24      |     -       |     Stationary paltforms are present int the game.        |      180'        |
| (6.B)  |   20.09.2      |     -       |     Moving platforms; Breakable paltforms; "One-Time-Use" platforms and boost platforms are present in the game.        |      300'        |
| 6.C  |    20.09.24      |     -       |     The game logic for the platforms (potentially for 6.B aswell) is implemented in the game and the character can interact with them.        |       240'       |
| 7.A  |    When the game is finished      |      -       |      Game runs smoothly       |       ?       |
| 8.A  |    27.09.24      |     -       |     Highscore saves the best try automatically.        |      60'        |
| 9.A  |    27.09.24      |     -       |     The player can wear clothes or use items after purchasing them from the store.        |         180'     |
| 10.A |     -     |      -       |      Game is on android       |       -       |

Total: 1817 minutes ~ 30 hours

## 3. Decisions

We chose these user stories because we find them to be perfect for this program. The systematic implementation of platforms is a great help for us, as this is the first time we are working with .NET MAUI. This enables us to implement what we really can and, if good enough, even more. The various parts of this program have been separated so that if one part doesn’t work, the rest can. The player character should be fully implemented for the program to be functional, as well as the buttons. Many ideas are not documented, as it might be too much for this group to handle, but they are still with us, and if needed, we can implement them in the program.

The work packages have been created in a way that if one person isn’t able to implement something, others can jump in to help. Many packages are divided into two parts: the logic (C#) and the GUI (XML). If someone can’t implement the GUI part, they can try to make the logic work, after someone else either helps them or does it themselves.

## 4. Implementation

| AP-№ | Date  | Responsible | Planned Time | Actual Time   |
| ---- | ----- | ----------- | ------------ | ------------- |
| 1.A  |       |             |              |               |
| ...  |       |             |              |               |

✍️ Each time you complete a work package, record how long it actually took.

## 5. Control

### 5.1 Test Report

| TC-№ | Date  | Result | Tester |
| ---- | ----- | ------ | ------ |
| 1.1  |       |        |        |
| ...  |       |        |        |

✍️ Don’t forget to add a conclusion that summarizes the test results.

## 6. Evaluation

✍️ Add a link to your learning report here.
