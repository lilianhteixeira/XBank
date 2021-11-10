# API XBank 

## Descrição
API desenvolvida como Projeto Final para a conclusão do curso de .NET da [XP Inc.](https://www.xpi.com.br/) em parceria com a [GamaAcademy](https://www.gama.academy/)

### Sumário
==================

- [Proposta do projeto final](#Proposta-do-projeto-final)
- [Regras de negócio](#Regras-de-negócio)
- [Arquitetura](#Arquitetura)


### Proposta do projeto final 
Construção de uma API com arquitetura REST para gerenciar as transações da nossa instituição bancária, o **XBank**. Capaz de executar um CRUD, as quatro operações básicas usadas em Banco de Dados Relacionais - Create (Criação), Read (Consulta), Update (Atualização) e Delete (Destruição), em um banco de dados NoSQL.

### Regras de negócio
#### Cliente
```hs
- Quando um cliente é cadastrado imediatamente está ativando e se vinculando a uma conta.
- Um cliente ao ser atualizado/desativado a sua conta será afetada.
- Não será possível cadastrar um cliente com CPF já cadastrado.
- Todos os dados cadastrais solicitados são obrigatórios.
``` 

#### Conta
```hs
- Uma conta só pode ser criada quando um cliente é cadastrado.
- Quando atualizar/desativar uma conta o cliente vinculado será afetado.
- Permitido apenas uma conta por CPF.
- Uma solicitação de cancelamento não deleta a conta e dados do cliente do banco, apenas desativa,  permanecendo todos os dados no banco de dados.
- O Saque deve conter a data e hora de quando foi realizado e o valor.
```

#### Movimentação
```hs
- Saque por cliente ilimitado.
- É possível realizar o histórico de movimentações por conta.
- Não será possível fazer movimentações negativas e nem superiores ao saldo da conta.
- Para realizar movimentação é necessário CPF de destino.
- A movimentação está vinculada a uma conta.
- Movimentações disponíveis saque, transferencia e depósito.
- No extrato ficará disponibilizado para o cliente a data e a hora das movimentações.
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