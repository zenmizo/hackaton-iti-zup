#!/bin/sh

set -e

cd /home/application
mvn -f /home/application/pom.xml clean install -U -Dspring.profiles.active=ci