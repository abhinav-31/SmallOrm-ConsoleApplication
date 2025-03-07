# SmallORM Console Application

## Overview

Welcome to **SmallORM**—your lightweight and efficient Object-Relational Mapping (ORM) tool developed in .NET! This console application seamlessly transforms your C# entity classes into SQL table creation queries using the power of reflection. With SmallORM, managing user accounts and automating SQL generation has never been easier. Focus on building great applications while we handle the backend!

## Key Features

- **Dynamic SQL Generation:** Wave goodbye to tedious manual SQL scripting! SmallORM automatically generates `CREATE TABLE` SQL queries based on your entity definitions, saving you time and minimizing errors.

- **Reflection & Attributes:** Leverage the power of reflection to read custom attributes from your entities. SmallORM intelligently maps these attributes to SQL data types, ensuring a smooth transition from your code to the database.

- **Account Management:** From user registration to account creation, deposits, and withdrawals, SmallORM provides a comprehensive suite of account management functionalities right at your fingertips.

- **File I/O Integration:** Easily review and integrate your generated SQL queries. SmallORM outputs the SQL scripts to a file, allowing for straightforward database integration and review.

## Getting Started

### Steps to Run the Project

1. **Clone the Project:**
   Bring SmallORM to your local machine by cloning the repository:
   ```bash
   git clone https://github.com/abhinav-31/SmallOrm-ConsoleApplication.git
2. **Open the Project in Visual Studio:**
- Launch Visual Studio.
- Navigate to **File** -> **Open Project or Solution**.
- Find your cloned project directory and open the `.sln` file.

### Steps to Generate the SQL Script

#### Add AttributesLib.dll to POCO Dependencies:
- In Solution Explorer, right-click on your POCO project.
- Select **Add** -> **Project Reference...**.
- Browse and add the `AttributesLib.dll` from the SmallORM Console Application project.

#### Run the Application:
- Build and run `SmallOrm-ConsoleApplication.exe`.
- When prompted, enter the full path to your POCO library DLL, e.g.:
  ```plaintext
  "C:\PGDAC24\.net\New folder (2)\SmallOrm-ConsoleApplication\POCO\bin\Debug\net6.0\POCO.dll"
### Enter the Desired Database Name
When prompted, enter the desired database name.

### Generate the SQL Script:
- Sit back and watch as SmallORM generates an SQL script based on your POCO classes.
- The script will be saved as `script.sql` in the directory where the application is executed.

### Running the SQL Script in Your Database
Once you have your `script.sql`, you can execute this script in your preferred database environment (e.g., SQL Server, MySQL) to effortlessly create the necessary tables and schema.

### Usage Instructions for the ORM Tool

#### Extract the Tool:
- Unzip the contents of the `SmallOrm-ConsoleApplication.zip` file to a directory on your machine.

#### Ensure Dependencies:
- Ensure the `AttributesLib.dll` file is in the same directory as `SmallOrm-ConsoleApplication.exe`.

#### Run the Tool:
1. Open a Command Prompt or Terminal and navigate to the directory where you extracted the files.
2. Execute the tool with:
   ```bash
   SmallOrm-ConsoleApplication.exe
### Enter the POCO Library Path:
When prompted, provide the full path to your POCO library DLL:
```plaintext
D:\path\to\your\POCO\library\YourLibrary.dll
```
### SQL Script Generation:
- Relax and let SmallORM generate the SQL script, which will be saved as `script.sql` in the current directory.

### Tech Stack
- **.NET (C#):** The backbone of SmallORM, providing a robust framework for development.
- **Reflection & Attributes:** Enabling dynamic behavior and seamless mapping from code to SQL.
- **SQL:** The language of the database, effortlessly generated by SmallORM.
- **File I/O:** Ensuring easy access and integration of generated SQL scripts.
