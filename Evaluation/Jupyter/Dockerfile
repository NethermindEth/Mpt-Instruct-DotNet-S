#  docker build -t nm/jupyterllm .
#  docker run -d -p 8888:8888 -v "C:/llm/data:/notebooks/data" --gpus all --shm-size=32g nm/jupyterllm /bin/bash -c "jupyter notebook --no-browser --ip=0.0.0.0"
#  docker run -d -p 8888:8888 -v  /home/fsuser/tst:/notebooks/data --gpus all --shm-size=32g nm/jupyterllm /bin/bash -c "jupyter notebook --no-browser --ip=0.0.0.0"

# Start with specified image
FROM nvcr.io/nvidia/pytorch:23.04-py3
RUN apt update && apt install htop git
# Install jupyter
RUN pip install jupyter pynvml transformers einops markdownify ftfy accelerate bitsandbytes

# Add a script that starts jupyter
COPY start-jupyter.sh /start-jupyter.sh

RUN chmod +x /start-jupyter.sh

# The directory for the notebook files
RUN mkdir /notebooks
COPY llm-mpt-Instruct-DotNet-S-torch.ipynb /notebooks/llm-mpt-Instruct-DotNet-S-torch.ipynb
WORKDIR /notebooks

# The port jupyter will listen on
EXPOSE 8888

# Start the jupyter server when the container starts
CMD ["jupyter notebook --no-browser --ip=0.0.0.0"]
