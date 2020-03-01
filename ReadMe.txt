
To setup Database follow the below mentioned instructions

1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
 
Update-Database Identity -Context ApplicationDbContext

5. On the console execute the following command

Update-Database Employee -Context Employee_Payee_Tax_Calculator_DBContext

6. After migration is successful Run the project 