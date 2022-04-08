Remove-Item src\CR.XML.Reader.WinUI\Publish\ -Force -Recurse -ErrorAction SilentlyContinue
dotnet publish --sc .\src\CR.XML.Reader.WinUI\CR.XML.Reader.WinUI.csproj -o .\src\CR.XML.Reader.WinUI\Publish\ -r win-x64 -c release
mkdir .\src\CR.XML.Reader.WinUI\Publish\db
& 'C:\Program Files (x86)\Inno Setup 6\ISCC.exe' .\Installer.iss