# CRM

This project was developed as part of a University project during Year 2 of my Computer Science course in collaboration with other students.

## Prerequisites
To use this application, you will need to install:
1. **SQL Server**
2. **SQL Server Management Studio 20 (SSMS)**
3. **Visual Studio 2022**

## Setup Instructions
1. After installing SSMS, connect to your local SQL Server (installed prior to SSMS).
2. Drag and drop the `SQLQueries.sql` file (provided in this folder) into SSMS.
3. This will display all the SQL code (e.g., `CREATE`, `INSERT`, etc.).
4. Select all the SQL code in the editor (`Ctrl+A`) and execute it in the **master database**.
   - This will create all necessary tables and insert dummy data into the database.

5. Retrieve your connection string for the server:
   - Open the `App.config` file in the Visual Studio project.
   - Replace the current connection string with your own.

6. Run the program to test the connection with the database.

## Dummy Admin User Accounts
The following dummy admin accounts are available for testing:

| **Username** | **Password** |
|--------------|--------------|
| Sahil        | 111111       |
| Kai          | 111111       |
| Sam          | 111111       |
