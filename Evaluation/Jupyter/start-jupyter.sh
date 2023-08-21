#!/bin/bash
set -e

# Get the password from the environment variable
JUPYTER_PASSWORD=${JUPYTER_PASSWORD:-}

# Hash the password
HASHED_PASSWORD=$(python -c "from notebook.auth import passwd; print(passwd('${JUPYTER_PASSWORD}'))")

# Start the jupyter server with the hashed password
jupyter notebook --NotebookApp.password='${HASHED_PASSWORD}' --no-browser --ip=0.0.0.0
