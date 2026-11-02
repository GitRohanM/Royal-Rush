# Royal Rush

![Unity 6](https://img.shields.io/badge/Unity-6000.0.10f1-black?logo=unity)
![Render Pipeline](https://img.shields.io/badge/Pipeline-URP%2017.0.3-228be6)
![C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp)
![Platform](https://img.shields.io/badge/Platform-WebGL%20%7C%20Windows-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)

A medieval-themed 3D endless runner built in **Unity 6** using the **Universal Render Pipeline (URP)**. Players guide the King down cobblestone lanes filled with barricades, rolling boulders, and collectibles—racing against a depleting countdown clock that intensifies with every checkpoint crossed.

---

## Gameplay Overview

In **Royal Rush**, the player sprints forward across dynamically spawned three-lane road chunks. The objective is to survive as long as possible and maximize score before the clock expires:

- **Time-Attack Survival:** Start with a 60-second timer. Reaching checkpoints adds +5 seconds of survival time but permanently decreases the obstacle spawn interval, ramping up difficulty over time.
- **Dynamic Speed Scaling:** Collecting apples increases chunk scrolling speed and increases forward gravity, elevating both pace and risk.
- **Tactile Impact & Hazard Penalties:** Colliding with fences triggers a stumble animation and inflicts an immediate speed penalty. Falling rocks and boulders dynamically generate Cinemachine camera shakes scaled by impact proximity.
- **Collectibles Economy:**
  - **Apples:** Boost movement speed and accelerate environmental flow.
  - **Gold Coins:** Award +100 points toward the final run score.
  - **Fences & Rolling Boulders:** Hazards to dodge across left, center, and right lanes.
- **Dramatic Finale:** When time runs out, the game transitions into slow motion (`Time.timeScale = 0.1f`) to highlight the final moments of the run.

---

## Controls

| Action | Primary Keyboard | Gamepad |
| :--- | :--- | :--- |
| **Move Left / Right** | `A` / `D` or `Left Arrow` / `Right Arrow` | `Left Stick` / `D-Pad` |
| **Move Forward / Backward** | `W` / `S` or `Up Arrow` / `Down Arrow` | `Left Stick` |
| **Quit Application** | `Escape` | `Menu` / `Start` |

---

## Architecture & Code Structure

The gameplay systems are modular and organized under `Assets/Scripts/`:

```
Assets/Scripts/
├── Manager/
│   ├── GameManager.cs            # Survival timer, game state loop, and game-over slow motion
│   └── ScoreManager.cs           # Run score calculation and TextMesh Pro UI binding
├── Pickup/
│   ├── Pickup.cs                 # Abstract base class: continuous rotation & trigger contract
│   ├── Apple.cs                  # Speed modification and world acceleration
│   └── Coin.cs                   # Score increment handler
├── Player/
│   ├── PlayerController.cs       # Unity Input System integration, clamped lateral movement
│   ├── PlayerCollisionHandler.cs # Impact cooldowns, stumble animations, speed penalties
│   └── CameraController.cs       # Dynamic FOV lerping and speed-line particle management
├── Proc Gen/
│   ├── LevelGenerator.cs         # Modular chunk streaming, gravity scaling, speed management
│   ├── Chunk.cs                  # Three-lane procedural obstacle and item distribution
│   ├── CheckPoint.cs             # Checkpoint triggers, timer replenishment, difficulty scaling
│   ├── ObstacleSpawner.cs        # Physics hazard instantiation and spawn rate decay
│   └── ObstacleDestroy.cs        # Boundary cleanup for out-of-bounds obstacles
├── Music.cs                      # Background audio state and ducking on game over
└── Rock.cs                       # Distance-scaled Cinemachine impulse screen shake & collision FX
```

### Key Technical Implementations

- **Polymorphic Collectibles:** An abstract base class `Pickup` standardizes continuous rotation and trigger consumption across item types, extended by `Apple` (speed manipulation) and `Coin` (score increments).
- **Procedural Chunk Streaming:** Modular roadway segments are instantiated and recycled dynamically along the Z-axis with strict three-lane clamping (`-2.5`, `0.0`, `+2.5`) to guarantee navigability.
- **Distance-Attenuated Screen Shake:** Boulder impacts calculate Euclidean distance to the primary camera lens, generating scaled Cinemachine Impulse shakes for tactile physical feedback.
- **Adaptive Camera FOV:** Smooth coroutine-based field-of-view transitions scale dynamically with world speed, paired with particle systems to convey velocity changes.

---

## Tech Stack & Dependencies

- **Engine:** Unity 6 (`6000.0.10f1` or later)
- **Render Pipeline:** Universal Render Pipeline (URP 17.0.3)
- **Input:** Unity New Input System (`com.unity.inputsystem` 1.8.2)
- **Cinematics & Camera:** Unity Cinemachine 3 (`com.unity.cinemachine` 3.1.4)
- **UI:** TextMesh Pro & Unity UI (uGUI 2.0.0)
- **Target Platforms:** WebGL, Windows Standalone (x86_64)

---

## Getting Started

### Prerequisites

1. Install [Unity Hub](https://unity.com/download).
2. Install **Unity 6 (6000.0.10f1 or compatible Unity 6 release)** with WebGL and Windows Build Support modules.

### Clone & Open

```bash
git clone https://github.com/GitRohanM/Royal-Rush.git
cd Royal-Rush
```

1. Open **Unity Hub**.
2. Click **Add** -> **Add project from disk**.
3. Select the cloned `Royal Rush` directory.
4. Open the project in the Unity Editor.
5. In the Project window, navigate to:
   ```
   Assets/Scenes/MainLevel.unity
   ```
6. Press the **Play** button in the Editor to test the game.

---

## WebGL Build & Local Play

A pre-built WebGL build is included in the [`WebGL Build/`](./WebGL%20Build/) directory.

To test the build locally:

```bash
cd "WebGL Build"
python -m http.server 8000
```

Open `http://localhost:8000` in any modern web browser (Chrome, Edge, Firefox, Brave).

---

## Author

**Rohan M**  
- GitHub: [@GitRohanM](https://github.com/GitRohanM)  
- Email: [inbox.rohanm@gmail.com](mailto:inbox.rohanm@gmail.com)

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
