# 👻 Soul Ascent

<p align="center">
  <img src="SoulAscent-ScreenShots/soul_ascent.jpg" alt="Soul Ascent Cover Art" width="100%">
</p>

[![Unity](https://img.shields.io/badge/Unity-6.3%20LTS-black?style=flat&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-PC%20%7C%20WebGL-blue)](https://play.unity.com)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

A 2D pixel-art action platformer built with **Unity 6**. Fight your way out of a hellish underworld: defeat monsters, pick up the items they drop (some make you stronger, some curse you) and collect enough of them to open the exit of each level.

🎮 **[Play the Game in Your Browser (Unity Play)](https://play.unity.com/en/games/2809f2ac-c0de-4aab-841a-94538f14d3c6/soul-ascent)**

---

## 📸 Screenshots

*In-game screenshots:*

### Menus

| Main Menu | Settings | Pause | Pause Settings |
| :---: | :---: | :---: | :---: |
| ![Main Menu](SoulAscent-ScreenShots/SoulAscent_MainMenu.png) | ![Settings](SoulAscent-ScreenShots/SoulAscent_SettingsPanel.png) | ![Pause](SoulAscent-ScreenShots/SoulAscent_PausePanel.png) | ![Pause Settings](SoulAscent-ScreenShots/SoulAscent_PausePanel_Settings.png) |

### Levels

| Level 1 | Level 2 |
| :---: | :---: |
| ![Level 1](SoulAscent-ScreenShots/SoulAscent_GameScreen_1.png) | ![Level 2](SoulAscent-ScreenShots/SoulAscent_GameScreen_2.png) |

### Combat

| Enemy Attack | Enemy Attack | Enemy Hit |
| :---: | :---: | :---: |
| ![Enemy attack 1](SoulAscent-ScreenShots/SoulAscent_EnemyAttack_1.png) | ![Enemy attack 2](SoulAscent-ScreenShots/SoulAscent_EnemyAttack_2.png) | ![Enemy hit](SoulAscent-ScreenShots/SoulAscent_EnemyHit.png) |

| Enemy Death | Enemy Death |
| :---: | :---: |
| ![Enemy death 1](SoulAscent-ScreenShots/SoulAscent_EnemyDeath_1.png) | ![Enemy death 2](SoulAscent-ScreenShots/SoulAscent_EnemyDeath_2.png) |

### Items and Level Exit

| Item Prompt | Item Prompt | Item Picked Up | Item Picked Up |
| :---: | :---: | :---: | :---: |
| ![Item text 1](SoulAscent-ScreenShots/SoulAscent_ItemText_1.png) | ![Item text 2](SoulAscent-ScreenShots/SoulAscent_ItemText_2.png) | ![Item pickup 1](SoulAscent-ScreenShots/SoulAscent_ItemPickUp_1.png) | ![Item pickup 2](SoulAscent-ScreenShots/SoulAscent_ItemPickUp_2.png) |

| Exit Locked | Exit Locked | Next Level |
| :---: | :---: | :---: |
| ![Requirement 1](SoulAscent-ScreenShots/SoulAscent_Item_Requirement_1.png) | ![Requirement 2](SoulAscent-ScreenShots/SoulAscent_Item_Requirement_2.png) | ![Pass level](SoulAscent-ScreenShots/SoulAscent_PassLevel.png) |

### Game Over and Victory

| Game Over | Finish Prompt | Victory |
| :---: | :---: | :---: |
| ![Game over](SoulAscent-ScreenShots/SoulAscent_GameOver.png) | ![Finish text](SoulAscent-ScreenShots/SoulAscent_FinishGameText.png) | ![Finish panel](SoulAscent-ScreenShots/SoulAscent_FinishGamePanel.png) |

---

## ✨ Features

- **Two-Attack Combat:** Left and right mouse buttons trigger two different attacks. Hitboxes are enabled and disabled by animation events, and attack damage changes with the items you collect.
- **Enemy AI:** Six enemy types (Crow, Goblin, Huntress, Skeleton, Slime and Soul Hunter) patrol between points, chase the player when in range and attack with a cooldown. They have hit stun and health bars.
- **Random Item Drops:** Defeated enemies can drop items that increase or decrease damage or health. Walk up to an item, read its description and press `E` to take it. A popup shows the effect.
- **Level Progression:** Collect the required number of items (3 by default) to unlock the exit. The last level ends with a victory screen.
- **Persistent Stats:** Health, damage and score carry over between levels through a `GameData` singleton. Health is restored for each new level.
- **Hazards:** Kill zones instantly defeat the player. The lava is animated with Tilemap animated tiles.
- **Particle Effects:** Particle bursts on enemy and player death.
- **HUD:** Health bar, damage, score and item counter for the player, health bars for enemies, and contextual prompts.
- **Menus:** Main menu, pause menu (`P`), game over and victory panels, and a settings panel with separate music and SFX sliders (Audio Mixer, saved with PlayerPrefs).
- **Audio System:** A central `SoundManager` handles menu and game music plus attack, hit, death, jump, pickup, UI, game over, victory and level-up sounds.
- **Modular Architecture:** The player and enemy controllers are `partial` classes split into movement, combat, health, animation and item files, and damage is handled through an `IDamageable` interface.
- **Tilemap Levels:** Levels are built with Unity's Tilemap system.
- **WebGL Build:** Playable directly in the browser via Unity Play.

---

## 🕹️ Controls

| Action | Input |
| ------ | ----- |
| **Move Left / Right** | `A` / `D` or `Left` / `Right` Arrow Keys |
| **Jump** | `Spacebar` |
| **Attack 1** | Left mouse button |
| **Attack 2** | Right mouse button |
| **Pick up item / Use exit** | `E` |
| **Pause** | `P` |

---

## 🧩 Scripts

| Script | Purpose |
| ------ | ------- |
| `CharacterController` (Movement, Combat, Health, Items, Animation) | Player controller split into partial classes |
| `EnemyController` (Movement, Combat, Health, Animation) | Enemy patrol, chase, attack, damage and item drops |
| `AttackPoint` | Attack hitbox and damage |
| `IDamageable` | Shared damage interface |
| `ItemPickup` / `ItemEffectType` | Collectible items and their effects |
| `LevelExit` | Exit that requires a set number of items |
| `KillZone` | Instant-death hazard |
| `GameData` | Health, damage and score carried between levels |
| `UIManager` + `HealthUI`, `DamageUI`, `ScoreUI`, `ItemCounterUI`, `ItemPopupUI`, `ItemPromptUI`, `EnemyHealthUI` | HUD and prompts |
| `GameOverUI` / `VictoryUI` | End screens |
| `ButtonActions` / `PauseMenu` / `SettingsPanel` / `VolumeSettings` | Menus, scene flow and volume sliders |
| `InputManager` | Player input |
| `SoundManager` | Music and sound effects |

---

## 🛠️ Tech Stack & Assets

- **Engine:** Unity 6.3 LTS (6000.3.13f1)
- **Language:** C#
- **2D Tools:** Tilemap, Animated Tiles, Rigidbody2D, Animator, Particle System, Audio Mixer
- **Assets & Packages:**
  * Main character: [Martial Hero](https://assetstore.unity.com/packages/2d/characters/martial-hero-170422)
  * Enemies: [Monsters Creatures Fantasy](https://assetstore.unity.com/packages/2d/characters/monsters-creatures-fantasy-167949), [Monsters Creatures Fantasy 2](https://assetstore.unity.com/packages/2d/characters/monsters-creatures-fantasy-2-379160)
  * Level 1 platforms: [Grotto Escape Pack](https://assetstore.unity.com/packages/2d/textures-materials/tiles/grotto-escape-pack-54254)
  * Level 2 and additional art: [CraftPix](https://craftpix.net/)
  * Items: [2D Pixel Item Asset Pack](https://assetstore.unity.com/packages/2d/gui/icons/2d-pixel-item-asset-pack-99645)
  * UI: [2D Simple UI Pack](https://assetstore.unity.com/packages/2d/gui/icons/2d-simple-ui-pack-218050)
  * Effects: [Free Stylized Smoke Effects Pack](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/free-stylized-smoke-effects-pack-226406), [Free Pixel Art Platformer](https://assetstore.unity.com/packages/2d/environments/asset-fttgr-free-pixel-art-platformer-222174), [2D Pixel Art Skull Icons & Emblems](https://assetstore.unity.com/packages/2d/gui/icons/2d-pixel-art-skull-icons-emblems-281870), [Pixel Art Icon Pack - RPG](https://assetstore.unity.com/packages/2d/gui/icons/pixel-art-icon-pack-rpg-158343)
  * Sound effects: [8 Bits Elements](https://assetstore.unity.com/packages/audio/sound-fx/8-bits-elements-16848), [Free Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116), [Free Deadly Kombat](https://assetstore.unity.com/packages/audio/sound-fx/free-deadly-kombat-228835), [True 8-bit Sound Effect Collection Lite](https://assetstore.unity.com/packages/audio/sound-fx/true-8-bit-sound-effect-collection-lite-version-264063)
  * Music and additional sound effects: [Pixabay](https://pixabay.com/)

---

## 📁 Project Structure

```
Assets/
└── Development/
    ├── Animations/
    ├── Audio Mixer/
    ├── Material/
    ├── Models/
    ├── PhysicsMaterial/
    ├── Prefab/      → Enemy, Item, Particle, Spike, UI
    ├── Scenes/      → S_MainMenu, S_Level_1, S_Level_2
    ├── Script/
    ├── Sound/
    ├── Sprite/
    └── Volume/
```

---

## 🚀 Getting Started (Local Setup)

1. **Clone the repository:**
```
   git clone https://github.com/emirsumer/SoulAscent.git
```
2. **Open with Unity:** Add the folder in Unity Hub and use Unity 6000.3.13f1 (or a compatible Unity 6 version).
3. **Run the Game:** Open `Assets/Development/Scenes/S_MainMenu.unity` and press **Play**. Start from the menu scene, because the input, sound and game data managers live there.

---

## 🙏 Credits

- Designed and developed solo.
- Art from the Unity Asset Store and CraftPix; sound effects from the Unity Asset Store and Pixabay; music from Pixabay.
- Cover art: AI-generated.

## 📜 License

This project is open-source and available under the MIT License.
