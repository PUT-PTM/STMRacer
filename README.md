PTM RACER
==============

Folders
--------------
* Kontroler - contains files from the Coocox program (related to accelerometer and sound support). <br />
* Gra PTM - contains the game's project files written in C#. <br />

Description
--------------
This project is a game based on an old popular mini-game from "9999 in 1 Brick Game" written in C#, which is controlled via STM32f4-Discovery kit using Virtual COM Port. 
Player's movements can be controlled using built-in accelerometer, button is used to resume/start the game. 

Tools
--------------
* Coocox CoIDE - microcontroller programming. <br />
* Microsoft Visual Studio 2013 - writing the game in C#. <br />

How to use
--------------
If you want to start the game with the microcontroller's movements support: <br />
* Open the project from Kontroler folder in Coocox. <br />
* Connect the device to your PC using microUSB->USB and miniUSB->USB cables. You can also plug in headphones to the audio socket. <br />
* Compile the program and send it to your Discovery board. <br />
* Afterwards run the project in C# from GRA PTM folder or run .exe application from GRA PTM/GRA PTM/bin/Release "PTM RACER.exe". <br />
*Follow the instructions sent by the application. <br />

*Have fun :)

Attributions
---------------
http://stm32f4-discovery.net/2014/08/library-24-virtual-com-port-vcp-stm32f4xx/ <br />
http://www.mind-dump.net/configuring-the-stm32f4-discovery-for-audio <br />


Credits
---------------
Project created by Adrian Kubaszewski & Grzegorz Wrzesiñski.
