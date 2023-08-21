[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)

# Teammate

## Requirements:

.NET 7

SQL Server

Conversational Language Understanding project in Azure with trained model

## Setup:

Add-Migration Initial

Database-Update

#### Properly populate the appsettings.json file:

##### AzureAd values:

TenantId

ClientId

ClientSecret

##### Azure Cognitive Service values:

ApiKey

EndpointUrl

## App description:

The application retrieves through the Graph API recent messages from Teams and tries to understand the sender's statement and tag them accordingly depending on the trained model.

The main task of the application is to catch important questions that have been asked in the chat and mark them accordingly.

The model I used detects questions that are work-related or urgent.

The attached file CommonQuestion.txt contains sample questions, which was used to train the model.

An example of a labeled question with the percentage probability of recognition:

![1](https://user-images.githubusercontent.com/9865520/224850955-ecee012d-e9fe-419a-adbb-d5ef10011076.png)


https://user-images.githubusercontent.com/9865520/224956685-0eb21cf7-4035-4f36-82bd-5f5968a0542b.mp4

