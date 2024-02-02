# Text Adventure Application
This is a text adventure game implemented in WinForms as part of my studies at the 2-year programme 'Programutvecklare .Net' at Nackademin. 

## Features
- A dozen or so rooms
- Over 20 interactable items
- Events when entering rooms the first time
- Obstacles that hinders your path
- Items that can be used on other items
- An NPC to interact with and give gifts to
- Containers to find items and store items in
- Smaller containers can be picked up and moved around
- A save system to save your progress, including autosaves
- A powerful handmade parser that can handle for example "A really long way to say take item" as easily as it can handle "take item"

## Technologies
The project is built in WinForms. All the logic is separated out into a class library, so doing a console implementation should not be too difficult. 
Programming language: C#

## Future ambitions
This is an unordered list of ideas that I would like to implement at some point
- A combat module
- RPG module - with stats impacting how many items you can carry, etc
- Database migration - currently everything is stored in json files, but I would like to move it to a proper database
- Fullstack application - build an API and a frontend to turn it into a webapp
