# 🎪 Funfair VR

Bienvenue dans **Funfair VR**, une collection immersive de mini-jeux de fête foraine en réalité virtuelle, plongés dans une ambiance médiévale low-poly. Ce projet a été développé sous Unity avec le XR Interaction Toolkit.

## 🎮 Mini-Jeux Disponibles

Le projet comprend 5 attractions principales accessibles depuis le hub central :

1.  **Chamboule-tout** 🥫
    *   Renversez les piles de conserves avec des balles. Testez votre précision !
2.  **Fruit Ninja Medieval** ⚔️
    *   Découpez les fruits au vol avec votre épée. Attention aux bombes !
3.  **Dunk Tank (Piscine)** 🎯
    *   Visez la cible pour faire tomber le personnage dans l'eau.
4.  **Stand de Tir (Shooter)** 🏹
    *   Tirez sur les cibles mouvantes pour marquer un maximum de points.
5.  **Punching Ball** 🥊
    *   Testez votre force brute en frappant le plus fort possible.

## 🛠️ Stack Technique

*   **Moteur** : Unity 2022.3+ (Recommandé)
*   **Pipeline de Rendu** : Universal Render Pipeline (URP) pour des performances optimales en VR.
*   **Framework VR** :
    *   Unity XR Interaction Toolkit (2.6.4)
    *   OpenXR Plugin
    *   Oculus XR Plugin
*   **Assets Graphiques** : Pack Polygon Medieval (Low-Poly).

## 🚀 Installation et Configuration

1.  **Cloner le dépôt** :
    ```bash
    git clone https://github.com/votre-username/Project_VR.git
    ```
2.  **Ouvrir avec Unity Hub** :
    *   Ajoutez le dossier cloné dans Unity Hub.
    *   Ouvrez le projet (assurez-vous d'avoir une version de Unity compatible installée).
3.  **Configuration VR** :
    *   Le projet est configuré pour OpenXR. Si vous utilisez un Quest via Link, assurez-vous que l'application Oculus est bien définie comme runtime OpenXR actif sur votre PC.

## 📂 Structure du Projet

*   `Assets/Scenes` : Contient les scènes des différents mini-jeux (`Chamboule-tout`, `FruitNinja`, `Piscine`, `Shooter`, `punchingball`).
*   `Assets/script` : Scripts C# gérant la logique des jeux (`GameManager`, `ScoreManagers`, interactions spécifiques).
*   `Assets/Prefabs` : Objets interactifs et éléments de décor préfabriqués.

---
*Projet réalisé dans le cadre d'un développement VR étudiant/personnel.*
