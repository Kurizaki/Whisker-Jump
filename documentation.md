
# Project Documentation

Whisker Jump team: Lorenzo, Keanu, Dorian, Cyril

| Date | Version | Summary                                                  |
| ---- | ------- | -------------------------------------------------------- |
|  23.08.24    | 0.0.1   | We created a .NET MAUI project and started to change the MainWindow.xaml file. |
|      | ...     |                                                          |
|      | ...     |                                                          |
|      | ...     |                                                          |
|      | ...     |                                                          |
|      | ...     |                                                          |
|      | ...     |                                                          |

## 1. Information

### 1.1 Your Project

Whisker Jump is a copy in .NET MAUI off Doodle Jump. The main character is cat, who will jump on top of platform to reach a high highscore. Once the cat falls down, the game is over and the player loses. There might be the possibility oof a shop, in which the player can buy skins and items. The player will have to catch fish, since they will be used to purchase items from the shop.

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

✍️ The number follows the format `N.m`, where `N` is the number of the user story that the test case covers, and `m` starts from `1` and increments. For example, the third test case that covers the second user story would have the number `2.3`.

### 1.4 Diagrams

✍️ Here you can insert PAPs, Use Case diagrams, Gantt charts, or similar visuals.

## 2. Planning

| AP-№ | Deadline | Responsible | Description | Planned Time |
| ---- | -------- | ----------- | ----------- | ------------ |
| 1.A  |          |             |             |              |
| ...  |          |             |             |              |

Total: 

✍️ The number follows the format `N.m`, where `N` is the number of the user story to which the work package relates, and `m` starts from `A` and goes upward in letters. For example, the third work package related to the second user story would have the number `2.C`.

✍️ A work package should take approximately 45 minutes for one person. The total number of work packages should roughly match this formula: `Number of R-Sessions` ╳ `Number of Group Members` ╳ `4`. So, if three people are working on a project with two planned R-sessions, you should have `2` ╳ `3` ╳ `4` = `24` work packages. If you find that you don’t have enough work packages, consider adding more "Can"-type user stories in Section 1.2.

## 3. Decisions

✍️ Document here the decisions and assumptions you made regarding your user stories and implementation.

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

### 5.2 Exploratory Testing

| BR-№ | Initial State | Input  | Expected Output | Actual Output |
| ---- | ------------ | ------ | --------------- | ------------- |
| I    |              |        |                 |               |
| ...  |              |        |                 |               |

✍️ Use Roman numerals for your bug reports, such as I, II, III, IV, etc.

## 6. Evaluation

✍️ Add a link to your learning report here.
