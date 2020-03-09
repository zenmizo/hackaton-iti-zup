#!/bin/bash

set -x

docker run \
	--name redis01 \
	--rm \
	-d \
	-p 6379:6379 \
	redis
