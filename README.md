# CRM
In order to use this application you will need to install:
    1) SQL Server
    2) SQL Server Management Studio 20 (SSMS)
    3) Visual Studio 2022

After you have installed SSMS, please connect to your local SQL server which you have installed before installing SSMS.
Once you are connected, drag and drop the 'SQLQueries.sql' provided within this folder to the SSMS.
This will show you all of the code for SQL server (CREATE, INSERT) and so on.
Now, select all the SQL code on that page (Ctrl+A) then execute the code in the master databse.
You will now have all the tables created for you and dummy data will also be inserted into the database.
Now get your connection string for your server and go to the App.config found in the Visual Studio project.
Replace the current connection string with your own and run the program to test if the connection with the database works. 

The dummy admin user we have created are:
    Username        Password
    Sahil           111111
    Kai             111111
    Sam             111111