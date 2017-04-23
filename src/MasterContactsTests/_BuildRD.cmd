rem Construction d'un projet .Net 
rem 15:40 24/02/2009
rem JF. PACORY

set projet=MasterClassesTests.csproj

"C:\WINDOWS\Microsoft.NET\Framework\v3.5\MSBuild.exe"  %projet% /t:Rebuild /p:Configuration=Debug
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\MSBuild.exe"  %projet% /t:Rebuild /p:Configuration=Release
 
set projet=