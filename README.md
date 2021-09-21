# banking.operation-contact-api

Banking Operation Solution - Contact Api

[![.NET](https://github.com/EdsonCaliman/banking.operation-contact-api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/EdsonCaliman/banking.operation-contact-api/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/EdsonCaliman/banking.operation-contact-api/badge.svg?branch=main)](https://coveralls.io/github/EdsonCaliman/banking.operation-contact-api?branch=main)

This project is a part of a Banking Operation solution, with DDD and microservices architecture, using .Net Core.

![BankingOperations (1)](https://user-images.githubusercontent.com/19686147/133843637-85277ee1-9748-4456-befa-4b2265e3ebec.jpg)

Using a docker-compose configuration the components will be connected so that together they work as a solution.

This component will be responsible for register the contacts, attending the crud operations. It uses a mysql database to register the data.

# Bussiness Rules

# How to run

With a docker already installed run:

docker-compose up -d

For swagger open the URL: http://localhost:8001/swagger