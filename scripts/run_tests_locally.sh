#!/bin/bash
set -e
set -u

./scripts/build.sh
./scripts/run_tests.sh