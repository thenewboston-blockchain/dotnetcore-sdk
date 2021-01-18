
# TheNewBoston .NET Core SDK
## Library Description
This is a .NET Core SDK for **thenewboston**, which will be available cross-platoform. The library itself will solely contain the domain and data layers of **thenewboston**. The presentation layer will be the responsibility of the host application.


## Getting Started
Get started using thenewboston SDK in your project by following this documentation. The SDK is available in the following languages. 

 1. .Net Core 3.1
 2. Kotlin
 3. Python
 4. JavaScript
 5. ...

## Setup Your Environment
### Nuget
You can use the Nuget package manager in Visual Studio or the Nuget CLI by installing the following package into a .Net Core 3.1 project:

    Thenewboston
    
For projects that support  adding  a Nuget reference you may paste the following into your .csproj file:

	<ItemGroup>
	    <PackageReference Include="Thenewboston" Version="1.0.0" />
	</ItemGroup>

## SDK References
 1. Bank
	 * AccountsService
	 * BankConfirmationBlockService
	 * BlocksService
	 * ConfigService
	 * ConnectedBankService
	 * InvalidBlocksService
	 * TransactionsService
	 * ValidatorService
	 
 2. Common
	 * 
 3. Validator
	 * AccountsService
	 * ConfigService
	 * ConnectedBankService
	 * PrimaryValidatorUpdatedService
	 * TransactionService
	 * ValidatorService
	 * ValidatorConfirmationBlockService

## Namespace Index
This section provides quick links to a list of items contained within the following namespaces
 1. Thenewboston.Bank.Api
 2. Thenewboston.Bank.Models
 3. Thenewboston.Common.Api
 4. Thenewboston.Common.Models
 5. Thenewboston.Validator.Api
 6. Thenewboston.Validator.Models

## Exceptions Index
This section provides quick links to exceptions that you may encounter while using the SDK
 1. Bank (BNK)
 2. Common (CMN)
 3. Validator  (VLD)

# Bank
Description 
## Namespaces
	 Thenewboston.Bank.Api
	 Thenewboston.Bank.Models
	 
##  AccountsService
##  BankConfirmationBLockService
##  BlocksService
##  ConfigService
##  ConfirmationService
##  ConnectedBankService
##  InvalidBlocksService
##  TransactionService
##  ValidatorService
##  Bank Exceptions (BNK)

|Exception|Class|Thrown From|Description|
|--|--|--|--|
|BNK001|AccountsService|SampleMethod()|Sample Description|
|BNK002|ConfigService|SampleMethod()|Sample Description|
|BNK003|Unassigned|Reserved for future codification|



# Common
Description
## Namespace
	Thenewboston.Common.Api
	Thenewboston.Common.Models
## Common Exceptions (CMN)
|Exception|Class|Thrown From|Description  |
|--|--|--|--|
|CMN001|Unassigned |Reserved for future codification||


# Validator
Description
## Namespace
	Thenewboston.Validator.Api
	Thenewboston.Validator.Models
## AccountsService
## ConfigService
## ConfirmationService
## ConnectedBankService
## PrimaryValidatorUpdatedService
## TransactionService
## ValidatorService
## ValidatorConfirmationBlockService
## Validator Exceptions (VLD)
|Exception|Class|Thrown From|Description  |
|--|--|--|--|
|VLD001|AccountsService|SampleMethod()|Sample Description|
|VLD002|ConfigService|SampleMethod()|Sample Description|
|VLD003|Unassigned|Reserved for future codification|
