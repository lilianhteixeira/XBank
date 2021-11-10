# API XBank 

## Descrição
API desenvolvida como Projeto Final para a conclusão do curso de .NET da [XP Inc.](https://www.xpi.com.br/) em parceria com a [GamaAcademy](https://www.gama.academy/)

#Sumário
==================
<!--ts-->
	*[Proposta do projeto final](#Proposta do projeto final)
	*[Regras de negócio](#Regras de negócio)
	*[Arquitetura](#Arquitetura)
<!--te-->

### Proposta do projeto final 
Construção de uma API com arquitetura REST para gerenciar as transações da nossa instituição bancária, o **XBank**. Capaz de executar um CRUD, as quatro operações básicas usadas em Banco de Dados Relacionais - Create (Criação), Read (Consulta), Update (Atualização) e Delete (Destruição), em um banco de dados NoSQL.

### Regras de negócio
```sh
- Quando criar/desativar um cliente a conta será afetada
- Não será possivel cadastrar um cliente com CPF já cadastrado
- Atualizar Cliente atualiza os dados ou reativar a conta
- Não será possivel fazer movimentações negativas e nem superiores ao saldo da conta
- Saque por cliente ilimitado
- Histórico de operações por conta-corrente
- Abertura de conta poderá ser feita apenas com os dados obrigatorios: Nome completo, Cpf, Rg, endereço, telefone, email.
```

### Arquitetura
        Arquitetura REST
        |
        \--📂 **HUB-FIGHTS**
            | 📄 README.md
            | 📄 .gitignore
            | 📄 **XBank.sln**  
            \--📂 .vs
            \--📂src  
                📂---Domain
                        |📄 **Core.csproj**
                            📂---Commands
                            📂---Entities
                            📂---Enums
                            📂---Queries
                            📂---Requests
                            📂---Responses
                    |   📄 **Shared.csproj**
                            📂---Entities
                            📂---Handlers
                            📂---Interfaces
                            📂---Util
                            📂---ValueObjects  
                📂---Infra
                    |   📄 **Infra.cspro**
                            📂---Configs
                            📂---Contexts
                            📂---Repositories
                📂---Service
                    |   📄 **API.**
                            📂---Properties
                            📂---Controllers
                            | 📄 appsettings.json
                            | 📄 Program.cs
                            | 📄 Startup.cs
                            | 📄 WeatherForecast.cs