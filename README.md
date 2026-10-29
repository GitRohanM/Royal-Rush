# 👑 Royal Rush

[![Unity](https://img.shields.io/badge/Unity-6000.0.10f1%20(Unity%206)-black?style=for-the-badge&logo=unity)](https://unity.com/)
[![Render Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP%2017.0.3-blue?style=for-the-badge)](https://unity.com/srp/universal-render-pipeline)
[![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-PC%20%7C%20WebGL-red?style=for-the-badge)](https://unity.com/)
[![License](https://img.shields.io/badge/License-MIT-brightgreen?style=for-the-badge)](LICENSE)

> **Sprint for your crown!** A fast-paced, medieval-themed 3D endless runner built in **Unity 6** with the **Universal Render Pipeline (URP)**, featuring procedural environment chunk generation, responsive lane maneuvering, dynamic camera FOV scaling, and distance-attenuated physics screen shake.

---

## 🎮 Gameplay Overview

In **Royal Rush**, you guide the King through perilous cobblestone lanes filled with medieval barricades, rolling boulders, and treasures. Race against a depleting survival clock—every checkpoint replenishes vital seconds while simultaneously intensifying incoming hazards. Collect stamina-boosting apples to hit breakneck speeds, dodge obstacles to avoid bone-rattling stumbles, and gather gold coins to achieve the ultimate high score!

---

## ✨ Key Features

- **🏰 Procedural Endless Chunk Generation:** Infinite modular road chunks spawn and recycle dynamically ahead of the camera, delivering seamless performance with zero frame drops.
- **⚡ Dynamic Speed & Velocity Scaling:** Consuming apples accelerates the world move speed and boosts forward gravity.
- **🎥 Adaptive Cinemachine Camera:** Dynamic FOV expansion simulates high-velocity rushes when speeding up, accompanied by custom speed-line particle VFX.
- **💥 Physics-Driven Hazard Feedback:** Falling rocks and tumbling boulders utilize **Cinemachine 6 Impulse Sources** to trigger screen shake dynamically scaled to the camera's distance, complemented by collision particles and audio.
- **⏱️ Time-Attack Checkpoint Pacing:** Begin with a 60-second countdown. Passing checkpoints restores time (+5s) but permanently raises the stakes by reducing obstacle spawn intervals.
- **🍎 Collectibles & Score Economy:**
  - **Gold Coins:** Rewarding +100 points toward your royal leaderboard run.
  - **Speed Apples:** Accelerate player movement speed and environmental flow.
  - **Fences & Barricades:** Cause player stumble animations and speed penalties upon impact.
- **⏳ Slow-Motion Finale:** Running out of time shifts the engine into dramatic slow-motion (`Time.timeScale = 0.1f`), highlighting the final moments of your sprint.
- **🌐 WebGL Optimized:** Packaged and compressed (Brotli) for instant browser-based play with minimal loading times.

---

## 🕹️ Controls

| Action | Primary Keyboard | Gamepad |
| :--- | :--- | :--- |
| **Move Left / Right** | `A` / `D` or `Left Arrow` / `Right Arrow` | `Left Stick` / `D-Pad` |
| **Move Forward / Back** | `W` / `S` or `Up Arrow` / `Down Arrow` | `Left Stick` |
| **Quit Game** | `Escape` | `Start` / `Menu` |

---

## 🏗️ Architecture & Technical Highlights

```
Assets/Scripts/
├── Manager/
│   ├── GameManager.cs          # Time-attack countdown, game loop state, slow-motion trigger
│   └── ScoreManager.cs         # Live score tracking and TMPro UI synchronization
├── Pickup/
│   ├── Pickup.cs               # Abstract base class: rotational animation & trigger contract
│   ├── Apple.cs                # Speed modification & player acceleration logic
│   └── Coin.cs                 # Score increment handler
├── Player/
│   ├── PlayerController.cs     # Input System integration, clamped lateral movement, acceleration
│   ├── PlayerCollisionHandler.cs # Impact cooldown, stumble animation triggers, speed reduction
│   └── CameraController.cs     # Coroutine-driven FOV lerping & speed particle management
└── Proc Gen/
    ├── LevelGenerator.cs       # Chunk pooling, forward gravity manipulation, speed control
    ├── Chunk.cs                # 3-Lane procedural hazard and collectible distribution
    ├── CheckPoint.cs           # Interval pacing, timer replenishment, difficulty scaling
    ├── ObstacleSpawner.cs      # Randomized boulder physics instantiation & spawn timer decay
    └── ObstacleDestroy.cs      # Boundary cleanup preventing physics overhead
```

### Engineering Design Patterns:
- **Object-Oriented Inheritance:** `Pickup` implements an extensible template pattern for game collectibles (`Apple`, `Coin`) with unified rotation animations and trigger responses.
- **Decoupled Architecture:** Event-driven architecture between the `GameManager`, `ScoreManager`, and `LevelGenerator` keeping UI, gameplay logic, and physics segregated.
- **Distance-Attenuated Screen Shake:** Boulder impacts calculate inverse square distance to the camera lens to scale Cinemachine Impulse magnitude for realistic tactile feedback.
- **Procedural Chunk Streaming:** Modular chunk pooling system with dynamic lane allocation (`-2.5`, `0.0`, `+2.5`) guaranteeing reproducible obstacle patterns and unobstructed escape routes.

---

## 🛠️ Tech Stack & Requirements

- **Engine:** Unity 6 (`6000.0.10f1`)
- **Render Pipeline:** Universal Render Pipeline (URP 17.0.3)
- **Input System:** Unity New Input System package (`com.unity.inputsystem` 1.8.2)
- **Cinematics & Cameras:** Unity Cinemachine 3 (`com.unity.cinemachine` 3.1.4)
- **UI:** TextMesh Pro (TMPro) / Unity UI (uGUI 2.0.0)
- **Target Platforms:** WebGL, Windows Standalone (x86_64)

---

## 🚀 Getting Started

### Prerequisites
1. Install [Unity Hub](https://unity.com/download).
2. Install **Unity 6 (6000.0.10f1)** with WebGL and Windows Build Support modules.
3. Install [Git LFS](https://git-lfs.github.com/) (recommended for large 3D meshes and audio).

### Clone & Open
```bash
git clone https://github.com/GitRohanM/Royal-Rush.git
cd Royal-Rush
```

1. Open **Unity Hub**.
2. Click **Add** -> **Add project from disk**.
3. Select the `Royal Rush` folder.
4. Open the project in Unity Editor.
5. In the Project browser, navigate to:
   ```
   Assets/Scenes/MainLevel.unity
   ```
6. Press the **Play** button in the Editor to test immediately!

---

## 📦 WebGL Build & Online Play

A pre-built, production-ready WebGL build is located in the [`WebGL Build/`](./WebGL%20Build/) directory.

To test locally:
1. Using Python:
   ```bash
   cd "WebGL Build"
   python -m http.server 8000
   ```
2. Open `http://localhost:8000` in any WebGL2-compatible modern browser (Chrome, Edge, Firefox, Brave).

---

## 👨‍💻 Author

**Rohan M**  
- **GitHub:** [@GitRohanM](https://github.com/GitRohanM)  
- **Email:** [inbox.rohanm@gmail.com](mailto:inbox.rohanm@gmail.com)  

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
