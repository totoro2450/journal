For start: 
Add-Migration InitialCreate
Update-Database

For update:
Update-Database Initial
Remove-Migration
Add-Migration Release_X_X_X (matches version number of app being pushed out with changes)
Update-Database

Or:
EntityFrameworkCore\Update-Database Initial
EntityFrameworkCore\Remove-Migration
EntityFrameworkCore\Add-Migration Release_X_X_X (matches version number of app being pushed out with changes)
EntityFrameworkCore\Update-Database