#!/usr/bin/env bash

find . -mindepth 2 -maxdepth 2 -type d \( -name "bin" -o -name "obj" \) -exec rm -r {} \+
rm -f AcceptanceTests/*.feature.cs