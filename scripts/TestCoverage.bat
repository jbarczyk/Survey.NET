dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit*]\*" /p:CoverletOutput="./TestResults/" ../source
reportgenerator "-reports:../source/Survey.NET.Tests/TestResults/coverage.cobertura.xml" "-targetdir:coverage-reports\html" -reporttypes:HTML;
