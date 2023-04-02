%systemroot%\system32\inetsrv\appcmd stop apppool /apppool.name:RemarkablePortalApp

rmdir /s /q "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Web\AspNet.Angular.Web\Areas\Mdp"
xcopy /I /E /Y "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Mod\AspNet.Angular.Mod\Areas\Mdp" "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Web\AspNet.Angular.Web\Areas\Mdp"

copy /Y "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Mod\AspNet.Angular.Mod\bin\*.*" "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Web\AspNet.Angular.Web\Areas\Mdp"

rmdir /s /q "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Web\AspNet.Angular.Web\angular-content\src\app\mdp"
xcopy /I /E /Y "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Mod\AspNet.Angular.Mod\angular-content\src\app\mdp" "D:\MyProjects\MyPublish\AspNetAngularSample\Src\AspNetAngularDebug\AspNet_Angular_Web\AspNet.Angular.Web\angular-content\src\app\mdp"

%systemroot%\system32\inetsrv\appcmd start apppool /apppool.name:RemarkablePortalApp


