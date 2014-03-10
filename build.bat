echo "Building ..."
rem %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe Whiteboard.sln /p:Configuration=Debug /p:Platform="Any CPU"


%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe Whiteboard.sln /p:DeployOnBuild=true /p:PublishProfile=pizarron_profile.pubxml

rem "%ProgramFiles%\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:package=deploy_package\Whiteboard.Web.zip -dest:auto -setParam:kind=ProviderPath,scope=Pizarron,value=pizarron.test

rem "%ProgramFiles%\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:package=deploy_package\Whiteboard.Web.zip -dest:auto
