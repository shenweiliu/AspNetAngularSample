%systemroot%\system32\inetsrv\appcmd stop apppool /apppool.name:AspNetAngularWebPool

rmdir /s /q "{Your_Path}\AspNet_Angular_Web\AspNet.Angular.Web\Areas\Mdp"
xcopy /I /E /Y "{Your_Path}\AspNet_Angular_Mod\AspNet.Angular.Mod\Areas\Mdp" "{Your_Path}\AspNet_Angular_Web\AspNet.Angular.Web\Areas\Mdp"

copy /Y "{Your_Path}\AspNet_Angular_Mod\AspNet.Angular.Mod\bin\*.*" "{Your_Path}\AspNet_Angular_Web\AspNet.Angular.Web\Areas\Mdp"

rmdir /s /q "{Your_Path}\AspNet_Angular_Web\AspNet.Angular.Web\angular-content\src\app\mdp"
xcopy /I /E /Y "{Your_Path}\AspNet_Angular_Mod\AspNet.Angular.Mod\angular-content\src\app\mdp" "{Your_Path}\AspNet_Angular_Web\AspNet.Angular.Web\angular-content\src\app\mdp"

%systemroot%\system32\inetsrv\appcmd start apppool /apppool.name:AspNetAngularWebPool


