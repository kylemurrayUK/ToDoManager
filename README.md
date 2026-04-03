# ToDoManager:
Command line tool for tracking to do tasks

## Overview:
Allows users to create a task description and title and save that task. Users can then view, complete and delete tasks. Tasks stored to JSON files using .net native library System.Text.JSON for serialised data handling.

## Features:
Create a task - User completes title and description and the program automatically applies a created on date, an ID and tracks whether task has been completed.
View Tasks - Lists all tasks and lets users know if they have been completed and when.
Complete Tasks - Mark tasks as complete via the ID and populates time when task completed.
Delete Tasks - Removes tasks from list and saves updated list to file
 

## Technical Highlights:
Separation of concerns with different layers - a service layer, file handling layer and user interaction layer
Class based architecture used, with each class owning single responsibility 
Access modifiers private and public applied to correctly partition functions 
Persistent memory error handling when loading data from file to prevent data corruption
Reusable utility classes such as validation
Menu driven which keeps the Program.cs clean

## How to run:
Currently not deployed as a standalone application - so once you have pulled the repo run dotnet build then dotnet run. 

## Project Structure:

```
├── Program.cs          # Entry point
├── Menu.cs             # Main menu and routing logic
├── ToDoItem.cs         # Class for ToDoItem 
├── FileStorage.cs      # Loads and saves tasks list
├── ToDoService.cs      # Service layer that handles manipulating data
└── ValidationUtils.cs  # Input validation logic
```