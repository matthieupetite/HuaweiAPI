ARG VARIANT="7.0"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}-jammy

# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi
ENV TZ=Europe/Paris
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN apt-get update && apt-get install -y tzdata

# Install dotnet tools
RUN dotnet tool install -g dotnet-ef
RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN curl -fsSL https://deb.nodesource.com/setup_19.x | sudo -E bash - && \
    sudo apt-get install -y nodejs && \
    sudo npm install -g yo bower generator-aspnet


ENV PATH $PATH:/root/.dotnet/tools
RUN mkdir /home/vscode/app
