# CaseApi_NetCon_Geo -> Por Paulo Cesar Cordovil Bruno.

API REST desenvolvida em .NET 8 para cálculo de viabilidade geográfica com base em latitude e longitude.

---

## Arquitetura

O projeto segue uma estrutura em camadas, com separação de responsabilidades:

- Api
- Application
- Domain
- Infrastructure

O domínio é isolado e não possui dependência de outras camadas.

---

## Tecnologias

- .NET 8
- ASP.NET Core
- FluentValidation
- Docker

---

## Como executar

### Rodando localmente

```
bash
git clone https://github.com/SEU-USUARIO/CaseApi_NetCon_Geo.git
cd CaseApi_NetCon_Geo
dotnet run --project CaseApi_NetCon_Geo.Api/CaseApi_NetCon_Geo.Api.csproj

---
==========================================================================================

## Deploy com Docker - passo a passo

### Pré-requisitos

- Docker instalado
- Docker em execução

### 1. Gerar a imagem Docker

Na raiz do projeto, onde está o arquivo Dockerfile, execute:

```bash
docker build -t feasibility-api .

Executar o container:
1 - docker run --rm -p 8080:8080 feasibility-api


Testar o endpoint principal no Navegador (Exemplo):
http://localhost:8080/swagger/index.html

==========================================================================================
Parâmetros obrigatórios
latitude → (-90 a 90)
longitude → (-180 a 180)
radius → (10 a 1000 metros)
page → (>= 1)

==========================================================================================

Por Paulo Bruno 
25/04/2026
