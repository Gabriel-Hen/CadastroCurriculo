#!/usr/bin/env bash
host="$1"shift
cmd="$@"until nc -z "$host" 3306; doecho"Waiting for MySQL..."sleep 5
doneecho"MySQL is up - executing command"exec$cmd