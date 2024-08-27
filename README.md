# Zenject Sample Project - Port of SamuelAsherRivello's Sample Project

This repository is a Zenject port of Samuel Asher Rivello's original sample project. The project illustrates how Dependency Injection (DI) can significantly reduce code complexity, improve readability, and enhance scalability in Unity projects.

## Overview

Zenject is a Dependency Injection framework designed for Unity3D. This port demonstrates how leveraging DI principles can help streamline code architecture, especially in complex game development scenarios. By decoupling dependencies, Zenject makes it easier to manage and extend your game systems.

## Original Project

The original project was developed by [Samuel Asher Rivello](https://github.com/SamuelAsherRivello). You can find the original project [here](https://github.com/SamuelAsherRivello/rmc-mini-mvcs/tree/main/RMC%20Mini%20MVCS/Samples~/RMC%20Mini%20MVCS%20-%202.%20Advanced%20Examples/Examples/Example01_ConfiguratorMini). This port builds upon Samuel's work by incorporating the Zenject DI framework into the project.

## New Features

In addition to porting the original project, the following new game features have been added:

- Re-architected the project to reduce complexity
- **Pick-Up Collection System:** Players can now collect items throughout the game, with smooth integration of Zenject's DI to manage the lifecycle of pick-ups.

## Benefits of Zenject

- **Improved Code Readability:** Zenject promotes cleaner code by removing the need for manually managing object dependencies.
- **Enhanced Scalability:** Adding new features or systems becomes easier, as dependencies are automatically injected without requiring major code rewrites.
- **Reduced Complexity:** By managing object lifetimes and dependencies through Zenject, the overall complexity of the architecture is greatly reduced.

## Features

- **Dependency Injection:** Zenject allows for easy injection of objects such as controllers, services, and other game components.
- **Modular Architecture:** The project is structured to allow for easy extension and maintenance.
- **Improved Flexibility:** The decoupled nature of the project allows individual components to be swapped or modified with minimal impact on the rest of the codebase.

## Getting Started

To get started with this project, you will need to:

1. Clone this [repository](https://github.com/sonystudios/RMCZenjectPort.git).
2. Install the Zenject package in Unity. You can do this via the Unity Package Manager or by downloading the Zenject package from [Unity asset store](https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735)

## Credits

This port was created by [Manu Thomas](https://github.com/manuthomas80) as a learning project and an illustration of how Dependency Injection improves code architecture. Additional game features such as pick-up collection and game data management have been added to enhance the project.

The original project was developed by [Samuel Asher Rivello](https://github.com/SamuelAsherRivello). You can find the original project [here](https://github.com/SamuelAsherRivello/rmc-mini-mvcs/tree/main/RMC%20Mini%20MVCS/Samples~/RMC%20Mini%20MVCS%20-%202.%20Advanced%20Examples/Examples/Example01_ConfiguratorMini).

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
