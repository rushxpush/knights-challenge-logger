# Knights Challenge - Logger Microserviço

[Tecnologias](#tecnologias) | [Funcionalidades](#funcionalidades) | [Descrição](#descrição) | [Instalação](#instalação) | [Suporte](#suporte)

## Tecnologias

<ul>
  <li>.Net</li>
</ul>

[Ir para o topo](#knights-challenge---logger-microserviço)

## Funcionalidades

- &check; 
- &#x2610; Configurar automatização de migrations no docker
```powershell
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```


[Ir para o topo](#knights-challenge---logger-microserviço)

## Microserviços

- LoggerService

## Descrição  

[Ir para o topo](#knights-challenge---logger-microserviço)

## Instalação


1. Faça um clone do repositório:
```bash
git clone git@github.com:rushxpush/knights-backend-logger.git
cd knights-backend-logger
```

2. Monte a imagem e rode:
```bash
# EventLogger
docker build -t knights-challenge-logger .
docker run -it --rm -p 5044:8080 --name KnightsChallengeLoggercontainer knights-challenge-logger

# Postgres
docker run --name some-postgres -p 5430:5432 -e POSTGRES_PASSWORD=mysecretpassword -d postgres

# Kafka
docker run -p 9092:9092 apache/kafka:3.9.0

# # Kafka with web ui
# docker run -d -p 9000:9000 \
#   -e KAFKA_BROKERCONNECT=localhost:9092 \
#   obsidiandynamics/kafdrop

```

3. Não esqueça de montar os seguintes projetos 

        Frontend: [knights-frontend](https://github.com/rushxpush/knights-frontend)
        Backend: [knights-backend](https://github.com/rushxpush/knights-backend)
        API Gateway: [knights-api-gateway](https://github.com/rushxpush/knights-api-gateway)

4. Acesse a página em [localhost:5044](http://localhost:5044)

5. Para rodar apenas os testes:
```bash
# docker compose --profile test up
```

6. Rodar sem docker
```bash
dotnet watch
```


[Ir para o topo](#knights-challenge---logger-microserviço)

## Suporte

Qualquer dúvida mande um email para [rafagarciadev@gmail.com](mailto:rafagarciadev@gmail.com)

[Ir para o topo](#knights-challenge---logger-microserviço)

## Lista de bugs

[Ir para o topo](#knights-challenge---logger-microserviço)

## Bugs Resolvidos

[Ir para o topo](#knights-challenge---logger-microserviço)


Por enquanto só testado no Windows 10

```powershell
dotnet run watch
```
