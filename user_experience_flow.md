# Game Systems Prototype – Console User Experience Diagram

This diagram describes how a **user interacts with the console-based game systems prototype** from launch to exit. The focus is on **player experience, choices, and feedback**, not internal code structure.

---

## High-Level User Experience Flow

```
┌──────────────────────────┐
│        Start Game        │
│  (Run Program.cs)        │
└────────────┬─────────────┘
             ▼
┌──────────────────────────┐
│     Title / Welcome      │
│  "Game Systems Prototype"│
└────────────┬─────────────┘
             ▼
┌──────────────────────────┐
│        Main Menu         │
│  1. New Game             │
│  2. Load Game            │
│  3. Exit                 │
└───────┬─────────┬────────┘
        │         │
        ▼         ▼
   New Game   Load Game
        │         │
        ▼         ▼
┌──────────────────────────┐
│     Player Setup         │◄─── Load restores state
│  - Show stats             │
│  - Show level             │
└────────────┬─────────────┘
             ▼
┌──────────────────────────┐
│       Game Loop          │
│  (Turn-Based System)     │
└────────────┬─────────────┘
             ▼
┌──────────────────────────┐
│     End Game Screen      │
│  Victory / Defeat        │
│  Save & Exit             │
└──────────────────────────┘
```

---

## Main Menu Interaction

```
Main Menu
-------------------------
1. Start New Game
2. Load Saved Game
3. Exit

> Enter choice:
```

**User Experience Notes**
- Input validation ensures only valid menu options are accepted
- Loops keep the menu active until a valid choice is made

---

## Player Setup & Status Display

```
Player Status
-------------------------
Level: 1
XP: 0 / 100
Health: 100
Strength: 10
Defense: 5

Press ENTER to continue...
```

**Purpose**
- Gives immediate feedback to the player
- Reinforces stats and progression systems
- Mirrors how Unity HUDs display player data

---

## Core Gameplay Loop (Turn-Based)

```
while (playerIsAlive && enemyIsAlive)
{
    DisplayPlayerStats()
    DisplayEnemyStats()
    PlayerTurn()
    EnemyTurn()
}
```

This loop continues until:
- The enemy is defeated → Victory
- The player is defeated → Game Over

---

## Player Turn Experience

```
Your Turn
-------------------------
1. Attack
2. Use Item
3. View Stats
4. Save Game
5. Quit to Menu

> Choose an action:
```

**User Actions**
- Attack → Damage calculation and feedback
- Use Item → Inventory interaction
- View Stats → Non-combat feedback
- Save Game → Writes game state to file
- Quit → Ends current run safely

---

## Enemy Turn Experience

```
Enemy Turn
-------------------------
The Goblin attacks!
You take 8 damage.
```

**Behind the scenes**
- Enemy AI decides action based on health and state
- Player receives clear text feedback

---

## Combat Resolution

### Victory
```
Enemy Defeated!
You gained 25 XP.
You found loot: Rusty Sword

Press ENTER to continue...
```

### Defeat
```
You have been defeated.
Game Over.

1. Load Game
2. Exit
```

---

## Save / Load User Flow

```
Save Game
-------------------------
Saving game data...
Save successful!
```

```
Load Game
-------------------------
Loading saved game...
Game loaded successfully!
```

**User Experience Goal**
- Clear confirmation of success or failure
- No silent errors

---

## Exit Flow

```
Thank you for playing!
Progress saved.
Goodbye.
```

---

## Why This UX Design Works

- Simple and intuitive console interactions
- Clear feedback after every action
- Easy to demo in under one minute
- Directly translates to Unity UI flows later

---

This diagram can be referenced in the README or explained verbally during the demo video to describe how users interact with the software.