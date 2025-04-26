
🏆 Pass Combo Minigame

A fast-paced reaction game built in Unity where players pass the ball to highlighted teammates under pressure. Designed to demonstrate both technical and creative skills using clean architecture and scalable systems.

🎮 Gameplay Overview

- One central player is surrounded by 4 teammates.
- Every 1.5s / 1.0s / 0.6s, a random teammate is highlighted.
- The player must tap/click the highlighted teammate to pass.
- Correct passes increase the score and build a combo streak.
- Game ends after 30 seconds, with final score and combo shown.

🧠 Difficulty Levels

Selected from the Main Menu dropdown before the game starts:

Difficulty | Highlight Duration | Combo Bonus         | Penalty
-----------|--------------------|---------------------|--------------------
Easy       | 1.5s               | No bonus            | No penalty
Medium     | 1.0s               | +2 pts at 3-combo   | No penalty
Hard       | 0.6s               | +3 pts at 5-combo   | –1 point on wrong pass

⚙️ Features Implemented

- 🎯 Combo logic with difficulty-based bonuses
- ✅ Touch + mouse input support
- 🔊 Sound effects: pass, miss, game over
- ⏱️ 30-second timer with auto-end
- 📱 Mobile-ready input system
- 💡 Observer design pattern (clean and modular)
- 🖼️ Game Over panel + Play Again
- 🎨 Visual feedback for highlighted teammates
- 💻 Main Menu with difficulty dropdown

🕹️ Controls

- Click or tap on the highlighted teammate to pass.
- Don't click the wrong player! (Penalty in Hard mode)

🚀 How to Run

1. Open the project in Unity.
2. Start from the MainMenu scene.
3. Select difficulty and press “Start Game”.
4. Play and enjoy!
