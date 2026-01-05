#!/bin/bash

# Health check script for Docker containers

set -e

API_URL="${API_URL:-http://localhost:8080}"
TIMEOUT="${TIMEOUT:-10}"

# Make request with timeout
if timeout $TIMEOUT curl -f "$API_URL/healthz" > /dev/null 2>&1; then
    echo "✅ Health check passed"
    exit 0
else
    echo "❌ Health check failed"
    exit 1
fi
