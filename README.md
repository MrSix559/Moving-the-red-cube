# 🟥 Moving the Red Cube

**‘Moving the Red Cube’** is a simple endless runner created on Unity3D. The player controls a red cube that moves across an infinitely generated map, avoiding obstacles and earning points.

---

## 🎮 Gameplay

- Controls: tap/click (depending on the platform)
- Goal: earn as many points as possible while avoiding death
- Gradually increasing difficulty as you progress

---

## 🛠️ What was used in the project

- **Unity 2022.3.50f1**
- **C#**
- **DOTween** — for animations
- **TextMesh Pro** — UI text display
- **Events (Action / Event)** — for communication between systems
- **Encrypted data storage** via `EncryptedPlayerPrefs`
- **Object pool** — for optimised block spawning and map generation
- **Automatic map generation** from chunks

---

## 🧠 Architecture

The project is divided into zones:
- `Game/` — game logic: generation, death, points
- `Menu/` — main menu and settings
- `UI/` — user interface management
- `Pool/` — object pool implementation
- `MapGenerator/` — chunks and level generation

---

## 📸 Screenshots/Gameplay videos
<img width="500" height="500" alt="MovingTheRedCubeIcon" src="https://github.com/user-attachments/assets/1dd5af78-11db-4196-b272-cd40bdc163bc" />

https://github.com/user-attachments/assets/e144552e-81cb-4d4a-9e69-3c5cc027e606


---

## 💾 Saving and settings

- The game saves:
  - cube colour,
  - FPS settings,
  - sound and music on/off
---
> ❗ Если вы открываете проект, убедитесь, что у вас установлен DOTween и TextMesh Pro
---

## 🧑‍💻 Author

- **MrSix559**
- [GitHub](https://github.com/MrSix559)

---

## 📜 Licence

This project is posted solely for my personal portfolio. You may use it for personal purposes, but please credit the author when copying/publishing - **MrSix559**.
