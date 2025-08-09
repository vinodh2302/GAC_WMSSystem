# Use official .NET 8 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install prerequisites for mssql-tools (sqlcmd)
RUN apt-get update && apt-get install -y curl apt-transport-https gnupg2

RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/debian/11/prod.list > /etc/apt/sources.list.d/mssql-release.list

RUN apt-get update && ACCEPT_EULA=Y apt-get install -y msodbcsql18 mssql-tools unixodbc-dev

# Add sqlcmd to PATH
ENV PATH="$PATH:/opt/mssql-tools/bin"

# Install dotnet-ef tool globally
RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /src

# Copy your source code to container
COPY . .

# Entrypoint to wait for SQL Server, build and run migrations
ENTRYPOINT ["sh", "-c", "\
  until /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P 'YourStrong!Passw0rd' -Q 'SELECT 1' > /dev/null 2>&1; do \
    echo Waiting for SQL Server...; sleep 10; \
  done; \
  echo Running build...; \
  dotnet build WMSSystems.csproj; \
  echo Running EF migrations...; \
  dotnet ef database update --project WMSSystems.csproj --connection \"Server=sqlserver;Database=WMSSystemsDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;\"; \
  echo Migrations complete; \
"]
