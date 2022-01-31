# Apress Source Code

This repository accompanies [*Introduction to Video Game Engine Development*](https://www.apress.com/9781484270387) by Victor Brusca (Apress, 2021).

[comment]: #cover
![Cover image](9781484270387.jpg)

Download the files as a zip using the green button, or clone the repository to your machine using Git.

## New Sample Game Projects

A new game project, well a port of an old cell phone game, to the MmgGameApi used in this text. 
The game is an RPG that runs off of a data file. It's a great example of how easy it is to port old Java
based call phone games to the game engine.
Use the link below to get the source code and check it out. Enjoy!

[comment]:repo_link
[*MmgGameApi - Tyre*](https://github.com/vbrusca/MmgGameApi-TyreSK)

[comment]: #sc1
![Cover image](https://github.com/vbrusca/MmgGameApi-TyreSK/blob/23058dff4976545097aa99cfaff054ec60535af5/storage/tyre_cs_sc1.png)

[comment]: #sc2
![Cover image](https://github.com/vbrusca/MmgGameApi-TyreSK/blob/23058dff4976545097aa99cfaff054ec60535af5/storage/tyre_cs_sc2.png)

[comment]: #sc3
![Cover image](https://github.com/vbrusca/MmgGameApi-TyreSK/blob/23058dff4976545097aa99cfaff054ec60535af5/storage/tyre_java_sc1.png)

[comment]: #sc4
![Cover image](https://github.com/vbrusca/MmgGameApi-TyreSK/blob/23058dff4976545097aa99cfaff054ec60535af5/storage/tyre_java_sc2.png)

## Releases

Release v1.1 corresponds to the code in the published book, without corrections or updates.

## Contributions

See the file Contributing.md for more information on how you can contribute to this repository.

## Repository Contents
- [Bonus chapters] - Included in the 'Bonus chapters' folder are PDFs for Chapters 20 to 24 detailing the creation of the DungeonTrap game.
- [Java Project] - Included in the 'NetBeans_IDE' folder is the full Java implementation of the game engine, example software, and demonstration game builds.
- [C# Project] - Included in the 'VisualStudio_IDE' folder is the full C#/MonoGame implementation of the game engine, example software, and demonstration game builds.

## General Project Notes
Ssome general project notes to help make sure you have things setup correctly and can address the most common issues quickly are as follows:

Java:
- The game project should be configured with a working directory set to './dist' in the project's 'Run' settings.

Java and C#: 
- The ENGINE_CONFIG_FILE field of the static main class should point to the game project's config file in the 'cfg' directory with a relative path from the project's working directory.    
- The game engine config file should have a NAME entry with a value that is the same as its associated project and that project's resource folder.    
- To turn off the gamepad 1 input add this line to your game engine config file:
    
    &lt;entry key="GAMEPAD_1_ON" val="false" type="bool" from="GameSettings" /&gt;

## Bug Fixes
C#:
- GamePanel.cs: Added support to allow access to windowActivated, windowClosing method so they can be overridden and customized. Fixed window size bug where the dimensions were pointing to the wrong class fields.
- MmgColor.cs: Fixed the GetTransparent() color method to actually return a transparent color.
- MmgHelper.cs: Small bug fix to set render target to null.
- MmgFont.cs: Added passive mode support to a constructor and as a static field so that you can bypass the font size enforcement.
- MmgCentralMain.cs: Added work to make the chapter strings work with E# and 2# chapter numberings.
- RunResourceLoad.cs: Adjusted loading process to support relaive paths.
- MmgHelper.cs: Adjusted create bmp set to properly clear the bitmap with transparency.
- Assorted MmgBase classes: Added a clear to transparent for certain advanced classes.

Java:
- General: Set window dimensions to prevent a flicker on some systems.
- MmgColor.java: Fixed the GetTransparent() color method to actually return a transparent color.
- MmgCentralMain.java: Added work to make the chapter strings work with E# and 2# chapter numberings.
- RunResourceLoad.java: Adjusted loading process to support relaive paths.

## Install Monogame Latest (C# Version Only):
Although the book discusses installation steps it's probably best to visit the source due to version changes etc.
https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_windows.html
https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_macos.html

## Downloadable Chapters
Chapters 20 - 24, E1 - E5, the DungeonTrap game build, were excluded from the published text due to their size. You can find these chapters in the 'Bonus chapters' folder of this repo.

### Chapter 20: DungeonTrap Project Setup (E1)
Chapter 20 starts the game build process by getting your development environment setup and ready to go. You'll also get the project compiled and running with a generic main menu screen.

### Chapter 21: DungeonTrap Main Menu Screen (E2)
In Chapter 21, we add in a custom main menu screen and supporting classes then run the game to demonstrate the changes.

### Chapter 22: DungeonTrap Base Classes (E3)
In this chapter you'll start creating the classes that power the DungeonTrap game by defining the base classes that form the game's foundation.

### Chapter 23: DungeonTrap Level 1 and 2 Extended Classes (E4)
Chapter 23 takes us further along in our game creation journey by defining all the classes that extend the game's base classes.

### Chapter 24: Completing The Game (E5)
In this chapter we complete the DungeonTrap game by reviewing the finished game classes one method at a time.
