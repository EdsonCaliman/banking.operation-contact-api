# banking.operation-contact-api

Banking Operation Solution - Contact Api

[![.NET](https://github.com/EdsonCaliman/banking.operation-contact-api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/EdsonCaliman/banking.operation-contact-api/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/EdsonCaliman/banking.operation-contact-api/badge.svg?branch=main)](https://coveralls.io/github/EdsonCaliman/banking.operation-contact-api?branch=main)

This project is a part of a Banking Operation solution, with DDD and microservices architecture, using .Net Core.

![BankingOperations (1)](https://user-images.githubusercontent.com/19686147/133843637-85277ee1-9748-4456-befa-4b2265e3ebec.jpg)

Using a docker-compose configuration the components will be connected so that together they work as a solution.

This component will be responsible for register the contacts, attending the crud operations. It uses a mysql database to register the data.

![image](https://user-images.githubusercontent.com/19686147/134337265-26891b11-359d-4d1b-9a79-6d56134608de.png)

# Bussiness Rules

 - A contact needs to have a name and a valid account number.
 - The client and account are not permitted to belong to the same register.
 - The contact needs to have a valid client to be registered.
 - The account number needs to have a valid client registered in the database.
 - One account number can only register once for a client.
 - The contact needs to have an Id for identification, which should be generated automatically.
 - When updating the contact only the name field can be changed.

# How to run

With a docker already installed:

Run first the project: https://github.com/EdsonCaliman/banking.operation-contact-api

After run:

docker-compose up -d

For swagger open the URL: http://localhost:8001/swagger

![image](https://user-images.githubusercontent.com/19686147/134339313-04b7f0eb-7ace-4058-b2d0-02a690f513d2.png)
