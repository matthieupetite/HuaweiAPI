#!/bin/bash
cd ~/app/Worker
dotnet tool install -g dotnet-ef
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
dotnet restore 
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet nuget add source --username matthieupetite --password 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  --store-password-in-clear-text --name github "https://nuget.pkg.github.com/matthieupetite/index.json"
export PATH="$PATH:/home/vscode/.dotnet/tools"
echo 'export PATH="$PATH:/home/vscode/.dotnet/tools"' >> ~/.bashrc
source ~/.bashrc
dotnet restore
dotnet build