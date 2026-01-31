# Game Systems Prototype – High-Level Diagram

This diagram shows how the major systems in the console-based Game Systems Prototype interact with each other. The focus is on **logic flow and object relationships**, not UI.

---

## Overall Program Flow

```
┌─────────────────────┐
│     Program.cs      │
│  (Main Entry Point) │
└─────────┬───────────┘
          │
          ▼
┌─────────────────────┐
│     GameManager     │◄──────────────┐
│  - RunGameLoop()    │               │
│  - HandleTurns()   │               │
│  - EndGame()       │               │
└─────────┬───────────┘               │
          │                           │
          ▼                           │
┌─────────────────────┐               │
│       Player        │               │
│  - Level            │               │
│  - Experience       │               │
│  - Stats (struct)   │               │
│  - Inventory        │               │
└─────────┬───────────┘               │
          │                           │
          │                           │
          ▼                           ▼
┌─────────────────────┐     ┌─────────────────────┐
│   Enemy (abstract)  │     │     SaveManager     │
│  - Stats (struct)   │     │  - SaveGame()       │
│  - DecideAction()  │     │  - LoadGame()       │
└─────────┬───────────┘     └─────────────────────┘
          │
          ▼
┌─────────────────────┐
│  Specific Enemies   │
│  Goblin / Skeleton  │
│  BossEnemy          │
└─────────────────────┘
```

---

## Player System

```
┌───────────────┐
│    Player     │
├───────────────┤
│ Level         │
│ CurrentXP     │
│ XPToNextLevel │
│ Stats         │◄───┐
│ Inventory     │    │
├───────────────┤    │
│ GainXP()      │    │
│ LevelUp()     │    │
│ Attack()      │    │
│ TakeDamage()  |    |
| LoadFromSave(SaveData data) 
└───────────────┘    │
                     │
             ┌─────────────┐
             │   Stats     │  (struct)
             ├─────────────┤
             │ Health      │
             │ Strength    │
             │ Defense     │
             └─────────────┘
```

**Key Concepts Demonstrated**
- Class composition (Player has Stats)
- Struct usage for lightweight data
- Expressions and conditionals for leveling

---

## Enemy AI System (Inheritance + Polymorphism)

```
┌─────────────────────┐
│   Enemy (abstract)  │
├─────────────────────┤
│ Stats               │
├─────────────────────┤
│ DecideAction() *    │◄── abstract
│ Attack()            │
│ TakeDamage()        │
└─────────┬───────────┘
          │
 ┌────────┴────────┐
 │                 │
 ▼                 ▼
┌──────────────┐  ┌────────────────┐
│    Goblin    │  │   Skeleton     │
│ Overrides    │  │ Overrides      │
│ DecideAction │  │ DecideAction   │
└──────────────┘  └────────────────┘
```

**Enemy Behavior Example**
- If health > 50% → aggressive action
- If health ≤ 50% → defensive or risky action

---

## Combat / Turn Loop

```
while (gameIsRunning)
{
    PlayerTurn()
    EnemyTurn()
    CheckVictoryConditions()
}
```

This loop demonstrates:
- Loops
- Conditionals
- Method calls
- Game state evaluation

---

## Loot System

```
┌───────────────┐
│     Item      │  (base class)
├───────────────┤
│ Name          │
│ ItemStats     │◄── struct
└───────┬───────┘
        │
  ┌─────┴─────┐
  │           │
  ▼           ▼
Weapon     Consumable
```

```
┌──────────────┐
│  ItemStats   │  (struct)
├──────────────┤
│ Power        │
│ Value        │
└──────────────┘
```

Loot drops are determined using:
- Random number generation
- Conditional logic
- Loops for loot tables

---

## Save / Load System (Optional File I/O)

```
┌─────────────────────┐
│    SaveManager      │
├─────────────────────┤
│ SaveGame(Player)    │
│ LoadGame()          │
└─────────┬───────────┘
          │
          ▼
   savegame.json
```

Saved data may include:
- Player level and XP
- Stats
- Inventory