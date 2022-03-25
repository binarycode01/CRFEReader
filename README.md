# Costa Rica Electronic Invoice XML Reader

## Test
```shell
dotnet test .\src\CR.XML.Reader.sln
```

### Test coverage report
```shell
dotnet tool install --tool-path . dotnet-reportgenerator-globaltool

dotnet test .\src\CR.XML.Reader.sln -c Debug -r ".\src\coverage" --collect:"XPlat Code Coverage" --test-adapter-path:. --logger:"junit;LogFilePath=./junit/junit-test-result.xml;MethodFormat=Class;FailureBodyFormat=Verbose"

.\reportgenerator.exe "-reports:.\src\coverage\*\coverage.cobertura.xml" "-targetdir:./src/coverage" "-reporttypes:Html"
```