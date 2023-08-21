# Tourch model loading demo
Torch results are different from GGML ones. Torch GPU version inference is 1.5-4 times faster.

## Prerequisites
1. Have docker installed (docker over WSL is OK)
2. Have Nvidia GPU with 8000MB free VRAM of RTX 20xx; T4 or newer (basically it is hard to run on anything that has < 16000MB VRAM in totall)
3. Have CUDA > 11.0 installed 

## Process

1. Build docker file from this folder
```bash
docker build -t nm/jupyterllm .
```

2. Run Dockerfile
```bash
 docker run -it -p 8888:8888 --gpus all --shm-size=2g nm/jupyterllm /bin/bash -c "jupyter notebook --no-browser --ip=0.0.0.0"
```

3. Open the docker link in the web browser and run all cells in the `llm-mpt-Instruct-DotNet-S-torch`  notebook. It will download the requiered model and run it with a few samples.