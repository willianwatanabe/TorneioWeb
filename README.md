# Torneio de luta - Torneio Yu-Gi-Oh!
*Projeto avaliativo da última semana do plano de estágio.*

**Objetivo:** Realizar um campeonato com 16 lutadores, onde o vencedor é definido seguindo alguns critérios de vitória.<br/>
[Clique aqui](https://sbs.t-systems.com.br/gitlab/mercedes/collab/planos-de-desenvolvimento/desenvolvimento-de-software/plano-de-estagio-dev/-/blob/stable/semanas/12.md) para mais informações.

## Pré-requisitos

- Versão mais recente do SQL Server 
- Versão mais recente do SQL Server Management Studio
- Versão mais recente do Visual Studio 

## Preparação

1º) Será necessário restaurar o banco de dados (Tournament.bak), que se encontra na pasta 'Data', utilizando o SQL Server MS.<br/>
2º) Deverá alterar a ConnectionString no arquivo `appsetting.json`, utilizando os dados do SQL Server, como por exemplo:
```json
"ConnectionStrings": {
    "DataBase": "Server=<Nome_do_servidor>;DataBase=Tournament;User Id=<Logon>;Password=<Senha>"
  }
  
"ConnectionStrings": {
    "DataBase": "Server=DESKTOP-SBPJ2OQ\\SQLEXPRESS;DataBase=Tournament;User Id=sa;Password=123456"
  }
```
3º) Após clonar o projeto na máquina local, abra o projeto com o Visual Studio e execute.
