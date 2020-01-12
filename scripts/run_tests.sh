#!/bin/bash
set -e
set -u


echo Running Acceptance Tests 
dotnet test AcceptanceTests/ --configuration Release --no-build