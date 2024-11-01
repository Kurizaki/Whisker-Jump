
# Whisker Jump Project Documentation

## Whisker Jump Team
- **Lorenzo**
- **Keanu**
- **Dorian**
- **Cyril**

| Date     | Version | Summary                                                                                              |
|----------|---------|------------------------------------------------------------------------------------------------------|
| 23.08.24 | 0.0.1   | Created a .NET MAUI project and started modifying the MainWindow.xaml file.                          |
| 30.08.24 | 0.0.2   | Created a Figma prototype and began implementing the design in MAUI. Game logic is pending.          |
| 06.09.24 | 0.0.3   | Updated the Figma design to align with the app. Created a use-case diagram and started platform logic.|
| 13.09.24 | 0.1.0   | Implemented platform logic, adding sprites and movement controls.                                     |
| 20.09.24 | 0.1.1   | Continued platform logic development and character movement.                                         |
| 27.09.24 | 0.1.2   | Refined game logic and game loop for platforms and character movement.                               |
| 01.11.24 | 0.2.0   | Added game music, improved jumping mechanics and control logic.                                      |


## 1. Project Overview

### 1.1 Whisker Jump
Whisker Jump is a .NET MAUI game inspired by *Doodle Jump*. Players control a cat character that jumps across platforms to reach high scores. Falling off ends the game. The game may include a shop where players can buy skins and items using fish collected during gameplay.

### 1.2 User Stories

| US-№ | Priority | Type            | Description                                                                                           |
|------|----------|-----------------|-------------------------------------------------------------------------------------------------------|
| 1    | Must     | Functional      | Control the character using two buttons at the screen bottom for navigating platforms.                |
| 2    | Must     | Functional      | Platforms appear randomly for unique game sessions.                                                   |
| 3    | Must     | Functional      | Collect fish during gameplay to earn points or currency.                                              |
| 4    | Can      | Functional      | Access a shop to buy power-ups, skins, or items using collected fish.                                 |
| 5    | Must     | Functional      | View high scores after each game for progress tracking.                                               |
| 6    | Can      | Functional      | Include different platform types (moving, breaking) for varied gameplay.                              |
| 7    | Must     | Quality         | Maintain smooth frame rate and responsive controls for optimal gameplay experience.                   |
| 8    | Must     | Functional      | Automatically save progress and high scores.                                                          |
| 9    | Can      | Functional      | Customize character appearance with purchasable skins.                                                |
| 10   | Can      | Non-functional  | Available on Android devices.                                                                         |

### 1.3 Test Cases

| TC-№ | Initial State                                | Input                                         | Expected Output                                              |
|------|---------------------------------------------|-----------------------------------------------|--------------------------------------------------------------|
| 1    | Game is running, player is on a platform.   | Press left/right button                      | Character moves accordingly.                                 |
| 2    | New game session                            | Start a session                              | Random platform positions appear each session.               |
| 3    | Game in progress, player is jumping.        | Move to collect fish                         | Fish are collected, points increase.                         |
| 4    | Collected fish, game session ended          | Access shop from main menu                   | Shop opens, allowing purchases.                              |
| 5    | Game session ended                          | View post-game screen                        | Player's high score is displayed.                            |
| 6    | Game in progress                            | Continue playing                             | Various platform types appear (moving, breaking, etc.).      |
| 7    | Game running                                | Observe performance                          | Smooth frame rate and responsive controls without lag.       |
| 8    | Game session ended, new high score          | Exit game                                    | High score and progress are saved.                           |
| 9    | Purchased skin                              | Access customization menu                    | Purchased skin is selectable and applies to character.       |
| 10   | Android device, game installed              | Launch game                                  | Game launches and functions on Android.                      |

### 1.4 Diagrams

#### Class Diagram

![image](https://github.com/user-attachments/assets/c14c57d8-a789-4147-bf13-b2760fda5739)

#### Use Case Diagram

![Whisker-Jump_Use-Case](https://github.com/user-attachments/assets/08fde408-263b-4ce6-995a-e661468a1150)


## 2. Project Planning

| AP-№ | Deadline | Responsible | Description | Planned Time |
|------|----------|-------------|-------------|--------------|
| 1.A  | 6.09.24  | Keanu           | Add buttons at the screen bottom.                              | 45'           |
| 1.B  | 6.09.24  | Keanu           | Implement button-based character movement.                     | 180'          |
| 2.A  | 6.09.24  | Keanu & Lorenzo           | Implement random platform logic with type distribution.        | 60'           |
| 2.B  | 6.09.24  | Keanu & Lorenzo           | Add platform collision and interaction logic.                  | 200'          |
| 3.A  | 6.09.24  | -           | Implement fish spawn on platforms every 5 seconds.             | 30'           |
| 3.B  | 13.09.24 | -           | Player can collect fish during gameplay.                       | 60'           |
| 4.A  | 13.09.24 | -           | Display collected fish amount.                                 | 15'           |
| 4.B  | 13.09.24 | -           | Add button to access shop at game start.                       | 45'           |
| 4.C  | 13.09.24 | -           | Enable purchases in shop using fish.                           | 120'          |
| 4.D  | 13.09.24 | -           | Complete shop logic with collectible and purchasable items.    | 180'          |
| 5.A  | 20.09.24 | Cyril        | Display high score post-game.                                  | 30'           |
| 6.A  | 20.09.24 | -           | Ensure stationary platforms work correctly.                    | 180'          |
| 6.B  | 20.09.24 | -           | Add moving, breakable, and one-time platforms.                 | 300'          |

## 4. Implementation

| AP-№ | Date     | Responsible      | Planned Time | Actual Time     |
|------|----------|------------------|--------------|-----------------|
| 1.A  | 6.09.24  | Keanu            | 45'          | 45'            |
| 1.B  | 6.09.24  | Keanu            | 180'         | 180'           |
| 2.A  | 6.09.24  | Keanu & Lorenzo  | 60'          | In progress    |
| 2.B  | 6.09.24  | Keanu & Lorenzo  | 200'         | In progress    |
| 3.A  | 6.09.24  | -                | 30'          | 30'            |
| 3.B  | 13.09.24 | -                | 60'          | In progress    |
| 4.A  | 13.09.24 | -                | 15'          | 15'            |
| 4.B  | 13.09.24 | -                | 45'          | 15'            |
| 4.C  | 13.09.24 | -                | 120'          | 15'            |
| 4.D  | 13.09.24 | -                | 180'          | 15'            |
| 5.A  | 20.09.24 | Cyril            | 30'          |   30'          |
| 6.A  | 20.09.24 | -                | 180'         |still working on it|
| 6.B  | 20.09.24 | -                | 300'         |still working on it|

## 5. Test Report and Evaluation

### Test Report

| TC-№ | Test Status | Remarks                                                                 |
|------|-------------|-------------------------------------------------------------------------|
| 1    | Pass        | Character movement responsive and accurate.                            |
| 2    | Pass        | Platforms generate randomly each session.                              |
| 3    | Incomplete  | Fish collection mechanics working as intended.                         |
| 4    | Incomplete  | Shop functionality partially implemented, pending item purchases.      |
| 5    | Pass        | High score displays correctly post-game.                               |
| 6    | Incomplete  | Different platform types appear as expected.                           |
| 7    | Pass        | Frame rate remains smooth.                                             |
| 8    | Pass        | High scores save automatically.                                        |
| 9    | Incomplete  | Skins unavailable in shop currently.                                   |
| 10   | Pass        | Game operates on Android device.                                       |


## 6. Risk Analysis

- **New Tech Stack:** Learning curve for .NET MAUI, requiring extra time for UI and logic integration.
- **Platform Generation Complexity:** Logic behind moving and breakable platforms is challenging.
- **Performance on Low-end Devices:** Potential frame rate drops or lag during gameplay, requiring optimization.
- **Team Coordination:** Clear task delegation needed for efficient development and bug resolution.

**Overall Project Risk:** Moderate – manageable with regular testing and team alignment.

# 8. Things we didn't finish

- **Shop and Currency System**: The partial implementation of the shop and currency system presents a risk, as it requires additional time and testing to finalize the purchasing functionality.
- **Collision Issues**: Collision problems with platforms may cause player frustration. This aspect requires focused debugging to ensure consistent gameplay.
- **New Tech Stack**: Learning curve for .NET MAUI, requiring extra time for UI and logic integration.

# Evaluation

Keanu: https://portfolio.bbbaden.ch/view/view.php?t=c9f294f7561e1b65c724
Cyril: https://portfolio.bbbaden.ch/view/view.php?t=40fba60858e5d34ef948
Lorenzo: 
Dorian:
